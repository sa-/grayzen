using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using grayzen.HotkeyHandling;
using System.Windows.Forms;

namespace grayzen.State
{
    using static NativeMethods;

    internal class AppState
    {
        private static State state;

        internal static void InitApp()
        {
            MagInitialize();
            SetKeyboardShortcut();
            GoGrey();
        }

        private static void SetKeyboardShortcut()
        {
            KeyboardHook hook = new KeyboardHook();
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            hook.RegisterHotKey(HotkeyModifierKeys.Control | HotkeyModifierKeys.Alt,
                Keys.Space);

            void hook_KeyPressed(object sender, KeyPressedEventArgs e)
            {
                ToggleTimedColourSession(5_000);
            }
        }

        static void ChangeState(State state)
        {
            AppState.state = state;
            RenderState();
        }

        internal static void ToggleBetweenGrayAndColour()
        {
            if (state == State.Gray) { ChangeState(State.Colour); }
            else if (state == State.Colour) { ChangeState(State.Gray); }
        }

        internal static void ToggleTimedColourSession(int milliseconds)
        {
            TimedColorSession.ToggleTimedColourSession(milliseconds);
            
        }

        static void RenderState()
        {
            if(state == State.Gray)
            {
                Grayscaler.GoGrey();
            }
            else if (state == State.Colour)
            {
                Grayscaler.DontTransformColor();
            }
        }
        internal static void GoGrey()
        {
            ChangeState(State.Gray);
        }

        internal static void GoColour()
        {
            ChangeState(State.Colour);
        }
    }
}
