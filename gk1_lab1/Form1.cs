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
        List<Vertice> vertices = new List<Vertice>();

        public MainWindow()
        {
            InitializeComponent();
            DoublePictureBox doublePictureBox = new DoublePictureBox(pictureBoxVisible, pictureBoxPicker);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            
        }

        void addVertice(int x, int y)
        {
            vertices.Add(new Vertice(x, y, colorGiver.GiveColor()));
        }

        class DoublePictureBox
        {
            PictureBox visible;
            PictureBox picker;

            public DoublePictureBox(PictureBox visible, PictureBox picker)
            {
                this.visible = visible;
                this.picker = picker;
            }

            void Refresh()
            {
                visible.Refresh();
                picker.Refresh();
            }
        }

        private void pictureBoxVisible_Paint(object sender, PaintEventArgs e)
        {
            foreach (Vertice v in vertices)
            {
                Rectangle circle = new Rectangle((int)v.X - 5, (int)v.Y - 5, 2 * 5, 2 * 5);
                e.Graphics.FillEllipse(Brushes.White, circle);
                e.Graphics.DrawEllipse(new Pen(v.Color, 3), circle);
            }
        }

        private void pictureBoxVisible_MouseDown(object sender, MouseEventArgs e)
        {
            addVertice(e.X, e.Y);
        }
    }
}
