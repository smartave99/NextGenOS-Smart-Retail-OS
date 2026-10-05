using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Cli
{
    /// <summary>A program that talks in lines of JSON over its standard input and output, kept open between messages.</summary>
    public interface IJsonLineChannel : IDisposable
    {
        Task WriteLineAsync(string line);

        /// <summary>The next line, or null when the program has closed its output.</summary>
        Task<string> ReadLineAsync();
    }

    /// <summary>
    /// Runs a program and keeps its standard input open, for conversations such as Codex's app server (which stops as
    /// soon as its input closes). Started the same way as <see cref="ProcessCliRunner"/>, so .cmd launchers work.
    /// Disposing it stops the program and anything it started.
    /// </summary>
    public sealed class ProcessJsonLineChannel : IJsonLineChannel
    {
        private static readonly Encoding Utf8 = new UTF8Encoding(false);
        private readonly Process _process;
        private readonly Stream _input;
        private int _disposed;

        private ProcessJsonLineChannel(Process process)
        {
            _process = process;
            _input = process.StandardInput.BaseStream;

            // Error output is read and dropped, so a chatty program never blocks on a full pipe.
            _ = process.StandardError.ReadToEndAsync();
        }

        public static IJsonLineChannel Start(CliInvocation invocation)
        {
            if (invocation == null)
            {
                throw new ArgumentNullException(nameof(invocation));
            }

            var process = new Process { StartInfo = ProcessCliRunner.CreateStartInfo(invocation) };
            try
            {
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                process.Dispose();
                throw new CliStartException("Could not start " + invocation.FileName + ": " + ex.Message, ex);
            }

            return new ProcessJsonLineChannel(process);
        }

        public async Task WriteLineAsync(string line)
        {
            var bytes = Utf8.GetBytes(line + "\n");
            await _input.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            await _input.FlushAsync().ConfigureAwait(false);
        }

        public Task<string> ReadLineAsync() => _process.StandardOutput.ReadLineAsync();

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1)
            {
                return;
            }

            try
            {
                _input.Dispose();
            }
            catch (IOException)
            {
            }

            ProcessCliRunner.KillProcessTree(_process);
            _process.Dispose();
        }
    }
}
