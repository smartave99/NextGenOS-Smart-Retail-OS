using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Tests
{
    internal sealed class FakeCliRunner : ICliRunner
    {
        public List<CliInvocation> Calls { get; } = new List<CliInvocation>();

        public Func<CliInvocation, CliResult> Handler { get; set; } = _ => new CliResult();

        public Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken)
        {
            Calls.Add(invocation);
            return Task.FromResult(Handler(invocation));
        }

        public static string ArgumentAfter(CliInvocation invocation, string flag)
        {
            var index = invocation.Arguments.IndexOf(flag);
            return index >= 0 && index + 1 < invocation.Arguments.Count ? invocation.Arguments[index + 1] : null;
        }
    }

    internal sealed class FakeProvider : IAiProvider, IReadsAttachments
    {
        private readonly Queue<Func<AiRequest, string>> _answers = new Queue<Func<AiRequest, string>>();

        public FakeProvider(string id, bool ready = true)
        {
            Id = id;
            Ready = ready;
        }

        public string Id { get; }

        public string DisplayName => "Fake " + Id;

        public ProviderKind Kind => ProviderKind.Api;

        public bool Ready { get; set; }

        /// <summary>Whether it can be given photos and voice notes.</summary>
        public bool ReadsAttachments { get; set; } = true;

        public string CannotRead(AiRequest request) => ReadsAttachments ? null : "it cannot read photos or voice notes";

        public Exception Failure { get; set; }

        public List<AiRequest> Requests { get; } = new List<AiRequest>();

        public FakeProvider Answers(params string[] answers)
        {
            foreach (var answer in answers)
            {
                _answers.Enqueue(_ => answer);
            }

            return this;
        }

        public Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Ready ? ProviderStatus.Ready("ready") : ProviderStatus.NotReady("not ready"));
        }

        public Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            Requests.Add(request);
            if (Failure != null)
            {
                throw Failure;
            }

            var answer = _answers.Count > 0 ? _answers.Dequeue()(request) : "ok";
            return Task.FromResult(new AiResponse(Id, answer, TimeSpan.FromMilliseconds(5)));
        }
    }

    internal sealed class FakeQueryExecutor : IQueryExecutor
    {
        public List<string> Queries { get; } = new List<string>();

        public Func<string, QueryResult> Handler { get; set; } = _ => Table(new[] { "x" });

        public Task<QueryResult> QueryAsync(string sql, IReadOnlyDictionary<string, object> parameters, int maxRows, CancellationToken cancellationToken)
        {
            Queries.Add(sql);
            return Task.FromResult(Handler(sql));
        }

        public static QueryResult Table(string[] columns, params object[][] rows)
        {
            return new QueryResult(columns, rows.ToList(), truncated: false, duration: TimeSpan.FromMilliseconds(3));
        }
    }

    internal sealed class StubHttpHandler : HttpMessageHandler
    {
        private readonly Queue<Func<HttpRequestMessage, HttpResponseMessage>> _responses = new Queue<Func<HttpRequestMessage, HttpResponseMessage>>();

        public List<(HttpRequestMessage Request, string Body)> Requests { get; } = new List<(HttpRequestMessage, string)>();

        public StubHttpHandler Respond(HttpStatusCode status, string json, Action<HttpResponseMessage> customize = null)
        {
            _responses.Enqueue(_ =>
            {
                var response = new HttpResponseMessage(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };
                customize?.Invoke(response);
                return response;
            });
            return this;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var body = request.Content == null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
            Requests.Add((request, body));
            return _responses.Dequeue()(request);
        }
    }

    /// <summary>Reversible stand-in for DPAPI, which only exists on Windows.</summary>
    internal sealed class FakeProtector : ISecretProtector
    {
        public string Protect(string plainText) => "enc:" + Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        public string Unprotect(string protectedValue)
        {
            if (!protectedValue.StartsWith("enc:", StringComparison.Ordinal))
            {
                throw new System.Security.Cryptography.CryptographicException("not ours");
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(protectedValue.Substring(4)));
        }
    }

    /// <summary>
    /// The checked-out repository the tests run in: the folder that holds SmartRetailSuite.sln (the monorepo) or, in the older
    /// layout of the two separate products, .github/workflows/installer.yml.
    /// </summary>
    internal static class Repository
    {
        public static string Root()
        {
            for (var folder = new DirectoryInfo(AppContext.BaseDirectory); folder != null; folder = folder.Parent)
            {
                if (File.Exists(System.IO.Path.Combine(folder.FullName, "SmartRetailSuite.sln"))
                    || File.Exists(System.IO.Path.Combine(folder.FullName, ".github", "workflows", "installer.yml")))
                {
                    return folder.FullName;
                }
            }

            throw new DirectoryNotFoundException("The repository was not found above " + AppContext.BaseDirectory);
        }

        private static string Product(string oldName, string newPath)
        {
            var old = System.IO.Path.Combine(Root(), oldName);
            return Directory.Exists(old) ? old : System.IO.Path.Combine(Root(), newPath);
        }

        /// <summary>The AI add-on's folder (SmartRetailAI, or apps/pos-ai-companion).</summary>
        public static string Ai() => Product("SmartRetailAI", System.IO.Path.Combine("apps", "pos-ai-companion"));

        /// <summary>The dashboard's folder (SmartRetailPOS, or apps/pos-dashboard-service).</summary>
        public static string Dashboard() => Product("SmartRetailPOS", System.IO.Path.Combine("apps", "pos-dashboard-service"));
    }

    /// <summary>A temporary folder deleted after the test.</summary>
    internal sealed class TempFolder : IDisposable
    {
        public TempFolder()
        {
            Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sr-ai-tests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(Path);
        }

        public string Path { get; }

        public string File(string name, string content = "")
        {
            var path = System.IO.Path.Combine(Path, name);
            System.IO.File.WriteAllText(path, content);
            return path;
        }

        public void Dispose()
        {
            try
            {
                Directory.Delete(Path, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    internal static class TestSettings
    {
        public static (AssistantSettings Settings, SecretStore Secrets) Create()
        {
            var settings = new AssistantSettings();
            settings.Normalize();
            return (settings, new SecretStore(() => settings, new FakeProtector()));
        }
    }
}
