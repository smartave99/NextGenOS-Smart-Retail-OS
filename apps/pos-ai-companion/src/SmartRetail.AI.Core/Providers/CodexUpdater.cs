using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartRetail.AI.Cli;

namespace SmartRetail.AI.Providers
{
    /// <summary>What the app remembers about keeping Codex up to date (codex-update.json, beside the settings).</summary>
    public sealed class CodexUpdateState
    {
        /// <summary>Update Codex by itself when a newer one is out. The owner can turn it off.</summary>
        public bool Automatic { get; set; } = true;

        /// <summary>A newer Codex that was tried and did not fit this app, e.g. "0.159.0": it is not tried again, a newer one is.</summary>
        public string SkippedVersion { get; set; } = "";

        public DateTime? CheckedAt { get; set; }

        /// <summary>The newest release this PC has seen, and when it first saw it: a new release settles for a day before it is installed by itself.</summary>
        public string SeenVersion { get; set; } = "";

        public DateTime? SeenAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        /// <summary>The version the last update went to, and the one it replaced.</summary>
        public string UpdatedTo { get; set; } = "";

        public string UpdatedFrom { get; set; } = "";

        /// <summary>Why the last try did not work, in words for the owner; empty when it went well.</summary>
        public string Problem { get; set; } = "";

        /// <summary>Nothing missing, whatever a file edited by hand said.</summary>
        public CodexUpdateState Normalize()
        {
            SkippedVersion = SkippedVersion ?? "";
            SeenVersion = SeenVersion ?? "";
            UpdatedTo = UpdatedTo ?? "";
            UpdatedFrom = UpdatedFrom ?? "";
            Problem = Problem ?? "";
            return this;
        }
    }

    /// <summary>
    /// Reads and writes <see cref="CodexUpdateState"/>; a damaged file is kept as .bad and the app starts again from the defaults.
    /// The owner's switch and the updater both change the file, and an update takes minutes: a change is always read, made and
    /// written inside one lock (<see cref="Update"/>), so one never puts back what the other's older copy had.
    /// </summary>
    public sealed class CodexUpdateFile
    {
        public const string FileName = "codex-update.json";

        private readonly object _lock = new object();
        private readonly string _path;

        public CodexUpdateFile(string folder)
        {
            _path = Path.Combine(folder ?? throw new ArgumentNullException(nameof(folder)), FileName);
        }

        public string FilePath => _path;

        public CodexUpdateState Load()
        {
            lock (_lock)
            {
                return LoadFile();
            }
        }

        public void Save(CodexUpdateState state)
        {
            lock (_lock)
            {
                SaveFile(state);
            }
        }

        /// <summary>Changes what is in the file now, and returns it as it is after the change.</summary>
        public CodexUpdateState Update(Action<CodexUpdateState> change)
        {
            lock (_lock)
            {
                var state = LoadFile();
                change(state);
                SaveFile(state);
                return state;
            }
        }

        private CodexUpdateState LoadFile()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    return new CodexUpdateState();
                }

