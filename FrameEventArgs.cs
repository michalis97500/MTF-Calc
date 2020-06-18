using System;
using System.Drawing;

namespace CameraInterfaceExample
{

    public class FrameEventArgs : EventArgs
    {
        public FrameEventArgs(Bitmap frameBitmap)
        {
            FrameBitmap = frameBitmap;
        }

        public Bitmap FrameBitmap { get; private set; }
    }

}
