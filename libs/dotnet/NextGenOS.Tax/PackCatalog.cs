using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace NextGenOS.Tax
{
    /// <summary>The packs built into this library (one per country), found by two-letter country code.</summary>
    public static class PackCatalog
    {
        private const string Prefix = "NextGenOS.Tax.packs.";
        private static readonly object Gate = new object();
        private static Dictionary<string, CountryPack> _packs;

        public static IReadOnlyList<CountryPack> All()
        {
            return Load().Values.OrderBy(p => p.Name, StringComparer.Ordinal).ToList();
        }

        /// <summary>The pack of a country, or null when there is none.</summary>
        public static CountryPack Find(string country)
        {
            if (string.IsNullOrEmpty(country)) return null;
            CountryPack pack;
            return Load().TryGetValue(country.Trim().ToUpperInvariant(), out pack) ? pack : null;
        }

        /// <summary>The pack of a country; throws a plain message when there is none.</summary>
        public static CountryPack Get(string country)
        {
            var pack = Find(country);
            if (pack == null) throw new ArgumentException("There is no country pack for \"" + country + "\". Add one with: node country-packs/tools/cli.mjs new " + country);
            return pack;
        }

        public static CountryPack Parse(string json)
        {
            return JsonConvert.DeserializeObject<CountryPack>(json);
        }

        private static Dictionary<string, CountryPack> Load()
        {
            lock (Gate)
            {
                if (_packs != null) return _packs;
                var packs = new Dictionary<string, CountryPack>(StringComparer.Ordinal);
                var assembly = typeof(PackCatalog).Assembly;
                foreach (var name in assembly.GetManifestResourceNames().Where(n => n.StartsWith(Prefix, StringComparison.Ordinal) && n.EndsWith(".json", StringComparison.Ordinal)))
                {
                    using (var stream = assembly.GetManifestResourceStream(name))
                    using (var reader = new StreamReader(stream))
                    {
                        var pack = Parse(reader.ReadToEnd());
                        packs[pack.Country] = pack;
                    }
                }
                _packs = packs;
                return _packs;
            }
        }
    }
}
