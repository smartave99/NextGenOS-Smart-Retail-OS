namespace DevNetLM.Models
{
    /// <summary>The answer of DevNet.Validate(): LicenseData is null when the program may not run.</summary>
    public class LicenseResponse
    {
        public LicenseData LicenseData { get; set; }
        public string Message { get; set; }
        public bool ShowActivation { get; set; }
    }
}
