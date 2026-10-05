using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NextGenOS.Licensing
{
    public sealed class LicenceOptions
    {
        /// <summary>The folder name under NextGenOS. All the suite's programs use the default so that one activation covers them.</summary>
        public string Product { get; set; } = "SmartRetailPOS";

        /// <summary>The module this program needs ("pos", "ai", "dashboard", "storefront"); null to skip the check.</summary>
        public string RequiredModule { get; set; }

        /// <summary>The Licence Studio's address. Default: the built-in one, or the NGOS_LICENCE_SERVER environment variable (signatures keep that safe).</summary>
        public string ServerUrl { get; set; }

        /// <summary>Normally left null: the keys built into the product. Tests set it.</summary>
        public IList<TrustedKey> TrustedKeys { get; set; }

        public string Directory { get; set; }
        public string AppVersion { get; set; } = "0.0.0";

        /// <summary>The web site's host name, for domain-bound licences.</summary>
        public string Host { get; set; }

        public Func<DateTime> UtcNow { get; set; }
        public IFingerprintSource Fingerprint { get; set; }
        public HttpMessageHandler HttpHandler { get; set; }
    }

    /// <summary>
    /// What a program calls: look at the licence, activate with a key, check in, use offline codes.
    /// Typical start-up: <c>var state = manager.Evaluate(); if (!state.IsUsable) show the activation window;</c>
    /// </summary>
    public sealed class LicenceManager
    {
        private readonly LicenceOptions _o;
        private readonly LicenceStore _store;
        private readonly IList<TrustedKey> _keys;
        private readonly IFingerprintSource _source;
        private DateTime _lastAttemptUtc = DateTime.MinValue;

        public LicenceManager(LicenceOptions options)
        {
            _o = options ?? new LicenceOptions();
            _keys = _o.TrustedKeys ?? LicenceDefaults.TrustedKeys;
            _store = new LicenceStore(_o.Directory ?? LicenceStore.DefaultDirectory(_o.Product));
            _source = _o.Fingerprint ?? DeviceFingerprint.CreateDefaultSource();
        }

        /// <summary>The reason the last online call failed, in words for a person; null after a success.</summary>
        public string LastError { get; private set; }

        public LicenceStore Store { get { return _store; } }

        public string ServerUrl
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_o.ServerUrl)) return _o.ServerUrl;
                var env = Environment.GetEnvironmentVariable("NGOS_LICENCE_SERVER");
                return !string.IsNullOrWhiteSpace(env) ? env : LicenceDefaults.ServerUrl;
            }
        }

        private DateTime NowUtc() { return _o.UtcNow != null ? _o.UtcNow() : DateTime.UtcNow; }

        private long Now() { return (long)(NowUtc() - LicenceState.Epoch).TotalSeconds; }

        private Dictionary<string, string> Fingerprint() { return DeviceFingerprint.Compute(_source); }

        private string[] FingerprintParts() { return DeviceFingerprint.AsList(Fingerprint()).ToArray(); }

        /// <summary>Reads the files and decides. Cheap enough to call on every start and every few minutes.</summary>
        public LicenceState Evaluate()
        {
            try
            {
                var parts = FingerprintParts();
                long lastSeen, lastCheckIn;
                _store.ReadState(parts, out lastSeen, out lastCheckIn);
                var state = LicenceEvaluator.Evaluate(new EvaluationInput
                {
                    LicenceToken = _store.LicenceToken,
                    ActivationToken = _store.ActivationToken,
                    RevocationListToken = _store.RevocationListToken,
                    Fingerprint = parts,
                    Host = _o.Host,
                    RequiredModule = _o.RequiredModule,
                    Now = Now(),
                    LastSeen = lastSeen,
                    TrustedKeys = _keys.ToList(),
                });
                if (state.Status != LicenceStatus.ClockTampered && state.Status != LicenceStatus.Invalid && state.Status != LicenceStatus.Missing)
                {
                    _store.TouchState(parts, Now(), false);
                }
                return state;
            }
            catch (Exception)
            {
                return new LicenceState { Status = LicenceStatus.Invalid };
            }
        }

        /// <summary>Activates this PC with a licence key. Returns the new state; throws <see cref="LicenceServerException"/> with a message for the person if the server says no.</summary>
        public async Task<LicenceState> ActivateAsync(string key, CancellationToken ct = default(CancellationToken))
        {
            var normalised = LicenceKey.Normalise(key);
            if (normalised == null) throw new LicenceServerException("bad_key", "That does not look like a licence key. It has 20 letters and numbers, like NGOS-ABCDE-12345-FGHJK-67890.", false);
            var parts = Fingerprint();
            if (parts.Count == 0) throw new LicenceServerException("no_fingerprint", "This PC could not be identified. Please contact support.", false);

            using (var client = new ActivationClient(ServerUrl, _o.HttpHandler))
            {
                ServerTokens tokens;
                try
                {
                    tokens = await client.ActivateAsync(normalised, _o.AppVersion, parts, Environment.MachineName, ct).ConfigureAwait(false);
                }
                catch (LicenceServerException ex)
                {
                    LastError = ex.Message;
                    throw;
                }
                Save(tokens, true);
            }
            LastError = null;
            ResetClock(DeviceFingerprint.AsList(parts).ToArray());
            return Evaluate();
        }

        /// <summary>Takes the time from the signed tokens just received (the licence server's clock).</summary>
        private void ResetClock(string[] fingerprint)
        {
            long server = 0;
            try
            {
                var act = _store.ActivationToken;
                if (!string.IsNullOrEmpty(act)) server = TokenVerifier.Verify<ActivationClaims>(act, _keys, "act").IssuedAt;
                if (server == 0) server = TokenVerifier.Verify<LicenceClaims>(_store.LicenceToken, _keys, "lic").IssuedAt;
            }
            catch (LicenceException) { }
            if (server > 0) _store.ResetState(fingerprint, server);
            else _store.TouchState(fingerprint, Now(), true);
        }

        /// <summary>Checks in with the server when it is time (or when forced). Never throws for a network problem: the grace period handles that.</summary>
        public async Task<LicenceState> CheckInAsync(bool force = false, int? stores = null, int? devices = null, int? users = null, CancellationToken ct = default(CancellationToken))
        {
            var state = Evaluate();
            if (state.Licence == null || state.Licence.Bind == null || state.Licence.Bind.Mode != "device") return state;
            var act = _store.ActivationToken;
            if (string.IsNullOrEmpty(act)) return state;

            // A held or withdrawn licence, or a clock problem, is asked about again so that a release or a repaired clock is noticed.
            var due = force || state.Status == LicenceStatus.Grace || state.Status == LicenceStatus.NeedsCheckIn
                      || state.Status == LicenceStatus.Revoked || state.Status == LicenceStatus.ClockTampered
                      || (state.Activation != null && Now() >= state.Activation.NextCheckIn - 2 * 86400L);
            if (!due) return state;
            if (!force && NowUtc() - _lastAttemptUtc < TimeSpan.FromHours(1)) return state;
            _lastAttemptUtc = NowUtc();

            var parts = Fingerprint();
            try
            {
                using (var client = new ActivationClient(ServerUrl, _o.HttpHandler))
                {
                    var tokens = await client.CheckInAsync(state.Licence.LicenceId, act, parts, _o.AppVersion, stores, devices, users, ct).ConfigureAwait(false);
                    Save(tokens, false);
                    LastError = null;
                    ResetClock(DeviceFingerprint.AsList(parts).ToArray());
                }
            }
            catch (LicenceServerException ex)
            {
                LastError = ex.Message;
                if (!ex.IsNetwork) await ApplyRefusalAsync(ex, state.Licence.LicenceId, ct).ConfigureAwait(false);
            }
            return Evaluate();
        }

        private async Task ApplyRefusalAsync(LicenceServerException ex, string licenceId, CancellationToken ct)
        {
            switch (ex.Code)
            {
                case "revoked":
                case "suspended":
                    try
                    {
                        using (var client = new ActivationClient(ServerUrl, _o.HttpHandler))
                        {
                            _store.SaveRevocationList(await client.GetRevocationListAsync(ct).ConfigureAwait(false));
                        }
                    }
                    catch (LicenceServerException) { }
                    break;
                case "device_mismatch":
                    _store.ClearActivation();
                    break;
            }
        }

        /// <summary>Gives this PC's seat back, so the licence can be used on another PC.</summary>
        public async Task DeactivateAsync(CancellationToken ct = default(CancellationToken))
        {
            var state = Evaluate();
            var act = _store.ActivationToken;
            if (state.Licence != null && !string.IsNullOrEmpty(act))
            {
                using (var client = new ActivationClient(ServerUrl, _o.HttpHandler))
                {
                    await client.DeactivateAsync(state.Licence.LicenceId, act, Fingerprint(), ct).ConfigureAwait(false);
                }
            }
            _store.ClearAll();
        }

        private void Save(ServerTokens tokens, bool replaceLicence)
        {
            if (string.IsNullOrEmpty(tokens.Licence)) throw new LicenceServerException("server_error", "The licence server sent an incomplete answer.", false);
            // Never store what this build cannot trust: a wrong server cannot install a licence.
            TokenVerifier.Verify<LicenceClaims>(tokens.Licence, _keys, "lic");
            if (!string.IsNullOrEmpty(tokens.Activation)) TokenVerifier.Verify<ActivationClaims>(tokens.Activation, _keys, "act");
            _store.SaveLicence(tokens.Licence);
            if (!string.IsNullOrEmpty(tokens.Activation)) _store.SaveActivation(tokens.Activation);
            else if (replaceLicence) _store.ClearActivation();
            if (!string.IsNullOrEmpty(tokens.RevocationList))
            {
                try { TokenVerifier.Verify<RevocationListClaims>(tokens.RevocationList, _keys, "crl"); _store.SaveRevocationList(tokens.RevocationList); } catch (LicenceException) { }
            }
        }

        // ----- Offline activation (spec section 9) -----

        /// <summary>The request code to read to the supplier: NGOSREQ1.… </summary>
        public string CreateOfflineRequest(string key)
        {
            var normalised = LicenceKey.Normalise(key);
            if (normalised == null) throw new LicenceServerException("bad_key", "That does not look like a licence key.", false);
            var body = new JObject
            {
                { "key", normalised },
                { "product", LicenceEvaluator.ProductId },
                { "version", _o.AppVersion },
                { "fp", JObject.FromObject(Fingerprint()) },
                { "host", Environment.MachineName },
                { "ts", Now() },
            };
            return "NGOSREQ1." + Base64Url.Encode(Encoding.UTF8.GetBytes(body.ToString(Formatting.None)));
        }

        /// <summary>Takes the supplier's answer (NGOSRES1.…) and activates this PC with it.</summary>
        public LicenceState ImportOfflineResponse(string code)
        {
            var s = Regex.Replace(code ?? string.Empty, "\\s+", string.Empty);
            if (!s.StartsWith("NGOSRES1.")) throw new LicenceException("That is not an answer code. It starts with NGOSRES1.");
            JObject body;
            try { body = JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(s.Substring("NGOSRES1.".Length)))); }
            catch (Exception ex) when (ex is FormatException || ex is JsonException) { throw new LicenceException("The answer code is damaged. Please copy it again, all of it."); }

            var tokens = new ServerTokens { Licence = (string)body["lic"], Activation = (string)body["act"], RevocationList = (string)body["crl"] };
            if (string.IsNullOrEmpty(tokens.Licence) || string.IsNullOrEmpty(tokens.Activation)) throw new LicenceException("The answer code has no activation in it.");
            var act = TokenVerifier.Verify<ActivationClaims>(tokens.Activation, _keys, "act");
            var current = FingerprintParts();
            if (!DeviceFingerprint.Matches(act.Fingerprint, act.FingerprintMin, current))
                throw new LicenceException("This answer code was made for a different PC.");
            Save(tokens, true);
            LastError = null;
            ResetClock(current);
            return Evaluate();
        }

        /// <summary>Loads a licence file (.ngoslic) or its text, for licences that need no activation and for renewals sent by e-mail.</summary>
        public LicenceState ImportLicenceFile(string pathOrToken)
        {
            var text = pathOrToken ?? string.Empty;
            if (text.IndexOf("NGOS1.", StringComparison.Ordinal) < 0 && File.Exists(text)) text = File.ReadAllText(text);
            text = text.Trim();
            var lic = TokenVerifier.Verify<LicenceClaims>(text, _keys, "lic");
            var existing = Evaluate().Licence;
            if (existing != null && existing.LicenceId == lic.LicenceId && lic.Revision < existing.Revision)
                throw new LicenceException("This file is older than the licence already installed.");
            if (existing == null || existing.LicenceId != lic.LicenceId) _store.ClearActivation();
            _store.SaveLicence(text);
            return Evaluate();
        }
    }
}
