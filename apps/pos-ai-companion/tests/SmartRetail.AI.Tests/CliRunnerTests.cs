using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class CommandLineTests
    {
        [Theory]
        [InlineData("simple", "simple")]
        [InlineData("", "\"\"")]
        [InlineData("two words", "\"two words\"")]
        [InlineData("say \"hi\"", "\"say \\\"hi\\\"\"")]
        [InlineData(@"C:\path with space\", "\"C:\\path with space\\\\\"")]
        [InlineData(@"C:\no\spaces\", @"C:\no\spaces\")]
        public void Quote_follows_the_windows_rules(string input, string expected)
        {
            Assert.Equal(expected, CommandLine.Quote(input));
        }

        [Fact]
        public void Split_keeps_quoted_parts_together()
        {
            Assert.Equal(new[] { "run", "my model", "--x", "" }, CommandLine.Split("run \"my model\"  --x \"\""));
            Assert.Empty(CommandLine.Split("   "));
        }

        [Fact]
        public void Cmd_launchers_are_run_through_cmd_with_every_argument_quoted()
        {
            var invocation = new CliInvocation { FileName = @"C:\Users\shop\AppData\Roaming\npm\codex.cmd" };
            invocation.Arguments.AddRange(new[] { "exec", "--cd", @"C:\Users\shop\runs\a b", "-" });

            var info = ProcessCliRunner.CreateStartInfo(invocation);

            Assert.EndsWith("cmd.exe", info.FileName, StringComparison.OrdinalIgnoreCase);
            Assert.Equal("/d /s /c \"\"C:\\Users\\shop\\AppData\\Roaming\\npm\\codex.cmd\" \"exec\" \"--cd\" \"C:\\Users\\shop\\runs\\a b\" \"-\"\"", info.Arguments);
        }

        [Theory]
        [InlineData("100%")]
        [InlineData("wow!")]
        [InlineData("a\"b")]
        [InlineData("line\nbreak")]
        public void Cmd_launchers_refuse_arguments_cmd_would_reinterpret(string argument)
        {
            var invocation = new CliInvocation { FileName = "tool.cmd" };
            invocation.Arguments.Add(argument);
            Assert.Throws<ArgumentException>(() => ProcessCliRunner.CreateStartInfo(invocation));
        }
    }

    /// <summary>Runs real processes; uses POSIX tools, so these checks run on Linux/macOS (the CI host).</summary>
    public class ProcessCliRunnerTests
    {
        private static bool IsWindows => OperatingSystem.IsWindows();

        [Fact]
        public async Task Round_trips_utf8_through_stdin_and_stdout()
        {
            if (IsWindows)
            {
                return;
            }

            var invocation = new CliInvocation { FileName = "/bin/cat", StandardInput = "नमस्ते ₹1,25,000 — ok" };
            var result = await new ProcessCliRunner().RunAsync(invocation, CancellationToken.None);

            Assert.Equal(0, result.ExitCode);
            Assert.Equal("नमस्ते ₹1,25,000 — ok", result.StandardOutput);
        }

        [Fact]
        public async Task Reports_the_exit_code_and_stderr()
        {
            if (IsWindows)
            {
                return;
            }

            var invocation = new CliInvocation { FileName = "/bin/sh" };
            invocation.Arguments.AddRange(new[] { "-c", "echo oops >&2; exit 3" });
            var result = await new ProcessCliRunner().RunAsync(invocation, CancellationToken.None);

            Assert.Equal(3, result.ExitCode);
            Assert.Equal("oops", result.StandardError.Trim());
            Assert.False(result.TimedOut);
        }

        [Fact]
        public async Task Kills_a_process_that_runs_past_its_timeout()
        {
            if (IsWindows)
            {
                return;
            }

            var invocation = new CliInvocation { FileName = "/bin/sleep", Timeout = TimeSpan.FromSeconds(1) };
            invocation.Arguments.Add("30");
            var stopwatch = Stopwatch.StartNew();
            var result = await new ProcessCliRunner().RunAsync(invocation, CancellationToken.None);

            Assert.True(result.TimedOut);
            Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(15), "should not wait for the full sleep");
        }

        [Fact]
        public async Task Cancellation_stops_the_process_and_throws()
        {
            if (IsWindows)
            {
                return;
            }

            var invocation = new CliInvocation { FileName = "/bin/sleep", Timeout = TimeSpan.FromMinutes(1) };
            invocation.Arguments.Add("30");
            using (var cancel = new CancellationTokenSource(TimeSpan.FromMilliseconds(300)))
            {
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => new ProcessCliRunner().RunAsync(invocation, cancel.Token));
            }
        }

        [Fact]
        public async Task Sets_and_removes_environment_variables()
        {
            if (IsWindows)
            {
                return;
            }

            var invocation = new CliInvocation { FileName = "/bin/sh" };
            invocation.Arguments.AddRange(new[] { "-c", "printf '%s|%s' \"$SR_TEST_KEY\" \"${HOME-unset}\"" });
            invocation.Environment["SR_TEST_KEY"] = "secret-value";
            invocation.Environment["HOME"] = null;
            var result = await new ProcessCliRunner().RunAsync(invocation, CancellationToken.None);

            Assert.Equal("secret-value|unset", result.StandardOutput);
        }

        [Fact]
        public async Task A_missing_program_raises_a_start_error()
        {
            var invocation = new CliInvocation { FileName = "/definitely/not/here/tool" };
            await Assert.ThrowsAsync<CliStartException>(() => new ProcessCliRunner().RunAsync(invocation, CancellationToken.None));
        }
    }
}
