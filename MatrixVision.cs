using mv.impact.acquire;
using mv.impact.acquire.examples.helper;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MTF_Calc
{
    public class MatrixVision : ICamera
    {
        public bool terminated = false;
        static Device pDev = null;
        FunctionInterface fi;
        public void UpdateImage(PictureBox picbox, FunctionInterface fi, Request pRequest, Request pPreviousRequest, Statistics statistics)
        {
            int timeout_ms = 500;
            int cnt = 0;
            int requestNr = Device.INVALID_ID;

            while (!terminated)
            {

                // wait for results from the default capture queue
                requestNr = fi.imageRequestWaitFor(timeout_ms);
                pRequest = fi.isRequestNrValid(requestNr) ? fi.getRequest(requestNr) : null;
                if (pRequest != null)
                {
                    if (pRequest.isOK)
                    {
                        ++cnt;
                        // here we can display some statistical information every 100th image
                        if (cnt % 100 == 0)
                        {
                            Console.WriteLine("Info from {0}: {1}: {2}, {3}: {4}, {5}: {6}", pDev.serial.read(),
                                statistics.framesPerSecond.name, statistics.framesPerSecond.readS(),
                                statistics.errorCount.name, statistics.errorCount.readS(),
                                statistics.captureTime_s.name, statistics.captureTime_s.readS());
                        }
                        using (mv.impact.acquire.RequestBitmapData data = pRequest.bitmapData)
                        {
                            // Building an instance of System.Drawing.Bitmap using the requests bitmapData
                            System.Drawing.Bitmap bmp = data.bitmap;
                            Image clonedImg = new Bitmap(pRequest.imageWidth.read(), pRequest.imageHeight.read());
                            using (var copy = Graphics.FromImage(clonedImg))
                            {
                                copy.DrawImage(bmp, 0, 0);
                            }

                            picbox.Image = clonedImg;

                            //bmp.Save("result.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                            //picbox.Image = Bitmap.FromFile(@"C:\Users\Michalis\source\repos\MTF Calc\bin\Debug\result.bmp");
                            Console.WriteLine();
                            Console.WriteLine("Image captured: {0}({1}x{2})", pRequest.imagePixelFormat.readS(), pRequest.imageWidth.read(), pRequest.imageHeight.read());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: {0}", pRequest.requestResult.readS());
                    }
                    if (pPreviousRequest != null)
                    {
                        // this image has been displayed thus the buffer is no longer needed...
                        pPreviousRequest.unlock();
                    }
                    pPreviousRequest = pRequest;
                    // send a new image request into the capture queue
                    fi.imageRequestSingle();
                }
                //else
                //{
                // Please note that slow systems or interface technologies in combination with high resolution sensors
                // might need more time to transmit an image than the timeout value which has been passed to imageRequestWaitFor().
                // If this is the case simply wait multiple times OR increase the timeout(not recommended as usually not necessary
                // and potentially makes the capture thread less responsive) and rebuild this application.
                // Once the device is configured for triggered image acquisition and the timeout elapsed before
                // the device has been triggered this might happen as well.
                // The return code would be -2119(DEV_WAIT_FOR_REQUEST_FAILED) in that case, the documentation will provide
                // additional information under TDMR_ERROR in the interface reference.
                // If waiting with an infinite timeout(-1) it will be necessary to call 'imageRequestReset' from another thread
                // to force 'imageRequestWaitFor' to return when no data is coming from the device/can be captured.
                // Console.WriteLine("imageRequestWaitFor failed ({0}, {1}), timeout value too small?", requestNr, ImpactAcquireException.getErrorCodeAsString(requestNr));
                //}
            }
            DeviceAccess.manuallyStopAcquisitionIfNeeded(pDev, fi);


            // In this sample all the next lines are redundant as the device driver will be
            // closed now, but in a real world application a thread like this might be started
            // several times an then it becomes crucial to clean up correctly.

            // free the last potentially locked request
            if (pRequest != null)
            {
                pRequest.unlock();
            }
            // clear all queues
            fi.imageRequestReset(0, 0);


        }
        public void ConnectCamera(ref bool _bool)
        {
            mv.impact.acquire.LibraryPath.init(); // this will add the folders containing unmanaged libraries to the PATH variable.
            try
            {
                pDev = mv.impact.acquire.DeviceManager.getDevice(0); // get the first device found

            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to connect to camera.(Error:" + e + ")");
                //CameraConnected = false;
            }

            if (pDev == null)
            {
                Console.WriteLine("Unable to continue!");
                //Environment.Exit(1);

                //CameraConnected = false;
            }
            else
            {
                Console.WriteLine("Initialising the device. This might take some time...");
                try
                {
                    pDev.open();
                    Console.WriteLine("Connected successfully.");
                    _bool = true;

                }
                catch (ImpactAcquireException e)
                {
                    // this e.g. might happen if the same device is already opened in another process...
                    Console.WriteLine("An error occurred while opening the device " + pDev.serial + "(error code: " + e.Message + ").");
                    Environment.Exit(1);

                }

                // create an interface to the selected device
                //FunctionInterface fi = new FunctionInterface(pDev);
                fi = new FunctionInterface(pDev);
                // send a request to the default request queue of the device and wait for the result.
                TDMR_ERROR result = (TDMR_ERROR)fi.imageRequestSingle();
                if (result != TDMR_ERROR.DMR_NO_ERROR)
                {
                    Console.WriteLine("'FunctionInterface.imageRequestSingle' returned with an unexpected result: {0}({1})", result, ImpactAcquireException.getErrorCodeAsString(result));

                }

            }


        }

        public void SingleImageCapture(PictureBox picbox)
        {
            if (pDev != null)
            {
                try
                {
                    // send a request to the default request queue of the device and wait for the result.
                    TDMR_ERROR result = (TDMR_ERROR)fi.imageRequestSingle();
                    if (result != TDMR_ERROR.DMR_NO_ERROR)
                    {
                        Console.WriteLine("'FunctionInterface.imageRequestSingle' returned with an unexpected result: {0}({1})", result, ImpactAcquireException.getErrorCodeAsString(result));
                    }
                    DeviceAccess.manuallyStartAcquisitionIfNeeded(pDev, fi);
                    // Wait for results from the default capture queue by passing a timeout (The maximum time allowed
                    // for the application to wait for a Result). Infinity value: -1, positive value: The time to wait in milliseconds.
                    // Please note that slow systems or interface technologies in combination with high resolution sensors
                    // might need more time to transmit an image than the timeout value.
                    // Once the device is configured for triggered image acquisition and the timeout elapsed before
                    // the device has been triggered this might happen as well.
                    // If waiting with an infinite timeout(-1) it will be necessary to call 'imageRequestReset' from another thread
                    // to force 'imageRequestWaitFor' to return when no data is coming from the device/can be captured.
                    int timeout_ms = 10000;
                    // wait for results from the default capture queue
                    int requestNr = fi.imageRequestWaitFor(timeout_ms);
                    Request pRequest = fi.isRequestNrValid(requestNr) ? fi.getRequest(requestNr) : null;
                    if (pRequest != null)
                    {
                        if (pRequest.isOK)
                        {
                            using (mv.impact.acquire.RequestBitmapData data = pRequest.bitmapData)
                            {
                                // Building an instance of System.Drawing.Bitmap using the requests bitmapData
                                System.Drawing.Bitmap bmp = data.bitmap;
                                Image clonedImg = new Bitmap(pRequest.imageWidth.read(), pRequest.imageHeight.read());
                                using (var copy = Graphics.FromImage(clonedImg))
                                {
                                    copy.DrawImage(bmp, 0, 0);
                                }

                                picbox.Image = clonedImg;
                                //bmp.Save("result.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                                //picbox.Image = Bitmap.FromFile(@"C:\Users\Michalis\source\repos\MTF Calc\bin\Debug\result.bmp");
                                Console.WriteLine();
                                Console.WriteLine("Image captured: {0}({1}x{2})", pRequest.imagePixelFormat.readS(), pRequest.imageWidth.read(), pRequest.imageHeight.read());
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: {0}", pRequest.requestResult.readS());
                            // if the application wouldn't terminate at this point this buffer HAS TO be unlocked before
                            // it can be used again as currently it is under control of the user. However terminating the application
                            // will free the resources anyway thus the call
                            // pRequest.unlock();
                            // could be omitted here.
                        }

                        // unlock the buffer to let the driver know that you no longer need this buffer.
                        pRequest.unlock();
                        Console.WriteLine();
                        Console.WriteLine("Press [ENTER] to end the application");
                        //Console.ReadKey();
                    }





                    else
                    {
                        // If the error code is -2119(DEV_WAIT_FOR_REQUEST_FAILED), the documentation will provide
                        // additional information under TDMR_ERROR in the interface reference
                        Console.WriteLine("imageRequestWaitFor failed maybe the timeout value has been too small?");

                    }
                    DeviceAccess.manuallyStopAcquisitionIfNeeded(pDev, fi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in single image : " + ex);
                }
            }


            else
            {
                MessageBox.Show("No Device is connected");
            }

        }

        public void LiveImage(PictureBox picbox)
        {
            if (pDev != null)
            {
                try
                {
                    // establish access to the statistic properties
                    Statistics statistics = new Statistics(pDev);
                    terminated = false;

                    // Send all requests to the capture queue. There can be more than 1 queue for some devices, but for this sample
                    // we will work with the default capture queue. If a device supports more than one capture or result
                    // queue, this will be stated in the manual. If nothing is mentioned about it, the device supports one
                    // queue only. This loop will send all requests currently available to the driver. To modify the number of requests
                    // use the property mv.impact.acquire.SystemSettings.requestCount at runtime or the property
                    // mv.impact.acquire.Device.defaultRequestCount BEFORE opening the device.
                    TDMR_ERROR result = TDMR_ERROR.DMR_NO_ERROR;
                    while ((result = (TDMR_ERROR)fi.imageRequestSingle()) == TDMR_ERROR.DMR_NO_ERROR) { };
                    if (result != TDMR_ERROR.DEV_NO_FREE_REQUEST_AVAILABLE)
                    {
                        Console.WriteLine("'FunctionInterface.imageRequestSingle' returned with an unexpected result: {0}({1})", result, ImpactAcquireException.getErrorCodeAsString(result));
                    }

                    DeviceAccess.manuallyStartAcquisitionIfNeeded(pDev, fi);
                    // run thread loop
                    Request pRequest = null;
                    // we always have to keep at least 2 images as the display module might want to repaint the image, thus we
                    // cannot free it unless we have a assigned the display to a new buffer.
                    Request pPreviousRequest = null;
                    Thread update = new Thread(() =>
                    {

                        UpdateImage(picbox, fi, pRequest, pPreviousRequest, statistics);


                    });
                    update.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Live feed : " + ex);
                }
            }
            else
            {
                MessageBox.Show("No camera connected");
            }



        }

        public void TerminateCapture()
        {
            terminated = true;
        }
        public void SetSettings()
        {
            // Set property exposureTime using GenICam
            mv.impact.acquire.GenICam.AcquisitionControl ac = new mv.impact.acquire.GenICam.AcquisitionControl(pDev);
            Console.WriteLine("exposureTime (current): {0}\n", ac.exposureTime.read());
            ac.exposureTime.write(10000);
            Console.WriteLine("exposureTime (new): {0}\n", ac.exposureTime.read());
        }

    }
}







