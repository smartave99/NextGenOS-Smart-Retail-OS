using System.Drawing;
using System.Windows.Forms;

namespace SmartRetail.AI.Desktop
{
    internal static class AppIcon
    {
        private static Icon _icon;

        /// <summary>The icon built into SmartRetailAI.exe (app.ico).</summary>
        public static Icon Get() => _icon ?? (_icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath) ?? SystemIcons.Application);
    }
}
