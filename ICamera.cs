using System.Windows.Forms;

namespace MTF_Calc
{
    interface ICamera
    {
        void ConnectCamera(ref bool cameraconnected);

        void SingleImageCapture(PictureBox picbox);

        void LiveImage(PictureBox picbox);

        void TerminateCapture();


    }
}
