using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SmartRetail.AI.Storage
{
    /// <summary>Where the add-on keeps its data: product photos and descriptions, and growth plans.</summary>
    public sealed class StorageSettings
    {
        /// <summary>The folder the owner chose; empty for the default in the Windows user's local app data.</summary>
        public string DataFolder { get; set; } = "";
    }

    /// <summary>The data folder and its parts. Settings and saved keys are not in it: they stay in the user's own folders.</summary>
    public static class DataFolders
    {
        public const string ProductsFolderName = "Product photos";
        public const string PlansFolderName = "Growth plans";
        public const string PostersFolderName = "Posters";
        public const string ChecksFolderName = "Shop checks";
        public const string MemoryFolderName = "Memory";

        public const string CreativesFolderName = "Creatives";
        public const string PriceChecksFolderName = "Price checks";

        /// <summary>The parts of the data folder, in the order they are moved.</summary>
        public static readonly IReadOnlyList<string> Parts = new[] { ProductsFolderName, PlansFolderName, PostersFolderName, ChecksFolderName, MemoryFolderName, CreativesFolderName, PriceChecksFolderName };

        /// <summary>"Product photos, Growth plans, Posters, Shop checks, Memory, Creatives and Price checks".</summary>
        public static string PartNames => string.Join(", ", Parts.Take(Parts.Count - 1)) + " and " + Parts[Parts.Count - 1];

        public static string Default => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Branding.Company,
            Branding.AppFolderName);

        public static string Resolve(StorageSettings settings) =>
            string.IsNullOrWhiteSpace(settings?.DataFolder) ? Default : Path.GetFullPath(settings.DataFolder.Trim());

        public static string Products(string dataFolder) => Path.Combine(dataFolder, ProductsFolderName);

        public static string Plans(string dataFolder) => Path.Combine(dataFolder, PlansFolderName);

        public static string Posters(string dataFolder) => Path.Combine(dataFolder, PostersFolderName);

        /// <summary>The Fix now page's notes: findings the owner marked as on purpose.</summary>
        public static string Checks(string dataFolder) => Path.Combine(dataFolder, ChecksFolderName);

        /// <summary>The assistant's memory: what it learned about the shop and the owner, and the shop's actions.</summary>
        public static string Memory(string dataFolder) => Path.Combine(dataFolder, MemoryFolderName);

        /// <summary>The creatives made in the Creatives studio, a folder each, and the shop's brand.</summary>
        public static string Creatives(string dataFolder) => Path.Combine(dataFolder, CreativesFolderName);

        /// <summary>The online prices found for the shop's products, and which pages the owner confirmed.</summary>
        public static string PriceChecks(string dataFolder) => Path.Combine(dataFolder, PriceChecksFolderName);

        /// <summary>A folder name to suggest on a drive the owner picks, e.g. D:\Smart Retail POS AI.</summary>
        public static string SuggestedOn(string driveRoot) => Path.Combine(driveRoot ?? "", Branding.AppFolderName);

        /// <summary>True when the folder holds any of the add-on's data.</summary>
        public static bool HasData(string dataFolder) =>
            Parts.Any(part => Directory.Exists(Path.Combine(dataFolder, part))
                && Directory.EnumerateFileSystemEntries(Path.Combine(dataFolder, part)).Any());

        /// <summary>The files and bytes of the add-on's data in the folder.</summary>
        public static (int Files, long Bytes) Size(string dataFolder, string part = null)
        {
            var files = 0;
            long bytes = 0;
            foreach (var name in part == null ? Parts : new[] { part })
            {
                var folder = Path.Combine(dataFolder, name);
                if (!Directory.Exists(folder))
                {
                    continue;
                }

                foreach (var file in new DirectoryInfo(folder).EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    files++;
                    bytes += file.Length;
                }
            }

            return (files, bytes);
        }
    }

    /// <summary>Keeps <see cref="StorageSettings"/> in storage.json, beside the side panel's settings file.</summary>
    public sealed class StorageSettingsStore
    {
        public const string FileName = "storage.json";

        public StorageSettingsStore(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        /// <summary>The storage file beside a settings file.</summary>
        public static StorageSettingsStore Beside(string settingsFile) =>
            new StorageSettingsStore(Path.Combine(Path.GetDirectoryName(Path.GetFullPath(settingsFile)) ?? "", FileName));

        public StorageSettings Load()
        {
            try
            {
                return File.Exists(FilePath)
                    ? JsonConvert.DeserializeObject<StorageSettings>(File.ReadAllText(FilePath, Encoding.UTF8)) ?? new StorageSettings()
                    : new StorageSettings();
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException || ex is UnauthorizedAccessException)
            {
                return new StorageSettings();
            }
        }

        public void Save(StorageSettings settings)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(FilePath)) ?? ".");
            var temp = FilePath + ".tmp";
            File.WriteAllText(temp, JsonConvert.SerializeObject(settings ?? new StorageSettings(), Formatting.Indented), new UTF8Encoding(false));
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            File.Move(temp, FilePath);
        }
    }
}
