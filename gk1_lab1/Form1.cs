﻿using System;
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
        ProgramState s = new ProgramState();
        private DoublePictureBox myPictureBox;

        

        public MainWindow()
        {
            InitializeComponent();
            myPictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
            s.MyPictureBox = myPictureBox;
        }

        void addVertex(int x, int y, Edge e1 = null, Edge e2 = null)
        {
            Vertex v = new Vertex(x, y, e1, e2);
            if (!s.IsClosed)
            {
                if (s.LastVertex != null)
                {
                    Edge e = AddEdge(s.LastVertex, v);
                    s.LastVertex.After = e;
                    v.Before = e;
                }
                else
                    s.FirstVertex = v;
                s.Vertices.Add(v);
                s.Finder.Add(v.Color.ToArgb(), v);
                s.LastVertex = v;
                pictureBoxPicker.Refresh();
            }
        }

        private Edge AddEdge(Vertex v1, Vertex v2)
        {
            Edge e = new Edge(v1, v2);
            s.Edges.Add(e);
            s.Finder.Add(e.Color.ToArgb(), e);
            return e;
        }

        private void pictureBoxPicker_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in s.Edges)
            {
                e.Graphics.DrawLine(new Pen(edge.Color, lineWidth * 2), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertex v in s.Vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - 2 * pointSize, (int)v.Y - (2 * pointSize), 4 * pointSize, 4 * pointSize);
                e.Graphics.FillEllipse(new SolidBrush(v.Color), circle);
            }
        }

        private void pictureBoxVisible_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in s.Edges)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertex v in s.Vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - pointSize, (int)v.Y - pointSize, 2 * pointSize, 2 * pointSize);
                if (v.Color == s.ChosenColor)
                    e.Graphics.FillEllipse(Brushes.Red, circle);
                else
                    e.Graphics.FillEllipse(Brushes.Black, circle);
            }
        }

        private void pictureBoxVisible_MouseDown(object sender, MouseEventArgs e)
        {
            if (!s.IsClosed)
            {
                Color color = myPictureBox.pickColor(e.X, e.Y);
                if (color.ToArgb() == pictureBoxPicker.BackColor.ToArgb())
                {                    
                    addVertex(e.X, e.Y);
                    myPictureBox.OnChange();
                }
                else if (s.FirstVertex != null && color.ToArgb() == s.Vertices[0].Color.ToArgb())
                {
                    Edge edge = AddEdge(s.LastVertex, s.FirstVertex);
                    s.LastVertex.After = edge;
                    s.FirstVertex.Before = edge;
                    s.IsClosed = true;
                    myPictureBox.OnChange();
                }
            }
            else
            {
                Color color = myPictureBox.pickColor(e.X, e.Y);
                if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
                {
                    s.ChosenColor = color;
                    s.ChosenPrimitive = s.Finder[s.ChosenColor.ToArgb()];
                    if (s.ChosenPrimitive.isVertex())
                    {                        
                        s.PosX = e.X;
                        s.PosY = e.Y;
                        pictureBoxVisible.MouseMove += moveVertex;
                    }
                    myPictureBox.Refresh();
                }
            }
        }

        private void moveVertex(object sender, MouseEventArgs e)
        {
            Vertex v = (Vertex)s.ChosenPrimitive;
            v.X += e.X - s.PosX;
            v.Y += e.Y - s.PosY;
            s.PosX = e.X;
            s.PosY = e.Y;
            myPictureBox.Refresh();
        }

        private void highlightPrimitive(object sender, MouseEventArgs e)
        {
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
            s.Vertices = new List<Vertex>();
            s.Edges = new List<Edge>();
            s.Finder = new Dictionary<int, IPickable>();
            colorGiver.Reset();
            s.IsClosed = false;
            s.FirstVertex = null;
            s.LastVertex = null;
            myPictureBox.OnChange();

        }

        private void pictureBoxVisible_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxVisible.MouseMove -= moveVertex;
            myPictureBox.OnChange();
        }
    }
}
