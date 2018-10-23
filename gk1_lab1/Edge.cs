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
        public enum Effect { none, vertical, horizontal, length };
        Effect state;
        double lenght;

        public Edge(Vertex v1, Vertex v2)
        {
            V1 = v1;
            V2 = v2;
            State = Effect.none;
            Color = colorGiver.Give();
        }
        public string getEffectSymbol()
        {
            string s = "";
            switch (State)
            {
                case Edge.Effect.horizontal:
                    s = "H";
                    break;
                case Edge.Effect.vertical:
                    s = "V";
                    break;
                case Edge.Effect.length:
                    s = "CL";
                    break;
            }
            return s;
        }

        public Color Color { get => color; set => color = value; }
        internal Vertex V1 { get => v1; set => v1 = value; }
        internal Vertex V2 { get => v2; set => v2 = value; }
        public double Lenght { get => lenght; set => lenght = value; }
        public Effect State { get => state;
            set
            {
                if (value == Effect.length)
                    Lenght = Vertex.calcDistance(V1, V2);
                state = value;
            }
        }


        static public int findYOnCircle(Vertex center, double R, int X, bool fromDown)
        {
            double a = center.X - X;
            int sgn = fromDown ? 1 : -1;
            return (int)Math.Sqrt((R * R) - (a * a))*sgn + center.Y;
        }

        static public int findXOnCircle(Vertex center, double R, int Y, bool fromLeft)
        {
            double a = center.Y - Y;
            int sgn = fromLeft ? 1 : -1;
            return (int)Math.Sqrt((R * R) - (a * a)) * sgn + center.X;
        }

        static public (int, int) calcIntersection(Edge e1, Edge e2)
        {
            double d = Vertex.calcDistance(e1.V1, e2.V2);
            double a = (e1.Lenght * e1.Lenght - e2.Lenght * e2.Lenght + d * d) / (2 * d);
            double h = Math.Sqrt(e1.Lenght * e1.Lenght - a * a);
            Vertex midV = new Vertex((int)(e1.V1.X + a * (e2.V2.X - e1.V1.X) / d), (int)(e1.V1.Y + a * (e2.V2.Y - e1.V1.Y) / d));
            Vertex out1 = new Vertex((int)(midV.X + h * (e2.V2.Y - e1.V1.Y) / d), (int)(midV.Y - h * (e2.V2.X - e1.V1.X) / d));
            Vertex out2 = new Vertex((int)(midV.X - h * (e2.V2.Y - e1.V1.Y) / d), (int)(midV.Y + h * (e2.V2.X - e1.V1.X) / d));
            if (Vertex.calcDistance(e1.V2, out1) < Vertex.calcDistance(e1.V2, out2))
                return (out1.X, out1.Y);
            else
                return (out2.X, out2.Y);
        }

        public bool isVertex() => false;

        //public Color Color => color;
    }
}