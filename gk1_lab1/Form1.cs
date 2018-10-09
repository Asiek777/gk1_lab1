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
    public partial class MainWindow : Form
    {
        const int pointSize = 5;
        const int lineWidth = 3;

        List<Vertex> Vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();
        Dictionary<int, IPickable> finder = new Dictionary<int, IPickable>();
        private DoublePictureBox myPictureBox;

        Color chosenColor;
        IPickable chosenPrimitive;
        bool isClosed = false;
        int posX, posY;
        

        public MainWindow()
        {
            InitializeComponent();
            myPictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
        }

        void addVertex(int x, int y)
        {
            if (!isClosed)
            {
                Vertex v = new Vertex(x, y);
                if (Vertices.Count > 0)
                {
                    Edge e = AddEdge(Vertices[Vertices.Count - 1], v);
                    Vertices[Vertices.Count - 1].After = e;
                    v.Before = e;
                }
                Vertices.Add(v);
                finder.Add(v.Color.ToArgb(), v);
            }
        }

        private Edge AddEdge(Vertex v1, Vertex v2)
        {
            Edge e = new Edge(v1, v2);
            edges.Add(e);
            finder.Add(e.Color.ToArgb(), e);
            return e;
        }

        private void pictureBoxPicker_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in edges)
            {
                e.Graphics.DrawLine(new Pen(edge.Color, lineWidth * 2), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertex v in Vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - 2 * pointSize, (int)v.Y - (2 * pointSize), 4 * pointSize, 4 * pointSize);
                e.Graphics.FillEllipse(new SolidBrush(v.Color), circle);
            }
        }

        private void pictureBoxVisible_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in edges)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertex v in Vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - pointSize, (int)v.Y - pointSize, 2 * pointSize, 2 * pointSize);
                if (v.Color == chosenColor)
                    e.Graphics.FillEllipse(Brushes.Red, circle);
                else
                    e.Graphics.FillEllipse(Brushes.Black, circle);
            }
        }

        private void pictureBoxVisible_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isClosed)
            {
                Color color = myPictureBox.pickColor(e.X, e.Y);
                if (color.ToArgb() == pictureBoxPicker.BackColor.ToArgb())
                {
                    addVertex(e.X, e.Y);
                    myPictureBox.OnChange();
                }
                else if (Vertices.Count > 1 && color.ToArgb() == Vertices[0].Color.ToArgb())
                {
                    Edge edge = AddEdge(Vertices[Vertices.Count - 1], Vertices[0]);
                    Vertices[Vertices.Count - 1].After = edge;
                    Vertices[0].Before = edge;
                    isClosed = true;
                    myPictureBox.OnChange();
                }
            }
            else
            {
                Color color = myPictureBox.pickColor(e.X, e.Y);
                if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
                {
                    chosenColor = color;
                    chosenPrimitive = finder[chosenColor.ToArgb()];
                    if (chosenPrimitive.isVertex())
                    {
                        pictureBoxVisible.MouseMove += moveVertex;
                        posX = e.X;
                        posY = e.Y;
                    }
                    myPictureBox.Refresh();
                }
            }
        }

        private void moveVertex(object sender, MouseEventArgs e)
        {
            Vertex v = (Vertex)chosenPrimitive;
            v.X += e.X - posX;
            v.Y += e.Y - posY;
            posX = e.X;
            posY = e.Y;
            myPictureBox.Refresh();
        }

        private void swapBoxBut_Click(object sender, EventArgs e)
        {
            if (pictureBoxVisible.Visible)
                pictureBoxVisible.Hide();
            else
                pictureBoxVisible.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            Vertices = new List<Vertex>();
            edges = new List<Edge>();
            finder = new Dictionary<int, IPickable>();
            colorGiver.Reset();
            isClosed = false;
            myPictureBox.OnChange();
        }

        private void pictureBoxVisible_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxVisible.MouseMove -= moveVertex;
            myPictureBox.OnChange();
        }
    }
}
