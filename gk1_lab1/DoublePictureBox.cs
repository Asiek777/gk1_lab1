using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gk1_lab1;
using System.Drawing;

namespace gk1_lab1
{
    class DoublePictureBox
    {
        PictureBox visible;
        PictureBox picker;
        Bitmap bitmapToPick;

        public Color pickColor(int x, int y) => 
            bitmapToPick.GetPixel(x, y);

        public DoublePictureBox(PictureBox visible, PictureBox picker)
        {
            this.visible = visible;
            this.picker = picker;
            bitmapToPick = new Bitmap(picker.Width, picker.Height);
            picker.DrawToBitmap(bitmapToPick, picker.ClientRectangle);
        }

        public void OnChange()
        {
            bitmapToPick = new Bitmap(picker.Width, picker.Height);
            picker.DrawToBitmap(bitmapToPick, picker.ClientRectangle);
            Refresh();
        }

        public void Refresh()
        {
            visible.Refresh();
            picker.Refresh();
        }
    }
}
