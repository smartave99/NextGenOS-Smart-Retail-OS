using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SmartRetail.AI.Settings
{
    public sealed class SettingsStore
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            // Without Replace, lists initialised with defaults get the saved items appended.
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            Formatting = Formatting.Indented,
        };

        private readonly string _profileFolder;

        /// <param name="profileFolder">Where the customer's AI profile (ai.json) is looked for: this folder, and the one above it. Default: the program's own folder.</param>
        public SettingsStore(string filePath, string profileFolder = null)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _profileFolder = profileFolder ?? AppContext.BaseDirectory;
        }

        public string FilePath { get; }

        public static string DefaultFilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Branding.Company,
            Branding.AppFolderName,
            "settings.json");

        /// <summary>Loads settings; a missing file gives defaults, a corrupt one is kept aside as .bad.</summary>
        public AssistantSettings Load()
        {
            AssistantSettings settings = null;
            if (File.Exists(FilePath))
            {
                try
                {
                    settings = JsonConvert.DeserializeObject<AssistantSettings>(File.ReadAllText(FilePath, Encoding.UTF8), JsonSettings);
                }
                catch (JsonException)
                {
                    File.Copy(FilePath, FilePath + ".bad", overwrite: true);
                }
            }

            settings = settings ?? new AssistantSettings();
            settings.Normalize();
            // The customer's picture settings come from its profile, never from this file: the owner's settings cannot change them.
            settings.Shop = ShopProfile.LoadNear(_profileFolder);
            return settings;
        }

        public void Save(AssistantSettings settings)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            var temp = FilePath + ".tmp";
            File.WriteAllText(temp, JsonConvert.SerializeObject(settings, JsonSettings), new UTF8Encoding(false));
            if (File.Exists(FilePath))
            {
                File.Replace(temp, FilePath, null);
            }
            else
            {
                File.Move(temp, FilePath);
            }
        }

        /// <summary>Deep copy, so a settings dialog can be cancelled without side effects.</summary>
        public static AssistantSettings Clone(AssistantSettings settings)
        {
            var copy = JsonConvert.DeserializeObject<AssistantSettings>(JsonConvert.SerializeObject(settings, JsonSettings), JsonSettings);
            copy.Normalize();
            return copy;
        }
    }
}