                try
                {
                    return (JsonConvert.DeserializeObject<CodexUpdateState>(File.ReadAllText(_path, Encoding.UTF8)) ?? new CodexUpdateState()).Normalize();
                }
                catch (JsonException)
                {
                    File.Copy(_path, _path + ".bad", overwrite: true);
                    return new CodexUpdateState();
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return new CodexUpdateState();
            }
        }

        private void SaveFile(CodexUpdateState state)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_path));
            var temporary = _path + ".tmp";
            File.WriteAllText(temporary, JsonConvert.SerializeObject(state, Formatting.Indented), new UTF8Encoding(false));
            if (File.Exists(_path))
            {
                File.Replace(temporary, _path, null);
            }
            else
            {
                File.Move(temporary, _path);
            }
        }
    }

    /// <summary>The Codex on this PC, as the updater needs it.</summary>
    public interface ICodexTool
    {
        /// <summary>What <c>codex --version</c> prints; null when Codex is not installed.</summary>
        Task<string> VersionAsync(CancellationToken cancellationToken);

        Task<CodexHelp> HelpAsync(CancellationToken cancellationToken);

        /// <summary>Whether Codex is signed in (<c>codex login status</c>); null when it could not be asked.</summary>
        Task<bool?> SignedInAsync(CancellationToken cancellationToken);

        /// <summary>
        /// True when this Codex is the one OpenAI's installer keeps, so running the installer again replaces it. A Codex that came
        /// another way (npm, say) is not changed by the installer, and is updated the way it was installed.
        /// </summary>
        bool IsInstallerManaged();

        /// <summary>Runs OpenAI's installer: for the newest Codex when <paramref name="release"/> is empty, else for that version (going back).</summary>
        Task InstallAsync(string release, Action<string> progress, CancellationToken cancellationToken);
    }

    /// <summary>Where the newest Codex is found.</summary>
    public interface ICodexReleases
    {
        /// <summary>The newest stable release; null when it could not be found out.</summary>
        Task<Version> LatestAsync(CancellationToken cancellationToken);
    }

    public enum CodexUpdateOutcome
    {
        /// <summary>Codex is not installed: Get started installs it.</summary>
        NotInstalled,

        UpToDate,

        /// <summary>A newer Codex is out and has not been installed.</summary>
        Available,

        /// <summary>A newer Codex is out, but an earlier try showed it does not fit this app.</summary>
        Skipped,

        /// <summary>A newer Codex came out less than a day ago: it is installed by itself once it has settled, or when the owner asks.</summary>
        Settling,

        /// <summary>A newer Codex is out, but this Codex was not put here by OpenAI's installer, so it is updated the way it was installed.</summary>
        Manual,

        Updated,

        /// <summary>The newer Codex lacked something this app needs, so the one that worked was put back.</summary>
        RolledBack,

        /// <summary>An AI task was running; the update did not start.</summary>
        Waiting,

        Failed,

        /// <summary>The version, or the newest release, could not be found out.</summary>
        Unknown,
    }

    public sealed class CodexUpdateResult
    {
        public CodexUpdateOutcome Outcome { get; set; }

        /// <summary>The version on this PC, e.g. "0.158.0"; empty when unknown.</summary>
        public string Installed { get; set; } = "";

        /// <summary>After an update: the version it replaced.</summary>
        public string Previous { get; set; } = "";

        /// <summary>The newest release; empty when unknown.</summary>
        public string Latest { get; set; } = "";

        /// <summary>One or two sentences for the owner.</summary>
        public string Message { get; set; } = "";
    }

    /// <summary>
    /// Keeps Codex up to date. Codex only looks for a newer version in its own terminal screen, which this app never opens
    /// (it runs Codex in the background), so nothing else would ever update it. The updater compares the installed version with
    /// the newest release. A new release is left to settle for a day (<see cref="Settle"/>), since a release that turns out bad is
    /// usually replaced within hours. To update, it waits for a moment when no AI task is running (<see cref="AiRunGate"/>), runs
    /// OpenAI's own installer, and checks that the new Codex still has every part of the command line this app uses
    /// (<see cref="CodexCompatibility"/>) and is still signed in; if not, the version that worked is put back and the newer one is
    /// skipped, so an update can never leave the shop without a working AI tool. Pure logic, tested with stand-ins.
    /// </summary>
    public sealed class CodexUpdater
    {
        /// <summary>How long a new release is left alone before it is installed by itself; the owner can install it at once.</summary>
        public static readonly TimeSpan Settle = TimeSpan.FromHours(24);

        private readonly ICodexTool _tool;
        private readonly ICodexReleases _releases;
        private readonly AiRunGate _gate;
        private readonly CodexUpdateFile _file;
        private readonly Func<DateTime> _now;

        public CodexUpdater(ICodexTool tool, ICodexReleases releases, AiRunGate gate, CodexUpdateFile file, Func<DateTime> now)
        {
            _tool = tool ?? throw new ArgumentNullException(nameof(tool));
            _releases = releases ?? throw new ArgumentNullException(nameof(releases));
            _gate = gate ?? throw new ArgumentNullException(nameof(gate));
            _file = file ?? throw new ArgumentNullException(nameof(file));
            _now = now ?? (() => DateTime.Now);
        }

        /// <summary>The remembered state: whether to update by itself, and what happened last.</summary>
        public CodexUpdateState State => _file.Load();

        public void SetAutomatic(bool automatic) => _file.Update(state => state.Automatic = automatic);

        /// <summary>Looks at what is installed and what is newest; changes nothing on the PC.</summary>
        public async Task<CodexUpdateResult> CheckAsync(CancellationToken cancellationToken)
        {
            var printed = await _tool.VersionAsync(cancellationToken).ConfigureAwait(false);
            if (printed == null)
            {
                return new CodexUpdateResult { Outcome = CodexUpdateOutcome.NotInstalled, Message = "Codex is not installed yet." };
            }

            var installed = CodexVersions.Installed(printed, out _);
            var latest = await _releases.LatestAsync(cancellationToken).ConfigureAwait(false);
            var now = _now();
            var state = _file.Update(kept =>
            {
                kept.CheckedAt = now;
                if (latest != null && kept.SeenVersion != CodexVersions.ForInstaller(latest))
                {
                    kept.SeenVersion = CodexVersions.ForInstaller(latest);
                    kept.SeenAt = now;
                }
            });

            var result = new CodexUpdateResult { Installed = CodexVersions.ForInstaller(installed), Latest = CodexVersions.ForInstaller(latest) };
            if (installed == null)
            {
                result.Outcome = CodexUpdateOutcome.Unknown;
                result.Message = "Codex's version could not be read.";
            }
            else if (latest == null)
            {
                result.Outcome = CodexUpdateOutcome.Unknown;
                result.Message = "OpenAI could not be asked which Codex is the newest now. It is tried again later.";
            }
            else if (!CodexVersions.IsNewer(latest, printed))
            {
                result.Outcome = CodexUpdateOutcome.UpToDate;
                result.Message = "Codex " + result.Installed + " is the newest.";
            }
            else if (!_tool.IsInstallerManaged())
            {
                result.Outcome = CodexUpdateOutcome.Manual;
                result.Message = "Codex " + result.Latest + " is out; this PC has " + result.Installed + ". This Codex was not put here by OpenAI's installer, so it is updated the way it was installed (for example with npm).";
            }
            else if (state.SkippedVersion == result.Latest)
            {
                result.Outcome = CodexUpdateOutcome.Skipped;
                result.Message = "Codex " + result.Latest + " was tried and did not fit this app, so Codex " + result.Installed + " stays until a newer one comes.";
            }
            else
            {
                result.Outcome = CodexUpdateOutcome.Available;
                result.Message = "Codex " + result.Latest + " is out; this PC has " + result.Installed + ".";
            }

            return result;
        }

        /// <summary>
        /// Updates Codex when a newer one is out and no AI task is running: the result says what happened. When the owner asked
        /// (<paramref name="ownerAsked"/>), a release that is only a few hours old is installed too, and so is a newer one that
        /// an earlier try showed does not fit; by itself the updater does neither. <paramref name="replacing"/> is called when the
        /// replacing really begins (the gate is closed), and not when there is nothing to install or a task is running.
        /// </summary>
        public async Task<CodexUpdateResult> UpdateAsync(bool ownerAsked, Action<string> progress, CancellationToken cancellationToken, Action replacing = null)
        {
            var check = await CheckAsync(cancellationToken).ConfigureAwait(false);
            if (check.Outcome != CodexUpdateOutcome.Available && !(ownerAsked && check.Outcome == CodexUpdateOutcome.Skipped))
            {
                return check;
            }

            if (!ownerAsked && !HasSettled(check.Latest))
            {
                check.Outcome = CodexUpdateOutcome.Settling;
                check.Message = "Codex " + check.Latest + " came out a short while ago. It is installed by itself after a day, or now if you choose Update now.";
                return check;
            }

            var before = await _tool.HelpAsync(cancellationToken).ConfigureAwait(false);
            if (CodexCompatibility.Visible(before).Count == 0)
            {
                // Without what the working Codex says about itself there is nothing to compare the newer one with.
                return Failed(check, "Codex did not show its own help, so it could not be checked that a newer Codex still fits this app. Codex " + check.Installed + " stays.");
            }

            var wasSignedIn = await _tool.SignedInAsync(cancellationToken).ConfigureAwait(false) == true;
            if (!_gate.TryClose())
            {
                check.Outcome = CodexUpdateOutcome.Waiting;
                check.Message = "An AI task is running, so Codex is updated when it is done.";
                return check;
            }

            try
            {
                replacing?.Invoke();
                return await ReplaceAsync(check, before, wasSignedIn, progress, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _gate.Open();
            }
        }

        private bool HasSettled(string latest)
        {
            var state = _file.Load();
            return state.SeenVersion == latest && state.SeenAt.HasValue && _now() - state.SeenAt.Value >= Settle;
        }

        private async Task<CodexUpdateResult> ReplaceAsync(CodexUpdateResult check, CodexHelp before, bool wasSignedIn, Action<string> progress, CancellationToken cancellationToken)
        {
            try
            {
                await _tool.InstallAsync("", progress, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                return Failed(check, "Codex could not be updated, so " + check.Installed + " stays: " + Short(ex.Message));
            }

            var after = CodexVersions.Installed(await _tool.VersionAsync(cancellationToken).ConfigureAwait(false), out _);
            if (after == null || after < Version.Parse(check.Latest))
            {
                return Failed(check, "The installer ran, but Codex is still " + (after == null ? "not answering" : after.ToString(3)) + ".");
            }

            var lost = CodexCompatibility.Lost(before, await _tool.HelpAsync(cancellationToken).ConfigureAwait(false));
            var signInLost = wasSignedIn && await _tool.SignedInAsync(cancellationToken).ConfigureAwait(false) != true;
            if (lost.Count == 0 && !signInLost)
            {
                var at = _now();
                _file.Update(state =>
                {
                    state.UpdatedAt = at;
                    state.UpdatedTo = check.Latest;
                    state.UpdatedFrom = check.Installed;
                    state.SkippedVersion = "";
                    state.Problem = "";
                });
                check.Previous = check.Installed;
                check.Installed = check.Latest;
                check.Outcome = CodexUpdateOutcome.Updated;
                check.Message = "Codex was updated to " + check.Latest + ".";
                return check;
            }

            // The newer Codex lacks what this app uses, or lost the sign-in: the one that worked goes back, and this one is skipped.
            var reason = "Codex " + check.Latest
                + (lost.Count > 0 ? " no longer has " + string.Join(", ", lost) + ", which this app needs" : "")
                + (signInLost ? (lost.Count > 0 ? ", and" : "") + " is not signed in any more" : "");
            try
            {
                await _tool.InstallAsync(check.Installed, progress, cancellationToken).ConfigureAwait(false);
                var back = CodexVersions.Installed(await _tool.VersionAsync(cancellationToken).ConfigureAwait(false), out _);
                if (back == null || CodexVersions.ForInstaller(back) != check.Installed)
                {
                    return Failed(check, reason + ", and Codex " + check.Installed + " could not be put back: it says " + (back == null ? "nothing" : back.ToString(3)) + ".");
                }
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                return Failed(check, reason + ", and Codex " + check.Installed + " could not be put back: " + Short(ex.Message));
            }

            if (signInLost && await _tool.SignedInAsync(cancellationToken).ConfigureAwait(false) != true)
            {
                return Failed(check, reason + ", and Codex " + check.Installed + " is not signed in either after it was put back: sign in again on the Get started page.", skip: check.Latest);
            }

            var problem = reason + ", so Codex " + check.Installed + " was put back. A newer Codex is tried when it comes out.";
            _file.Update(state =>
            {
                state.SkippedVersion = check.Latest;
                state.Problem = problem;
            });
            check.Outcome = CodexUpdateOutcome.RolledBack;
            check.Message = problem;
            return check;
        }

        /// <summary>The try did not work: what to tell the owner is kept, and with <paramref name="skip"/> that version is not tried again.</summary>
        private CodexUpdateResult Failed(CodexUpdateResult check, string problem, string skip = null)
        {
            _file.Update(state =>
            {
                state.Problem = problem;
                if (skip != null)
                {
                    state.SkippedVersion = skip;
                }
            });
            check.Outcome = CodexUpdateOutcome.Failed;
            check.Message = problem;
            return check;
        }

        private static string Short(string text)
        {
            var one = (text ?? "").Replace('\r', ' ').Replace('\n', ' ').Trim();
            return one.Length <= 300 ? one : one.Substring(0, 299) + "…";
        }
    }
}
