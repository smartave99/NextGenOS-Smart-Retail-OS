using System.Threading.Tasks;
using System.Windows.Forms;
using SmartRetail.AI.Updates;

namespace SmartRetail.AI.Desktop
{
    /// <summary>What the owner is asked and told about an update, the same in both hosts of the app.</summary>
    internal static class UpdatePrompt
    {
        private const string Title = "Smart Retail POS";

        public static string TrayText(UpdateStatus status) => "Install update " + status.Available + "…";

        /// <summary>The line in the assistant window's status bar, which installs the update when it is clicked.</summary>
        public static string StatusBarText(UpdateStatus status) => "Version " + status.Available + " is ready: install…";

        public static string BalloonText(UpdateStatus status) =>
            "Version " + status.Available + " is ready. Open Smart Retail POS and use the bell, or right-click this icon, to install it.";

        /// <summary>
        /// Starts the update: asks first when <paramref name="confirm"/> (the tray menu; the dashboard's card has asked
        /// already). True when the setup has started and the app should quit for it; a problem is shown to the owner.
        /// </summary>
        public static async Task<bool> InstallAsync(UpdateService updates, bool confirm)
        {
            if (confirm)
            {
                var answer = MessageBox.Show(
                    "Version " + updates.Status.Available + " is ready.\r\n\r\nSmart Retail POS will close, update and open again by itself. Your settings, photos and plans are kept.\r\n\r\nInstall it now?",
                    Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer != DialogResult.Yes)
                {
                    return false;
                }
            }

            var problem = await updates.InstallAsync();
            if (problem == null)
            {
                return true;
            }

            MessageBox.Show(problem, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
