namespace SmartRetail.AI.Settings
{
    /// <summary>
    /// Whether the app starts when the owner signs in to Windows. The setup ticks "Start with Windows" for a new install and
    /// writes the sign-in entry itself, but the app's own settings file does not know that yet, and saving other settings would
    /// take the entry away. An entry that exists therefore counts as the owner's choice, so Settings shows it as on and keeps it.
    /// An owner who unticked it in the setup has no entry, and it stays off. Windows also keeps a list of start-up apps (Task
    /// Manager, Settings → Apps → Startup) in which anyone can switch an entry off: it stays in the Run key but Windows does not
    /// start it, so it does not count as on.
    /// </summary>
    public static class StartupChoice
    {
        public static bool Effective(bool saved, bool entryExists, bool switchedOffInWindows = false) =>
            (saved || entryExists) && !switchedOffInWindows;

        /// <summary>
        /// What Windows keeps for an entry of the Run key in its list of start-up apps (the binary value of the same name in
        /// StartupApproved\Run): a first byte that is odd (03, 07) means switched off, even (02, 06) on. Nothing there means on.
        /// </summary>
        public static bool IsSwitchedOff(byte[] approved) => approved != null && approved.Length > 0 && (approved[0] & 1) == 1;
    }
}
