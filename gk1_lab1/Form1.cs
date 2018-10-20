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
        const int lineWidth = 2;
        ProgramState s = new ProgramState();
        private DoublePictureBox myPictureBox;

        

        public MainWindow()
        {
            InitializeComponent();
            myPictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
            s.MyPictureBox = myPictureBox;
            pictureBoxVisible.ContextMenuStrip = changeContextMenu;
        }

        void addVertex(int x, int y, Vertex beforeV=null, Vertex afterV = null)
        {
            Vertex v = new Vertex(x, y);

            if (beforeV != null)
                AddEdge(beforeV, v);
            else
                s.FirstVertex = v;
            if (afterV != null)
                AddEdge(v, afterV);
            s.Vertices.Add(v);
            s.Finder.Add(v.Color.ToArgb(), v);
            s.LastVertex = v;
            pictureBoxPicker.Refresh();
        }

        private Edge AddEdge(Vertex v1, Vertex v2)
        {
            Edge e = new Edge(v1, v2);
            v1.After = e;
            v2.Before = e;
            s.Edges.Add(e);
            s.Finder.Add(e.Color.ToArgb(), e);
            return e;
        }

        private void pictureBoxPicker_Paint(object sender, PaintEventArgs e)
        {
            foreach (Edge edge in s.Edges)
            {
                e.Graphics.DrawLine(new Pen(edge.Color, lineWidth * 5), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            }
            foreach (Vertex v in s.Vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - 4 * pointSize, (int)v.Y - (4 * pointSize), 8 * pointSize, 8 * pointSize);
                e.Graphics.FillEllipse(new SolidBrush(v.Color), circle);
            }
        }

        private void pictureBoxVisible_Paint(object sender, PaintEventArgs e)
        {     
            foreach (Edge edge in s.Edges)
                drawEdgeVisible(e, edge);

            foreach (Vertex v in s.Vertices)
                drawVertexVisible(e, v);

            if (s.ShowcaseVertex != null)
                drawVertexVisible(e, s.ShowcaseVertex);
            if (s.ShowcaseEdge != null)
                drawEdgeVisible(e, s.ShowcaseEdge);
        }

        private void drawEdgeVisible(PaintEventArgs e, Edge edge)
        {
            if (edge.Color == s.HighlightColor)
                e.Graphics.DrawLine(new Pen(Color.Red, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            else
                e.Graphics.DrawLine(new Pen(Color.Black, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
        }

        private void drawVertexVisible(PaintEventArgs e, Vertex v)
        {
            Rectangle circle = new Rectangle((int)v.X - pointSize, (int)v.Y - pointSize, 2 * pointSize, 2 * pointSize);
            if (v.Color == s.HighlightColor)
                e.Graphics.FillEllipse(Brushes.Red, circle);
            else
                e.Graphics.FillEllipse(Brushes.Black, circle);
        }

        private void pictureBoxVisible_MouseDown(object sender, MouseEventArgs e)
        {
            Color color = myPictureBox.pickColor(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (!s.IsClosed)
                {
                    if (color.ToArgb() == pictureBoxPicker.BackColor.ToArgb())
                    {
                        addVertex(e.X, e.Y, s.LastVertex);
                        myPictureBox.OnChange();
                    }
                    else if (s.FirstVertex != null && color.ToArgb() == s.FirstVertex.Color.ToArgb())
                    {
                        Edge edge = AddEdge(s.LastVertex, s.FirstVertex);
                        s.IsClosed = true;
                        pictureBoxVisible.MouseMove += highlightPrimitive;
                        myPictureBox.OnChange();
                    }
                }
                else
                {
                    if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
                    {
                        s.ChosenColor = color;
                        s.ChosenPrimitive = s.Finder[s.ChosenColor.ToArgb()];
                        s.PosX = e.X;
                        s.PosY = e.Y;
                        if (s.ChosenPrimitive.isVertex())
                        {
                            pictureBoxVisible.MouseMove -= highlightPrimitive;
                            pictureBoxVisible.MouseMove += moveVertex;
                        }
                        else
                        {
                            pictureBoxVisible.MouseMove -= highlightPrimitive;
                            pictureBoxVisible.MouseMove += moveEdge;
                        }

                        myPictureBox.Refresh();
                    }
                    else
                    {
                        s.PosX = e.X;
                        s.PosY = e.Y;
                        s.ChosenPrimitive = new Vertex(e.X, e.Y);
                        pictureBoxVisible.MouseMove += moveVertex;
                        s.ShowcaseVertex = new Vertex(e.X, e.Y);
                        s.ShowcaseEdge = new Edge(s.ShowcaseVertex, s.ChosenPrimitive as Vertex);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
                {
                    s.ChosenPrimitive = s.Finder[color.ToArgb()];
                    if (s.ChosenPrimitive.isVertex())
                    {
                        deleteVertexToolStripMenuItem.Enabled = true;
                    }
                    else
                        foreach (ToolStripItem toolStrip in changeContextMenu.Items)
                            toolStrip.Enabled = true;
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

        private void moveEdge(object sender, MouseEventArgs e)
        {
            Edge edge = (Edge)s.ChosenPrimitive;
            edge.V1.X += e.X - s.PosX;
            edge.V1.Y += e.Y - s.PosY;
            edge.V2.X += e.X - s.PosX;
            edge.V2.Y += e.Y - s.PosY;
            s.PosX = e.X;
            s.PosY = e.Y;
            myPictureBox.Refresh();
        }


        private void highlightPrimitive(object sender, MouseEventArgs e)
        {
            Color c = myPictureBox.pickColor(e.X, e.Y);
            if (c != s.HighlightColor)
            {
                s.HighlightColor = c;
                myPictureBox.Refresh();
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
            s.Vertices = new List<Vertex>();
            s.Edges = new List<Edge>();
            s.Finder = new Dictionary<int, IPickable>();
            colorGiver.Reset();
            s.IsClosed = false;
            s.FirstVertex = null;
            s.LastVertex = null;
            pictureBoxVisible.MouseMove -= highlightPrimitive;
            myPictureBox.OnChange();

        }

        private void pictureBoxVisible_MouseUp(object sender, MouseEventArgs e)
        {
            if (s.ShowcaseVertex != null)
            {
                if (s.HighlightColor.ToArgb() != pictureBoxPicker.BackColor.ToArgb()
                    && !s.Finder[s.HighlightColor.ToArgb()].isVertex())
                {
                    Edge edge = (Edge)s.Finder[s.HighlightColor.ToArgb()];
                    s.Edges.Remove(edge);
                    addVertex(s.ShowcaseVertex.X, s.ShowcaseVertex.Y, edge.V1, edge.V2);
                }
                s.ShowcaseEdge = null;
                s.ShowcaseVertex = null;
                s.ChosenPrimitive = null;
            }
            pictureBoxVisible.MouseMove -= moveVertex;
            pictureBoxVisible.MouseMove -= moveEdge;
            if (s.IsClosed)
            {
                pictureBoxVisible.MouseMove -= highlightPrimitive;
                pictureBoxVisible.MouseMove += highlightPrimitive;
            }
            myPictureBox.OnChange();
        }

        private void deleteVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vertex v = (Vertex)s.ChosenPrimitive;
            s.Vertices.Remove(v);
            AddEdge(v.Before.V1, v.After.V2);
            s.Edges.Remove(v.After);
            s.Edges.Remove(v.Before);
            deleteVertexToolStripMenuItem.Enabled = false;
            myPictureBox.OnChange();
        }

        private void switchEdgeState(Edge e, Edge.Effect effect)
        {
            if (e.State != effect)
                e.State = effect;
            else
                e.State = Edge.Effect.none;
            foreach (ToolStripItem toolStrip in changeContextMenu.Items)
                toolStrip.Enabled = false;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.pion);

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.poziom);

        private void constLengthToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.poziom);
    }
}
