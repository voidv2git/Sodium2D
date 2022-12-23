using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sodium.Game_Engine
{
    class Animate
    {
        List<Image> frames = new List<Image>();
        int inc = 0;
        int count = 0;
        int delay = 10;

        public Animate(int delay)
        {
            this.delay = delay;
        }

        public Image PlayOneFrame()
        {
            count++;
            if (count % delay == 0)
            {
                inc = (inc == frames.Count) ? 0 : inc + 1;
            }
            return frames[inc - 1];
        }

        public void AddFrame(Image frame)
        {
            frames.Add(frame);
        }
    }
}
