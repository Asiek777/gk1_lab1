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
            pictureBoxVisible.Image = new Bitmap(pictureBoxVisible.Width, pictureBoxVisible.Height);
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
            myPictureBox.DrawBitmap = (Bitmap)pictureBoxVisible.Image;
            Graphics.FromImage(myPictureBox.DrawBitmap).Clear(pictureBoxVisible.BackColor);
            foreach (Edge edge in s.Edges)
                drawEdgeVisible(e, edge);
            //pictureBoxVisible.Image = myPictureBox.DrawBitmap.;
            foreach (Edge edge in s.Edges)
                e.Graphics.DrawString(edge.getEffectSymbol(), SystemFonts.MessageBoxFont, Brushes.Black, (edge.V1.X + edge.V2.X) / 2 + 5, (edge.V1.Y + edge.V2.Y) / 2 - 15);

            foreach (Vertex v in s.Vertices)
                drawVertexVisible(e, v);

            if (s.ShowcaseVertex != null)
                drawVertexVisible(e, s.ShowcaseVertex);
            if (s.ShowcaseEdge != null)
                drawEdgeVisible(e, s.ShowcaseEdge);
        }

        private void drawEdgeVisible(PaintEventArgs e, Edge edge)
        {
            Color color;
            if (edge.Color == s.HighlightColor)
                color = Color.Red;
            //e.Graphics.DrawLine(new Pen(Color.Red, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
            else
                color = Color.Black;
            line(edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y, color);
                //e.Graphics.DrawLine(new Pen(Color.Black, lineWidth), edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);

        }

        private void line(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x > 0 && x < pictureBoxVisible.Width && y > 0 && y < pictureBoxVisible.Height)
                    myPictureBox.DrawBitmap.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
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
                            (s.BeforeDirEdges, s.BeforeDirVertices) = ((Vertex)s.ChosenPrimitive).beforeDirection();
                            (s.AfterDirEdges, s.AfterDirVertices) = ((Vertex)s.ChosenPrimitive).afterDirection();
                            pictureBoxVisible.MouseMove += moveVertex;
                        }
                        else
                        {
                            pictureBoxVisible.MouseMove -= highlightPrimitive;
                            (s.BeforeDirEdges, s.BeforeDirVertices) = ((Edge)s.ChosenPrimitive).V1.beforeDirection();
                            (s.AfterDirEdges, s.AfterDirVertices) = ((Edge)s.ChosenPrimitive).V2.afterDirection();
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
                    prepareContextMenu();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                pictureBoxVisible.MouseMove -= highlightPrimitive;
                s.PosX = e.X;
                s.PosY = e.Y;
                pictureBoxVisible.MouseMove += moveEverything;
            }
        }

        private void moveVertex(object sender, MouseEventArgs e)
        {
            Vertex v = (Vertex)s.ChosenPrimitive;
            v.X += e.X - s.PosX;
            v.Y += e.Y - s.PosY;

            if (v.After != null)
            {
                adjustPosition(s.BeforeDirEdges, s.BeforeDirVertices, v, e);
                adjustPosition(s.AfterDirEdges, s.AfterDirVertices, v, e);
            }

            myPictureBox.Refresh();
            s.PosX = e.X;
            s.PosY = e.Y;
        }

        private void moveEdge(object sender, MouseEventArgs e)
        {
            Edge edge = (Edge)s.ChosenPrimitive;
            edge.V1.X += e.X - s.PosX;
            edge.V1.Y += e.Y - s.PosY;
            edge.V2.X += e.X - s.PosX;
            edge.V2.Y += e.Y - s.PosY;
            if (edge.V2.After != null)
            {
                adjustPosition(s.BeforeDirEdges, s.BeforeDirVertices, edge.V1, e);
                adjustPosition(s.AfterDirEdges, s.AfterDirVertices, edge.V2, e);
            }
            s.PosX = e.X;
            s.PosY = e.Y;
            myPictureBox.Refresh();
        }

        private void moveEverything(object sender, MouseEventArgs e)
        {
            foreach (Vertex v in s.Vertices)
            {
                v.X += e.X - s.PosX;
                v.Y += e.Y - s.PosY;
            }
            myPictureBox.Refresh();
            s.PosX = e.X;
            s.PosY = e.Y;
        }

        private void adjustPosition(Edge[] edges, Vertex[] vertices, Vertex v, MouseEventArgs e=null)
        {
            if (vertices.Length < 2)
                return;
            void restart(int i)
            {
                adjustPosition(edges.Skip(i).ToArray(), vertices.Skip(i).ToArray(), vertices[i-1], e);
            }
            switch (edges[0].State)
            {
                case Edge.Effect.vertical:
                    vertices[0].X = v.X;
                    if (edges[1].State != Edge.Effect.length)
                        return;
                    else if (edges[1].Lenght > Math.Abs(vertices[0].X - vertices[1].X))
                        vertices[0].Y = Edge.findYOnCircle(vertices[1], edges[1].Lenght, vertices[0].X, vertices[1].Y < vertices[0].Y);
                    else
                        restart(1);


                    break;
                case Edge.Effect.horizontal:
                    vertices[0].Y = v.Y;
                    if (edges[1].State != Edge.Effect.length)
                        return;
                    else if (edges[1].Lenght > Math.Abs(vertices[0].Y - vertices[1].Y))
                        vertices[0].X = Edge.findXOnCircle(vertices[1], edges[1].Lenght, vertices[0].Y, vertices[1].X < vertices[0].X);
                    else
                        restart(1);
                    break;

                case Edge.Effect.length:
                    if (edges[1].State == Edge.Effect.none)
                    {
                        if (e != null)
                        {
                            vertices[0].X += e.X - s.PosX;
                            vertices[0].Y += e.Y - s.PosY;
                        }
                    }
                    else if (edges[1].State == Edge.Effect.horizontal)
                    {
                        if (edges[0].Lenght > Math.Abs(v.Y - vertices[0].Y))
                            vertices[0].X = Edge.findXOnCircle(v, edges[0].Lenght, vertices[0].Y, v.X < vertices[0].X);
                        else
                        {
                            vertices[0].Y = v.Y - vertices[0].Y > 0 ? v.Y - (int)edges[0].Lenght : v.Y + (int)edges[0].Lenght;
                            restart(1);
                        }
                    }
                    else if (edges[1].State == Edge.Effect.vertical)
                    {
                        if (edges[0].Lenght > Math.Abs(v.X - vertices[0].X))
                            vertices[0].Y = Edge.findYOnCircle(v, edges[0].Lenght, vertices[0].X, v.Y < vertices[0].Y);
                        else
                        {
                            vertices[0].X = v.X - vertices[0].X > 0 ? v.X - (int)edges[0].Lenght : v.X + (int)edges[0].Lenght;
                            restart(1);
                        }
                    }
                    else
                    {
                        double dist = Vertex.calcDistance(v, vertices[1]);
                        if (dist < edges[0].Lenght + edges[1].Lenght && dist > Math.Abs(edges[0].Lenght - edges[1].Lenght))
                        {
                            (vertices[0].X, vertices[0].Y) = Edge.calcIntersection(vertices[0].Before, vertices[0].After);
                        }
                        else
                        {
                            //if (dist > edges[0].Lenght + edges[1].Lenght)
                            //{
                                edges[1] = new Edge(vertices[0].Before.V1, vertices[0].After.V2);
                                edges[1].State = Edge.Effect.length;
                            if (vertices[1].Before == edges[2])
                                vertices[1].After = edges[1];
                            else
                                vertices[1].Before = edges[1];
                            if (v.After == edges[0])
                                v.After = edges[1];
                            else
                                v.Before = edges[1];
                            adjustPosition(edges.Skip(1).ToArray(), vertices.Skip(1).ToArray(), v, e);
                            //}
                            (vertices[0].X, vertices[0].Y) = ((int)(v.X + edges[0].Lenght * (v.X - vertices[1].X) / dist),
                                (int)(v.Y + edges[0].Lenght * (v.Y - vertices[1].Y) / dist));
                            //restart(1);
                        }
                    }

                    break;
            }
        }
        

        private void highlightPrimitive(object sender, MouseEventArgs e)
        {
            Color c = myPictureBox.pickColor(e.X, e.Y);
            if (c != s.HighlightColor)
            {
                s.HighlightColor = c;
                myPictureBox.Refresh();
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

        private void exmpleBut_Click(object sender, EventArgs e)
        {
            clearBut_Click(sender, e);
            addVertex(100, 300);
            addVertex(300, 300, s.LastVertex);
            addVertex(300, 100, s.LastVertex);
            addVertex(100, 100, s.LastVertex);
            addVertex(50, 200, s.LastVertex, s.FirstVertex);
            s.IsClosed = true;
            s.Edges[0].State = Edge.Effect.horizontal;
            s.Edges[1].State = Edge.Effect.vertical;
            s.Edges[2].State = Edge.Effect.horizontal;
            s.Edges[3].State = Edge.Effect.length;
            s.Edges[4].State = Edge.Effect.length;
            pictureBoxVisible.MouseMove += highlightPrimitive;
            myPictureBox.OnChange();
            myPictureBox.Refresh();
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            s = new ProgramState();
            colorGiver.Reset();
            s.MyPictureBox = myPictureBox;
            pictureBoxVisible.MouseMove -= highlightPrimitive;
            myPictureBox.OnChange();
            myPictureBox.Refresh();
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
            pictureBoxVisible.MouseMove -= moveEverything;
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
            //deleteVertexToolStripMenuItem.Enabled = false;
            myPictureBox.OnChange();
        }

        private void switchEdgeState(Edge e, Edge.Effect effect)
        {
            if (e.State != effect)
                e.State = effect;
            else
                e.State = Edge.Effect.none;
            (s.AfterDirEdges, s.AfterDirVertices) = e.V1.afterDirection();
            adjustPosition(s.AfterDirEdges, s.AfterDirVertices, e.V1);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.horizontal);

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.vertical);

        private void constLengthToolStripMenuItem_Click(object sender, EventArgs e) => 
            switchEdgeState((Edge)s.ChosenPrimitive, Edge.Effect.length);

        private void changeContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            foreach (ToolStripItem toolStrip in changeContextMenu.Items)
                toolStrip.Enabled = false;
        }

        private void prepareContextMenu()
        {
            if (s.ChosenPrimitive.isVertex())
            {
                deleteVertexToolStripMenuItem.Enabled = true;
            }
            else
            {
                Edge edge = (Edge)s.ChosenPrimitive;
                foreach (ToolStripItem toolStrip in changeContextMenu.Items)
                    toolStrip.Enabled = true;
                deleteVertexToolStripMenuItem.Enabled = false;
                if (edge.V1.Before.State == Edge.Effect.vertical || edge.V2.After.State == Edge.Effect.vertical)
                    verticalToolStripMenuItem.Enabled = false;
                if (edge.V1.Before.State == Edge.Effect.horizontal || edge.V2.After.State == Edge.Effect.horizontal)
                    horizontalToolStripMenuItem.Enabled = false;
            }
        }
    }
}
