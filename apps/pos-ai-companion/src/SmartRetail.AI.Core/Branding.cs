namespace SmartRetail.AI
{
    /// <summary>
    /// Names shown in the UI and prompts, and used for per-user data folders. The product name is NextGenOS's own
    /// (Smart Retail POS) until a licence with a brand of its own is read (<see cref="Apply"/>): then the windows and
    /// messages show that brand. Folder names never change with the brand, so a customer's data stays where it is.
    /// </summary>
    public static class Branding
    {
        public const string Company = "NextGenOS";
        public const string DefaultProduct = "Smart Retail POS";
        public const string AppFolderName = "Smart Retail POS AI";

        private static string _product = DefaultProduct;
        private static string _assistant = DefaultProduct + " AI Assistant";

        /// <summary>The product's name as the customer knows it.</summary>
        public static string Product { get { return _product; } }

        /// <summary>The name of the assistant window and messages.</summary>
        public static string AssistantName { get { return _assistant; } }

        /// <summary>Shows a brand's name in place of the default. A blank or very long name is ignored.</summary>
        public static void Apply(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return;
            }

            var name = productName.Trim();
            if (name.Length > 60)
            {
                return;
            }

            _product = name;
            _assistant = name + " AI Assistant";
        }
    }
}
