using System;

namespace DevNetLM.Models
{
    /// <summary>What the POS reads about its licence (kept as it has always been, filled from the signed licence).</summary>
    public class LicenseData
    {
        public string ProName { get; set; }
        public string LKey { get; set; }
        public string SYSID { get; set; }
        public DateTime VFrom { get; set; }
        public DateTime VTill { get; set; }
        public DateTime TStamp { get; set; }
        public string CusName { get; set; }
        public string CusEmail { get; set; }
        public string CusPhone { get; set; }
        public string ProductId { get; set; }
        public string issuedby { get; set; }
        public string issued_byid { get; set; }
    }
}
