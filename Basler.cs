using Basler.Pylon;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;


namespace CameraInterfaceExample
{
    // Basler-specific implementation of the ICamera interface
    public class BaslerCamera : MTF_Calc.ICamera
    {
        private Camera camera;
        private PixelDataConverter converter = new PixelDataConverter();
        public Bitmap captured;
        public bool terminated = false;
        public event EventHandler<FrameEventArgs> NewFrame;

        public void ConnectCamera(ref bool _bool)
        {
            try
            {
                if (camera == null)
                {
                    camera = new Camera(CameraSelectionStrategy.FirstFound);
                }
                camera.Open();
                _bool = true;
                camera.StreamGrabber.ImageGrabbed += new EventHandler<ImageGrabbedEventArgs>(StreamGrabber_ImageGrabbed);

                //ResetToFactoryDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LiveImage(PictureBox picbox)
        {
            try
            {
                terminated = false;
                camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
                Thread thread = new Thread(() =>
                {
                    while (!terminated)
                    {
                        UpdateImage(picbox);
                    }

                });
                thread.Start();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        public void TerminateCapture()
        {
            try
            {
                terminated = true;
                camera.StreamGrabber.Stop();


            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        public void SingleImageCapture(PictureBox picbox)
        {
            if (camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Stop();
            }

            camera.StreamGrabber.GrabOne(1000);
            UpdateImage(picbox);
        }
        void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;
                Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                // Lock the bits of the bitmap.
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                // Place the pointer to the buffer of the bitmap.
                converter.OutputPixelFormat = PixelType.BGRA8packed;
                IntPtr ptrBmp = bmpData.Scan0;
                converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                bitmap.UnlockBits(bmpData);


                captured = (Bitmap)bitmap.Clone();

                bitmap.Dispose();
                bitmap = null;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        private void InvokeNewFrameEvent(FrameEventArgs args)
        {
            //var handler = NewFrame;
            //if (handler != null)
            //{
            //    handler(this, args);
            //}

            NewFrame?.Invoke(this, args);
        }

        private void ResetToFactoryDefault()
        {
            if (camera != null)
            {

                // Start from Basler factory defaults
                camera.Parameters[PLCamera.UserSetSelector].SetValue(PLCamera.UserSetSelector.Default);
                camera.Parameters[PLCamera.UserSetLoad].Execute();

                camera.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.Off);
                camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);

                // Minimum gain (auto off)
                camera.Parameters[PLCamera.GainAuto].SetValue(PLCamera.GainAuto.Off);
                camera.Parameters[PLCamera.Gain].SetToMinimum();

                // AcquisitionFrameRate can go to 1-100000 but our frame rate is usually 10-50 fps so set value above that.
                camera.Parameters[PLCamera.AcquisitionFrameRate].SetValue(20.0);

                // Exposure time (auto off)
                camera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);
                camera.Parameters[PLCamera.ExposureTime].SetValue(40000);

                // Flip image. X reversed, Y not reversed (same as Spectrum Image)
                camera.Parameters[PLCamera.ReverseX].SetValue(true);
                camera.Parameters[PLCamera.ReverseY].SetValue(false);

                // Image size. Default = 2000*1600 with *2 binning (to produce a 1000*800 pixel image)
                // Offsets are set to use the central region of the camera (full size 2592*1944)
                camera.Parameters[PLCamera.BinningHorizontal].SetValue(2);
                camera.Parameters[PLCamera.BinningHorizontalMode].SetValue(PLCamera.BinningHorizontalMode.Average);
                camera.Parameters[PLCamera.BinningVertical].SetValue(2);
                camera.Parameters[PLCamera.BinningVerticalMode].SetValue(PLCamera.BinningVerticalMode.Average);

                // Not all values are valid, get as close as possible
                camera.Parameters[PLCamera.Width].SetValue(1000, IntegerValueCorrection.Nearest);
                camera.Parameters[PLCamera.Height].SetValue(800, IntegerValueCorrection.Nearest);
                camera.Parameters[PLCamera.OffsetX].SetValue(148, IntegerValueCorrection.Nearest);
                camera.Parameters[PLCamera.OffsetY].SetValue(86, IntegerValueCorrection.Nearest);

                // Set contrast and gamma to give a response similar to Videology, (this also affects the Visual Image Quality metric)
                const double IMAGE_CONSTRAST = 0.5;
                const double IMAGE_GAMMA = 1.6;

                // The name of the Contrast property changed between model 8 and 11 of the daA2500-14uc camera  
                // Recent firmware should support BslContrast, older firmware might support  'ContrastEnhancement' but this is not
                // available through the API defined constants
                bool bOK = false;
                if (camera.Parameters[PLCamera.BslContrast].IsWritable)
                {
                    bOK = camera.Parameters[PLUsbCamera.BslContrast].TrySetValue(IMAGE_CONSTRAST);
                }
                else
                {
                    bOK = camera.Parameters[(FloatName)"ContrastEnhancement"].TrySetValue(IMAGE_CONSTRAST);
                }
                if (!bOK)
                {
                    // TODO - warn that contrast cannot be set
                }

                camera.Parameters[PLCamera.Gamma].SetValue(IMAGE_GAMMA);
                camera.Parameters[PLCamera.BalanceWhiteAuto].SetValue(PLCamera.BalanceWhiteAuto.Off);
                camera.Parameters[PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Green);
                camera.Parameters[PLCamera.BalanceRatio].SetValuePercentOfRange(50.0);
                camera.Parameters[PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Red);
                camera.Parameters[PLCamera.BalanceRatio].SetValuePercentOfRange(50.0);
                camera.Parameters[PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Blue);
                camera.Parameters[PLCamera.BalanceRatio].SetValuePercentOfRange(50.0);
                // Set pixel format to RGB8. This gives 24 bits per pixel images
                bOK = camera.Parameters[PLCamera.PixelFormat].TrySetValue(PLCamera.PixelFormat.RGB8);
            }
        }

        public void UpdateImage(PictureBox picbox)
        {

            if (picbox.InvokeRequired)
            {
                picbox.Invoke(new MethodInvoker(delegate ()
               {
                   picbox.Image = captured;
               }));
            }
            else
            {
                picbox.Image = captured;
            }


        }
    }
}
