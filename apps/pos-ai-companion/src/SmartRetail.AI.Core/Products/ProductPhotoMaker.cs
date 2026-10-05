using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Providers;

namespace SmartRetail.AI.Products
{
    /// <summary>The photo being made, or the listing being written, right now.</summary>
    public sealed class PhotoWork
    {
        public PhotoWork(int productId, string setId, PhotoKind kind, DateTime started, bool isListing = false)
        {
            ProductId = productId;
            SetId = setId;
            Kind = kind;
            Started = started;
            IsListing = isListing;
        }

        /// <summary>The product's listings for Amazon and the website are being written, not a photo made.</summary>
        public bool IsListing { get; }

        public int ProductId { get; }

        public string SetId { get; }

        public PhotoKind Kind { get; }

        public DateTime Started { get; }
    }

    /// <summary>
    /// Makes the five photos of each product in the background, one photo at a time and one product at a time, in the
    /// order the phone photos came in, and writes its listings for Amazon and the website once, right after the
    /// white-background photo (when the AI first describes the product). What is still to do is kept in the store, so
    /// the work carries on after the app restarts. A failed photo stops that product's set until someone continues it,
    /// skips the photo or adds new photos; a failed listing only waits for "Write again". When Codex's usage limit is reached
    /// nothing has failed: the work waits for the time Codex gave (<see cref="UsageLimitPause"/>) and carries on from the photo
    /// it stopped at.
    /// </summary>
    public sealed class ProductPhotoMaker
    {
        private readonly ProductPhotoStore _store;
        private readonly Func<ProductPhotoRequest, CancellationToken, Task<ProductPhotoResult>> _make;
        private readonly Func<ProductListingRequest, CancellationToken, Task<ProductListingResult>> _writeListing;
        private readonly Func<byte[], PhotoShape, byte[]> _fit;
        private readonly UsageLimitPause _pause;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();
        private readonly List<int> _queue = new List<int>();
        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);
        private readonly Dictionary<int, PhotoChange> _changed = new Dictionary<int, PhotoChange>();
        private PhotoWork _current;
        private CancellationTokenSource _currentCancel;

        /// <summary>What was taken away from the photo or listing being made right now, so it is made again or dropped.</summary>
        private enum PhotoChange
        {
            None,

            /// <summary>A phone photo was removed: what was being made from it is made again from the others.</summary>
            PhonePhotoRemoved,

            /// <summary>The whole set was removed: what was being made for it is dropped.</summary>
            SetRemoved,
        }

