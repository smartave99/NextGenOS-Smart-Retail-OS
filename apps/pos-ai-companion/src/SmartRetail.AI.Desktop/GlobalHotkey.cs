using System;
using System.Windows.Forms;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Desktop
{
    /// <summary>A shortcut that works while any program, such as the POS, is in front. Pressed is raised on the UI thread.</summary>
    internal sealed class GlobalHotkey : NativeWindow, IDisposable
    {
        private const int WmHotkey = 0x0312;
        private const int NoRepeat = 0x4000;
        private const int HotkeyId = 0x5341;
        private static readonly IntPtr MessageOnlyParent = new IntPtr(-3);
        private bool _registered;

        public GlobalHotkey()
        {
            CreateHandle(new CreateParams { Parent = MessageOnlyParent });
        }

        public event EventHandler Pressed;

        /// <summary>False when another program already uses the shortcut.</summary>
        public bool Register(Hotkey hotkey)
        {
            Unregister();

            // NoRepeat stops a held-down shortcut from toggling the panel over and over.
            _registered = NativeMethods.RegisterHotKey(Handle, HotkeyId, hotkey.Modifiers | NoRepeat, hotkey.VirtualKey)
                || NativeMethods.RegisterHotKey(Handle, HotkeyId, hotkey.Modifiers, hotkey.VirtualKey);
            return _registered;
        }

        public void Unregister()
        {
            if (_registered)
            {
                NativeMethods.UnregisterHotKey(Handle, HotkeyId);
                _registered = false;
            }
        }

        public void Dispose()
        {
            Unregister();
            DestroyHandle();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WmHotkey && m.WParam.ToInt64() == HotkeyId)
            {
                Pressed?.Invoke(this, EventArgs.Empty);
                return;
            }

            base.WndProc(ref m);
        }
    }
}
