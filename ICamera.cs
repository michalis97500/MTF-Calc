using System.Windows.Forms;

namespace MTF_Calc
{
    interface ICamera
    {
        void ConnectCamera(bool cameraconnected);

        void SingleImageCapture(PictureBox picbox);

        void LiveImage(PictureBox picbox);

        void TerminateCapture();


    }
}
