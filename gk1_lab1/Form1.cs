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
        List<Vertice> vertices = new List<Vertice>();
        List<Edge> edges = new List<Edge>();
        private DoublePictureBox doublePictureBox;
        Color chosenColor;
        bool isClosed = false;

        public MainWindow()
        {
            InitializeComponent();
            doublePictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
        }

        void addVertice(int x, int y)
        {
            if (!isClosed)
            {
                Vertice v = new Vertice(x, y);
                if (vertices.Count > 0)
                {
                    Edge e = new Edge(vertices[vertices.Count - 1], v);
                    edges.Add(e);
                    vertices[vertices.Count - 1].After = e;
                    v.Before = e;
                }
                vertices.Add(v);
            }
        }

        private void pictureBoxPicker_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in edges)
            {
                e.Graphics.DrawLine(new Pen(edge.Color, lineWidth * 2), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertice v in vertices)
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
            foreach (Vertice v in vertices)
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
                Color color = doublePictureBox.pickColor(e.X, e.Y);
                if (color.ToArgb() == pictureBoxPicker.BackColor.ToArgb())
                {
                    addVertice(e.X, e.Y);
                    doublePictureBox.OnChange();
                }
                else if (vertices.Count > 1 && color.ToArgb() == vertices[0].Color.ToArgb())
                {
                    Edge edge = new Edge(vertices[vertices.Count - 1], vertices[0]);
                    edges.Add(edge);
                    vertices[vertices.Count - 1].After = edge;
                    vertices[0].Before = edge;
                    isClosed = true;
                    doublePictureBox.OnChange();
                }
            }
            else
            {
                //Color color = doublePictureBox.pickColor(e.X, e.Y);
                //if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
                //{
                //    chosenColor = color;
                //    doublePictureBox.Refresh();
                //}
                //else
                //{
                //    addVertice(e.X, e.Y);
                //    doublePictureBox.OnChange();
                //}
            }
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
            vertices = new List<Vertice>();
            edges = new List<Edge>();
            colorGiver.Reset();
            isClosed = false;
            doublePictureBox.OnChange();
        }
    }
}
