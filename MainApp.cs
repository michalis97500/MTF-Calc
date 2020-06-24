using CameraInterfaceExample;
using mv.impact.acquire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Threading;

namespace MTF_Calc
{
    public partial class MainApp : Form
    {
        private ICamera camera;
        public MainApp()
        {
            
            DialogResult result = MessageBox.Show("Is the USAF target positive? (Yes for positive, No for negative)","Target select" , MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                positivetarget = 1;
                negativetarget = 0;

            }
            else
            {
                negativetarget = 1;
                positivetarget = 0;
                    
            }
            DialogResult result1 = MessageBox.Show("Is the connected camera a Basler? (Yes for Basler, No for MatrixVision)", "Camera select", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {

                camera = new BaslerCamera();

            }
            else
            {
                camera = new MatrixVision();

            }
            InitializeComponent();
            Array.Clear(MTFData, 0, MTFData.Length);
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                SerialSelect.Items.Add(port);
            }

        }


        public void load_image_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "bitmap file|*.bmp|png file|*.png|tiff file|*.tiff|raw16 file|*.raw16";
                DialogResult image = dialog.ShowDialog();
                if (image == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    SelectedBMP = (Bitmap)Image.FromFile(filename);
                    this.ImageDisplay.Image = SelectedBMP;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
            "Check the path to the image file.");
            }
        }

        private void SingleImageButton_Click(object sender, EventArgs e)
        {

            camera.SingleImageCapture(ImageDisplay);


        }


        private void LiveFeedButton_Click(object sender, EventArgs e)
        {
            
            camera.LiveImage(ImageDisplay);
            

        }

        private void StopLiveFeedButton_Click(object sender, EventArgs e)
        {
            camera.TerminateCapture();
        }

        private void cameraconnectbutton_Click(object sender, EventArgs e)
        {
            camera.ConnectCamera(cameraconnected);
        }

        private void GenerateLineArrayVertical(int xposition, int yposition, Bitmap bmp, int length)
        {
            if (bmp != null)
            {
                Color[] TempColorArray = new Color[length+1];
                
                for (int i = yposition; i < yposition + length; i++)
                {
                    
                    TempColorArray[i - yposition] = bmp.GetPixel(xposition, i);
                    int pR = TempColorArray[i - yposition].R;
                    int pG = TempColorArray[i - yposition].G;
                    int pB = TempColorArray[i - yposition].B;
                    int avg = (pR + pG + pB) / 3;
                    ColorAvgVert[i - yposition] = avg;
                    ColorAvgVertical.Add(avg);
                    Console.WriteLine(avg);
                }
            }
            else
            {
                MessageBox.Show("Error in generating array, no image found");
            }
        }

        private void GenerateLineArrayHorizontal(int xposition, int yposition, Bitmap bmp, int length)
        {
            if (bmp != null)
            {
                Color[] TempColorArray = new Color[length + 1];
                for (int i = xposition; i < xposition + length; i++)
                {

                    TempColorArray[i - xposition] = bmp.GetPixel(i, yposition);
                    int pR = TempColorArray[i - xposition].R;
                    int pG = TempColorArray[i - xposition].G;
                    int pB = TempColorArray[i - xposition].B;
                    int avg = (pR + pG + pB) / 3;
                    ColorAvgHori[i - xposition] = avg;
                    ColorAvgHorizontal.Add(avg);
                    Console.WriteLine(avg);
                }
            }
            else
            {
                MessageBox.Show("Error in generating array, no image found");
            }

        }

        private void GetBMPValuesVer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(XposVert.Text) || string.IsNullOrWhiteSpace(YposVert.Text))
            {
                MessageBox.Show("No input found");

            }
            else
            {

                GenerateLineArrayVertical(Convert.ToInt32(XposVert.Text), Convert.ToInt32(YposVert.Text), (Bitmap)ImageDisplay.Image, 100);
            }
        }

        private void StartTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (StageSerialPort.IsOpen)
                {
                    
                    if (cameraconnected == true)
                    {
                        camera.TerminateCapture();
                        
                        double x, y, z;
                        for(int i=0;i<5;i++)
                        {
                            x = StageCalibrationPositions[i, 0, 0];
                            y = StageCalibrationPositions[i, 1, 0];
                            z = StageCalibrationPositions[i, 0, 1];
                            var destination = new ThreeDPoint(x,y,z);
                            MoveStage(destination, Timeouts.ASYNC);
                            camera.LiveImage(ImageDisplay);
                            camera.TerminateCapture();
                            int x_image = Convert.ToInt32(ImageCalibrationPositions[i, 0]);
                            int y_image = Convert.ToInt32(ImageCalibrationPositions[i, 1]);
                            Bitmap bitmap = (Bitmap)ImageDisplay.Image;
                            GenerateLineArrayHorizontal(x_image, y_image, bitmap, 40);
                            GenerateLineArrayVertical(x_image, y_image, bitmap, 40);
                            FindPeaks(ColorAvgHorizontal);
                            MTFCalc(Convert.ToDouble(i),1);
                            FindPeaks(ColorAvgVertical);
                            MTFCalc(Convert.ToDouble(i),0);
                            ColorAvgHorizontal.Clear();
                            ColorAvgVertical.Clear();
                            Debug.Print(Convert.ToString(MTFData[i, 0, 0]));
                            Debug.Print(Convert.ToString(MTFData[i, 1, 0]));
                            Debug.Print(Convert.ToString(MTFData[i, 0, 1]));

                        }
                        
                        


                    }
                    else
                    {
                        MessageBox.Show("Camera is not connected");
                    }

                }
                else
                {
                    MessageBox.Show("Serial port is not connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void FindPeaks(List<int> list)
        {
            //Clear lists and find peaks/troughs of the list variable and append them to global Peak/Trough lists
            try
            {
                PeakList.Clear();
                TroughList.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0 || i == (list.Count -1))
                    {
                        Console.WriteLine("No adjacent values");
                    }
                    else
                    {
                        if (list[i] > list[i - 1] && list[i] > list[i + 1])
                        {
                            Console.WriteLine("Peak found at " + i + " of value " + list[i]);
                            PeakList.Add(list[i]);
                        }

                        if (list[i] < list[i - 1] && list[i] < list[i + 1])
                        {
                            Console.WriteLine("Trough found at " + i + " of value " + list[i]);
                            TroughList.Add(list[i]);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in finding peaks : " + ex);
            }
        }

        private void MTFCalc(double value,int direction)
        {
            //check that the global lists have any values + same number of values. 
            if (PeakList.Count + positivetarget == TroughList.Count + negativetarget)
            {
                if (PeakList.Any())
                {
                    for (int i = 0; i < PeakList.Count; i++)
                    {
                        double mtf;
                        double upper;
                        double lower;
                        upper = PeakList[i] - TroughList[i];
                        lower = PeakList[i] + TroughList[i];
                        mtf = upper / lower;
                        for (int x = 0; x < MTFData.Length; x++)
                        {
                            if (MTFData[x, 0,0] == 0)
                            {
                                MTFData[x, 0, 0] = mtf;
                                MTFData[x, 1, 0] = value;
                                MTFData[x, 0, 1] = Convert.ToDouble(direction);
                                
                                break;
                            }
                        }

                    }
                }
            }
        }

        private void CenterStageButton_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(xcenter);
            double y = Convert.ToDouble(ycenter);
            double z = Convert.ToDouble(zcenter);
            var destination = new ThreeDPoint(x, y, z);
            Debug.Print(string.Format("Moving stage to: ({0},{1},{2})", x, y, z));
            MoveStage(destination, Timeouts.ASYNC);
            PositionXYZ();
        }

        private void CalibrateStageButton_Click(object sender, EventArgs e)
        {
            if (StageSerialPort.IsOpen)
            {
                CalibrateStage();
            }
            else
            {
                MessageBox.Show("No COM port connected ");
            }
        }

        private void CalibrateImageCenterToLU()
        {
            try
            {
                //Establish a center of field, and get coordinates for image+ stage
                
                ImageCalibrationPositions[0, 0] = CurrentPosition[0];
                ImageCalibrationPositions[0, 1] = CurrentPosition[1];
                PositionXYZ();
                double x = Convert.ToDouble(xposition);
                double y = Convert.ToDouble(yposition);
                double z = Convert.ToDouble(zposition);
                StageCalibrationPositions[0, 0, 0] = x;
                StageCalibrationPositions[0, 1, 0] = y;
                StageCalibrationPositions[0, 0, 1] = z;
                ThreeDPoint lcorner = new ThreeDPoint(x + (FieldSize.X * ((double)FieldSizeRatio.Value/100) / 2), y - (FieldSize.Y * ((double)FieldSizeRatio.Value/100) / 2), z);
                MoveStage(lcorner, Timeouts.ASYNC);
                MessageBox.Show("Ensure the crosshair is at left top corner of the field and click on the crosshair");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration : " + ex);
            }

        }
        private void CalibrateImageLUCornerToRU()
        {

            try
            {
                ImageCalibrationPositions[1, 0] = CurrentPosition[0];
                ImageCalibrationPositions[1, 1] = CurrentPosition[1];
                PositionXYZ();
                double x = Convert.ToDouble(xposition);
                double y = Convert.ToDouble(yposition);
                double z = Convert.ToDouble(zposition);
                StageCalibrationPositions[1, 0, 0] = x;
                StageCalibrationPositions[1, 1, 0] = y;
                StageCalibrationPositions[1, 0, 1] = z;
                ThreeDPoint rcorner = new ThreeDPoint(x - (FieldSize.X * ((double)FieldSizeRatio.Value)/100), y , z);
                MoveStage(rcorner, Timeouts.ASYNC);
                MessageBox.Show("Ensure the crosshair is at right top corner of the field and click on the crosshair");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration 2 : " + ex);
            }
        }
        private void CalibrateImageRUCornerToRB()
        {

            try
            {
                ImageCalibrationPositions[2, 0] = CurrentPosition[0];
                ImageCalibrationPositions[2, 1] = CurrentPosition[1];
                PositionXYZ();
                double x = Convert.ToDouble(xposition);
                double y = Convert.ToDouble(yposition);
                double z = Convert.ToDouble(zposition);
                StageCalibrationPositions[2, 0, 0] = x;
                StageCalibrationPositions[2, 1, 0] = y;
                StageCalibrationPositions[2, 0, 1] = z;
                ThreeDPoint rbtcorner = new ThreeDPoint(x, y+ (FieldSize.Y * ((double)FieldSizeRatio.Value)/100), z);
                MoveStage(rbtcorner, Timeouts.ASYNC);
                MessageBox.Show("Ensure the crosshair is at right bottom corner of the field and click on the crosshair");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration 3 : " + ex);
            }
        }

        private void CalibrateImageRBCornerToLB()
        {

            try
            {
                ImageCalibrationPositions[3, 0] = CurrentPosition[0];
                ImageCalibrationPositions[3, 1] = CurrentPosition[1]; 
                PositionXYZ();
                double x = Convert.ToDouble(xposition);
                double y = Convert.ToDouble(yposition);
                double z = Convert.ToDouble(zposition);
                StageCalibrationPositions[3, 0, 0] = x;
                StageCalibrationPositions[3, 1, 0] = y;
                StageCalibrationPositions[3, 0, 1] = z;
                ThreeDPoint lbcorner = new ThreeDPoint(x + (FieldSize.X * ((double)FieldSizeRatio.Value)/100), y, z);
                MoveStage(lbcorner, Timeouts.ASYNC);
                MessageBox.Show("Ensure the crosshair is at left bottom corner of the field and click on the crosshair");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration 4 : " + ex);
            }
        }
        private void CalibrateImageLB()
        {

            try
            {
                ImageCalibrationPositions[4, 0] = CurrentPosition[0];
                ImageCalibrationPositions[4, 1] = CurrentPosition[1];
                PositionXYZ();
                double x = Convert.ToDouble(xposition);
                double y = Convert.ToDouble(yposition);
                double z = Convert.ToDouble(zposition);
                StageCalibrationPositions[4, 0, 0] = x;
                StageCalibrationPositions[4, 1, 0] = y;
                StageCalibrationPositions[4, 0, 1] = z;
                
                //ThreeDPoint lbcorner = new ThreeDPoint(x + (FieldSize), y, z);
                //MoveStage(lbcorner, Timeouts.ASYNC);
                //MessageBox.Show("Ensure the crosshair is at left bottom corner of the field of size {0} and click on the crosshair", Convert.ToString(FieldSize));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration 5 : " + ex);
            }
        }
        private void ImageDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                camera.TerminateCapture();
                if (Clickable == true)
                {
                    var mouseEventArgs = e as MouseEventArgs;
                    int widthInPixels = 0;
                    int heightInPixels = 0;
                    // coordinate in image pixels
                    widthInPixels = ImageDisplay.Image.Width;
                    heightInPixels = ImageDisplay.Image.Height;
                    int imagePixelX = widthInPixels * mouseEventArgs.X / ImageDisplay.Width;
                    int imagePixelY = heightInPixels * mouseEventArgs.Y / ImageDisplay.Height;
                    Debug.Print("{0} , {1}", imagePixelX, imagePixelY);
                    DialogResult result = MessageBox.Show("Coordinates have been recorded. Proceed?", "Coordinates recorded", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        CurrentPosition[0] = imagePixelX;
                        CurrentPosition[1] = imagePixelY;


                        if (counter == 4)
                        {
                            paint = true;
                            DrawRectangle(ImageDisplay, 3, 10);
                            DrawRectangle(ImageDisplay, 10, 3);
                            CalibrateImageLB();
                            MessageBox.Show("Calibration Complete");
                            Clickable = false;
                            StartTestButton.Visible = true;
                            camera.LiveImage(ImageDisplay);
                        }

                        if (counter == 3)
                        {
                            paint = true;
                            DrawRectangle(ImageDisplay, 3, 10);
                            DrawRectangle(ImageDisplay, 10, 3);
                            CalibrateImageRBCornerToLB();
                            counter++;
                            camera.LiveImage(ImageDisplay);
                        }

                        if (counter == 2)
                        {
                            paint = true;
                            DrawRectangle(ImageDisplay, 3, 10);
                            DrawRectangle(ImageDisplay, 10, 3);
                            CalibrateImageRUCornerToRB();
                            counter++;
                            camera.LiveImage(ImageDisplay);
                        }

                        if (counter == 1)
                        {
                            paint = true;
                            DrawRectangle(ImageDisplay, 3, 10);
                            DrawRectangle(ImageDisplay, 10, 3);
                            CalibrateImageLUCornerToRU();
                            counter++;
                            camera.LiveImage(ImageDisplay);

                        }
                        if (counter == 0)
                        {
                            paint = true;
                            DrawRectangle(ImageDisplay, 3, 10);
                            DrawRectangle(ImageDisplay, 10, 3);
                            CalibrateImageCenterToLU();
                            counter++;
                            camera.LiveImage(ImageDisplay);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.Print("Error : " + ex);
            }
        }

        private void CalibrateImageButton_Click(object sender, EventArgs e)
        {
            camera.TerminateCapture();
            counter = 0;
            Clickable = true;
            MessageBox.Show("Place the PKI Test graticule on the stage, focus and center the PKI Crosshairs on the screen. Click on the center of the crosshair to begin");
            camera.LiveImage(ImageDisplay);
        }

        private void StageConnectButton_Click(object sender, EventArgs e)
        {
            SerialConnection();
        }

    /*    private void FieldSizeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FieldSizeTextbox.Text) || string.IsNullOrWhiteSpace(FieldSizeTextbox.Text))
            {
                MessageBox.Show("No input found");

            }
            else
            {

                //FieldSize = Convert.ToDouble(FieldSizeTextbox.Text);
            }
        }
    */
        
        private void SetIllumination(Decimal value)
        {
            try
            {
                double targetIllumBottomLED = (1 * (Convert.ToDouble(value)/100));
                if (StageSerialPort.IsOpen)
                {
                    StringBuilder buffer = new StringBuilder();
                    buffer.AppendFormat("!{0}{1:X2}\r", "a", LineariseIllumination(targetIllumBottomLED));
                    buffer.Append("!\r");
                    SendCommand(buffer.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Error in illumination settings : " + ex);
            }
        }

        private int LineariseIllumination(double reqillum)
        {
            // Ensure shuts down fully
            if (reqillum < 0.01)
            {
                return 0;
            }

            // For LEDs there is light even at illum=1;  the camera saturates at 100,
            // but we will leave plenty in hand to blast it through dark samples.
            // lineariseIlluminationB is set at 100 so for low levels 1 click has an effect.
            // lineariseIlluminationA is set so 100% gives us max (255);

            int illum = (int)(155 * reqillum * reqillum + 100 * reqillum + 0);

            if (illum > 255)
            {
                illum = 255;
            }
            if (illum < 0)
            {
                illum = 0;
            }

            return illum;
        }
        private bool SendCommand(string commandString, bool waitForReply)
        {
            bool retValue = false;
            try
            {
                this.readbuffer.Initialize();
                StageSerialPort.DiscardInBuffer();
                StageSerialPort.Write(commandString);
                //Trace.WriteLine("SendCommand() commandString = " + commandString);
                if (waitForReply)
                {
                    //set the time out
                    waitTime = (DateTime.Now).AddMilliseconds(60000);
                    while (StageSerialPort.BytesToRead <= 3 && DateTime.Now < waitTime)
                    {
                        //wait for the three bytes or time out.
                        Thread.Sleep(30);
                    }
                    //read the reply
                    if (this.StageSerialPort.BytesToRead > 0)
                    {
                        StageSerialPort.Read(readbuffer, 0, 3);
                        //string reply = new string(readbuffer);
                        //Trace.WriteLine("SendCommand() readBuffer = " + reply);

                        //check reply signature is correct
                        if (readbuffer[0] == '!' && readbuffer[1] == '~')
                        {
                            retValue = true;
                           
                        }
                        else
                        {
                            retValue = false;
                        }
                    }
                    else
                    {
                        // Timed out, no bytes to read
                        retValue = false;
                    }
                }
                else
                {
                    retValue = true;
                }
            }
            catch (System.Exception ex)
            {
                retValue = false;
                Debug.Print("Error in sending command : " + ex);
                
            }

            return retValue;
        }


        private void DrawRectangle(PictureBox picbox, int len,int hei)
        {
            if (paint == true)
            {
                using (Graphics graphics = Graphics.FromImage(picbox.Image))
                {
                    Debug.Print(Convert.ToString(CurrentPosition[0]));
                    Debug.Print(Convert.ToString(CurrentPosition[1]));
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(CurrentPosition[0] - (len/2)), Convert.ToInt32(CurrentPosition[1]) - (hei/2) , len, hei);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(170, 254, 50, 50));
                    graphics.FillRectangle(brush, rectangle);
                }
                picbox.Refresh();
            }
        }
       

        private void FieldSizeRatio_ValueChanged(object sender, EventArgs e)
        {
            double x = (double)FieldSizeRatio.Value;
            Debug.Print(Convert.ToString((double)FieldSizeRatio.Value));
        }

        private void IlluminationControl_ValueChanged(object sender, EventArgs e)
        {
            if(StageSerialPort.IsOpen)
            {
                SetIllumination(IlluminationControl.Value);
            }
            
        }

        private void MoveStageButton_Click(object sender, EventArgs e)
        {
            if (StageSerialPort.IsOpen)
                {
                    try
                    {
                        if ((xcoord.Text == "") | (zcoord.Text == "") | (ycoord.Text == ""))
                        {
                            MessageBox.Show("Please input stage coordinates ");
                        }
                        else
                        {
                            if ((xcoord.Text == xLabel.Text) & (zcoord.Text == zLabel.Text) & (ycoord.Text == yLabel.Text))
                            {
                                MessageBox.Show("Stage already at coordinates ");
                            }
                            else
                            {
                                //Get X,Y,Z -> convert to double
                                double x = Convert.ToDouble(xcoord.Text);
                                double y = Convert.ToDouble(ycoord.Text);
                                double z = Convert.ToDouble(zcoord.Text);
                                var destination = new ThreeDPoint(x, y, z);
                                Debug.Print(string.Format("Moving stage to: ({0},{1},{2})", x, y, z));
                                MoveStage(destination, Timeouts.ASYNC);
                            


                            }

                        }



                    }
                    catch (Exception ex)
                    {
                        Debug.Print("Stage error " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No COM port connected ");
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            PositionXYZ();
            xLabel.Text = xposition;
            yLabel.Text = yposition;
            zLabel.Text = zposition;
        }

        private void FindGraticuleButton_Click(object sender, EventArgs e)
        {
            if (StageSerialPort.IsOpen)
            {
                if (stagecalibrated == true)
                {
                    double x = 32800;
                    double y = 22540;
                    double z = 9100;
                    var destination = new ThreeDPoint(x, y, z);
                    MoveStage(destination, Timeouts.ASYNC);
                    PositionXYZ();
                }
                else
                {
                    MessageBox.Show("Stage is not calibrated");
                }
            }
            else
            {
                MessageBox.Show("Stage is not connected");
            }
        }
    }
}
