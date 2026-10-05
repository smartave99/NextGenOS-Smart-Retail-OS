using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Cli
{
    /// <summary>Runs programs through another runner and tells <c>observe</c> how each run went, e.g. that Codex answered.</summary>
    public sealed class ObservingCliRunner : ICliRunner
    {
        private readonly ICliRunner _inner;
        private readonly Action<CliInvocation, CliResult> _observe;

        public ObservingCliRunner(ICliRunner inner, Action<CliInvocation, CliResult> observe)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _observe = observe ?? throw new ArgumentNullException(nameof(observe));
        }

        public async Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken)
        {
            var result = await _inner.RunAsync(invocation, cancellationToken).ConfigureAwait(false);
            try
            {
                _observe(invocation, result);
            }
            catch (Exception)
            {
                // Watching must never change how a run went.
            }

            return result;
        }

        /// <summary>True for a Codex task (<c>codex exec</c>) that finished well: Codex is installed and signed in.</summary>
        public static bool IsCodexAnswer(CliInvocation invocation, CliResult result) =>
            invocation != null && result != null && result.ExitCode == 0 && !result.TimedOut
            && string.Equals(ProgramName(invocation.FileName), "codex", StringComparison.OrdinalIgnoreCase)
            && invocation.Arguments.Count > 0 && invocation.Arguments[0] == "exec";

        /// <summary>"codex" for C:\...\codex.exe, codex.cmd or /usr/local/bin/codex, whatever the machine's separator.</summary>
        private static string ProgramName(string path)
        {
            var name = path ?? "";
            name = name.Substring(Math.Max(name.LastIndexOf('/'), name.LastIndexOf('\\')) + 1);
            var dot = name.LastIndexOf('.');
            return dot > 0 ? name.Substring(0, dot) : name;
        }
    }
}
