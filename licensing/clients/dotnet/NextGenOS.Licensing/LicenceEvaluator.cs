using System;
using System.Collections.Generic;
using System.Linq;

namespace NextGenOS.Licensing
{
    /// <summary>Everything the evaluator looks at. Times are Unix seconds, UTC.</summary>
    public sealed class EvaluationInput
    {
        public string LicenceToken { get; set; }
        public string ActivationToken { get; set; }
        public string RevocationListToken { get; set; }

        /// <summary>This PC's fingerprint parts as "kind:hash" strings.</summary>
        public IList<string> Fingerprint { get; set; }

        /// <summary>The web site's host name, for domain-bound licences.</summary>
        public string Host { get; set; }

        /// <summary>The module this app needs, such as "pos"; null to skip the check.</summary>
        public string RequiredModule { get; set; }

        public long Now { get; set; }

        /// <summary>The latest time this PC has seen before (from the state file), or 0.</summary>
        public long LastSeen { get; set; }

        public IList<TrustedKey> TrustedKeys { get; set; }
    }

    /// <summary>The decision rules of spec section 10. A pure function: no files, no network, no clock. It fails closed.</summary>
    public static class LicenceEvaluator
    {
        public const string ProductId = "smart-retail-os";
        private const long ClockSlack = 24 * 3600;

        public static LicenceState Evaluate(EvaluationInput input)
        {
            try
            {
                return EvaluateCore(input);
            }
            catch (Exception)
            {
                return new LicenceState { Status = LicenceStatus.Invalid };
            }
        }

        private static LicenceState EvaluateCore(EvaluationInput input)
        {
            if (string.IsNullOrWhiteSpace(input.LicenceToken)) return new LicenceState { Status = LicenceStatus.Missing };

            LicenceClaims lic;
            try { lic = TokenVerifier.Verify<LicenceClaims>(input.LicenceToken, input.TrustedKeys, "lic"); }
            catch (LicenceException) { return new LicenceState { Status = LicenceStatus.Invalid }; }

            var state = new LicenceState { Licence = lic };
            if (lic.Product != ProductId || string.IsNullOrEmpty(lic.LicenceId) || lic.Bind == null || lic.Modules == null || lic.Limits == null)
            {
                state.Status = LicenceStatus.Invalid;
                return state;
            }

            // The revocation list can only make things stricter, so a broken one is ignored.
            RevocationListClaims crl = null;
            if (!string.IsNullOrWhiteSpace(input.RevocationListToken))
            {
                try { crl = TokenVerifier.Verify<RevocationListClaims>(input.RevocationListToken, input.TrustedKeys, "crl"); }
                catch (LicenceException) { crl = null; }
            }
            if (crl != null && crl.Revoked != null && crl.Revoked.Contains(lic.LicenceId))
            {
                state.Status = LicenceStatus.Revoked;
                return state;
            }

            ActivationClaims act = null;
            var needsActivation = lic.Bind.Mode == "device";
            if (needsActivation && !string.IsNullOrWhiteSpace(input.ActivationToken))
            {
                try { act = TokenVerifier.Verify<ActivationClaims>(input.ActivationToken, input.TrustedKeys, "act"); }
                catch (LicenceException) { state.Status = LicenceStatus.Invalid; return state; }
                if (act.LicenceId != lic.LicenceId || act.Fingerprint == null || act.Fingerprint.Count == 0)
                {
                    state.Status = LicenceStatus.Invalid;
                    return state;
                }
                state.Activation = act;
            }

            // A clock set back: earlier than something this PC has already seen, or than the moment the Studio signed the files.
            var floor = Math.Max(input.LastSeen, Math.Max(lic.IssuedAt, Math.Max(act != null ? act.IssuedAt : 0, crl != null ? crl.IssuedAt : 0)));
            if (input.Now < floor - ClockSlack)
            {
                state.Status = LicenceStatus.ClockTampered;
                return state;
            }

            if (input.Now < lic.NotBefore) { state.Status = LicenceStatus.NotYetValid; return state; }
            if (lic.Expires.HasValue && input.Now > lic.Expires.Value) { state.Status = LicenceStatus.Expired; return state; }

            if (input.RequiredModule != null && !lic.Modules.Contains(input.RequiredModule))
            {
                state.Status = LicenceStatus.ModuleNotLicensed;
                return state;
            }

            switch (lic.Bind.Mode)
            {
                case "none":
                    state.Status = LicenceStatus.Valid;
                    return state;

                case "domain":
                    state.Status = HostMatches(input.Host, lic.Bind.Domains) ? LicenceStatus.Valid : LicenceStatus.DomainMismatch;
                    return state;

                case "device":
                    if (act == null) { state.Status = LicenceStatus.NotActivated; return state; }
                    if (!DeviceFingerprint.Matches(act.Fingerprint, act.FingerprintMin, input.Fingerprint)) { state.Status = LicenceStatus.DeviceMismatch; return state; }
                    if (input.Now <= act.NextCheckIn) { state.Status = LicenceStatus.Valid; return state; }
                    if (input.Now <= act.Until)
                    {
                        state.Status = LicenceStatus.Grace;
                        state.GraceDaysLeft = (int)Math.Max(0, (act.Until - input.Now + 86399) / 86400);
                        return state;
                    }
                    state.Status = LicenceStatus.NeedsCheckIn;
                    return state;

                default:
                    state.Status = LicenceStatus.Invalid;
                    return state;
            }
        }

        /// <summary>"example.com" matches itself; "*.example.com" matches any sub-domain but not example.com. Case and port are ignored.</summary>
        public static bool HostMatches(string host, IList<string> domains)
        {
            if (string.IsNullOrWhiteSpace(host) || domains == null) return false;
            var h = host.Trim().ToLowerInvariant();
            var colon = h.LastIndexOf(':');
            if (colon > 0 && h.IndexOf(']') < colon) h = h.Substring(0, colon);
            foreach (var raw in domains)
            {
                var d = (raw ?? string.Empty).Trim().ToLowerInvariant();
                if (d.Length == 0) continue;
                if (d.StartsWith("*."))
                {
                    var suffix = d.Substring(1); // ".example.com"
                    if (h.Length > suffix.Length && h.EndsWith(suffix, StringComparison.Ordinal)) return true;
                }
                else if (h == d) return true;
            }
            return false;
        }
    }
}
