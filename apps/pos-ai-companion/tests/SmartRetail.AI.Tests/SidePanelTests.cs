using System.IO;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class HotkeyTests
    {
        [Theory]
        [InlineData("Ctrl+Shift+Space", Hotkey.ControlFlag | Hotkey.ShiftFlag, 0x20, "Ctrl+Shift+Space")]
        [InlineData(" ctrl + shift + space ", Hotkey.ControlFlag | Hotkey.ShiftFlag, 0x20, "Ctrl+Shift+Space")]
        [InlineData("Alt+a", Hotkey.AltFlag, 0x41, "Alt+A")]
        [InlineData("Control+Alt+9", Hotkey.ControlFlag | Hotkey.AltFlag, 0x39, "Ctrl+Alt+9")]
        [InlineData("Win+Shift+F9", Hotkey.WindowsFlag | Hotkey.ShiftFlag, 0x78, "Shift+Win+F9")]
        [InlineData("Ctrl+F24", Hotkey.ControlFlag, 0x87, "Ctrl+F24")]
        [InlineData("Ctrl+pagedown", Hotkey.ControlFlag, 0x22, "Ctrl+PageDown")]
        [InlineData("Shift+Ctrl+Home", Hotkey.ControlFlag | Hotkey.ShiftFlag, 0x24, "Ctrl+Shift+Home")]
        public void Reads_shortcuts_and_writes_them_the_standard_way(string text, int modifiers, int virtualKey, string standard)
        {
            Assert.True(Hotkey.TryParse(text, out var hotkey, out var problem), problem);
            Assert.Equal(modifiers, hotkey.Modifiers);
            Assert.Equal(virtualKey, hotkey.VirtualKey);
            Assert.Equal(standard, hotkey.ToString());
        }

        [Theory]
        [InlineData(null, "like Ctrl+Shift+Space")]
        [InlineData("", "like Ctrl+Shift+Space")]
        [InlineData("Space", "like Ctrl+Shift+Space")]
        [InlineData("Ctrl+", "like Ctrl+Shift+Space")]
        [InlineData("Shift+A", "Include Ctrl, Alt or Win")]
        [InlineData("Ctrl+Shift", "Add a key")]
        [InlineData("Ctrl+A+B", "one key")]
        [InlineData("Ctrl+Ctrl+A", "twice")]
        [InlineData("Ctrl+Enter", "\"Enter\" is not a key")]
        [InlineData("Ctrl+F25", "\"F25\" is not a key")]
        [InlineData("Ctrl+F0", "\"F0\" is not a key")]
        [InlineData("Ctrl+é", "\"é\" is not a key")]
        public void Refuses_shortcuts_that_cannot_work_or_would_block_typing(string text, string expected)
        {
            Assert.False(Hotkey.TryParse(text, out var hotkey, out var problem));
            Assert.Null(hotkey);
            Assert.Contains(expected, problem);
        }
    }

    public class PanelLayoutTests
    {
        // A 1366×768 till with the taskbar along the bottom.
        private static readonly PixelRect Till = new PixelRect(0, 0, 1366, 728);

        [Fact]
        public void The_panel_fills_the_height_of_the_right_edge()
        {
            Assert.Equal(new PixelRect(926, 0, 440, 728), PanelLayout.Panel(Till, PanelEdge.Right, 440));
        }

        [Fact]
        public void The_panel_can_sit_on_the_left_edge_beside_a_left_taskbar()
        {
            var area = new PixelRect(62, 0, 1304, 768);

            Assert.Equal(new PixelRect(62, 0, 440, 768), PanelLayout.Panel(area, PanelEdge.Left, 440));
        }

        [Theory]
        [InlineData(100, 360)]
        [InlineData(1000, 683)]
        public void The_panel_is_never_too_narrow_or_more_than_half_the_screen(int wanted, int expected)
        {
            var panel = PanelLayout.Panel(Till, PanelEdge.Right, wanted);

            Assert.Equal(expected, panel.Width);
            Assert.Equal(Till.Right, panel.Right);
        }

        [Fact]
        public void The_wide_panel_takes_three_fifths_of_the_screen()
        {
            var wide = PanelLayout.Panel(Till, PanelEdge.Right, 440, wide: true);

            Assert.Equal(819, wide.Width);
            Assert.Equal(Till.Right, wide.Right);
        }

        [Fact]
        public void A_tiny_screen_still_gets_a_panel_that_fits()
        {
            Assert.Equal(new PixelRect(0, 0, 320, 480), PanelLayout.Panel(new PixelRect(0, 0, 320, 480), PanelEdge.Right, 440));
        }

        [Fact]
        public void The_tab_sits_on_the_edge_a_little_above_the_middle()
        {
            Assert.Equal(new PixelRect(1338, 246, 28, 112), PanelLayout.Tab(Till, PanelEdge.Right));
            Assert.Equal(new PixelRect(0, 246, 28, 112), PanelLayout.Tab(Till, PanelEdge.Left));
        }

        [Fact]
        public void A_normal_window_shrinks_to_fit_a_small_till_screen()
        {
            Assert.Equal(new PixelRect(83, 0, 1200, 728), PanelLayout.CenteredWindow(Till, 1200, 800));
            Assert.Equal(new PixelRect(360, 120, 1200, 800), PanelLayout.CenteredWindow(new PixelRect(0, 0, 1920, 1040), 1200, 800));
        }
    }

    public class PanelSettingsTests
    {
        [Fact]
        public void Defaults_show_a_side_panel_on_the_right_with_a_shortcut()
        {
            var panel = new AssistantSettings().Panel;

            Assert.True(panel.SidePanel);
            Assert.Equal(PanelEdge.Right, panel.Edge);
            Assert.Equal(440, panel.Width);
            Assert.True(panel.ShowEdgeTab);
            Assert.Equal("Ctrl+Shift+Space", panel.Shortcut);
            Assert.False(panel.StartWithWindows);
        }

        [Theory]
        [InlineData("ctrl + shift + space", "Ctrl+Shift+Space")]
        [InlineData("  ", "")]
        [InlineData("Shift+A", "Ctrl+Shift+Space")]
        [InlineData("nonsense", "Ctrl+Shift+Space")]
        public void Normalizing_tidies_or_replaces_the_shortcut(string saved, string expected)
        {
            var settings = new AssistantSettings();
            settings.Panel.Shortcut = saved;

            settings.Normalize();

            Assert.Equal(expected, settings.Panel.Shortcut);
        }

        [Fact]
        public void Normalizing_repairs_the_width_the_edge_and_a_missing_section()
        {
            var settings = new AssistantSettings();
            settings.Panel.Width = 10;
            settings.Panel.Edge = (PanelEdge)7;
            settings.Normalize();
            Assert.Equal(PanelSettings.MinimumWidth, settings.Panel.Width);
            Assert.Equal(PanelEdge.Right, settings.Panel.Edge);

            settings.Panel.Width = 99999;
            settings.Normalize();
            Assert.Equal(PanelSettings.MaximumWidth, settings.Panel.Width);

            settings.Panel = null;
            settings.Normalize();
            Assert.True(settings.Panel.SidePanel);
        }

        [Fact]
        public void Panel_settings_survive_saving_and_the_edge_is_written_as_a_word()
        {
            using (var folder = new TempFolder())
            {
                var path = Path.Combine(folder.Path, "settings.json");
                var store = new SettingsStore(path);
                var settings = store.Load();
                settings.Panel.SidePanel = false;
                settings.Panel.Edge = PanelEdge.Left;
                settings.Panel.Width = 520;
                settings.Panel.Shortcut = "Alt+F9";
                settings.Panel.StartWithWindows = true;
                store.Save(settings);

                Assert.Contains("\"Edge\": \"Left\"", File.ReadAllText(path));
                var loaded = store.Load().Panel;
                Assert.False(loaded.SidePanel);
                Assert.Equal(PanelEdge.Left, loaded.Edge);
                Assert.Equal(520, loaded.Width);
                Assert.Equal("Alt+F9", loaded.Shortcut);
                Assert.True(loaded.StartWithWindows);
            }
        }

        [Fact]
        public void A_settings_file_from_before_the_side_panel_gets_the_defaults()
        {
            using (var folder = new TempFolder())
            {
                var path = Path.Combine(folder.Path, "settings.json");
                File.WriteAllText(path, "{}");

                var panel = new SettingsStore(path).Load().Panel;

                Assert.True(panel.SidePanel);
                Assert.Equal("Ctrl+Shift+Space", panel.Shortcut);
            }
        }
    }
}
