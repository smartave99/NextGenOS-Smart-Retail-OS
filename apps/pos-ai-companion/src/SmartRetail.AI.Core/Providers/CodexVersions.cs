using System;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// Codex's version numbers: what <c>codex --version</c> prints ("codex-cli 0.158.0"), and what OpenAI's release channel
    /// calls a release ("rust-v0.159.0"). Only a released, stable version counts as "the latest": an alpha or a beta is never
    /// something to update to. Pure and tested.
    /// </summary>
    public static class CodexVersions
    {
        private static readonly Regex Printed = new Regex(@"(?<![\d.])(\d{1,4})\.(\d{1,4})\.(\d{1,4})(?<pre>-(?:alpha|beta)[0-9A-Za-z.]*)?(?![\d.])", RegexOptions.CultureInvariant);

        private static readonly Regex Tag = new Regex(@"^rust-v(\d{1,4})\.(\d{1,4})\.(\d{1,4})$", RegexOptions.CultureInvariant);

        /// <summary>The version in the words <c>codex --version</c> prints, or null when there is none.</summary>
        public static Version Installed(string output, out bool prerelease)
        {
            prerelease = false;
            var match = Printed.Match(output ?? "");
            if (!match.Success)
            {
                return null;
            }

            prerelease = match.Groups["pre"].Success;
            return new Version(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
        }

        /// <summary>The version of a release tag such as "rust-v0.159.0", or null for anything else (an alpha, a beta, another name).</summary>
        public static Version OfTag(string tag)
        {
            var match = Tag.Match((tag ?? "").Trim());
            return match.Success
                ? new Version(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value))
                : null;
        }

        /// <summary>
        /// True when <paramref name="latest"/> is newer than what <c>codex --version</c> printed. An alpha or beta of the
        /// same numbers is older than the release; one of newer numbers is not to be replaced by an older release.
        /// </summary>
        public static bool IsNewer(Version latest, string installedOutput)
        {
            var installed = Installed(installedOutput, out var prerelease);
            if (latest == null || installed == null)
            {
                return false;
            }

            return latest > installed || (latest == installed && prerelease);
        }

        /// <summary>The version as the installer takes it in CODEX_RELEASE: "0.158.0".</summary>
        public static string ForInstaller(Version version) => version == null ? "" : version.ToString(3);
    }
}
