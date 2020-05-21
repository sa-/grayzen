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

        internal static void ColorFor1Min()
        {
            if (state == State.Gray) { 
                ChangeState(State.Normal);
                var timer = new Timer(1000);
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = false;
                timer.Start();
            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
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
