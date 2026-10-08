using System.Collections.Concurrent;

namespace NextGenOS.Hub.Web.Diagnostics;

/// <summary>
/// Remembers, in memory only, the last warnings and errors the program logged since it started, so that the Help button's support file can say what went wrong lately. It keeps the words as
/// they were logged; they are cleaned of anything personal when a support file is made (<see cref="NextGenOS.Hub.Diagnostics.SupportRedaction"/>), and nothing is ever written to disk or sent.
/// </summary>
public sealed class TroubleLog : ILoggerProvider
{
    public const int Capacity = 200;

    public sealed record Entry(DateTimeOffset At, LogLevel Level, string Category, string Message, string? ExceptionType, string? ExceptionMessage, IReadOnlyList<string> Where);

    private readonly ConcurrentQueue<Entry> _entries = new();

    public ILogger CreateLogger(string categoryName) => new Writer(this, categoryName);

    public void Dispose() { }

    /// <summary>The newest entries, newest first.</summary>
    public IReadOnlyList<Entry> Recent(int count = 30) => _entries.Reverse().Take(Math.Clamp(count, 1, Capacity)).ToList();

    internal void Add(Entry entry)
    {
        _entries.Enqueue(entry);
        while (_entries.Count > Capacity && _entries.TryDequeue(out _)) { }
    }

    private sealed class Writer(TroubleLog owner, string category) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Warning;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            string message;
            try { message = formatter(state, exception); }
            catch (Exception) { message = "(the message could not be written)"; }
            owner.Add(new Entry(DateTimeOffset.UtcNow, logLevel, category, message, exception?.GetType().Name, exception?.Message, Frames(exception)));
        }

        /// <summary>The names of the first few places in the program the error passed through (class and method only: no file, no folder, no values).</summary>
        private static IReadOnlyList<string> Frames(Exception? e)
        {
            if (e?.StackTrace is not { } trace) return [];
            return trace.Split('\n').Select(line => line.Trim()).Where(line => line.StartsWith("at ", StringComparison.Ordinal))
                .Select(line => line[3..]).Select(line => line.Contains('(') ? line[..line.IndexOf('(')] : line).Take(4).ToList();
        }
    }
}
