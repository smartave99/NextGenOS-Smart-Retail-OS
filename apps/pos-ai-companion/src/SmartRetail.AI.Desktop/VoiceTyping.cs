using System;
using System.Runtime.InteropServices;

namespace SmartRetail.AI.Desktop
{
    /// <summary>
    /// Starts Windows voice typing (Windows+H), which types what is said into the box that has the focus: a way to
    /// talk to Ask AI when the AI itself does not take voice notes. Windows shows its own microphone bar, and the owner
    /// stops it there.
    /// </summary>
    internal static class VoiceTyping
    {
        private const uint InputKeyboard = 1;
        private const uint KeyUp = 0x0002;
        private const ushort WindowsKey = 0x5B;
        private const ushort LetterH = 0x48;

        public static void Start()
        {
            var inputs = new[]
            {
                Key(WindowsKey, down: true),
                Key(LetterH, down: true),
                Key(LetterH, down: false),
                Key(WindowsKey, down: false),
            };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        private static Input Key(ushort key, bool down) => new Input
        {
            Type = InputKeyboard,
            Union = new InputUnion { Keyboard = new KeyboardInput { VirtualKey = key, Flags = down ? 0 : KeyUp } },
        };

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint count, Input[] inputs, int size);

        [StructLayout(LayoutKind.Sequential)]
        private struct Input
        {
            public uint Type;
            public InputUnion Union;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public MouseInput Mouse;

            [FieldOffset(0)]
            public KeyboardInput Keyboard;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardInput
        {
            public ushort VirtualKey;
            public ushort ScanCode;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MouseInput
        {
            public int X;
            public int Y;
            public uint Data;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }
    }
}
