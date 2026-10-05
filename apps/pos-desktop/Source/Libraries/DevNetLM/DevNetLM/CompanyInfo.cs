using NextGenOS.Licensing;

namespace DevNetLM
{
    /// <summary>
    /// The shop's name, country and logo for the splash screen, the login window and the support forms. Before, the old licence
    /// system kept them in the registry under a shared key; now they come from the signed licence and its brand.
    /// </summary>
    public sealed class CompanyInfo
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        /// <summary>A data URI or base64 text of the logo, or empty.</summary>
        public string Logo { get; set; }
        public string MainLogo { get; set; }
        public string LicenceKey { get; set; }

        public static CompanyInfo Read()
        {
            var info = new CompanyInfo { Company = string.Empty, Name = string.Empty, Email = string.Empty, Phone = string.Empty, Address = string.Empty, State = string.Empty, Country = string.Empty, Logo = string.Empty, MainLogo = string.Empty, LicenceKey = string.Empty };
            try
            {
                var state = PosLicence.Manager.Evaluate();
                if (state.Licence == null) return info;
                info.LicenceKey = state.Licence.LicenceId;
                if (state.Licence.Customer != null)
                {
                    info.Company = state.Licence.Customer.Name ?? string.Empty;
                    info.Name = info.Company;
                    info.Email = state.Licence.Customer.Email ?? string.Empty;
                    info.Country = state.Licence.Customer.Country ?? string.Empty;
                }
                var brand = state.Brand;
                if (brand != null)
                {
                    info.Phone = brand.SupportPhone ?? string.Empty;
                    info.Logo = brand.Logo ?? string.Empty;
                    info.MainLogo = brand.Logo ?? string.Empty;
                }
            }
            catch (System.Exception) { }
            return info;
        }
    }
}
