using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// The Codex on this PC for <see cref="CodexUpdater"/>: its version, its own help, whether it is signed in, and OpenAI's
    /// installer. It runs Codex through a runner that is <b>not</b> behind <see cref="AiRunGate"/>: the updater has closed the gate
    /// while it looks at the new Codex, and its questions must not wait for it.
    /// </summary>
    public sealed class CodexTool : ICodexTool
    {
        private static readonly TimeSpan AskTimeout = TimeSpan.FromSeconds(30);

        private readonly Func<AssistantSettings> _settings;
        private readonly ICliRunner _runner;
        private readonly CodexInstaller _installer;
        private readonly string _installFolder;

        public CodexTool(Func<AssistantSettings> settings, ICliRunner runner, CodexInstaller installer, string installFolder = null)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _runner = runner ?? throw new ArgumentNullException(nameof(runner));
            _installer = installer ?? throw new ArgumentNullException(nameof(installer));
            _installFolder = installFolder ?? CodexInstaller.InstallFolder;
        }

        /// <summary>Where the Codex this app runs is, as the provider finds it; null when there is none.</summary>
        public string ExecutablePath() =>
            ExecutableLocator.Resolve(_settings().Codex.ExecutablePath, "codex", ExecutableLocator.CommonUserToolDirectories());

        public bool IsInstallerManaged()
        {
            var executable = ExecutablePath();
            if (executable == null)
            {
                return false;
            }

            try
            {
                return string.Equals(
                    Path.GetFullPath(Path.GetDirectoryName(executable)).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                    Path.GetFullPath(_installFolder).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                    StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException)
            {
                return false;
            }
        }

        public async Task<string> VersionAsync(CancellationToken cancellationToken)
        {
            var executable = ExecutablePath();
            if (executable == null)
            {
                return null;
            }

            var result = await AskAsync(executable, new[] { "--version" }, cancellationToken).ConfigureAwait(false);
            return result == null ? "" : (result.StandardOutput + "\n" + result.StandardError).Trim();
        }

        public async Task<CodexHelp> HelpAsync(CancellationToken cancellationToken)
        {
            var executable = ExecutablePath();
            if (executable == null)
            {
                return new CodexHelp("", "", "");
            }

            return new CodexHelp(
                await HelpTextAsync(executable, new[] { "--help" }, cancellationToken).ConfigureAwait(false),
                await HelpTextAsync(executable, new[] { "exec", "--help" }, cancellationToken).ConfigureAwait(false),
                await HelpTextAsync(executable, new[] { "login", "--help" }, cancellationToken).ConfigureAwait(false));
        }

        public async Task<bool?> SignedInAsync(CancellationToken cancellationToken)
        {
            var executable = ExecutablePath();
            if (executable == null)
            {
                return null;
            }

            try
            {
                var result = await RunAsync(executable, new[] { "login", "status" }, cancellationToken).ConfigureAwait(false);
                return result.ExitCode == 0 && !result.TimedOut;
            }
            catch (Exception ex) when (ex is CliStartException || ex is ArgumentException)
            {
                return null;
            }
        }

        public Task InstallAsync(string release, Action<string> progress, CancellationToken cancellationToken) =>
            _installer.InstallAsync(release, progress, cancellationToken);

        private async Task<string> HelpTextAsync(string executable, string[] arguments, CancellationToken cancellationToken)
        {
            var result = await AskAsync(executable, arguments, cancellationToken).ConfigureAwait(false);
            return result == null ? "" : (string.IsNullOrWhiteSpace(result.StandardOutput) ? result.StandardError : result.StandardOutput);
        }

        /// <summary>What Codex printed when it answered well; null when it did not start, did not answer in time or failed.</summary>
        private async Task<CliResult> AskAsync(string executable, string[] arguments, CancellationToken cancellationToken)
        {
            try
            {
                var result = await RunAsync(executable, arguments, cancellationToken).ConfigureAwait(false);
                return result.ExitCode == 0 && !result.TimedOut ? result : null;
            }
            catch (Exception ex) when (ex is CliStartException || ex is ArgumentException)
            {
                return null;
            }
        }

        private Task<CliResult> RunAsync(string executable, string[] arguments, CancellationToken cancellationToken)
        {
            var invocation = new CliInvocation
            {
                FileName = executable,
                Timeout = AskTimeout,
                WorkingDirectory = Path.GetTempPath(),
            };
            invocation.Arguments.AddRange(arguments);
            invocation.Environment["NO_COLOR"] = "1";
            return _runner.RunAsync(invocation, cancellationToken);
        }
    }
}
