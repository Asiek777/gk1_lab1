using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gk1_lab1;
using System.Drawing;

namespace gk1_lab1
{
    class Vertex : IPickable
    {
        int x, y;
        Edge before, after;
        Color color;

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
            Color = colorGiver.Give();
        }

        public Vertex(int x, int y, Edge before, Edge after) : this(x, y)
        {
            Before = before;
            After = after;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Color Color { get => color; set => color = value; }
        internal Edge Before { get => before; set => before = value; }
        internal Edge After { get => after; set => after = value; }

        //public Color Color => color;

        public bool isVertex() => true;
    }
}
