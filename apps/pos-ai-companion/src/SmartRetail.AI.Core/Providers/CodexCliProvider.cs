using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Posters;
using SmartRetail.AI.Prices;
using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>OpenAI Codex CLI via <c>codex exec</c>. Uses whatever Codex is signed in with on this PC
    /// (a ChatGPT account or an OpenAI API key).</summary>
    public sealed class CodexCliProvider : CliProviderBase, IReadsAttachments
    {
        internal const string LastMessageFile = "last-message.txt";
        internal const string PhotoSchemaFile = "product-schema.json";
        internal const string ListingSchemaFile = "listing-schema.json";
        internal const string PriceSchemaFile = "price-check-schema.json";
        internal const string CreativeSchemaFile = "creative-schema.json";

        /// <summary>Making an image takes longer than answering a question.</summary>
        public static readonly TimeSpan MinimumPhotoTimeout = TimeSpan.FromMinutes(5);

        /// <summary>A listing reads up to four photos and writes a good deal.</summary>
        public static readonly TimeSpan MinimumListingTimeout = TimeSpan.FromMinutes(3);

        /// <summary>Reading several shops' pages on the web takes longer than writing text.</summary>
        public static readonly TimeSpan MinimumPriceCheckTimeout = TimeSpan.FromMinutes(6);

        /// <summary>A whole advertisement takes longer than a photo; it is still stopped if it never ends.</summary>
        public static readonly TimeSpan MinimumCreativeTimeout = TimeSpan.FromMinutes(10);

        public CodexCliProvider(ICliRunner runner, Func<AssistantSettings> settings, string workspaceRoot = null)
            : base(runner, settings, workspaceRoot)
        {
        }

        public override string Id => ProviderIds.CodexCli;

        public override string DisplayName => "Codex CLI (OpenAI)";

        protected override string CommandName => "codex";

        protected override CliProviderSettings ProviderSettings => Settings().Codex;

        protected override string InstallHint => "Install Node.js, then run: npm install -g @openai/codex — and sign in with: codex login";

        private string SignInHelp => "Codex is not signed in. Open a terminal and run \"codex login\", or use \"Sign in Codex with API key\" in Settings.";

        /// <summary>Codex reads photos either way; a voice note needs its app server, and a model that listens.</summary>
        public string CannotRead(AiRequest request) => null;

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            if (request?.Audio.Count > 0)
            {
                // Only the app server takes a recording (codex exec has no way to attach one).
                try
                {
                    return await StreamAsync(request, () => { }, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (!cancellationToken.IsCancellationRequested
                    && (ex is CodexAppServerException || ex is CliStartException || ex is IOException || ex is InvalidOperationException))
                {
                    var voiceLimit = CodexErrors.UsageLimitOf(ex.Message);
                    throw new AiProviderException(Id, voiceLimit?.Message
                        ?? "Codex could not take the voice note: " + ex.Message + " Type the question instead, or choose a model that takes audio.", canFallback: true, innerException: ex, usageLimit: voiceLimit);
                }
            }

            if (request?.OnText != null)
            {
                var streamed = false;
                try
                {
                    return await StreamAsync(request, () => streamed = true, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (!streamed && !cancellationToken.IsCancellationRequested
                    && (ex is CodexAppServerException || ex is CliStartException || ex is IOException || ex is InvalidOperationException))
                {
                    // The account's usage limit: asking the usual way would only hit it again.
                    if (CodexErrors.UsageLimitOf(ex.Message) is UsageLimitInfo limit)
                    {
                        throw new AiProviderException(Id, limit.Message, canFallback: true, innerException: ex, usageLimit: limit);
                    }

                    // An older Codex without the app server, or one that stopped before answering: ask the usual way.
                }
                catch (CodexAppServerException ex) when (streamed && !cancellationToken.IsCancellationRequested)
                {
                    // Stopped part way through its answer: what it said so far is shown; another tool would start over.
                    var stoppedLimit = CodexErrors.UsageLimitOf(ex.Message);
                    throw new AiProviderException(Id, stoppedLimit?.Message ?? "Codex stopped while answering: " + ex.Message, canFallback: false, innerException: ex, usageLimit: stoppedLimit);
                }
            }

            var executable = RequireExecutable();
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = PromptText.Combine(request.SystemPrompt, request.UserPrompt),
                    Timeout = PromptTimeout,
                };
                invocation.Arguments.AddRange(BuildArguments(workspace.DirectoryPath, workspace.PathOf(LastMessageFile), CopyInto(workspace, request.Images, "photo")));
                invocation.Environment["NO_COLOR"] = "1";

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                var answer = (workspace.ReadFileOrNull(LastMessageFile) ?? "").Trim();
                if (result.TimedOut || result.ExitCode != 0 || answer.Length == 0)
                {
                    throw Failure(result, SignInHelp);
                }

                return new AiResponse(Id, answer, result.Duration);
            }
        }

        /// <summary>
        /// The same question through Codex's app server, whose answer arrives word by word: a thread that is never saved,
        /// in an empty folder, read-only unless the settings allow the workspace, and no approvals.
        /// </summary>
        private async Task<AiResponse> StreamAsync(AiRequest request, Action started, CancellationToken cancellationToken)
        {
            RequireExecutable();
            var settings = Settings().Codex;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            using (var server = await OpenAppServerAsync(cancellationToken).ConfigureAwait(false))
            {
                var turn = new CodexTurnRequest
                {
                    Prompt = PromptText.Combine(request.SystemPrompt, request.UserPrompt),
                    WorkingDirectory = workspace.DirectoryPath,
                    Sandbox = settings.SandboxMode == "workspace-write" ? "workspace-write" : "read-only",
                    Model = CheckToken(settings.Model, "Codex model"),
                    ReasoningEffort = CheckToken(settings.ReasoningEffort, "Codex reasoning effort")?.ToLowerInvariant(),
                };
                turn.Images.AddRange(CopyInto(workspace, request.Images, "photo"));
                turn.Audio.AddRange(CopyInto(workspace, request.Audio, "voice"));
                var answer = await server.RunTurnAsync(turn, text =>
                {
                    started();
                    request.OnText?.Invoke(text);
                }, PromptTimeout, cancellationToken).ConfigureAwait(false);
                if (string.IsNullOrWhiteSpace(answer))
                {
                    throw new CodexAppServerException("Codex answered nothing.");
                }

                return new AiResponse(Id, answer.Trim(), stopwatch.Elapsed);
            }
        }

        /// <summary>Codex's own folder (CODEX_HOME, or .codex in the user's folder), where its image tool keeps what it makes.</summary>
        internal string CodexHome { get; set; } = DefaultCodexHome;

        private static string DefaultCodexHome
        {
            get
            {
                var configured = Environment.GetEnvironmentVariable("CODEX_HOME");
                return string.IsNullOrWhiteSpace(configured)
                    ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".codex")
                    : configured.Trim();
            }
        }

        private TimeSpan PhotoTimeout => PromptTimeout > MinimumPhotoTimeout ? PromptTimeout : MinimumPhotoTimeout;

        /// <summary>
        /// Makes one photo of a product from its phone photos with Codex's built-in image tool (ChatGPT Images for a
        /// ChatGPT sign-in, the OpenAI image models for an API key). With the white-background photo, Codex also
        /// describes the product. Codex works in an empty folder holding only copies of the photos.
        /// </summary>
        public async Task<ProductPhotoResult> MakeProductPhotoAsync(ProductPhotoRequest request, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var problem = request == null ? "No product was given." : request.Problem();
            if (problem != null)
            {
                throw new AiProviderException(Id, problem, canFallback: false);
            }

            var executable = RequireExecutable();
            using var turn = await TakeImageTurnAsync(progress, cancellationToken).ConfigureAwait(false);
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            using (var forget = new ForgetRun(CodexHome, workspace.DirectoryPath, turn.Started))
            {
                var photos = new List<string>();
                var number = 0;
                foreach (var attachment in request.Attachments())
                {
                    var name = request.IsChange && attachment == request.PreviousPhoto ? "previous-photo"
                        : attachment == request.CataloguePhoto ? "catalogue-photo" : "photo-" + ++number;
                    var copy = workspace.PathOf(name + Path.GetExtension(attachment).ToLowerInvariant());
                    File.Copy(attachment, copy);
                    photos.Add(copy);
                }

                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = ProductPhotoPrompt.CodexPrompt(request),
                    Timeout = PhotoTimeout,
                };
                var schema = request.Describe ? workspace.WriteFile(PhotoSchemaFile, ProductPhotoPrompt.UnderstandingSchema) : null;
                invocation.Arguments.AddRange(BuildPhotoArguments(workspace.DirectoryPath, photos, schema, workspace.PathOf(LastMessageFile)));
                invocation.Environment["NO_COLOR"] = "1";

                progress?.Report("Codex is " + (request.IsChange ? "changing" : "making") + " photo " + request.Kind.Number() + " of " + PhotoKinds.All.Count + ": " + request.Kind.Title() + ". This can take a minute or two…");
                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, SignInHelp);
                }

                var image = FindNewImage(workspace.DirectoryPath, photos, turn.Started, turn.Before, out var owned);
                if (image == null)
                {
                    throw new AiProviderException(Id, "Codex answered but made no image. Making images needs Codex signed in with a ChatGPT plan "
                        + "that includes images, or with an OpenAI API key; check with \"codex login status\".", canFallback: false);
                }

                return new ProductPhotoResult
                {
                    Image = Keep(forget, image, owned),
                    Understanding = request.Describe ? ProductUnderstanding.Parse(workspace.ReadFileOrNull(LastMessageFile)) : null,
                    ProviderName = DisplayName,
                    Duration = result.Duration,
                };
            }
        }

        /// <summary>
        /// Writes a product's listings for Amazon and the shop's website from its photos and what Codex saw in them
        /// earlier: text only, in an empty folder holding copies of the photos, read-only and never saved as a session.
        /// The answer is checked by <see cref="ListingRules"/> before it is kept.
        /// </summary>
        public async Task<ProductListingResult> WriteProductListingAsync(ProductListingRequest request, CancellationToken cancellationToken)
        {
            var problem = request == null ? "No product was given." : request.Problem();
            if (problem != null)
            {
                throw new AiProviderException(Id, problem, canFallback: false);
            }

            var executable = RequireExecutable();
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var photos = new List<string>();
                var number = 0;
                foreach (var attachment in request.Attachments())
                {
                    var name = attachment == request.CataloguePhoto ? "catalogue-photo" : "photo-" + ++number;
                    var copy = workspace.PathOf(name + Path.GetExtension(attachment).ToLowerInvariant());
                    File.Copy(attachment, copy);
                    photos.Add(copy);
                }

                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = ProductListingPrompt.CodexPrompt(request),
                    Timeout = PromptTimeout > MinimumListingTimeout ? PromptTimeout : MinimumListingTimeout,
                };
                var arguments = BuildArguments(workspace.DirectoryPath, workspace.PathOf(LastMessageFile), photos, readOnly: true);
                arguments.InsertRange(arguments.Count - 1, new[] { "--output-schema", workspace.WriteFile(ListingSchemaFile, ProductListingPrompt.Schema) });
                invocation.Arguments.AddRange(arguments);
                invocation.Environment["NO_COLOR"] = "1";

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, SignInHelp);
                }

                var listing = ProductListing.Parse(workspace.ReadFileOrNull(LastMessageFile))
                    ?? throw new AiProviderException(Id, "Codex answered without a listing. Try Write again.", canFallback: false);
                return new ProductListingResult { Listing = listing, ProviderName = DisplayName, Duration = result.Duration };
            }
        }

        /// <summary>
        /// Looks for a product's price in online shops with Codex's web search (<c>--search</c>): text only, in an empty
        /// folder, read-only and never saved as a session. Only the product's name, maker's barcode and category leave the
        /// PC, never a price of the shop's. The answer is checked by <see cref="PriceCheckRules"/> before it is kept.
        /// </summary>
        public async Task<PriceCheckResult> CheckPricesAsync(PriceCheckRequest request, CancellationToken cancellationToken)
        {
            var problem = request == null ? "No product was given." : request.Problem();
            if (problem != null)
            {
                throw new AiProviderException(Id, problem, canFallback: false);
            }

            var executable = RequireExecutable();
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = PriceCheckRules.Prompt(request),
                    Timeout = PromptTimeout > MinimumPriceCheckTimeout ? PromptTimeout : MinimumPriceCheckTimeout,
                };
                var arguments = BuildArguments(workspace.DirectoryPath, workspace.PathOf(LastMessageFile), readOnly: true);
                arguments.InsertRange(arguments.Count - 1, new[] { "--output-schema", workspace.WriteFile(PriceSchemaFile, PriceCheckRules.Schema) });

                // Web search is a switch of Codex itself, given before the command as Codex documents it.
                arguments.Insert(0, "--search");
                invocation.Arguments.AddRange(arguments);
                invocation.Environment["NO_COLOR"] = "1";

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, SignInHelp);
                }

                var answer = PriceCheckRules.Parse(workspace.ReadFileOrNull(LastMessageFile), request)
                    ?? throw new AiProviderException(Id, "Codex answered without a price list. Try again.", canFallback: false);
                return new PriceCheckResult { Answer = answer, ProviderName = DisplayName, Duration = result.Duration };
            }
        }

        /// <summary>
        /// Makes the artwork for an A4 poster with Codex's built-in image tool: colours and decoration only, with no text,
        /// numbers, products or people, because the app prints the words, photos and prices on it. Codex works in an
        /// empty folder.
        /// </summary>
        public async Task<PosterArtworkResult> MakePosterArtworkAsync(PosterArtworkRequest request, IProgress<string> progress, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request?.Theme))
            {
                throw new AiProviderException(Id, "The poster needs a theme.", canFallback: false);
            }

            var executable = RequireExecutable();
            using var turn = await TakeImageTurnAsync(progress, cancellationToken).ConfigureAwait(false);
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            using (var forget = new ForgetRun(CodexHome, workspace.DirectoryPath, turn.Started))
            {
                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = PosterArtworkPrompt.CodexPrompt(request),
                    Timeout = PhotoTimeout,
                };
                invocation.Arguments.AddRange(BuildPhotoArguments(workspace.DirectoryPath, new string[0], null, workspace.PathOf(LastMessageFile)));
                invocation.Environment["NO_COLOR"] = "1";

                progress?.Report("Codex is making the poster's artwork. This can take a minute or two…");
                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, SignInHelp);
                }

                var image = FindNewImage(workspace.DirectoryPath, new List<string>(), turn.Started, turn.Before, out var owned, PosterArtworkPrompt.ResultFileName);
                if (image == null)
                {
                    throw new AiProviderException(Id, "Codex answered but made no image. Making images needs Codex signed in with a ChatGPT plan "
                        + "that includes images, or with an OpenAI API key; check with \"codex login status\".", canFallback: false);
                }

                return new PosterArtworkResult
                {
                    Image = Keep(forget, image, owned),
                    ProviderName = DisplayName,
                    Duration = result.Duration,
                };
            }
        }

        /// <summary>
        /// Designs an advertising creative with Codex's built-in image tool, from the owner's brief. The products'
        /// photos, the logo, pictures to take the look from and, for a change, the picture made before are copied into an
        /// empty folder. The answer says where Codex left room for the prices, which the app adds itself.
        /// </summary>
        public async Task<CreativeArtResult> MakeCreativeAsync(CreativeArtRequest request, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var problem = request == null ? "No creative was given." : request.Problem();
            if (problem != null)
            {
                throw new AiProviderException(Id, problem, canFallback: false);
            }

            var executable = RequireExecutable();
            using var turn = await TakeImageTurnAsync(progress, cancellationToken).ConfigureAwait(false);
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            using (var forget = new ForgetRun(CodexHome, workspace.DirectoryPath, turn.Started))
            {
                // A file given twice (one photo for two products) is copied once, under the name the prompt uses.
                var images = new List<string>();
                var copied = new HashSet<string>(StringComparer.Ordinal);
                foreach (var file in request.Attachments())
                {
                    if (copied.Add(file.Key))
                    {
                        var copy = workspace.PathOf(file.Value);
                        File.Copy(file.Key, copy);
                        images.Add(copy);
                    }
                }

                var prompt = CreativeArtPrompt.CodexPrompt(request);
                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = prompt,
                    Timeout = PromptTimeout > MinimumCreativeTimeout ? PromptTimeout : MinimumCreativeTimeout,
                };
                var schema = workspace.WriteFile(CreativeSchemaFile, CreativeArtPrompt.Schema);
                invocation.Arguments.AddRange(BuildPhotoArguments(workspace.DirectoryPath, images, schema, workspace.PathOf(LastMessageFile)));
                invocation.Environment["NO_COLOR"] = "1";

                progress?.Report(request.IsRevision
                    ? "Codex is changing the creative. This can take a few minutes…"
                    : "Codex is designing the creative. This can take a few minutes…");
                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, SignInHelp);
                }

                var image = FindNewImage(workspace.DirectoryPath, images, turn.Started, turn.Before, out var owned, CreativeArtPrompt.ResultFileName);
                if (image == null)
                {
                    throw new AiProviderException(Id, "Codex answered but made no picture. Making images needs Codex signed in with a ChatGPT plan "
                        + "that includes images, or with an OpenAI API key; check with \"codex login status\".", canFallback: false);
                }

                var (areas, notes) = CreativeArtAnswer.Parse(workspace.ReadFileOrNull(LastMessageFile), request.PriceTags);
                return new CreativeArtResult
                {
                    Image = Keep(forget, image, owned),
                    PriceAreas = areas,
                    Notes = notes,
                    Prompt = prompt,
                    ProviderName = DisplayName,
                    Duration = result.Duration,
                };
            }
        }

        /// <param name="schemaPath">The JSON schema for the answer; null when only the image is wanted.</param>
        internal List<string> BuildPhotoArguments(string workingDirectory, IEnumerable<string> photos, string schemaPath, string lastMessagePath)
        {
            // The photos come first: --image takes several values and the next flag ends the list,
            // so the final "-" (prompt on standard input) is never taken for an image.
            var arguments = new List<string> { "exec" };
            foreach (var photo in photos)
            {
                arguments.Add("--image");
                arguments.Add(photo);
            }

            arguments.AddRange(new[]
            {
                "--skip-git-repo-check",
                // Codex has to copy the image it makes into the working folder, which holds nothing but the photos.
                "--sandbox", "workspace-write",
                "--color", "never",
                "--cd", workingDirectory,
                "--enable", "image_generation",
            });
            if (schemaPath != null)
            {
                arguments.Add("--output-schema");
                arguments.Add(schemaPath);
            }

            arguments.Add("--output-last-message");
            arguments.Add(lastMessagePath);

            var model = CheckToken(Settings().Codex.Model, "Codex model");
            if (model != null)
            {
                arguments.Add("--model");
                arguments.Add(model);
            }

            arguments.Add("-");
            return arguments;
        }

        /// <summary>
        /// Image runs in this app go one at a time for each Codex folder (CODEX_HOME), so a picture Codex leaves only in
        /// its own folder (generated_images) during a run is never another of the app's runs'.
        /// </summary>
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> ImageRuns =
            new ConcurrentDictionary<string, SemaphoreSlim>(StringComparer.OrdinalIgnoreCase);

        /// <summary>Waits for the run's turn, then notes when it began and the pictures Codex's folder already held.</summary>
        private async Task<ImageTurn> TakeImageTurnAsync(IProgress<string> progress, CancellationToken cancellationToken)
        {
            var runs = ImageRuns.GetOrAdd(FolderKey(CodexHome), _ => new SemaphoreSlim(1, 1));
            if (!runs.Wait(0))
            {
                progress?.Report("Waiting for the picture Codex is making now…");
                await runs.WaitAsync(cancellationToken).ConfigureAwait(false);
            }

            try
            {
                return new ImageTurn(runs, DateTime.UtcNow, GeneratedImages());
            }
            catch
            {
                runs.Release();
                throw;
            }
        }

        private static string FolderKey(string folder)
        {
            try
            {
                return Path.GetFullPath(folder).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException || ex is System.Security.SecurityException)
            {
                return folder ?? "";
            }
        }

        /// <summary>An image run's turn: when it began, and the pictures in Codex's folder before it, with when each was written.</summary>
        private sealed class ImageTurn : IDisposable
        {
            private SemaphoreSlim _runs;

            public ImageTurn(SemaphoreSlim runs, DateTime started, IReadOnlyDictionary<string, DateTime> before)
            {
                _runs = runs;
                Started = started;
                Before = before;
            }

            public DateTime Started { get; }

            public IReadOnlyDictionary<string, DateTime> Before { get; }

            public void Dispose() => Interlocked.Exchange(ref _runs, null)?.Release();
        }

        /// <summary>The picture's bytes; Codex's copies of them are cleared after the run only when the picture was surely
        /// this run's.</summary>
        private static byte[] Keep(ForgetRun forget, string image, bool owned)
        {
            var bytes = File.ReadAllBytes(image);
            if (owned)
            {
                forget.Image = bytes;
            }

            return bytes;
        }

        /// <summary>
        /// The image Codex made: the file asked for (clean.png for a photo), else the newest other new image in the run's
        /// folder, else the newest its tool filed under this run's own session in CODEX_HOME. All of those are surely
        /// this run's (<paramref name="owned"/>). Failing them, the newest picture its tool saved there during the run
        /// that was not there before it (<paramref name="before"/>), which is only likely to be: image runs in this app go
        /// one at a time, but Codex could be used on its own meanwhile.
        /// </summary>
        internal string FindNewImage(string workingDirectory, ICollection<string> inputs, DateTime startedUtc, IReadOnlyDictionary<string, DateTime> before,
            out bool owned, string fileName = ProductPhotoPrompt.ResultFileName)
        {
            owned = true;
            var named = Path.Combine(workingDirectory, fileName);
            if (File.Exists(named))
            {
                return named;
            }

            string Newest(IEnumerable<string> paths) => paths
                .Select(path => new FileInfo(path))
                .OrderByDescending(file => file.LastWriteTimeUtc)
                .Select(file => file.FullName)
                .FirstOrDefault();

            var inFolder = Newest(Directory.EnumerateFiles(workingDirectory)
                .Where(path => IsImage(path) && !inputs.Contains(path, StringComparer.OrdinalIgnoreCase)));
            if (inFolder != null)
            {
                return inFolder;
            }

            var generated = GeneratedImages()
                .Where(picture => picture.Value >= startedUtc.AddSeconds(-5)
                    && !(before != null && before.TryGetValue(picture.Key, out var written) && written == picture.Value))
                .Select(picture => picture.Key)
                .ToList();
            var folder = Path.Combine(CodexHome ?? "", "generated_images");
            var sessions = CodexHomeCleaner.SessionIds(CodexHome, workingDirectory, startedUtc);
            var own = Newest(generated.Where(path => sessions.Any(id => path.Substring(folder.Length).IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0)));
            if (own != null)
            {
                return own;
            }

            owned = false;
            return Newest(generated);
        }

        /// <summary>The pictures in Codex's folder (generated_images), with when each was written.</summary>
        private Dictionary<string, DateTime> GeneratedImages()
        {
            var pictures = new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);
            var folder = Path.Combine(CodexHome ?? "", "generated_images");
            try
            {
                if (Directory.Exists(folder))
                {
                    foreach (var path in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories).Where(IsImage))
                    {
                        pictures[path] = File.GetLastWriteTimeUtc(path);
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                // What was read is kept; the time each run began still limits what it may take.
            }

            return pictures;
        }

        private static bool IsImage(string path) =>
            ProductPhotoRequest.PhotoExtensions.Contains(Path.GetExtension(path).ToLowerInvariant());

        /// <summary>A usage limit, in plain words; another AI tool may still answer.</summary>
        protected override AiProviderException KnownFailure(CliResult result) =>
            CodexErrors.UsageLimitInfoIn(result.StandardError + "\n" + result.StandardOutput) is UsageLimitInfo limit
                ? new AiProviderException(Id, limit.Message, canFallback: true, usageLimit: limit)
                : null;

        /// <summary>Codex echoes the prompt before its errors, so only its error lines are searched, when it wrote any.</summary>
        protected override string ErrorText(CliResult result)
        {
            var errors = CodexErrors.Short(result.StandardError + "\n" + result.StandardOutput);
            return errors.Length > 0 ? errors : base.ErrorText(result);
        }

        /// <summary>Its error lines, each once, never the prompt it echoed; else the end of what it wrote.</summary>
        protected override string FailureDetail(CliResult result)
        {
            var errors = CodexErrors.Short(result.StandardError + "\n" + result.StandardOutput);
            return errors.Length > 0 ? errors : base.FailureDetail(result);
        }

        /// <summary>A one-time sign-in code is valid for 15 minutes; wait a little longer than that.</summary>
        public static readonly TimeSpan DeviceSignInTimeout = TimeSpan.FromMinutes(16);

        /// <summary>
        /// Signs Codex in with ChatGPT using a one-time code (<c>codex login --device-auth</c>), which anyone can do, even
        /// on a phone: <paramref name="showCode"/> gets the page to open and the code to type as soon as Codex prints them,
        /// and the task ends when the code has been entered on that page. Returns Codex's status afterwards.
        /// </summary>
        public async Task<ProviderStatus> SignInWithChatGptAsync(Action<DeviceCode> showCode, CancellationToken cancellationToken)
        {
            var executable = RequireExecutable();
            var reader = new DeviceCodeReader();
            var invocation = new CliInvocation
            {
                FileName = executable,
                WorkingDirectory = Path.GetTempPath(),
                Timeout = DeviceSignInTimeout,
                OutputLine = line =>
                {
                    if (reader.Read(line) is DeviceCode code)
                    {
                        showCode?.Invoke(code);
                    }
                },
            };
            invocation.Arguments.AddRange(new[] { "login", "--device-auth" });
            invocation.Environment["NO_COLOR"] = "1";

            var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
            if (result.TimedOut)
            {
                throw new AiProviderException(Id, "The sign-in code expired before it was entered. Start the sign-in again.", canFallback: false);
            }

            if (result.ExitCode != 0)
            {
                throw new AiProviderException(Id, "Codex could not sign in: " + Tail(result.StandardError + "\n" + result.StandardOutput, 300), canFallback: false);
            }

            return await CheckAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Stores an OpenAI API key in Codex's own sign-in (<c>codex login --with-api-key</c>).</summary>
        public async Task<string> SignInWithApiKeyAsync(string apiKey, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new AiProviderException(Id, "Enter an OpenAI API key first.", canFallback: false);
            }

            var executable = RequireExecutable();
            var result = await RunToolAsync(executable, new[] { "login", "--with-api-key" }, apiKey.Trim(), TimeSpan.FromSeconds(60), cancellationToken).ConfigureAwait(false);
            if (result.ExitCode != 0)
            {
                throw new AiProviderException(Id, "Codex could not save the API key: " + Tail(result.StandardError + result.StandardOutput), canFallback: false);
            }

            return FirstLine(result.StandardOutput) ?? "Signed in.";
        }

        /// <summary>Copies files sent with a question into the run's empty folder, named photo-1.jpg and so on, and gives
        /// the copies' paths: Codex reads only what is in its folder.</summary>
        private static List<string> CopyInto(RunWorkspace workspace, IEnumerable<string> files, string prefix)
        {
            var copies = new List<string>();
            foreach (var file in files ?? Enumerable.Empty<string>())
            {
                var copy = workspace.PathOf(prefix + "-" + (copies.Count + 1) + Path.GetExtension(file).ToLowerInvariant());
                File.Copy(file, copy);
                copies.Add(copy);
            }

            return copies;
        }

        /// <param name="readOnly">Always read-only, whatever the settings allow (e.g. for writing a listing).</param>
        internal List<string> BuildArguments(string workingDirectory, string lastMessagePath, IEnumerable<string> images = null, bool readOnly = false)
        {
            var settings = Settings().Codex;
            // Never offer danger-full-access: the assistant only needs Codex to write text.
            var sandbox = !readOnly && settings.SandboxMode == "workspace-write" ? "workspace-write" : "read-only";
            var arguments = new List<string> { "exec" };

            // Photos first: --image takes several values and the next flag ends the list, so the final "-" (the prompt
            // on standard input) is never taken for a photo.
            foreach (var image in images ?? Enumerable.Empty<string>())
            {
                arguments.Add("--image");
                arguments.Add(image);
            }

            arguments.AddRange(new[]
            {
                "--skip-git-repo-check",
                "--ephemeral",
                "--sandbox", sandbox,
                "--color", "never",
                "--cd", workingDirectory,
                "--output-last-message", lastMessagePath,
            });

            var model = CheckToken(settings.Model, "Codex model");
            if (model != null)
            {
                arguments.Add("--model");
                arguments.Add(model);
            }

            var effort = CheckToken(settings.ReasoningEffort, "Codex reasoning effort");
            if (effort != null)
            {
                arguments.Add("--config");
                arguments.Add("model_reasoning_effort=" + effort.ToLowerInvariant());
            }

            // "-" = read the prompt from standard input, which avoids command-line length and quoting limits.
            arguments.Add("-");
            return arguments;
        }

        /// <summary>
        /// Clears what an image run left in CODEX_HOME (<see cref="CodexHomeCleaner"/>) when the run ends, whether it made a
        /// picture or not; a failure to clear never fails the run.
        /// </summary>
        private sealed class ForgetRun : IDisposable
        {
            private readonly string _codexHome;
            private readonly string _folder;
            private readonly DateTime _started;

            public ForgetRun(string codexHome, string folder, DateTime started)
            {
                _codexHome = codexHome;
                _folder = folder;
                _started = started;
            }

            /// <summary>The picture the app took from the run, so Codex's copy of it goes too.</summary>
            public byte[] Image { get; set; }

            public void Dispose()
            {
                try
                {
                    CodexHomeCleaner.Clean(_codexHome, _folder, _started, Image);
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException || ex is NotSupportedException)
                {
                    // Codex's own folder is left as it is.
                }
            }
        }

        /// <summary>Starts a program that talks JSON lines; replaced by a stand-in in tests.</summary>
        internal Func<CliInvocation, IJsonLineChannel> StartChannel { get; set; } = ProcessJsonLineChannel.Start;

        /// <summary>The version this app tells Codex it is.</summary>
        internal static string AppVersion =>
            typeof(CodexCliProvider).Assembly.GetName().Version?.ToString(3) ?? "";

        /// <summary>
        /// Every conversation with the app server goes in through this gate, as a run of the runner does, so that Codex is only
        /// replaced by a newer one when nothing is talking to it. Null: no gate.
        /// </summary>
        public AiRunGate Gate { get; set; }

        /// <summary>A conversation with Codex's app server (<see cref="CodexAppServer"/>): sign-in, models, usage limits.</summary>
        public async Task<CodexAppServer> OpenAppServerAsync(CancellationToken cancellationToken)
        {
            var lease = Gate == null ? null : await Gate.EnterAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var invocation = new CliInvocation
                {
                    FileName = RequireExecutable(),
                    WorkingDirectory = System.IO.Path.GetTempPath(),
                };
                invocation.Arguments.Add("app-server");
                invocation.Environment["NO_COLOR"] = "1";
                var server = await CodexAppServer.StartAsync(StartChannel(invocation), AppVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                server.Attach(lease);
                return server;
            }
            catch
            {
                lease?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Signed in or not, as Codex itself says (its app server), which also names the ChatGPT plan. An older Codex
        /// without the app server is asked with <c>codex login status</c>, whose exit code is what counts: it may
        /// print warnings first.
        /// </summary>
        protected override async Task<ProviderStatus> CheckReadinessAsync(string executable, string version, CancellationToken cancellationToken)
        {
            try
            {
                using (var server = await OpenAppServerAsync(cancellationToken).ConfigureAwait(false))
                {
                    var signIn = await server.GetSignInAsync(cancellationToken).ConfigureAwait(false);
                    if (signIn.SignedIn)
                    {
                        return ProviderStatus.Ready(signIn.Describe(), version);
                    }
                }
            }
            catch (Exception ex) when (ex is CodexAppServerException || ex is CliStartException || ex is System.IO.IOException || ex is InvalidOperationException)
            {
                // An older Codex: ask the way it understands.
            }

            var result = await RunToolAsync(executable, new[] { "login", "status" }, null, TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);
            return result.ExitCode == 0 && !result.TimedOut
                ? ProviderStatus.Ready(SignedInLine(result.StandardOutput + "\n" + result.StandardError), version)
                : ProviderStatus.NotReady("Installed but not signed in. Run \"codex login\" in a terminal, or sign in with an API key in Settings.", version);
        }

        /// <summary>The line of <c>codex login status</c> that says how Codex is signed in, skipping warnings.</summary>
        internal static string SignedInLine(string output) =>
            (output ?? "").Split('\n').Select(line => line.Trim())
                .FirstOrDefault(line => line.StartsWith("Logged in", StringComparison.OrdinalIgnoreCase))
            ?? "Signed in.";
    }
}
