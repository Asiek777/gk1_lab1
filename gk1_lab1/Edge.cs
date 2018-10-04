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
        internal Vertice V1 { get => v1; set => v1 = value; }
        internal Vertice V2 { get => v2; set => v2 = value; }
    }
}