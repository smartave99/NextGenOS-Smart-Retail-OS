using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>The setup ticks "Start with Windows" and writes the sign-in entry itself; the app must not undo that.</summary>
    public class StartupChoiceTests
    {
        [Theory]
        [InlineData(false, false, false)] // unticked in the setup, never turned on: stays off
        [InlineData(true, false, true)]   // turned on in Settings: on (the entry is written again)
        [InlineData(false, true, true)]   // ticked in the setup, the settings file does not know: on, and Settings shows it
        [InlineData(true, true, true)]
        public void An_entry_that_exists_counts_as_the_owners_choice(bool saved, bool entryExists, bool expected) =>
            Assert.Equal(expected, StartupChoice.Effective(saved, entryExists));

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void An_entry_that_Windows_has_switched_off_does_not_start_so_it_is_not_on(bool saved, bool entryExists) =>
            Assert.False(StartupChoice.Effective(saved, entryExists, switchedOffInWindows: true));

        [Fact]
        public void A_fresh_settings_file_does_not_turn_it_on_by_itself()
        {
            Assert.False(new PanelSettings().StartWithWindows);
        }

        [Theory]
        [InlineData(null, false)]                                       // no record: on
        [InlineData(new byte[0], false)]
        [InlineData(new byte[] { 0x02, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, false)]   // on
        [InlineData(new byte[] { 0x06, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, false)]   // on, chosen by the user
        [InlineData(new byte[] { 0x03, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8 }, true)]    // switched off, with the time
        [InlineData(new byte[] { 0x07, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8 }, true)]
        public void Windows_marks_an_entry_it_does_not_start_with_an_odd_first_byte(byte[] approved, bool switchedOff) =>
            Assert.Equal(switchedOff, StartupChoice.IsSwitchedOff(approved));
    }
}
