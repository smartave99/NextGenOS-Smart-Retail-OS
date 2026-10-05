using System;

namespace SmartRetail.AI.Updates
{
    /// <summary>
    /// What must hold before the app starts a downloaded setup, whatever the state of the PC: the update was checked
    /// (<see cref="UpdateState.Ready"/>), its version and file name are the ones the release writes, its SHA-256 is known,
    /// and it is newer than what is running. Pure and tested; the app adds what only Windows can tell (how it was installed,
    /// the file's bytes).
    /// </summary>
    public static class UpdateInstallRules
    {
        /// <summary>Why <paramref name="ready"/> may not be installed by a copy that is version <paramref name="current"/>, or null when it may.</summary>
        public static string Problem(UpdateStatus ready, Version current)
        {
            if (ready == null || ready.State != UpdateState.Ready || !UpdateManifest.IsVersion(ready.Available)
                || ready.File != UpdateManifest.SetupFileName(ready.Available) || !UpdateManifest.IsSha256(ready.Sha256))
            {
                return "No update is ready to install.";
            }

            if (current != null && Version.Parse(ready.Available) <= current)
            {
                return "Version " + ready.Available + " is already installed, or newer is.";
            }

            return null;
        }
    }
}
