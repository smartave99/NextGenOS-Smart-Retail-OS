using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The software is open source under the MIT License, and what it is built from keeps its own licences. The licence and the
    /// notices travel with every copy (the package and so the setup), the files they point to are there, and a library cannot join
    /// a shipped project without its notice.
    /// </summary>
    public sealed class LicenceTests
    {
        private static string Read(params string[] path) => File.ReadAllText(Path.Combine(new[] { Repository.Root() }.Concat(path).ToArray()));

        [Fact]
        public void The_software_is_under_the_MIT_License_held_by_NextGen_OS()
        {
            var licence = Read("LICENSE");

            Assert.StartsWith("MIT License", licence);
            Assert.Matches(@"(?m)^Copyright \(c\) 20\d\d NextGen OS\r?$", licence);
            Assert.Contains("Permission is hereby granted, free of charge", licence);
            Assert.Contains("THE SOFTWARE IS PROVIDED \"AS IS\"", licence);
        }

        [Fact]
        public void Every_library_a_shipped_project_names_has_its_notice()
        {
            var root = Repository.Root();
            var notices = Read("THIRD-PARTY-NOTICES.md");
            var missing = new List<string>();
            foreach (var project in new[] { "SmartRetailAI", "SmartRetailPOS" }
                         .SelectMany(product => Directory.GetFiles(Path.Combine(root, product, "src"), "*.csproj", SearchOption.AllDirectories)))
            {
                foreach (Match reference in Regex.Matches(File.ReadAllText(project), "<PackageReference Include=\"([^\"]+)\""))
                {
                    var id = reference.Groups[1].Value;

                    // The Linux natives are for the tests on Linux; the dashboard that ships is published for Windows only.
                    if (id.Contains(".NativeAssets.Linux", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (!notices.Contains(id, StringComparison.Ordinal))
                    {
                        missing.Add(id + " (" + Path.GetFileName(project) + ")");
                    }
                }
            }

            Assert.True(missing.Count == 0, "Name these, with their licence, in THIRD-PARTY-NOTICES.md: " + string.Join(", ", missing));
        }

        [Fact]
        public void The_licence_files_the_notices_point_to_are_there_and_whole()
        {
            var root = Repository.Root();
            var notices = Read("THIRD-PARTY-NOTICES.md");

            Assert.Contains("licenses/Apache-2.0.txt", notices);
            var apache = Read("licenses", "Apache-2.0.txt");
            Assert.Contains("Apache License", apache);
            Assert.Contains("Version 2.0, January 2004", apache);
            Assert.Contains("END OF TERMS AND CONDITIONS", apache);

            // The fonts and supabase-js keep their own licence files beside them.
            foreach (var file in new[]
            {
                "SmartRetailPOS/src/SmartRetail.Pos.Web/wwwroot/fonts/Inter-LICENSE.txt",
                "SmartRetailPOS/src/SmartRetail.Pos.Web/wwwroot/fonts/NotoSansDevanagari-LICENSE.txt",
                "SmartRetailPOS/owner-app/vendor/supabase-js.LICENSE",
            })
            {
                Assert.True(File.Exists(Path.Combine(root, file)), file + " is missing");
                Assert.Contains(Path.GetFileName(file), notices);
            }
        }

        [Fact]
        public void The_vendors_own_notices_that_travel_with_their_binaries_are_there_and_every_one_is_named()
        {
            var notices = Read("THIRD-PARTY-NOTICES.md");
            var folder = Path.Combine(Repository.Root(), "licenses", "third-party");

            // What the binary downloads hold that is not MIT: Microsoft's terms for the SQL Server network library (which must be
            // passed on with it), WebView2's BSD text, and the notices of the native libraries and of the runtime the dashboard carries.
            foreach (var name in new[]
            {
                "Microsoft.Data.SqlClient.SNI-LICENSE.txt",
                "Microsoft.Web.WebView2-LICENSE.txt",
                "SkiaSharp-THIRD-PARTY-NOTICES.txt",
                "OnnxRuntime-ThirdPartyNotices.txt",
                "dotnet-runtime-THIRD-PARTY-NOTICES.txt",
                "aspnetcore-runtime-THIRD-PARTY-NOTICES.txt",
            })
            {
                Assert.True(File.Exists(Path.Combine(folder, name)), name + " is missing from licenses/third-party");
            }

            Assert.Contains("MICROSOFT SOFTWARE LICENSE TERMS", File.ReadAllText(Path.Combine(folder, "Microsoft.Data.SqlClient.SNI-LICENSE.txt")));
            foreach (var file in Directory.GetFiles(folder))
            {
                Assert.True(notices.Contains(Path.GetFileName(file), StringComparison.Ordinal), Path.GetFileName(file) + " is not named in THIRD-PARTY-NOTICES.md");
            }
        }

        [Fact]
        public void The_package_carries_the_licence_and_the_notices()
        {
            var build = Read("SmartRetailAI", "build.ps1");

            Assert.Matches(@"Copy-Item\s+""\.\./LICENSE""\s+\(Join-Path \$out ""LICENSE\.txt""\)", build);
            Assert.Matches(@"Copy-Item\s+""\.\./THIRD-PARTY-NOTICES\.md""\s+\$out", build);
            Assert.Matches(@"Copy-Item\s+""\.\./licenses""\s+\(Join-Path \$out ""licenses""\)\s+-Recurse", build);
        }
    }
}
