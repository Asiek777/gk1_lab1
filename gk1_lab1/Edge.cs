using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gk1_lab1;
using System.Drawing;

namespace gk1_lab1
{
    class Edge
    {
        Vertice v1, v2;
        Color color;

        public Edge(Vertice v1, Vertice v2)
        {
            V1 = v1;
            V2 = v2;
            Color = colorGiver.Give();
        }

        public Color Color { get => color; set => color = value; }
        internal Vertice V1 { get => v1; set => v1 = value; }
        internal Vertice V2 { get => v2; set => v2 = value; }
    }
}