using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Desktop
{
    /// <summary>What <see cref="SmokeTest"/> found.</summary>
    internal sealed class SmokeReport
    {
        public string WebView2 { get; set; } = "";

        public bool Dashboard { get; set; }

        /// <summary>The app window showed Today.</summary>
        public bool Today { get; set; }

        public string Title { get; set; } = "";

        /// <summary>The side panel showed its page with the question box.</summary>
        public bool Panel { get; set; }

        /// <summary>A page's message reached the app.</summary>
        public bool Bridge { get; set; }

        /// <summary>The app window showed Ask AI.</summary>
        public bool Ask { get; set; }

        /// <summary>The app window showed Posters.</summary>
        public bool Posters { get; set; }

        /// <summary>The app window showed a barcode sticker, and the panel its barcode finder.</summary>
        public bool Barcodes { get; set; }

        /// <summary>The app window showed the Fix now page with the checks' result.</summary>
        public bool FixNow { get; set; }

        /// <summary>The app window showed the Memory page.</summary>
        public bool Memory { get; set; }

        /// <summary>The app window showed the Actions page.</summary>
        public bool Actions { get; set; }

        /// <summary>The app window's Settings listed every AI job, and a job's model and thinking level opened.</summary>
        public bool Jobs { get; set; }

        /// <summary>The app window's Settings showed the Start with Windows switch (a row only the Windows app shows).</summary>
        public bool Startup { get; set; }

        /// <summary>The page's top bar took the place of the Windows title bar.</summary>
        public bool TopBar { get; set; }

        /// <summary>Dragging the top bar moved the window.</summary>
        public bool Moves { get; set; }

        /// <summary>How far the drag moved the window, e.g. "120,80".</summary>
        public string MovedBy { get; set; } = "";

        /// <summary>A double click on the top bar, and its maximise button, maximised the window and brought it back.</summary>
        public bool Maximises { get; set; }

        public string Error { get; set; }

        [JsonIgnore]
        public bool Passed => WebView2.Length > 0 && Dashboard && Today && Panel && Bridge && Ask && Posters && Barcodes && FixNow && Memory && Actions && Jobs && Startup && TopBar && Moves && Maximises && Error == null;
    }

    /// <summary>
    /// SmartRetailAI.exe --smoke-test report.json: opens the app window and the side panel on this PC, checks that
    /// their pages load and can talk to the app, writes what it found and exits (0 when all is well). The build
    /// runs it on Windows, where WebView2 can be checked for real.
    /// </summary>
    internal sealed class SmokeTest
    {
        public const string Argument = "--smoke-test";

        private SmokeTest(string reportPath)
        {
            ReportPath = reportPath;
        }

        public string ReportPath { get; }

        public int ExitCode { get; private set; } = 1;

        public static SmokeTest FromArguments(string[] args)
        {
            var index = Array.FindIndex(args, a => string.Equals(a, Argument, StringComparison.OrdinalIgnoreCase));
            if (index < 0)
            {
                return null;
            }

            var path = index + 1 < args.Length ? args[index + 1] : Path.Combine(Path.GetTempPath(), "smart-retail-smoke-test.json");
            return new SmokeTest(Path.GetFullPath(path));
        }

        public void Finish(SmokeReport report)
        {
            ExitCode = report.Passed ? 0 : 1;
            var json = JsonConvert.SerializeObject(new { passed = report.Passed, report }, Formatting.Indented);
            File.WriteAllText(ReportPath, json, new UTF8Encoding(false));
        }

        public void Fail(string why) => Finish(new SmokeReport { Error = why });

        /// <summary>The task's result, or false when it takes longer than <paramref name="limit"/>.</summary>
        public static async Task<bool> Within(Task<bool> task, TimeSpan limit)
        {
            var first = await Task.WhenAny(task, Task.Delay(limit));
            return first == task && task.Result;
        }
    }
}

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// The smoke test's check of the app window's own top bar: it stands in for the Windows title bar, dragging it moves
    /// the window, and a double click or its maximise button maximises the window and brings it back. The mouse is
    /// moved for real, from another thread, as the window's own move loop runs on this one. With SMOKE_SHOTS set,
    /// pictures of the window go to that folder.
    /// </summary>
    internal static class TopBarCheck
    {
        private const int DragX = 120;
        private const int DragY = 80;

        // An empty part of the bar, in the page's pixels: where the page itself is under the pointer.
        private const string EmptySpotScript = @"(() => {
            const bar = document.querySelector('.window-bar');
            if (!bar) return '';
            const r = bar.getBoundingClientRect(), y = r.top + r.height / 2;
            let best = null, run = null;
            for (let x = r.left + 2; x < r.right - 2; x += 4) {
                const empty = document.elementFromPoint(x, y) === bar;
                if (empty) { run = run || { from: x, to: x }; run.to = x; }
                if ((!empty || x + 4 >= r.right - 2) && run) { if (!best || run.to - run.from > best.to - best.from) best = run; run = null; }
            }
            return best ? JSON.stringify({ x: Math.round((best.from + best.to) / 2), y: Math.round(y) }) : '';
        })()";

        public static async Task RunAsync(AppWindow window, SmokeReport report, Func<string, Task<bool>> waitFor)
        {
            window.WindowState = FormWindowState.Normal;
            window.Activate();
            report.TopBar = await waitFor("document.documentElement.getAttribute('data-frame') === 'app' && getComputedStyle(document.querySelector('.window-bar')).display === 'grid'")
                && await Until(() => window.HasOwnTitleBar, TimeSpan.FromSeconds(30))
                && CaptionHeight(window) <= 1;
            Shoot(window, "app-window");
            if (!report.TopBar)
            {
                return;
            }

            var before = window.Location;
            var spot = await EmptySpotAsync(window);
            await Task.Run(() => Drag(spot, DragX, DragY));
            await Task.Delay(500);
            var moved = new Point(window.Location.X - before.X, window.Location.Y - before.Y);
            report.MovedBy = moved.X + "," + moved.Y;
            report.Moves = Math.Abs(moved.X - DragX) <= 4 && Math.Abs(moved.Y - DragY) <= 4;

            spot = await EmptySpotAsync(window);
            await Task.Run(() => DoubleClick(spot));
            var byDoubleClick = await Until(() => window.IsMaximized, TimeSpan.FromSeconds(5));
            await Task.Delay(500);
            Shoot(window, "app-window-maximised");
            spot = await EmptySpotAsync(window);
            await Task.Run(() => DoubleClick(spot));
            var backByDoubleClick = await Until(() => !window.IsMaximized, TimeSpan.FromSeconds(5));

            await window.RunScriptAsync("document.querySelector('[data-window=maximize]').click()");
            var byButton = await Until(() => window.IsMaximized, TimeSpan.FromSeconds(5))
                && await waitFor("document.documentElement.getAttribute('data-window-state') === 'maximized'");
            await window.RunScriptAsync("document.querySelector('[data-window=maximize]').click()");
            var backByButton = await Until(() => !window.IsMaximized, TimeSpan.FromSeconds(5));
            report.Maximises = byDoubleClick && backByDoubleClick && byButton && backByButton;
        }

        /// <summary>How far the page starts below the window's top: 0 without the Windows title bar.</summary>
        private static int CaptionHeight(Form window)
        {
            NativeMethods.GetWindowRect(window.Handle, out var bounds);
            return window.PointToScreen(Point.Empty).Y - bounds.Top;
        }

        private static async Task<Point> EmptySpotAsync(AppWindow window)
        {
            var json = await window.RunScriptAsync(EmptySpotScript);
            var text = json == null ? "" : (string)JToken.Parse(json) ?? "";
            if (text.Length == 0)
            {
                throw new InvalidOperationException("The top bar has no empty part to drag.");
            }

            var spot = JObject.Parse(text);
            return window.PageToScreen((double)spot["x"], (double)spot["y"]);
        }

        private static void Drag(Point from, int dx, int dy)
        {
            NativeMethods.SetCursorPos(from.X, from.Y);
            Thread.Sleep(200);
            NativeMethods.mouse_event(NativeMethods.MouseLeftDown, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(200);
            for (var step = 1; step <= 12; step++)
            {
                NativeMethods.SetCursorPos(from.X + dx * step / 12, from.Y + dy * step / 12);
                Thread.Sleep(40);
            }

            Thread.Sleep(200);
            NativeMethods.mouse_event(NativeMethods.MouseLeftUp, 0, 0, 0, IntPtr.Zero);
        }

        private static void DoubleClick(Point at)
        {
            NativeMethods.SetCursorPos(at.X, at.Y);
            Thread.Sleep(200);
            for (var click = 0; click < 2; click++)
            {
                NativeMethods.mouse_event(NativeMethods.MouseLeftDown, 0, 0, 0, IntPtr.Zero);
                NativeMethods.mouse_event(NativeMethods.MouseLeftUp, 0, 0, 0, IntPtr.Zero);
                Thread.Sleep(80);
            }
        }

        private static async Task<bool> Until(Func<bool> condition, TimeSpan limit)
        {
            var until = DateTime.UtcNow + limit;
            while (!condition())
            {
                if (DateTime.UtcNow > until)
                {
                    return false;
                }

                await Task.Delay(100);
            }

            return true;
        }

        /// <summary>A picture of the window and a little around it, into SMOKE_SHOTS when set.</summary>
        private static void Shoot(Form window, string name)
        {
            var folder = Environment.GetEnvironmentVariable("SMOKE_SHOTS");
            if (string.IsNullOrEmpty(folder))
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(folder);
                NativeMethods.GetWindowRect(window.Handle, out var bounds);
                var area = Rectangle.Intersect(
                    Rectangle.FromLTRB(bounds.Left - 16, bounds.Top - 16, bounds.Right + 16, bounds.Bottom + 16),
                    SystemInformation.VirtualScreen);
                using (var picture = new Bitmap(area.Width, area.Height))
                using (var graphics = Graphics.FromImage(picture))
                {
                    graphics.CopyFromScreen(area.Location, Point.Empty, area.Size);
                    picture.Save(Path.Combine(folder, name + ".png"), ImageFormat.Png);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is ExternalException || ex is ArgumentException)
            {
                AppLog.Error("A smoke test picture", ex);
            }
        }
    }
}
