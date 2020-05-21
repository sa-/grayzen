using System;
using System.Windows.Forms;

namespace grayzen.HotkeyHandling
{
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        internal KeyPressedEventArgs(HotkeyModifierKeys modifier, Keys key)
        {
            Modifier = modifier;
            Key = key;
        }

        public HotkeyModifierKeys Modifier { get; }

        public Keys Key { get; }
    }
}
