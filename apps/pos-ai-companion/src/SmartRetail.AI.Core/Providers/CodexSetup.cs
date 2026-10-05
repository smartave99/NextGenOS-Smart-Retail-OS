using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;

namespace SmartRetail.AI.Providers
{
    /// <summary>The page to open and the one-time code to type there, to sign Codex in with ChatGPT.</summary>
    public sealed class DeviceCode
    {
        public DeviceCode(string url, string code)
        {
            Url = url;
            Code = code;
        }

        public string Url { get; }

        public string Code { get; }
    }

    /// <summary>
    /// Picks the sign-in page and the one-time code out of <c>codex login --device-auth</c>'s output, line by line, e.g.
    /// "https://auth.openai.com/codex/device" and "WRB5-1KWS7". Only pages on OpenAI's own sites are accepted.
    /// </summary>
    public sealed class DeviceCodeReader
    {
        private static readonly Regex Colours = new Regex(@"\x1B\[[0-9;]*[A-Za-z]", RegexOptions.Compiled);
        private static readonly Regex Link = new Regex(@"https://[^\s""'<>]+", RegexOptions.Compiled);
        private static readonly Regex OneTimeCode = new Regex(@"^\s*([A-Z0-9]{3,8}(?:-[A-Z0-9]{3,8})+)\s*$", RegexOptions.Compiled);
        private static readonly string[] OpenAiHosts = { "openai.com", "chatgpt.com" };

        private string _url;
        private string _code;
        private bool _done;

        /// <summary>The page and the code, once, as soon as both have been printed; otherwise null.</summary>
        public DeviceCode Read(string line)
        {
            if (_done || line == null)
            {
                return null;
            }

            var text = Colours.Replace(line, "");
            var link = Link.Match(text);
            if (link.Success)
            {
                var url = link.Value.TrimEnd('.', ',', ')');
                if (Uri.TryCreate(url, UriKind.Absolute, out var uri)
                    && OpenAiHosts.Any(host => uri.Host.Equals(host, StringComparison.OrdinalIgnoreCase) || uri.Host.EndsWith("." + host, StringComparison.OrdinalIgnoreCase)))
                {
                    _url = url;
                }
            }
            else if (OneTimeCode.Match(text) is Match code && code.Success)
            {
                _code = code.Groups[1].Value;
            }

            if (_url == null || _code == null)
            {
                return null;
            }

            _done = true;
            return new DeviceCode(_url, _code);
        }
    }

    /// <summary>
    /// Installs Codex CLI on Windows with OpenAI's official installer, which needs no Node.js: it downloads the latest
    /// release, checks its SHA-256 and puts codex.exe in %LOCALAPPDATA%\Programs\OpenAI\Codex\bin, adding that folder to
    /// the user's PATH. It runs as the signed-in Windows user, so Codex and its sign-in belong to that user.
    /// </summary>
    public sealed class CodexInstaller
    {
        public const string ScriptUrl = "https://chatgpt.com/codex/install.ps1";

        public static readonly TimeSpan InstallTimeout = TimeSpan.FromMinutes(10);

        private readonly ICliRunner _runner;
        private readonly bool _windows;

        public CodexInstaller(ICliRunner runner)
            : this(runner, Path.DirectorySeparatorChar == '\\')
        {
        }

        internal CodexInstaller(ICliRunner runner, bool windows)
        {
            _runner = runner ?? throw new ArgumentNullException(nameof(runner));
            _windows = windows;
        }

        /// <summary>Installing works on Windows, where the shop PC is.</summary>
        public bool CanInstall => _windows;

        /// <summary>The folder the official installer puts codex.exe in.</summary>
        public static string InstallFolder => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs", "OpenAI", "Codex", "bin");

        /// <summary>Downloads and runs the official installer for the newest Codex. <paramref name="progress"/> gets each line it prints.</summary>
        public Task InstallAsync(Action<string> progress, CancellationToken cancellationToken) =>
            InstallAsync("", progress, cancellationToken);

        /// <summary>
        /// Downloads and runs the official installer: for the newest Codex when <paramref name="release"/> is empty, or for that
        /// version, e.g. "0.158.0" (the installer keeps every release it installed, so going back to one is quick).
        /// </summary>
        public async Task InstallAsync(string release, Action<string> progress, CancellationToken cancellationToken)
        {
            var pinned = ReleaseArgument(release);
            if (!_windows)
            {
                throw new PlatformNotSupportedException("Installing Codex automatically works on Windows only.");
            }

            var script = Path.Combine(Path.GetTempPath(), "codex-install-" + Guid.NewGuid().ToString("N") + ".ps1");
            try
            {
                var result = await _runner.RunAsync(CreateInvocation(script, progress, pinned), cancellationToken).ConfigureAwait(false);
                if (result.TimedOut)
                {
                    throw new InvalidOperationException("Installing Codex took too long. Check the internet connection, then try again.");
                }

                if (result.ExitCode != 0)
                {
                    var output = (result.StandardError + "\n" + result.StandardOutput).Trim();
                    throw new InvalidOperationException("Codex could not be installed: "
                        + (output.Length <= 400 ? output : "…" + output.Substring(output.Length - 400)));
                }
            }
            catch (CliStartException ex)
            {
                throw new InvalidOperationException("Windows PowerShell could not be started to install Codex: " + ex.Message, ex);
            }
            finally
            {
                try
                {
                    File.Delete(script);
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // A leftover copy of the installer in the temp folder does no harm.
                }
            }
        }

        /// <summary>A version as it goes into CODEX_RELEASE: empty (the newest) or three numbers such as "0.158.0", never anything else.</summary>
        internal static string ReleaseArgument(string release)
        {
            var value = (release ?? "").Trim();
            if (value.Length > 0 && !System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-9]{1,4}\.[0-9]{1,4}\.[0-9]{1,4}$"))
            {
                throw new ArgumentException("That is not a Codex version: " + (value.Length <= 20 ? value : value.Substring(0, 20) + "…"), nameof(release));
            }

            return value;
        }

        internal static CliInvocation CreateInvocation(string script, Action<string> progress) =>
            CreateInvocation(script, progress, "");

        internal static CliInvocation CreateInvocation(string script, Action<string> progress, string release)
        {
            var quoted = "'" + script.Replace("'", "''") + "'";
            var invocation = new CliInvocation
            {
                FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "WindowsPowerShell", "v1.0", "powershell.exe"),
                WorkingDirectory = Path.GetTempPath(),
                Timeout = InstallTimeout,
                OutputLine = line =>
                {
                    var text = (line ?? "").Trim();
                    if (text.Length > 0)
                    {
                        progress?.Invoke(text);
                    }
                },
            };
            invocation.Arguments.AddRange(new[]
            {
                "-NoProfile", "-NonInteractive", "-ExecutionPolicy", "Bypass", "-Command",
                "$ProgressPreference = 'SilentlyContinue'; Invoke-RestMethod -UseBasicParsing -Uri '" + ScriptUrl + "' -OutFile " + quoted + "; & " + quoted,
            });
            // The installer asks nothing and changes nothing but its own folder and the user's PATH.
            invocation.Environment["CODEX_NON_INTERACTIVE"] = "1";

            // The newest release unless a version is asked for; a CODEX_RELEASE left set on this PC never decides it.
            invocation.Environment["CODEX_RELEASE"] = release ?? "";
            return invocation;
        }
    }
}
