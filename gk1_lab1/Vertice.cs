using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gk1_lab1;

namespace gk1_lab1
{
    class Vertice
    {
        float x, y;
        Edge before, after;
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        internal Edge Before { get => before; set => before = value; }
        internal Edge After { get => after; set => after = value; }  
    }
}
