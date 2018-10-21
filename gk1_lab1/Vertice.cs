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

        public (Edge[], Vertex[]) beforeDirection()
        {
            Vertex v = Before.V1;
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            while (v != this)
            {
                edges.Add(v.After);
                vertices.Add(v);
                v = v.Before.V1;
            }
            return (edges.ToArray(), vertices.ToArray());
        }

        public (Edge[], Vertex[]) afterDirection()
        {
            Vertex v = After.V2;
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            while (v != this)
            {
                edges.Add(v.Before);
                vertices.Add(v);
                v = v.After.V2;
            }
            return (edges.ToArray(), vertices.ToArray());
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
