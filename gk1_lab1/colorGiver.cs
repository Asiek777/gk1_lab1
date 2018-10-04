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
        static public Color GiveColor()
        {
            Color color = Color.FromArgb(nextToGive >> 16, 
                (nextToGive >> 8) & 0xff, nextToGive & 0xff);
            nextToGive++;
            return color;
        }
    }
}
