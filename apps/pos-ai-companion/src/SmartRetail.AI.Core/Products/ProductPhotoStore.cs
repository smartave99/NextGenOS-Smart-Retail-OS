using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmartRetail.AI.Products
{
    /// <summary>One photo the AI made.</summary>
    public sealed class ProductPhotoImage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PhotoKind Kind { get; set; }

        public string File { get; set; } = "";

        public DateTime Made { get; set; }

        public string Provider { get; set; } = "";

        /// <summary>What the owner asked to change from the photo before it, in their words; empty for a photo made without a note.</summary>
        public string Note { get; set; } = "";
    }

    /// <summary>The five photos made from one upload of phone photos.</summary>
    public sealed class PhotoSet
    {
        public string Id { get; set; } = "";

        public DateTime Started { get; set; }

        public List<string> RawFiles { get; set; } = new List<string>();

        /// <summary>Every photo made for the set, newest first. A photo made again keeps the earlier one.</summary>
        public List<ProductPhotoImage> Images { get; set; } = new List<ProductPhotoImage>();

        /// <summary>The photos still to make, in order.</summary>
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<PhotoKind> Pending { get; set; } = new List<PhotoKind>();

        /// <summary>What the owner asked to change, for the photos still to make again: the note goes with the next photo of that kind
        /// (<see cref="ProductPhotoImage.Note"/>) once it is made.</summary>
        public Dictionary<PhotoKind, string> PendingNotes { get; set; } = new Dictionary<PhotoKind, string>();

        /// <summary>Why making stopped, or null while it goes on. A stopped set waits until someone continues it.</summary>
        public string Problem { get; set; }

        public ProductPhotoImage Latest(PhotoKind kind) => Images.FirstOrDefault(image => image.Kind == kind);

        /// <summary>How many of the five photos exist.</summary>
        [JsonIgnore]
        public int MadeCount => PhotoKinds.All.Count(kind => Latest(kind) != null);
    }

    /// <summary>A product's photo sets, newest first, and the latest description the AI gave.</summary>
    public sealed class ProductPhotoInfo
    {
        public int ProductId { get; set; }

        public string Code { get; set; } = "";

        public string Name { get; set; } = "";

        public string Category { get; set; } = "";

        public ProductUnderstanding Understanding { get; set; }

        /// <summary>The set whose white-background photo the AI described the product from; empty when it is not known
        /// (kept by an earlier version).</summary>
        public string UnderstandingSetId { get; set; } = "";

        public List<PhotoSet> Sets { get; set; } = new List<PhotoSet>();

        /// <summary>The listings for Amazon and the website, kept so they are not written again; null until written.</summary>
        public ProductListing Listing { get; set; }

        /// <summary>Earlier listings, newest first (at most <see cref="ProductPhotoStore.EarlierListingsKept"/>), to go back to.</summary>
        public List<ProductListing> EarlierListings { get; set; } = new List<ProductListing>();

        /// <summary>A listing waits to be written, e.g. after the first photos or "Write again".</summary>
        public bool ListingPending { get; set; }

        /// <summary>Why the listing could not be written, or null.</summary>
        public string ListingProblem { get; set; }

        /// <summary>Where the product goes on the shop's website, chosen from the website's own categories after its photos and
        /// listing were made; null until chosen.</summary>
        public WebsiteCategoryChoice WebsiteCategory { get; set; }

        [JsonIgnore]
        public PhotoSet LatestSet => Sets.Count > 0 ? Sets[0] : null;

        /// <summary>The photo that stands for the product in lists: the newest white-background photo, else the newest photo.</summary>
        [JsonIgnore]
        public string Thumbnail =>
            Sets.Select(set => set.Latest(PhotoKind.WhiteBackground)?.File).FirstOrDefault(file => file != null)
            ?? Sets.SelectMany(set => set.Images).Select(image => image.File).FirstOrDefault();
    }

    /// <summary>
    /// Product photos and descriptions, kept in the add-on's data folder, never in the POS database. Each product has
    /// its own folder named by its POS product id and then its name, e.g. "1006 Sunflower Oil 1 L", so people can find
    /// it by hand. Only file names this store makes can be read back, so a request cannot reach other files.
    /// </summary>
    public sealed class ProductPhotoStore
    {
        private const string InfoFile = "product.json";

        public const int EarlierListingsKept = 5;

        private static readonly Regex NotForFileNames = new Regex(@"[\x00-\x1f<>:""/\\|?*\s]+", RegexOptions.Compiled);

        private static readonly Regex PhotoFileName = new Regex(
            @"^(raw|white|in-use|european-model|indian-model|east-asian-model)-\d{8}-\d{6}(-\d{1,3})?\.(jpg|jpeg|png|webp)$", RegexOptions.Compiled);

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ObjectCreationHandling = ObjectCreationHandling.Replace,
        };

        private readonly object _gate = new object();
        private readonly Func<string> _root;

        public ProductPhotoStore(string root = null)
            : this(() => root)
        {
        }

        /// <param name="root">The folder, asked for each time, so a new data folder chosen by the owner is used at once.</param>
        public ProductPhotoStore(Func<string> root)
        {
            _root = root ?? (() => null);
        }

        public static string DefaultRoot => Storage.DataFolders.Products(Storage.DataFolders.Default);

        public string Root
        {
            get
            {
                var root = _root();
                return string.IsNullOrWhiteSpace(root) ? DefaultRoot : root;
            }
        }

        /// <summary>A product name made safe for a folder name: no characters Windows refuses, at most 60 characters.</summary>
        public static string FolderNameOf(int productId, string productName)
        {
            var name = NotForFileNames.Replace(productName ?? "", " ").Trim();
            name = (name.Length > 60 ? name.Substring(0, 60) : name).TrimEnd(' ', '.');
            var id = productId.ToString(CultureInfo.InvariantCulture);
            return name.Length == 0 ? id : id + " " + name;
        }

        public static bool IsPhotoFileName(string fileName) => fileName != null && PhotoFileName.IsMatch(fileName);

        /// <summary>Keeps an uploaded phone photo. Returns its file name.</summary>
        /// <param name="productName">Names the product's folder when it is made; optional.</param>
        public string SaveRaw(int productId, Stream content, string extension, DateTime now, string productName = null)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var ext = (extension ?? "").Trim().ToLowerInvariant();
            if (!ProductPhotoRequest.PhotoExtensions.Contains(ext))
            {
                throw new ArgumentException("Photos must be JPG, PNG or WEBP files.", nameof(extension));
            }

            lock (_gate)
            {
                var folder = Folder(productId, productName);
                var name = UniqueName(folder, "raw", now, ext);
                using (var file = File.Create(Path.Combine(folder, name)))
                {
                    content.CopyTo(file);
                }

                return name;
            }
        }

        /// <summary>
        /// Starts a new set of the five photos from phone photos kept with <see cref="SaveRaw"/>. The product's older
        /// sets stop waiting for photos: the newest phone photos are the ones that count.
        /// </summary>
        public PhotoSet StartSet(int productId, string code, string name, string category, IReadOnlyList<string> rawFiles, DateTime now)
        {
            var raws = (rawFiles ?? new string[0]).ToList();
            if (raws.Count == 0 || raws.Count > ProductPhotoRequest.MaxPhotos)
            {
                throw new ArgumentException("Use 1 to " + ProductPhotoRequest.MaxPhotos + " photos of one product.", nameof(rawFiles));
            }

            if (raws.Any(raw => !raw.StartsWith("raw-", StringComparison.Ordinal) || PathOf(productId, raw) == null))
            {
                throw new ArgumentException("Only phone photos kept for this product can be used.", nameof(rawFiles));
            }

            lock (_gate)
            {
                var info = LoadUnlocked(productId) ?? new ProductPhotoInfo { ProductId = productId };
                info.Code = code ?? "";
                info.Name = name ?? "";
                info.Category = category ?? "";
                foreach (var older in info.Sets)
                {
                    older.Pending.Clear();
                }

                var id = now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
                for (var n = 1; info.Sets.Any(existing => existing.Id == id); n++)
                {
                    id = now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "-" + n.ToString(CultureInfo.InvariantCulture);
                }

                var set = new PhotoSet { Id = id, Started = now, RawFiles = raws, Pending = PhotoKinds.All.ToList() };
                info.Sets.Insert(0, set);
                SaveUnlocked(info);
                return set;
            }
        }

        /// <summary>Keeps a photo the AI made, as the newest of its kind in the set, and the description if it came with one.</summary>
        public ProductPhotoImage SaveImage(int productId, string setId, PhotoKind kind, ProductPhotoResult result, DateTime now)
        {
            if (result?.Image == null || result.Image.Length == 0)
            {
                throw new ArgumentException("There is no photo to keep.", nameof(result));
            }

            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                var set = info?.Sets.FirstOrDefault(s => s.Id == setId) ?? throw new InvalidOperationException("The photo set " + setId + " was not found.");
                var folder = Folder(productId, info.Name);
                var name = UniqueName(folder, kind.FilePrefix(), now, ImageFile.ExtensionOf(result.Image) ?? ".png");
                File.WriteAllBytes(Path.Combine(folder, name), result.Image);

                var image = new ProductPhotoImage { Kind = kind, File = name, Made = now, Provider = result.ProviderName ?? "" };
                if (set.PendingNotes != null && set.PendingNotes.TryGetValue(kind, out var note))
                {
                    image.Note = note ?? "";
                    set.PendingNotes.Remove(kind);
                }

                set.Images.Insert(0, image);
                set.Pending.Remove(kind);
                if (result.Understanding != null)
                {
                    info.Understanding = result.Understanding;
                    info.UnderstandingSetId = setId;
                }

                SaveUnlocked(info);
                return image;
            }
        }

        /// <summary>Stops a set with the reason; its photos stay pending until someone continues it.</summary>
        public void Stop(int productId, string setId, string problem)
        {
            Change(productId, setId, set => set.Problem = string.IsNullOrWhiteSpace(problem) ? "Stopped." : problem.Trim());
        }

        /// <summary>Adds photos to make (none just continues a stopped set) and clears the problem. True when anything is pending.</summary>
        public bool Queue(int productId, string setId, params PhotoKind[] kinds)
        {
            var pending = false;
            Change(productId, setId, set =>
            {
                set.Pending = set.Pending.Concat(kinds ?? new PhotoKind[0]).Distinct().OrderBy(kind => kind).ToList();
                set.Problem = null;
                pending = set.Pending.Count > 0;
            });
            return pending;
        }

        /// <summary>
        /// Queues one photo to be made again, changed as the owner asks (<paramref name="note"/>, see <see cref="PhotoNotes"/>): the note
        /// waits with it, and goes with the new photo once it is made. An empty note is a plain "make it again".
        /// </summary>
        public bool QueueChange(int productId, string setId, PhotoKind kind, string note)
        {
            var text = PhotoNotes.Tidy(note);
            if (PhotoNotes.Problem(text) is string problem)
            {
                throw new ArgumentException(problem, nameof(note));
            }

            var pending = false;
            Change(productId, setId, set =>
            {
                if (set.PendingNotes == null)
                {
                    set.PendingNotes = new Dictionary<PhotoKind, string>();
                }

                if (text.Length > 0)
                {
                    set.PendingNotes[kind] = text;
                }
                else
                {
                    set.PendingNotes.Remove(kind);
                }

                set.Pending = set.Pending.Concat(new[] { kind }).Distinct().OrderBy(k => k).ToList();
                set.Problem = null;
                pending = set.Pending.Count > 0;
            });
            return pending;
        }

        /// <summary>Gives up one pending photo, e.g. one the AI keeps refusing, and lets the rest carry on.</summary>
        public bool Skip(int productId, string setId, PhotoKind kind)
        {
            var pending = false;
            Change(productId, setId, set =>
            {
                set.Pending.Remove(kind);
                set.PendingNotes?.Remove(kind);
                set.Problem = null;
                pending = set.Pending.Count > 0;
            });
            return pending;
        }

        /// <summary>
        /// Deletes one phone photo of a set, e.g. one added by mistake: the file is removed from this PC and the set
        /// carries on with the others. A set keeps at least one phone photo, so the last one goes with
        /// <see cref="RemoveSet"/>. False when the set has no such photo. Nothing changes when the file cannot be deleted.
        /// </summary>
        public bool RemoveRaw(int productId, string setId, string fileName)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                var set = info?.Sets.FirstOrDefault(s => s.Id == setId);
                if (set == null || !set.RawFiles.Contains(fileName))
                {
                    return false;
                }

                if (set.RawFiles.Count == 1)
                {
                    throw new InvalidOperationException("It is the only phone photo of this set: remove the whole set instead.");
                }

                var path = PathOf(productId, fileName);
                if (path != null)
                {
                    File.Delete(path);
                }

                set.RawFiles.Remove(fileName);
                SaveUnlocked(info);
                return true;
            }
        }

        /// <summary>
        /// Deletes a whole set: its phone photos and every photo made from them, from this PC. What was made from it
        /// goes with it: the AI's description of the product when it came from this set, and the listings the AI wrote
        /// from it (the owner's own changes to a listing are kept). False when there is no such set. When some files
        /// cannot be deleted the set is still removed, and an <see cref="IOException"/> names them.
        /// </summary>
        public bool RemoveSet(int productId, string setId)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                var set = info?.Sets.FirstOrDefault(s => s.Id == setId);
                if (set == null)
                {
                    return false;
                }

                var stuck = new List<string>();
                foreach (var file in set.RawFiles.Concat(set.Images.Select(image => image.File)).Distinct())
                {
                    var path = PathOf(productId, file);
                    try
                    {
                        if (path != null)
                        {
                            File.Delete(path);
                        }
                    }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        stuck.Add(file);
                    }
                }

                var wasLatest = ReferenceEquals(set, info.LatestSet);
                info.Sets.Remove(set);
                if (info.UnderstandingSetId == set.Id || (info.UnderstandingSetId.Length == 0 && info.Sets.Count == 0))
                {
                    info.Understanding = null;
                    info.UnderstandingSetId = "";
                }

                if (info.Listing != null && info.Listing.SetId == set.Id && info.Listing.Edited == null)
                {
                    info.Listing = null;
                    if (info.WebsiteCategory != null && info.WebsiteCategory.Source != WebsiteCategoryChoice.ByOwner)
                    {
                        info.WebsiteCategory = null;
                    }
                }

                info.EarlierListings.RemoveAll(listing => listing.SetId == set.Id && listing.Edited == null);
                if (wasLatest)
                {
                    info.ListingPending = false;
                    info.ListingProblem = null;
                }

                SaveUnlocked(info);
                if (stuck.Count > 0)
                {
                    throw new IOException("The set was removed, but these files could not be deleted and are still in the product's folder: " + string.Join(", ", stuck) + ".");
                }

                return true;
            }
        }

        public ProductPhotoInfo Load(int productId)
        {
            lock (_gate)
            {
                return LoadUnlocked(productId);
            }
        }

        /// <summary>Every product that has photos, by POS product id.</summary>
        public IReadOnlyDictionary<int, ProductPhotoInfo> LoadAll()
        {
            var all = new Dictionary<int, ProductPhotoInfo>();
            if (!Directory.Exists(Root))
            {
                return all;
            }

            lock (_gate)
            {
                foreach (var folder in Directory.EnumerateDirectories(Root))
                {
                    var name = Path.GetFileName(folder);
                    var space = name.IndexOf(' ');
                    if (int.TryParse(space < 0 ? name : name.Substring(0, space), NumberStyles.None, CultureInfo.InvariantCulture, out var id)
                        && !all.ContainsKey(id)
                        && LoadUnlocked(id) is ProductPhotoInfo info)
                    {
                        all[id] = info;
                    }
                }
            }

            return all;
        }

        /// <summary>Products whose newest set still has photos to make and was not stopped, or whose listing waits to be
        /// written, e.g. when the app closed mid-way.</summary>
        public IReadOnlyList<int> Resumable() =>
            LoadAll().Values
                .Where(info => info.LatestSet is PhotoSet set && ((set.Pending.Count > 0 && set.Problem == null) || ProductPhotoMaker.ListingReady(info, set)))
                .OrderBy(info => info.LatestSet.Started)
                .Select(info => info.ProductId)
                .ToList();

        /// <summary>Asks for the product's listing to be written (again). False when the product has no photos.</summary>
        public bool QueueListing(int productId)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                if (info?.LatestSet == null)
                {
                    return false;
                }

                info.ListingPending = true;
                info.ListingProblem = null;
                SaveUnlocked(info);
                return true;
            }
        }

        /// <summary>Keeps a listing the AI wrote; the one it replaces becomes the newest earlier listing.</summary>
        public ProductListing SaveListing(int productId, ProductListing listing, DateTime now)
        {
            return Keep(productId, listing, info =>
            {
                listing.Written = now;
                listing.Edited = null;
                info.ListingPending = false;
                info.ListingProblem = null;
            });
        }

        /// <summary>Keeps the owner's changes to the listing, checked by <see cref="ListingRules"/>; the listing as it was
        /// becomes the newest earlier listing, so the change can be undone.</summary>
        public ProductListing EditListing(int productId, ProductListing listing, DateTime now)
        {
            return Keep(productId, listing, info => listing.Edited = now);
        }

        /// <summary>Goes back to an earlier listing (0 is the newest); the current one becomes an earlier one.</summary>
        public ProductListing RestoreListing(int productId, int index)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                if (info == null || index < 0 || index >= info.EarlierListings.Count)
                {
                    return null;
                }

                var restored = info.EarlierListings[index];
                info.EarlierListings.RemoveAt(index);
                if (info.Listing != null)
                {
                    info.EarlierListings.Insert(0, info.Listing);
                }

                info.Listing = restored;
                info.EarlierListings = info.EarlierListings.Take(EarlierListingsKept).ToList();
                SaveUnlocked(info);
                return restored;
            }
        }

        /// <summary>Keeps where the product goes on the website; null takes the choice back.</summary>
        public void SaveWebsiteCategory(int productId, WebsiteCategoryChoice choice)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                if (info == null)
                {
                    return;
                }

                info.WebsiteCategory = choice;
                SaveUnlocked(info);
            }
        }

        /// <summary>The listing could not be written: says why, and waits for "Write again".</summary>
        public void StopListing(int productId, string problem)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                if (info == null)
                {
                    return;
                }

                info.ListingPending = false;
                info.ListingProblem = string.IsNullOrWhiteSpace(problem) ? "Stopped." : problem.Trim();
                SaveUnlocked(info);
            }
        }

        private ProductListing Keep(int productId, ProductListing listing, Action<ProductPhotoInfo> change)
        {
            if (listing == null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            lock (_gate)
            {
                var info = LoadUnlocked(productId) ?? throw new InvalidOperationException("The product " + productId + " has no photos.");
                change(info);
                var clean = ListingRules.Clean(listing).Listing;
                if (info.Listing != null)
                {
                    info.EarlierListings.Insert(0, info.Listing);
                    info.EarlierListings = info.EarlierListings.Take(EarlierListingsKept).ToList();
                }

                info.Listing = clean;
                SaveUnlocked(info);
                return clean;
            }
        }

        /// <summary>The full path of one of the product's photos, or null for any other name.</summary>
        public string PathOf(int productId, string fileName)
        {
            if (productId < 0 || !IsPhotoFileName(fileName))
            {
                return null;
            }

            var folder = FindFolder(productId);
            var path = folder == null ? null : Path.Combine(folder, fileName);
            return path != null && File.Exists(path) ? path : null;
        }

        /// <summary>The product's folder, or null when it has none yet.</summary>
        public string FolderOf(int productId) => productId < 0 ? null : FindFolder(productId);

        private void Change(int productId, string setId, Action<PhotoSet> change)
        {
            lock (_gate)
            {
                var info = LoadUnlocked(productId);
                var set = info?.Sets.FirstOrDefault(s => s.Id == setId);
                if (set == null)
                {
                    return;
                }

                change(set);
                SaveUnlocked(info);
            }
        }

        /// <summary>The product's folder: "1006", or "1006 Sunflower Oil 1 L" as made from the name. Null when there is none.</summary>
        private string FindFolder(int productId)
        {
            var root = Root;
            if (!Directory.Exists(root))
            {
                return null;
            }

            var id = productId.ToString(CultureInfo.InvariantCulture);
            var plain = Path.Combine(root, id);
            return Directory.Exists(plain) ? plain : Directory.EnumerateDirectories(root, id + " *").OrderBy(path => path, StringComparer.Ordinal).FirstOrDefault();
        }

        /// <summary>The product's folder, made (named after the product when the name is known) if it does not exist.</summary>
        private string Folder(int productId, string productName = null)
        {
            if (productId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId));
            }

            var folder = FindFolder(productId) ?? Path.Combine(Root, FolderNameOf(productId, productName));
            Directory.CreateDirectory(folder);
            return folder;
        }

        private static string UniqueName(string folder, string kind, DateTime now, string extension)
        {
            var stamp = kind + "-" + now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            var name = stamp + extension;
            for (var n = 1; File.Exists(Path.Combine(folder, name)); n++)
            {
                name = stamp + "-" + n.ToString(CultureInfo.InvariantCulture) + extension;
            }

            return name;
        }

        private ProductPhotoInfo LoadUnlocked(int productId)
        {
            var folder = FindFolder(productId);
            var path = folder == null ? null : Path.Combine(folder, InfoFile);
            if (path == null || !File.Exists(path))
            {
                return null;
            }

            try
            {
                var info = JsonConvert.DeserializeObject<ProductPhotoInfo>(File.ReadAllText(path, Encoding.UTF8), JsonSettings);
                if (info != null)
                {
                    info.ProductId = productId;
                    info.UnderstandingSetId = info.UnderstandingSetId ?? "";
                    info.Sets = (info.Sets ?? new List<PhotoSet>()).Where(set => set != null).ToList();
                    info.EarlierListings = (info.EarlierListings ?? new List<ProductListing>()).Where(l => l != null).Take(EarlierListingsKept).ToList();

                    // One name for the website and Amazon: a listing kept when they had a name each takes the website's, as it is shown.
                    info.Listing?.WithOneName();
                    foreach (var earlier in info.EarlierListings)
                    {
                        earlier.WithOneName();
                    }

                    foreach (var set in info.Sets)
                    {
                        set.RawFiles = (set.RawFiles ?? new List<string>()).Where(IsPhotoFileName).ToList();
                        set.Images = (set.Images ?? new List<ProductPhotoImage>()).Where(image => image != null && IsPhotoFileName(image.File)).ToList();
                        set.Pending = (set.Pending ?? new List<PhotoKind>()).Where(kind => Enum.IsDefined(typeof(PhotoKind), kind)).Distinct().OrderBy(kind => kind).ToList();

                        // A note goes into the AI's instructions, so a file edited by hand is screened as the owner's words are.
                        set.PendingNotes = (set.PendingNotes ?? new Dictionary<PhotoKind, string>())
                            .Where(note => set.Pending.Contains(note.Key) && PhotoNotes.Tidy(note.Value).Length > 0 && PhotoNotes.Problem(note.Value) == null)
                            .ToDictionary(note => note.Key, note => PhotoNotes.Tidy(note.Value));
                        foreach (var image in set.Images)
                        {
                            image.Note = PhotoNotes.Problem(image.Note) == null ? PhotoNotes.Tidy(image.Note) : "";
                        }
                    }
                }

                return info;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private void SaveUnlocked(ProductPhotoInfo info)
        {
            var path = Path.Combine(Folder(info.ProductId, info.Name), InfoFile);
            var temp = path + ".tmp";
            File.WriteAllText(temp, JsonConvert.SerializeObject(info, JsonSettings), new UTF8Encoding(false));
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.Move(temp, path);
        }
    }
}
