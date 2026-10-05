using System;
using System.IO;
using System.Text;

namespace SmartRetail.AI.Cli
{
    /// <summary>An empty folder per request, so an agent CLI has no project files to read or change.
    /// Deleted when disposed.</summary>
    public sealed class RunWorkspace : IDisposable
    {
        private static readonly Encoding Utf8 = new UTF8Encoding(false);

        public RunWorkspace(string root = null)
        {
            var baseDirectory = string.IsNullOrWhiteSpace(root) ? DefaultRoot : root;
            DirectoryPath = Path.Combine(baseDirectory, DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + "-" + Guid.NewGuid().ToString("N").Substring(0, 8));
            Directory.CreateDirectory(DirectoryPath);
        }

        public static string DefaultRoot => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Branding.Company,
            Branding.AppFolderName,
            "runs");

        public string DirectoryPath { get; }

        public string PathOf(string fileName) => Path.Combine(DirectoryPath, fileName);

        public string WriteFile(string fileName, string content)
        {
            var path = PathOf(fileName);
            File.WriteAllText(path, content ?? "", Utf8);
            return path;
        }

        public string ReadFileOrNull(string fileName)
        {
            var path = PathOf(fileName);
            return File.Exists(path) ? File.ReadAllText(path, Encoding.UTF8) : null;
        }

        public void Dispose()
        {
            try
            {
                Directory.Delete(DirectoryPath, recursive: true);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
