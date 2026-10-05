using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>The names the windows and messages show come from the licence's brand, with NextGenOS's own as the default; data folders never move with it.</summary>
    [Collection("Branding")]
    public sealed class BrandingTests
    {
        [Fact]
        public void A_licence_brand_changes_what_the_windows_say_and_a_blank_or_huge_name_does_not()
        {
            try
            {
                Assert.Equal("Smart Retail POS", Branding.DefaultProduct);

                Branding.Apply("Acme Retail Suite");
                Assert.Equal("Acme Retail Suite", Branding.Product);
                Assert.Equal("Acme Retail Suite AI Assistant", Branding.AssistantName);

                Branding.Apply("   ");
                Branding.Apply(null);
                Branding.Apply(new string('x', 61));
                Assert.Equal("Acme Retail Suite", Branding.Product);

                // The company and the data folder stay NextGenOS's: a customer's data is not lost when a brand changes.
                Assert.Equal("NextGenOS", Branding.Company);
                Assert.Equal("Smart Retail POS AI", Branding.AppFolderName);
            }
            finally
            {
                Branding.Apply(Branding.DefaultProduct);
            }
        }
    }

    [CollectionDefinition("Branding", DisableParallelization = true)]
    public sealed class BrandingCollection { }
}
