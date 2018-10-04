using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gk1_lab1
{
    static class colorGiver
    {
        static int nextToGive = 0;
        static public Color Give()
        {
            Color color = Color.FromArgb(nextToGive >> 16, 
                (nextToGive >> 8) & 0xff, nextToGive & 0xff);
            nextToGive += 10; //TODO: switch to 1
            return color;
        }
    }
}
