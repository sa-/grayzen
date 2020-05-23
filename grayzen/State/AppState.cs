namespace grayzen.State
{
    using static NativeMethods;

    internal class AppState
    {
        private static State state;

        internal static void InitApp()
        {
            MagInitialize();
            GoGrey();
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
            if (state == State.Gray)
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
