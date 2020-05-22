using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace grayzen.State
{
    internal class AppActions
    {
        private static State state;

        static void ChangeState(State state)
        {
            AppActions.state = state;
            RenderState();
        }

        internal static void ToggleBetweenGrayAndColour()
        {
            if (state == State.Gray) { ChangeState(State.Normal); }
            else if (state == State.Normal) { ChangeState(State.Gray); }
        }

        internal static void EnableColourModeForTimeInterval()
        {
            if (state == State.Gray) { 
                ChangeState(State.Normal);
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += new EventHandler(OnTimedEvent);
                timer.Start();
            }
        }

        private static void OnTimedEvent(Object source, EventArgs e)
        {
            if (source is System.Windows.Forms.Timer timer)
            {
                timer.Stop();

            }
            ChangeState(State.Gray);
        }

        static void RenderState()
        {
            if(state == State.Gray)
            {
                Grayscaler.GoGrey();
            }
            else if (state == State.Normal)
            {
                Grayscaler.DontTransformColor();
            }
        }
        internal static void GoGrey()
        {
            ChangeState(State.Gray);
        }

        internal static void GoNormal()
        {
            ChangeState(State.Normal);
        }
    }
}
