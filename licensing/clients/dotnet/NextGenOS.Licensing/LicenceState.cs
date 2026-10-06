using System;

namespace NextGenOS.Licensing
{
    /// <summary>What the app must do about the licence (spec section 10).</summary>
    public enum LicenceStatus
    {
        Valid,
        Grace,
        NotActivated,
        NeedsCheckIn,
        Expired,
        NotYetValid,
        Revoked,
        DeviceMismatch,
        DomainMismatch,
        ClockTampered,
        Invalid,
        Missing,
        ModuleNotLicensed,
    }

    /// <summary>The result of looking at the licence files: a status, the claims, and words for a person.</summary>
    public sealed class LicenceState
    {
        public LicenceStatus Status { get; set; }
        public LicenceClaims Licence { get; set; }
        public ActivationClaims Activation { get; set; }

        /// <summary>For <see cref="LicenceStatus.Grace"/>: whole days left before the licence stops until it checks in.</summary>
        public int GraceDaysLeft { get; set; }

        /// <summary>When the licence ends, or null for no end date.</summary>
        public DateTime? ExpiresUtc
        {
            get { return Licence != null && Licence.Expires.HasValue ? (DateTime?)Epoch.AddSeconds(Licence.Expires.Value) : null; }
        }

        /// <summary>True when the app may run: <see cref="LicenceStatus.Valid"/> or <see cref="LicenceStatus.Grace"/>.</summary>
        public bool IsUsable { get { return Status == LicenceStatus.Valid || Status == LicenceStatus.Grace; } }

        /// <summary>The brand to show: the licence's, or NextGenOS's own.</summary>
        public BrandProfile Brand
        {
            get { return Licence != null && Licence.Brand != null && !string.IsNullOrEmpty(Licence.Brand.Name) ? Licence.Brand : BrandProfile.Default(); }
        }

        /// <summary>"none", "theme" or "full": how much of the look this customer may change themselves. Without a licence: "none".</summary>
        public string WhiteLabelLevel
        {
            get { return Licence != null && Licence.White != null && !string.IsNullOrEmpty(Licence.White.Level) ? Licence.White.Level : "none"; }
        }

        public bool HasModule(string module)
        {
            return Licence != null && Licence.Modules != null && Licence.Modules.Contains(module);
        }

        /// <summary>A short sentence for the person using the app, with no technical words.</summary>
        public string Message
        {
            get
            {
                switch (Status)
                {
                    case LicenceStatus.Valid:
                        return ExpiresUtc.HasValue ? "Your licence is active until " + ExpiresUtc.Value.ToString("d MMMM yyyy") + "." : "Your licence is active.";
                    case LicenceStatus.Grace:
                        return "This PC could not check in with the licence server. It works for " + GraceDaysLeft + " more day" + (GraceDaysLeft == 1 ? "" : "s") + ". Please connect it to the Internet.";
                    case LicenceStatus.NotActivated:
                        return "This program needs to be activated. Enter your licence key.";
                    case LicenceStatus.NeedsCheckIn:
                        return "This PC has not checked in with the licence server for too long. Connect it to the Internet and press Check now, or activate without Internet.";
                    case LicenceStatus.Expired:
                        return "Your licence has ended. Please renew it with your supplier.";
                    case LicenceStatus.NotYetValid:
                        return "Your licence has not started yet. Check the date and time of this PC, or the start date with your supplier.";
                    case LicenceStatus.Revoked:
                        return "This licence has been withdrawn. Please contact your supplier.";
                    case LicenceStatus.DeviceMismatch:
                        return "This licence is activated for a different PC. Activate it again on this PC, or ask your supplier to free the other PC.";
                    case LicenceStatus.DomainMismatch:
                        return "This licence is for a different website address.";
                    case LicenceStatus.ClockTampered:
                        return "The date and time of this PC look wrong. Correct them, then connect to the Internet and press Check now.";
                    case LicenceStatus.ModuleNotLicensed:
                        return "Your licence does not include this part of the program. Please ask your supplier to add it.";
                    case LicenceStatus.Missing:
                        return "No licence was found. Enter your licence key to activate.";
                    default:
                        return "The licence could not be read. Please activate again, or contact your supplier.";
                }
            }
        }

        internal static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
