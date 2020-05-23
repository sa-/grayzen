using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grayzen.State
{
    class TimedColorMode
    {
        private System.Windows.Forms.Timer timer;

        public void StartTimer(int milliseconds)
        {
            if(timer.Enabled) { return; }
            timer = new System.Windows.Forms.Timer();
            timer.Interval = milliseconds;
            timer.Tick += new EventHandler(BackToGrayscaleWhenTimedModeEnds);
            timer.Start();
        }

        public void EndTimerEarly()
        {
            timer.Dispose();
            AppState.GoGrey();
        }

        private static void BackToGrayscaleWhenTimedModeEnds(Object source, EventArgs e)
        {
            if (source is System.Windows.Forms.Timer timer)
            {
                timer.Dispose();
            }
            AppState.GoGrey();
        }

    }
}
