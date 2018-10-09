using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gk1_lab1;
using System.Drawing;

namespace gk1_lab1
{
    class Edge : IPickable
    {
        Vertex v1, v2;
        Color color;

        public Edge(Vertex v1, Vertex v2)
        {
            V1 = v1;
            V2 = v2;
            Color = colorGiver.Give();
        }

        public Color Color { get => color; set => color = value; }
        internal Vertex V1 { get => v1; set => v1 = value; }
        internal Vertex V2 { get => v2; set => v2 = value; }

        public bool isVertex() => false;
    }
}