using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>Label/control rows for the settings tabs.</summary>
    internal static class FormLayout
    {
        public static TableLayoutPanel NewGrid()
        {
            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                Padding = new Padding(12, 6, 18, 12),
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            return grid;
        }

        public static TabPage Page(string title, TableLayoutPanel grid)
        {
            var page = new TabPage(title) { AutoScroll = true, Padding = new Padding(4) };
            page.Controls.Add(grid);
            return page;
        }

        public static void Heading(TableLayoutPanel grid, string text)
        {
            Span(grid, new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10.5f),
                Margin = new Padding(0, 14, 0, 4),
            });
        }

        public static void Note(TableLayoutPanel grid, string text)
        {
            var row = NewRow(grid);
            grid.Controls.Add(new Label
            {
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(560, 0),
                ForeColor = Color.DimGray,
                Margin = new Padding(3, 0, 3, 8),
            }, 1, row);
        }

        public static T Row<T>(TableLayoutPanel grid, string label, T control)
            where T : Control
        {
            var row = NewRow(grid);
            grid.Controls.Add(new Label { Text = label, AutoSize = true, Margin = new Padding(3, 7, 3, 3) }, 0, row);
            grid.Controls.Add(control, 1, row);
            return control;
        }

        public static void Span(TableLayoutPanel grid, Control control)
        {
            var row = NewRow(grid);
            grid.Controls.Add(control, 0, row);
            grid.SetColumnSpan(control, 2);
        }

        public static FlowLayoutPanel Inline(params Control[] controls)
        {
            var panel = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0) };
            panel.Controls.AddRange(controls);
            return panel;
        }

        public static TextBox Text(string value, int width = 380) => new TextBox { Text = value ?? "", Width = width };

        public static NumericUpDown Number(int value, int minimum, int maximum)
        {
            return new NumericUpDown
            {
                Minimum = minimum,
                Maximum = maximum,
                Value = Math.Min(maximum, Math.Max(minimum, value)),
                Width = 90,
            };
        }

        public static ComboBox Choice(string value, params string[] options)
        {
            var box = new ComboBox { DropDownStyle = ComboBoxStyle.DropDown, Width = 160 };
            box.Items.AddRange(options);
            box.Text = value ?? "";
            return box;
        }

        private static int NewRow(TableLayoutPanel grid)
        {
            var row = grid.RowCount++;
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            return row;
        }
    }

    /// <summary>A password box that never shows the saved value: type to replace it, or remove it.</summary>
    internal sealed class SecretField : FlowLayoutPanel
    {
        private readonly TextBox _box = new TextBox { Width = 320, UseSystemPasswordChar = true };
        private readonly Button _remove = new Button { Text = "Remove", AutoSize = true };
        private readonly Label _state = new Label { AutoSize = true, ForeColor = Color.DimGray, Margin = new Padding(6, 7, 3, 3) };
        private readonly bool _hasSavedValue;
        private bool _removed;

        public SecretField(bool hasSavedValue)
        {
            _hasSavedValue = hasSavedValue;
            AutoSize = true;
            WrapContents = false;
            Margin = new Padding(0);
            Controls.AddRange(new Control[] { _box, _remove, _state });
            _box.TextChanged += (sender, args) => UpdateState();
            _remove.Click += (sender, args) =>
            {
                _box.Clear();
                _removed = true;
                UpdateState();
            };
            UpdateState();
        }

        public string TypedValue => _box.Text.Trim();

        /// <summary>The value the user means right now: typed, saved, or none if removed.</summary>
        public string CurrentValue(SecretStore store, string name)
        {
            if (TypedValue.Length > 0)
            {
                return TypedValue;
            }

            return _removed ? null : store.Get(name);
        }

        public void SetTyped(string value)
        {
            _box.Text = value ?? "";
        }

        public void Apply(SecretStore store, string name)
        {
            if (TypedValue.Length > 0)
            {
                store.Set(name, TypedValue);
            }
            else if (_removed)
            {
                store.Set(name, null);
            }
        }

        private void UpdateState()
        {
            _remove.Enabled = (_hasSavedValue && !_removed) || TypedValue.Length > 0;
            _state.Text = TypedValue.Length > 0 ? "will be saved"
                : _removed ? "will be removed"
                : _hasSavedValue ? "saved (encrypted)" : "not set";
        }
    }

    internal static class CueBanner
    {
        private const int EmSetCueBanner = 0x1501;

        /// <summary>Grey hint text in an empty TextBox (Windows cue banner).</summary>
        public static void Set(TextBox box, string text)
        {
            box.HandleCreated += (sender, args) => SendMessage(box.Handle, EmSetCueBanner, (IntPtr)1, text);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
    }
}
