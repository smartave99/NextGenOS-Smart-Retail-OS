namespace NextGenOS.Licensing
{
    /// <summary>
    /// The public keys the product trusts and the address of the Licence Studio, put here at build time by
    /// "node src/cli.js sync-clients" (see licensing/README.md). Public keys only: a private key must never be in this file.
    /// With no key here every licence is refused, which is the safe default until the Studio has been set up.
    /// </summary>
    public static class LicenceDefaults
    {
        public static readonly TrustedKey[] TrustedKeys = new TrustedKey[]
        {
            // GENERATED-KEYS-BEGIN
            // GENERATED-KEYS-END
        };

        // GENERATED-URL-BEGIN
        public const string ServerUrl = "";
        // GENERATED-URL-END
    }
}
