using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SmartRetail.AI.Settings
{
    /// <summary>
    /// A keyboard shortcut such as "Ctrl+Shift+Space" that works while any program is in front.
    /// It must use Ctrl, Alt or the Windows key, so ordinary typing in the POS is never taken over.
    /// </summary>
    public sealed class Hotkey
    {
        // Modifier flags as used by the Windows RegisterHotKey function.
        public const int AltFlag = 0x1;
        public const int ControlFlag = 0x2;
        public const int ShiftFlag = 0x4;
        public const int WindowsFlag = 0x8;

        public const string Default = "Ctrl+Shift+Space";

        // Windows virtual-key codes for the named keys a shortcut may use.
        private static readonly Dictionary<string, int> NamedKeys = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            ["Space"] = 0x20,
            ["PageUp"] = 0x21,
            ["PageDown"] = 0x22,
            ["End"] = 0x23,
            ["Home"] = 0x24,
            ["Insert"] = 0x2D,
            ["Delete"] = 0x2E,
            ["Pause"] = 0x13,
        };

        private Hotkey(int modifiers, string key, int virtualKey)
        {
            Modifiers = modifiers;
            Key = key;
            VirtualKey = virtualKey;
        }

        /// <summary>Combination of <see cref="ControlFlag"/>, <see cref="AltFlag"/>, <see cref="ShiftFlag"/> and <see cref="WindowsFlag"/>.</summary>
        public int Modifiers { get; }

        /// <summary>The key besides the modifiers, e.g. "Space", "A" or "F9".</summary>
        public string Key { get; }

        /// <summary>The Windows virtual-key code of <see cref="Key"/>.</summary>
        public int VirtualKey { get; }

        public static bool TryParse(string text, out Hotkey hotkey, out string problem)
        {
            hotkey = null;
            var parts = (text ?? "").Split('+').Select(part => part.Trim()).ToList();
            if (parts.Count < 2 || parts.Any(part => part.Length == 0))
            {
                problem = "Write a shortcut like Ctrl+Shift+Space.";
                return false;
            }

            var modifiers = 0;
            string key = null;
            var virtualKey = 0;
            foreach (var part in parts)
            {
                var flag = ModifierFlag(part);
                if (flag != 0)
                {
                    if ((modifiers & flag) != 0)
                    {
                        problem = "\"" + part + "\" appears twice.";
                        return false;
                    }

                    modifiers |= flag;
                }
                else if (key != null)
                {
                    problem = "Use one key besides Ctrl, Alt, Shift and Win.";
                    return false;
                }
                else if (!TryKey(part, out key, out virtualKey))
                {
                    problem = "\"" + part + "\" is not a key a shortcut can use (letters, digits, F1–F24, Space, Home, End, PageUp, PageDown, Insert, Delete, Pause).";
                    return false;
                }
            }

            if (key == null)
            {
                problem = "Add a key after the modifiers, e.g. Ctrl+Shift+Space.";
                return false;
            }

            if ((modifiers & (ControlFlag | AltFlag | WindowsFlag)) == 0)
            {
                problem = "Include Ctrl, Alt or Win, so normal typing in the POS is not affected.";
                return false;
            }

            problem = null;
            hotkey = new Hotkey(modifiers, key, virtualKey);
            return true;
        }

        /// <summary>The shortcut written the standard way, e.g. "Ctrl+Shift+Space".</summary>
        public override string ToString()
        {
            var parts = new List<string>();
            if ((Modifiers & ControlFlag) != 0)
            {
                parts.Add("Ctrl");
            }

            if ((Modifiers & AltFlag) != 0)
            {
                parts.Add("Alt");
            }

            if ((Modifiers & ShiftFlag) != 0)
            {
                parts.Add("Shift");
            }

            if ((Modifiers & WindowsFlag) != 0)
            {
                parts.Add("Win");
            }

            parts.Add(Key);
            return string.Join("+", parts);
        }

        private static int ModifierFlag(string part)
        {
            switch (part.ToLowerInvariant())
            {
                case "ctrl":
                case "control":
                    return ControlFlag;
                case "alt":
                    return AltFlag;
                case "shift":
                    return ShiftFlag;
                case "win":
                case "windows":
                    return WindowsFlag;
                default:
                    return 0;
            }
        }

        private static bool TryKey(string part, out string key, out int virtualKey)
        {
            // Letters and digits: the virtual-key code is the upper-case ASCII code.
            if (part.Length == 1 && part[0] < 128 && char.IsLetterOrDigit(part[0]))
            {
                var c = char.ToUpperInvariant(part[0]);
                key = c.ToString();
                virtualKey = c;
                return true;
            }

            if (part.Length > 1 && (part[0] == 'F' || part[0] == 'f')
                && int.TryParse(part.Substring(1), NumberStyles.None, CultureInfo.InvariantCulture, out var number)
                && number >= 1 && number <= 24)
            {
                key = "F" + number.ToString(CultureInfo.InvariantCulture);
                virtualKey = 0x70 + number - 1;
                return true;
            }

            foreach (var named in NamedKeys)
            {
                if (string.Equals(named.Key, part, StringComparison.OrdinalIgnoreCase))
                {
                    key = named.Key;
                    virtualKey = named.Value;
                    return true;
                }
            }

            key = null;
            virtualKey = 0;
            return false;
        }
    }
}
