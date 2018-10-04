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
        List<Vertice> vertices = new List<Vertice>();
        DoublePictureBox doublePictureBox;
        Color chosenColor;

        public MainWindow()
        {
            InitializeComponent();
            doublePictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
        }

        void addVertice(int x, int y)
        {
            vertices.Add(new Vertice(x, y));
        }

        private void pictureBoxPicker_Paint(object sender, PaintEventArgs e)
        {
            foreach (Vertice v in vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - 2 * pointSize, (int)v.Y - (2 * pointSize), 4 * pointSize, 4 * pointSize);
                e.Graphics.FillEllipse(new SolidBrush(v.Color), circle);
            }
        }

        private void pictureBoxVisible_Paint(object sender, PaintEventArgs e)
        {
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
            Color color = doublePictureBox.pickColor(e.X, e.Y);
            if (color.ToArgb() != pictureBoxPicker.BackColor.ToArgb())
            {
                chosenColor = color;
                doublePictureBox.Refresh();
            }
            else
            {
                addVertice(e.X, e.Y);
                doublePictureBox.OnChange();
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
    }
}
