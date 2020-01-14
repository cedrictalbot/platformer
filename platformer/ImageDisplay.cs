using System;
using System.Windows.Forms;
using System.Drawing;

namespace platformgame {
    public static class PictureBoxExtension {
        public static void SetImage(this PictureBox pic, Image image) {
            Bitmap bm = new Bitmap(pic.Width, pic.Height);
            Graphics gp = Graphics.FromImage(bm);
            for (int x = 0; x <= bm.Width - image.Width; x += image.Width) {
                gp.DrawImage(image, new Point(x, 0));
            }
            pic.Image = bm;
        }
    }
}