        /// <param name="make">Makes one photo, e.g. with Codex.</param>
        /// <param name="writeListing">Writes a product's listings, e.g. with Codex; null writes none.</param>
        /// <param name="fit">Trims a photo the AI made to the shape of the owner's phone photo (the image and that shape in, the image
        /// out); null keeps each photo as the AI made it. A photo it cannot fit is kept as it is.</param>
        /// <param name="pause">Where the account's usage limit stands, shared with whatever else uses Codex: when a run meets the limit the
        /// work waits for it and carries on; null treats the limit like any other failure.</param>
        public ProductPhotoMaker(
            ProductPhotoStore store,
            Func<ProductPhotoRequest, CancellationToken, Task<ProductPhotoResult>> make,
            Func<DateTime> now = null,
            Func<ProductListingRequest, CancellationToken, Task<ProductListingResult>> writeListing = null,
            Func<byte[], PhotoShape, byte[]> fit = null,
            UsageLimitPause pause = null)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
            _make = make ?? throw new ArgumentNullException(nameof(make));
            _now = now ?? (() => DateTime.Now);
            _writeListing = writeListing;
            _fit = fit;
            _pause = pause;
            if (pause != null)
            {
                // The pages showing the work learn when it is paused and when it carries on.
                pause.Changed += RaiseAll;
            }
        }

        /// <summary>Where the account's usage limit stands; null when the maker does not wait for it.</summary>
        public UsageLimitPause Pause => _pause;

        /// <summary>True while the work waits for Codex's usage limit to lift.</summary>
        public bool IsPaused => _pause != null && _pause.IsPaused;

        /// <summary>Stops waiting for the usage limit: the work tries again at once (e.g. the owner got more usage).</summary>
        public void TryNow() => _pause?.Clear();

        /// <summary>Whether listings are written here.</summary>
        public bool WritesListings => _writeListing != null;

        /// <summary>Raised with the product id whenever its photos or its place in the queue change. Raised on a background thread.</summary>
        public event Action<int> Changed;

        /// <summary>Raised when something outside a single photo goes wrong, e.g. the disk is full.</summary>
        public event Action<Exception> Error;

        public ProductPhotoStore Store => _store;

        public PhotoWork Current
        {
            get
            {
                lock (_gate)
                {
                    return _current;
                }
            }
        }

        /// <summary>True while nothing is being made and nothing waits.</summary>
        public bool IsIdle
        {
            get
            {
                lock (_gate)
                {
                    return _current == null && _queue.Count == 0;
                }
            }
        }

        /// <summary>The products waiting for their turn, next first (the one being made is not in it).</summary>
        public IReadOnlyList<int> Waiting()
        {
            lock (_gate)
            {
                return _queue.ToList();
            }
        }

        /// <summary>The product's place in the queue: 1 is next; 0 when it is not waiting.</summary>
        public int PlaceInQueue(int productId)
        {
            lock (_gate)
            {
                return _queue.IndexOf(productId) + 1;
            }
        }

        /// <summary>
        /// Starts the five photos from newly kept phone photos, replacing any work still waiting for older ones, and the
        /// listings when the product has none yet: a listing once written is kept, and written again only when asked.
        /// </summary>
        public PhotoSet Start(int productId, string code, string name, string category, IReadOnlyList<string> rawFiles)
        {
            var set = _store.StartSet(productId, code, name, category, rawFiles, _now());
            if (_writeListing != null && _store.Load(productId)?.Listing == null)
            {
                _store.QueueListing(productId);
            }

            Enqueue(productId);
            return set;
        }

        /// <summary>Writes the product's listings (again), from its newest photos; the current one is kept as an earlier one.</summary>
        public void WriteListing(int productId)
        {
            if (_writeListing != null && _store.QueueListing(productId))
            {
                Enqueue(productId);
            }
        }

        /// <summary>
        /// Makes one of the newest set's photos again; the earlier one is kept. With a <paramref name="note"/> (the owner's few words,
        /// see <see cref="PhotoNotes"/>) the AI changes the photo made before as asked, instead of starting over.
        /// </summary>
        /// <exception cref="ArgumentException">The note is too long or has a character that cannot be used.</exception>
        public void MakeAgain(int productId, PhotoKind kind, string note = null)
        {
            if (_store.Load(productId)?.LatestSet is PhotoSet set && _store.QueueChange(productId, set.Id, kind, note))
            {
                Enqueue(productId);
            }
        }

        /// <summary>Carries on with a stopped set, and with listings that were stopped or could not be written.</summary>
        public void Continue(int productId)
        {
            var info = _store.Load(productId);
            if (info?.LatestSet is not PhotoSet set)
            {
                return;
            }

            var listing = _writeListing != null && info.ListingProblem != null && _store.QueueListing(productId);
            if (_store.Queue(productId, set.Id) || listing)
            {
                Enqueue(productId);
            }
        }

        /// <summary>Gives up the photo the set stopped at, and carries on with the rest.</summary>
        public void Skip(int productId, PhotoKind kind)
        {
            if (_store.Load(productId)?.LatestSet is PhotoSet set && _store.Skip(productId, set.Id, kind))
            {
                Enqueue(productId);
            }
            else
            {
                Raise(productId);
            }
        }

        /// <summary>Stops all work on the product: the photo or listing being made is cancelled, and the rest waits until
        /// someone continues (or asks for the listings again).</summary>
        public void Stop(int productId)
        {
            CancellationTokenSource cancel = null;
            lock (_gate)
            {
                _queue.Remove(productId);
                if (_current?.ProductId == productId)
                {
                    cancel = _currentCancel;
                }

                var info = _store.Load(productId);
                if (info != null && (info.ListingPending || (_current?.ProductId == productId && _current.IsListing)))
                {
                    _store.StopListing(productId, "Stopped.");
                }

                if (info?.LatestSet is PhotoSet set && set.Pending.Count > 0)
                {
                    _store.Stop(productId, set.Id, "Stopped.");
                }
            }

            try
            {
                cancel?.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // The photo had just finished.
            }

            Raise(productId);
        }

        /// <summary>
        /// Deletes one of the newest set's phone photos, e.g. one added by mistake. The photo or the listing being made
        /// right now, which was made from it too, is made again from the others; photos already made stay, and can be
        /// made again. The last phone photo of a set goes with <see cref="RemoveSet"/>.
        /// </summary>
        public void RemoveRaw(int productId, string fileName)
        {
            CancellationTokenSource cancel;
            lock (_gate)
            {
                var set = _store.Load(productId)?.LatestSet ?? throw new InvalidOperationException("This product has no photos.");
                if (!_store.RemoveRaw(productId, set.Id, fileName))
                {
                    throw new InvalidOperationException("That photo is not in the newest set any more.");
                }

                cancel = Interrupt(productId, PhotoChange.PhonePhotoRemoved);
            }

            CancelQuietly(cancel);
            Raise(productId);
        }

        /// <summary>Deletes a set with its phone photos and every photo made from them; work on it is cancelled and dropped.</summary>
        public void RemoveSet(int productId, string setId)
        {
            CancellationTokenSource cancel = null;
            bool removed;
            try
            {
                lock (_gate)
                {
                    if (_store.Load(productId)?.LatestSet?.Id == setId)
                    {
                        _queue.Remove(productId);
                        cancel = Interrupt(productId, PhotoChange.SetRemoved);
                    }

                    removed = _store.RemoveSet(productId, setId);
                }
            }
            finally
            {
                CancelQuietly(cancel);
                Raise(productId);
            }

            if (!removed)
            {
                throw new InvalidOperationException("That set of photos is not there any more.");
            }
        }

        /// <summary>Notes what was taken away from the work in progress on the product, and gives its token to cancel (outside
        /// the lock); null when nothing is being made for it. Called with the lock held.</summary>
        private CancellationTokenSource Interrupt(int productId, PhotoChange change)
        {
            if (_current?.ProductId != productId || _currentCancel == null)
            {
                return null;
            }

            _changed[productId] = change;
            return _currentCancel;
        }

        private static void CancelQuietly(CancellationTokenSource cancel)
        {
            try
            {
                cancel?.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // The photo had just finished.
            }
        }

        /// <summary>What was taken away from the work that just ended, once.</summary>
        private PhotoChange TakeChange(int productId)
        {
            lock (_gate)
            {
                if (_changed.TryGetValue(productId, out var change))
                {
                    _changed.Remove(productId);
                    return change;
                }

                return PhotoChange.None;
            }
        }

        /// <summary>Queues every product whose photos were left unfinished, e.g. when the app last closed.</summary>
        public void ResumeAll()
        {
            // Work that an earlier version stopped on the usage limit, and left for the owner to continue, carries on by itself:
            // if the limit still holds, the first try says so and the work waits for it.
            foreach (var info in _store.LoadAll().Values)
            {
                if (info.LatestSet is PhotoSet set && set.Pending.Count > 0 && CodexErrors.IsUsageLimitMessage(set.Problem))
                {
                    _store.Queue(info.ProductId, set.Id);
                }

                if (_writeListing != null && CodexErrors.IsUsageLimitMessage(info.ListingProblem))
                {
                    _store.QueueListing(info.ProductId);
                }
            }

            foreach (var productId in _store.Resumable())
            {
                Enqueue(productId);
            }
        }

        public void Enqueue(int productId)
        {
            bool added;
            lock (_gate)
            {
                // A product being worked on is looked at again after each photo, so it needs no place in the queue.
                added = !_queue.Contains(productId) && _current?.ProductId != productId;
                if (added)
                {
                    _queue.Add(productId);
                }
            }

            if (added)
            {
                _signal.Release();
            }

            Raise(productId);
        }

        /// <summary>Makes photos until <paramref name="stopping"/> is cancelled.</summary>
        public async Task RunAsync(CancellationToken stopping)
        {
            while (true)
            {
                await _signal.WaitAsync(stopping).ConfigureAwait(false);

                // Not while Codex's usage limit holds: the work waits for the time Codex gave, then goes on from where it stopped.
                if (_pause != null)
                {
                    await _pause.WaitAsync(stopping).ConfigureAwait(false);
                }

                await MakeNextAsync(stopping).ConfigureAwait(false);
            }
        }

        /// <summary>Makes all the pending photos of the next product in the queue. False when nothing waits.</summary>
        public async Task<bool> MakeNextAsync(CancellationToken stopping)
        {
            int productId;
            lock (_gate)
            {
                if (_queue.Count == 0)
                {
                    return false;
                }

                productId = _queue[0];
                _queue.RemoveAt(0);
            }

            try
            {
                await MakeProductAsync(productId, stopping).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (stopping.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
            finally
            {
                lock (_gate)
                {
                    if (_current?.ProductId == productId)
                    {
                        _current = null;
                        _currentCancel = null;
                    }
                }

                Raise(productId);
            }

            return true;
        }

        /// <summary>The listing is written once the white-background photo is no longer waiting: the AI has then described
        /// the product, and the listing shows the owner the words while the other photos are made.</summary>
        internal static bool ListingReady(ProductPhotoInfo info, PhotoSet set) =>
            info.ListingPending && !set.Pending.Contains(PhotoKind.WhiteBackground);

        private async Task MakeProductAsync(int productId, CancellationToken stopping)
        {
            while (true)
            {
                // Another job (a creative, a poster's artwork) may have met Codex's usage limit meanwhile: no try is made until it lifts.
                if (_pause != null && _pause.IsPaused && HasWork(productId))
                {
                    lock (_gate)
                    {
                        if (!_queue.Contains(productId))
                        {
                            _queue.Insert(0, productId);
                        }

                        _current = null;
                        _currentCancel = null;
                    }

                    _signal.Release();
                    Raise(productId);
                    return;
                }

                ProductPhotoRequest request = null;
                ProductListingRequest listingRequest = null;
                PhotoWork work;
                var cancel = CancellationTokenSource.CreateLinkedTokenSource(stopping);
                lock (_gate)
                {
                    var info = _store.Load(productId);
                    var set = info?.LatestSet;
                    var listing = set != null && _writeListing != null && ListingReady(info, set);
                    if (set == null || (!listing && (set.Pending.Count == 0 || set.Problem != null)))
                    {
                        _current = null;
                        _currentCancel = null;
                        cancel.Dispose();
                        return;
                    }

                    if (listing)
                    {
                        listingRequest = ListingRequestFor(info, set);
                        work = new PhotoWork(productId, set.Id, PhotoKind.WhiteBackground, _now(), isListing: true);
                    }
                    else
                    {
                        var kind = set.Pending.Min();
                        request = RequestFor(info, set, kind);
                        work = new PhotoWork(productId, set.Id, kind, _now());
                    }

                    _current = work;
                    _currentCancel = cancel;

                    // Anything taken away before this request was built is already left out of it.
                    _changed.Remove(productId);
                }

                Raise(productId);
                if (listingRequest != null)
                {
                    var listingPaused = await WriteListingAsync(productId, listingRequest, cancel, stopping).ConfigureAwait(false);
                    Raise(productId);
                    if (listingPaused)
                    {
                        return;
                    }

                    continue;
                }

                var paused = false;
                try
                {
                    var result = await _make(request, cancel.Token).ConfigureAwait(false);
                    Fit(result, request.Shape);
                    _store.SaveImage(productId, work.SetId, work.Kind, result, _now());
                    if (TakeChange(productId) == PhotoChange.PhonePhotoRemoved)
                    {
                        // Made from a phone photo that was removed meanwhile: make it again from the others.
                        _store.Queue(productId, work.SetId, work.Kind);
                    }
                }
                catch (OperationCanceledException) when (stopping.IsCancellationRequested)
                {
                    // The app is closing: the photo stays pending and is made after the next start.
                    throw;
                }
                catch (Exception ex)
                {
                    // Cancelled or failed because a phone photo or the set was removed: no reason to stop, the work
                    // goes on with what is left (nothing, when the set is gone).
                    if (TakeChange(productId) == PhotoChange.None)
                    {
                        if (UsageLimitOf(ex) is UsageLimitInfo limit)
                        {
                            // Nothing failed: the photo stays pending, and is made when Codex can answer again.
                            WaitForLimit(productId, limit);
                            paused = true;
                        }
                        else
                        {
                            _store.Stop(productId, work.SetId, ex is OperationCanceledException ? "Stopped." : ex.Message);
                        }
                    }
                }
                finally
                {
                    lock (_gate)
                    {
                        _currentCancel = null;
                    }

                    cancel.Dispose();
                }

                Raise(productId);
                if (paused)
                {
                    return;
                }
            }
        }

        /// <summary>Whether the product has a photo or a listing still to make.</summary>
        private bool HasWork(int productId)
        {
            var info = _store.Load(productId);
            var set = info?.LatestSet;
            return set != null && ((set.Problem == null && set.Pending.Count > 0) || (_writeListing != null && ListingReady(info, set)));
        }

        /// <summary>The usage limit a run ended on, when that is why it ended (and the maker waits for the limit).</summary>
        private UsageLimitInfo UsageLimitOf(Exception ex) => _pause != null && ex is AiProviderException provider ? provider.UsageLimit : null;

        /// <summary>Codex is at its usage limit: everything waits for the time it gave, and this product is first when it ends.</summary>
        private void WaitForLimit(int productId, UsageLimitInfo limit)
        {
            _pause.Hit(limit);
            lock (_gate)
            {
                if (!_queue.Contains(productId))
                {
                    _queue.Insert(0, productId);
                }
            }

            _signal.Release();
        }

        /// <summary>Trims the photo to the owner's photo's shape; a photo that cannot be trimmed is kept as the AI made it.</summary>
        private void Fit(ProductPhotoResult result, PhotoShape shape)
        {
            if (_fit == null || result?.Image == null || !shape.IsKnown)
            {
                return;
            }

            try
            {
                result.Image = _fit(result.Image, shape) ?? result.Image;
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                Error?.Invoke(ex);
            }
        }

        /// <summary>Writes the listing; true when Codex's usage limit stopped it, so the listing waits with the rest of the product's work.</summary>
        private async Task<bool> WriteListingAsync(int productId, ProductListingRequest request, CancellationTokenSource cancel, CancellationToken stopping)
        {
            try
            {
                var result = await _writeListing(request, cancel.Token).ConfigureAwait(false);
                var listing = result?.Listing ?? throw new InvalidOperationException("The AI answered without a listing. Try Write again.");
                listing.Provider = result.ProviderName ?? "";
                listing.SetId = request.SetId;
                var change = TakeChange(productId);
                if (change == PhotoChange.SetRemoved || _store.Load(productId)?.Sets.Any(set => set.Id == request.SetId) != true)
                {
                    // Written from a set that was removed meanwhile: it is not kept.
                    return false;
                }

                _store.SaveListing(productId, listing, _now());
                if (change == PhotoChange.PhonePhotoRemoved)
                {
                    // Written from a phone photo that was removed meanwhile: write it again from the others.
                    _store.QueueListing(productId);
                }

                return false;
            }
            catch (OperationCanceledException) when (stopping.IsCancellationRequested)
            {
                // The app is closing: the listing stays waiting and is written after the next start.
                throw;
            }
            catch (Exception ex)
            {
                // Only the listing waits: the photos carry on. Not when a phone photo or the set was removed meanwhile.
                if (TakeChange(productId) == PhotoChange.None)
                {
                    if (UsageLimitOf(ex) is UsageLimitInfo limit)
                    {
                        // Nothing failed: the listing is still to be written, when Codex can answer again.
                        WaitForLimit(productId, limit);
                        return true;
                    }

                    _store.StopListing(productId, ex is OperationCanceledException ? "Stopped." : ex.Message);
                }

                return false;
            }
            finally
            {
                lock (_gate)
                {
                    _currentCancel = null;
                }

                cancel.Dispose();
            }
        }

        /// <summary>The listing's request: the set's phone photos, its white-background photo, and what the AI saw.</summary>
        private ProductListingRequest ListingRequestFor(ProductPhotoInfo info, PhotoSet set)
        {
            var catalogue = set.Latest(PhotoKind.WhiteBackground)?.File;
            return new ProductListingRequest
            {
                ProductId = info.ProductId,
                Code = info.Code,
                Name = info.Name,
                Category = info.Category,
                SetId = set.Id,
                RawPhotos = set.RawFiles.Select(file => _store.PathOf(info.ProductId, file)).Where(path => path != null).ToList(),
                CataloguePhoto = catalogue == null ? null : _store.PathOf(info.ProductId, catalogue),
                Understanding = info.Understanding,
            };
        }

        /// <summary>The request for one photo: the set's phone photos, and for photos 2 to 5 the white-background photo
        /// and what the AI understood about the product.</summary>
        private ProductPhotoRequest RequestFor(ProductPhotoInfo info, PhotoSet set, PhotoKind kind)
        {
            var catalogue = kind == PhotoKind.WhiteBackground ? null : set.Latest(PhotoKind.WhiteBackground)?.File;
            var raws = set.RawFiles.Select(file => _store.PathOf(info.ProductId, file)).Where(path => path != null).ToList();

            // The photos made follow the shape of the owner's first phone photo, as it is shown.
            int width = 0, height = 0;
            foreach (var raw in raws)
            {
                if (ImageFile.TryReadShownSize(raw, out width, out height))
                {
                    break;
                }

                width = height = 0;
            }

            // A note asks for a change to the photo of this kind made before: it comes with that photo.
            var note = set.PendingNotes != null && set.PendingNotes.TryGetValue(kind, out var asked) ? asked : "";
            var before = note.Length > 0 && set.Latest(kind) is ProductPhotoImage previous ? _store.PathOf(info.ProductId, previous.File) : null;
            return new ProductPhotoRequest
            {
                ProductId = info.ProductId,
                Code = info.Code,
                Name = info.Name,
                Category = info.Category,
                Kind = kind,
                RawPhotos = raws,
                CataloguePhoto = catalogue == null ? null : _store.PathOf(info.ProductId, catalogue),
                Understanding = kind == PhotoKind.WhiteBackground ? null : info.Understanding,
                ReferenceWidth = width,
                ReferenceHeight = height,
                Note = before == null ? "" : note,
                PreviousPhoto = before,
            };
        }

        /// <summary>Tells the pages about every product with work: they all wait for the limit, or all carry on.</summary>
        private void RaiseAll()
        {
            List<int> products;
            lock (_gate)
            {
                products = _queue.ToList();
                if (_current != null && !products.Contains(_current.ProductId))
                {
                    products.Add(_current.ProductId);
                }
            }

            foreach (var productId in products)
            {
                Raise(productId);
            }

            if (products.Count == 0)
            {
                // The queue panel and the sidebar listen to any product.
                Raise(0);
            }
        }

        private void Raise(int productId)
        {
            var handlers = Changed;
            if (handlers == null)
            {
                return;
            }

            foreach (Action<int> handler in handlers.GetInvocationList())
            {
                try
                {
                    handler(productId);
                }
                catch (Exception ex)
                {
                    Error?.Invoke(ex);
                }
            }
        }
    }
}
