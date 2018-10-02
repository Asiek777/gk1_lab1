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
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        Edge before, after;
    }
}
