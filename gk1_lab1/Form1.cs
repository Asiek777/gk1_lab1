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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
    }
}
