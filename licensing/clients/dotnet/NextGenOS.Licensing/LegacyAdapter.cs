using System;

namespace NextGenOS.Licensing
{
    /// <summary>
    /// What the Windows POS wants to know, in the shape it has always asked for (the old DevNetLM answer): may I run, what
    /// is the customer called, when does it end. A pure mapping from a <see cref="LicenceState"/>, so it can be tested anywhere.
    /// </summary>
    public sealed class LegacyView
    {
        public bool Allowed { get; set; }
        public bool ShowActivation { get; set; }
        public string Message { get; set; }
        public string ProductName { get; set; }
        public string LicenceId { get; set; }
        public string SystemId { get; set; }
        public DateTime From { get; set; }

        /// <summary>The end date. With no end date it is ten years away, so that the POS's "expires soon" reminder stays quiet.</summary>
        public DateTime Till { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        /// <summary>The POS shows this in a label and compares it with "Trial": the edition name, or "Trial".</summary>
        public string CustomerPhone { get; set; }
        public string Edition { get; set; }
        public bool IsTrial { get; set; }
        public BrandProfile Brand { get; set; }
        public LicenceStatus Status { get; set; }
    }

    public static class LegacyAdapter
    {
        public const string ProductName = "Smart Retail POS";

        public static LegacyView From(LicenceState state, DateTime nowUtc)
        {
            var lic = state.Licence;
            var view = new LegacyView
            {
                Allowed = state.IsUsable,
                // Every state that stops the program opens the activation window: it tells the person what is wrong and what to do.
                ShowActivation = !state.IsUsable,
                Message = state.Message,
                ProductName = ProductName,
                Status = state.Status,
                Brand = state.Brand,
                From = nowUtc.Date,
                Till = nowUtc.Date.AddYears(10),
            };
            if (lic == null) return view;

            view.LicenceId = lic.LicenceId;
            view.Edition = lic.Edition;
            view.IsTrial = lic.Trial;
            view.CustomerName = lic.Customer != null ? lic.Customer.Name : string.Empty;
            view.CustomerEmail = lic.Customer != null ? lic.Customer.Email : string.Empty;
            view.CustomerPhone = lic.Trial ? "Trial" : Capitalise(lic.Edition);
            view.From = LicenceState.Epoch.AddSeconds(lic.NotBefore).ToLocalTime().Date;
            if (lic.Expires.HasValue) view.Till = LicenceState.Epoch.AddSeconds(lic.Expires.Value).ToLocalTime().Date;
            if (state.Activation != null && state.Activation.Fingerprint != null && state.Activation.Fingerprint.Count > 0)
            {
                var first = state.Activation.Fingerprint[0];
                view.SystemId = first.Substring(first.IndexOf(':') + 1).ToUpperInvariant();
            }
            return view;
        }

        private static string Capitalise(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : char.ToUpperInvariant(s[0]) + s.Substring(1);
        }
    }
}
