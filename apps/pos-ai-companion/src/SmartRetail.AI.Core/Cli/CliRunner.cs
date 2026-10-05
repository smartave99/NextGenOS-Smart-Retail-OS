using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Cli
{
    public sealed class CliInvocation
    {
        public string FileName { get; set; } = "";

        public List<string> Arguments { get; } = new List<string>();

        /// <summary>Written to the tool's standard input as UTF-8, then the stream is closed.</summary>
        public string StandardInput { get; set; }

        public string WorkingDirectory { get; set; }

        /// <summary>Variables to set for the child process; a null value removes the variable.</summary>
        public Dictionary<string, string> Environment { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(3);

        /// <summary>Called with each line the tool writes (standard output and error) as soon as it writes it. Optional:
        /// for tools that print something to act on while they keep running, such as a sign-in code.</summary>
        public Action<string> OutputLine { get; set; }

        /// <summary>Called with each line of standard output only, as soon as the tool writes it: for an answer that is
        /// printed while it is written. Optional.</summary>
        public Action<string> StandardOutputLine { get; set; }
    }

    public sealed class CliResult
    {
        public int ExitCode { get; set; }

        public string StandardOutput { get; set; } = "";

        public string StandardError { get; set; } = "";

        public bool TimedOut { get; set; }

        public TimeSpan Duration { get; set; }
    }

    public interface ICliRunner
    {
        Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken);
    }

    public sealed class CliStartException : Exception
    {
        public CliStartException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public sealed class ProcessCliRunner : ICliRunner
    {
        private static readonly Encoding Utf8 = new UTF8Encoding(false);

        // A tool can leave a helper process holding its output pipe open; don't wait on it forever.
        private static readonly TimeSpan OutputDrainTimeout = TimeSpan.FromSeconds(5);

        public async Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken)
        {
            if (invocation == null)
            {
                throw new ArgumentNullException(nameof(invocation));
            }

            var startInfo = CreateStartInfo(invocation);
            using (var process = new Process { StartInfo = startInfo, EnableRaisingEvents = true })
            {
                var exited = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                process.Exited += (sender, args) => exited.TrySetResult(true);

                var stopwatch = Stopwatch.StartNew();
                try
                {
                    process.Start();
                }
                catch (Win32Exception ex)
                {
                    throw new CliStartException("Could not start " + invocation.FileName + ": " + ex.Message, ex);
                }

                var stdout = ReadAllAsync(process.StandardOutput, Both(invocation.OutputLine, invocation.StandardOutputLine));
                var stderr = ReadAllAsync(process.StandardError, invocation.OutputLine);
                await WriteInputAsync(process, invocation.StandardInput).ConfigureAwait(false);

                var timedOut = false;
                using (var wait = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    var delay = Task.Delay(invocation.Timeout, wait.Token);
                    var first = await Task.WhenAny(exited.Task, delay).ConfigureAwait(false);
                    if (first != exited.Task)
                    {
                        timedOut = !cancellationToken.IsCancellationRequested;
                        KillProcessTree(process);
                        await Task.WhenAny(exited.Task, Task.Delay(OutputDrainTimeout)).ConfigureAwait(false);
                    }

                    wait.Cancel();
                }

                var result = new CliResult
                {
                    ExitCode = process.HasExited ? process.ExitCode : -1,
                    StandardOutput = await DrainAsync(stdout).ConfigureAwait(false),
                    StandardError = await DrainAsync(stderr).ConfigureAwait(false),
                    TimedOut = timedOut,
                    Duration = stopwatch.Elapsed,
                };

                cancellationToken.ThrowIfCancellationRequested();
                return result;
            }
        }

        private static Action<string> Both(Action<string> first, Action<string> second) =>
            first == null ? second : second == null ? first : line =>
            {
                first(line);
                second(line);
            };

        private static async Task<string> ReadAllAsync(StreamReader reader, Action<string> outputLine)
        {
            if (outputLine == null)
            {
                return await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            var all = new StringBuilder();
            string line;
            while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                all.AppendLine(line);
                try
                {
                    outputLine(line);
                }
                catch (Exception)
                {
                    // Whoever listens must not stop the output being read, or the tool would block on a full pipe.
                }
            }

            return all.ToString();
        }

        internal static bool IsBatchFile(string path)
        {
            return (path ?? "").EndsWith(".cmd", StringComparison.OrdinalIgnoreCase)
                || (path ?? "").EndsWith(".bat", StringComparison.OrdinalIgnoreCase);
        }

        internal static ProcessStartInfo CreateStartInfo(CliInvocation invocation)
        {
            var info = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Utf8,
                StandardErrorEncoding = Utf8,
                WorkingDirectory = invocation.WorkingDirectory ?? "",
            };

            if (IsBatchFile(invocation.FileName))
            {
                // npm installs Windows launchers as .cmd files, which only cmd.exe can run.
                foreach (var argument in invocation.Arguments)
                {
                    if (!CommandLine.IsSafeForBatchFile(argument))
                    {
                        throw new ArgumentException("This value cannot be passed safely to a .cmd launcher: " + argument);
                    }
                }

                var inner = CommandLine.QuoteAlways(invocation.FileName) + " "
                    + string.Join(" ", invocation.Arguments.Select(CommandLine.QuoteAlways));
                info.FileName = System.Environment.GetEnvironmentVariable("ComSpec") ?? "cmd.exe";
                info.Arguments = "/d /s /c \"" + inner + "\"";
            }
            else
            {
                info.FileName = invocation.FileName;
#if NET
                foreach (var argument in invocation.Arguments)
                {
                    info.ArgumentList.Add(argument);
                }
#else
                info.Arguments = CommandLine.Join(invocation.Arguments);
#endif
            }

            foreach (var pair in invocation.Environment)
            {
                if (pair.Value == null)
                {
                    info.Environment.Remove(pair.Key);
                }
                else
                {
                    info.Environment[pair.Key] = pair.Value;
                }
            }

            return info;
        }

        private static async Task WriteInputAsync(Process process, string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    var bytes = Utf8.GetBytes(input);
                    var stream = process.StandardInput.BaseStream;
                    await stream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
                    await stream.FlushAsync().ConfigureAwait(false);
                }

                process.StandardInput.Close();
            }
            catch (IOException)
            {
                // The tool exited without reading its input; its exit code tells the story.
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private static async Task<string> DrainAsync(Task<string> read)
        {
            var first = await Task.WhenAny(read, Task.Delay(OutputDrainTimeout)).ConfigureAwait(false);
            return first == read && read.Status == TaskStatus.RanToCompletion ? read.Result : "";
        }

        internal static void KillProcessTree(Process process)
        {
            try
            {
                if (process.HasExited)
                {
                    return;
                }
#if NET
                process.Kill(entireProcessTree: true);
#else
                var taskkill = new ProcessStartInfo("taskkill", "/PID " + process.Id + " /T /F")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                using (var killer = Process.Start(taskkill))
                {
                    killer?.WaitForExit(5000);
                }

                if (!process.HasExited)
                {
                    process.Kill();
                }
#endif
            }
            catch (InvalidOperationException)
            {
            }
            catch (Win32Exception)
            {
            }
        }
    }
}
