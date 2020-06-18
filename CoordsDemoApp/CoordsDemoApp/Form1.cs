using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordsDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = @"BMP|*.bmp|JPG|*.jpg|PNG|*.png|*.*|*.*", FilterIndex = 1 };
            var dlgRes = ofd.ShowDialog();
            if (dlgRes == DialogResult.OK )
            {
                var filename = ofd.FileName;
                var bmp = Bitmap.FromFile(filename);
                pictureBox1.Image = bmp;
                Debug.Print("image size {0} x {1} pixels", bmp.Width, bmp.Height);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // NB assumes picturebox.SizeMode is set to StretchImage, so the image fills the picture box.

            double widthInMicrons = 0;
            double heightInMicrons = 0;
            double widthInPixels = 0;
            double heightInPixels = 0;

            // check for valid inputs
            if (pictureBox1.Image == null)
            {
                Debug.Print("invalid image");
                return;
            }
            if (!double.TryParse(widthInMicronsTextBox.Text, out widthInMicrons))
            {
                Debug.Print("invalid widthInMicrons {0}", widthInMicronsTextBox.Text);
                return;
            }
            if (!double.TryParse(heightInMicronsTextBox.Text, out heightInMicrons))
            {
                Debug.Print("invalid heightInMicrons {0}", heightInMicronsTextBox.Text);
                return;
            }

            // NB size of original bitmap image, not size of picturebox
            widthInPixels = pictureBox1.Image.Width;
            heightInPixels =  pictureBox1.Image.Height;

            // coordinate of mouse cursor in picture box coords = e.X, e.Y,   top left = (0,0)) 

            // coordinate in image pixels
            double imagePixelX = (int) (widthInPixels * e.X / pictureBox1.Width);
            double imagePixelY = (int) (heightInPixels * e.Y / pictureBox1.Height);

            // coordinate in microns
            var imageMicronsX = imagePixelX * widthInMicrons / widthInPixels;
            var imageMicronsY = imagePixelY * widthInMicrons / widthInPixels;

            // display info
            var sb = new StringBuilder();
            sb.AppendFormat("mouse coords=({0},{1}) \r\n", e.X, e.Y);
            sb.AppendFormat("pixel coords=({0},{1}) \r\n", imagePixelX, imagePixelY);
            sb.AppendFormat("micron coords=({0:F3},{1:F3}) \r\n", imageMicronsX, imageMicronsY);

            cursorInfoLabel.Text = sb.ToString();
        }
    }
}
