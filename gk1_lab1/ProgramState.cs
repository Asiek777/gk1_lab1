using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk1_lab1
{
    class ProgramState
    {
        List<Vertex> vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();
        Dictionary<int, IPickable> finder = new Dictionary<int, IPickable>();
        DoublePictureBox myPictureBox;


        Vertex lastVertex, firstVertex;
        Color chosenColor;
        IPickable chosenPrimitive;
        bool isClosed = false;
        int posX, posY;



        public Color ChosenColor { get => chosenColor; set => chosenColor = value; }
        public bool IsClosed { get => isClosed; set => isClosed = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        internal List<Vertex> Vertices { get => vertices; set => vertices = value; }
        internal List<Edge> Edges { get => edges; set => edges = value; }
        internal Dictionary<int, IPickable> Finder { get => finder; set => finder = value; }
        internal IPickable ChosenPrimitive { get => chosenPrimitive; set => chosenPrimitive = value; }
        internal DoublePictureBox MyPictureBox { get => myPictureBox; set => myPictureBox = value; }
        internal Vertex LastVertex { get => lastVertex; set => lastVertex = value; }
        internal Vertex FirstVertex { get => firstVertex; set => firstVertex = value; }
    }
}
