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
        float x, y;
        Edge before, after;
        Color color;

        public Vertex(float x, float y)
        {
            X = x;
            Y = y;
            Color = colorGiver.Give();
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public Color Color { get => color; set => color = value; }
        internal Edge Before { get => before; set => before = value; }
        internal Edge After { get => after; set => after = value; }

        public bool isVertex()
        {
            return true;
        }
    }
}
