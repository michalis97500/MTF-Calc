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
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace MTF_Calc
{
    public partial class MainApp : Form
    {
        private ICamera camera;
        public MainApp()
        {
            ///<Summary>
            /// On program load we ask whether a Basler or a MV camera is connected to create the interface object
            /// Then the user is asked to choose whether to load a calibration file or to start fresh
            ///</Summary>

            InitializeComponent();
            DialogResult result1 = MessageBox.Show("Is the connected camera a Basler? (Yes for Basler, No for MatrixVision)", "Camera select", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {

                camera = new BaslerCamera();

            }
            else
            {
                camera = new MatrixVision();

            }
            DialogResult result = MessageBox.Show("Do you want to load a calibration file?", "Load calibration select", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                LoadCalibration();

            }
            Array.Clear(MTFData, 0, MTFData.Length);
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                SerialSelect.Items.Add(port);
            }
            GroupSelectionBox.Items.Add("G7.1");
            GroupSelectionBox.Items.Add("G7.2");
            GroupSelectionBox.Items.Add("G7.3");
            GroupSelectionBox.Items.Add("G7.4");
            GroupSelectionBox.Items.Add("G7.5");


        }


        public void load_image_button_Click(object sender, EventArgs e)
        {
            try
            {
                //Function to load an image on the main picturbox
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
                MessageBox.Show("There was an error." + "Check the path to the image file.");
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
            cameraconnected = true;
            if(cameraconnected == true)
            {
                LiveFeedButton.Visible = true;
                StopLiveFeedButton.Visible = true;
                SingleImageButton.Visible = true;


            }
        }

        private void GenerateLineArrayVertical(int xposition, int yposition, Bitmap bmp, int length)
        {
            if (bmp != null) //check that be BMP given is not empty
            {
                Color[] TempColorArray = new Color[length+1]; //create a temporary array to hold values for RGB
                
                for (int i = yposition; i < yposition + length; i++)
                {
                    ///summary
                    ///This loop will take the coordinates given and run through them finding RGB colors at each pixel.
                    ///The RGB values are then averaged and put on a list to be used later
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
                ///see GenerateLineArrayVertical
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
                StartTest(defaultPositions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void StartTest(bool _default)
        {
            ///<summary>
            ///First we check that the COM port is open, a camera is connected and the calibration is complete.
            ///Camera capture is terminated since this makes the software runs slower.
            ///Some dummy variables are created and then the MTF data array is cleared.
            /// </summary>

            if (StageSerialPort.IsOpen)
            {
                camera.TerminateCapture();
                if (calibrationcomplete == true)
                {

                    if (cameraconnected == true)
                    {

                        DialogResult result = MessageBox.Show("Is the USAF target positive? (Yes for positive, No for negative)", "Target select", MessageBoxButtons.YesNo);
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

                        double x, y, z;
                        double x_relative_horizontal = 0;
                        double y_relative_horizontal = 0;
                        double x_relative_vertical = 0;
                        double y_relative_vertical = 0;

                        switch (GroupSelectionBox.SelectedIndex)
                        {
                            case -1:
                                MessageBox.Show("No group is selected. Please select a group to begin testing");
                                return;
                            case 0:
                                x_relative_horizontal = GroupPositions.G1.Xhori;
                                x_relative_vertical = GroupPositions.G1.Xvert;
                                y_relative_horizontal = GroupPositions.G1.Yhori;
                                y_relative_vertical = GroupPositions.G1.Yvert;
                                break;

                            case 1:
                                x_relative_horizontal = GroupPositions.G2.Xhori;
                                x_relative_vertical = GroupPositions.G2.Xvert;
                                y_relative_horizontal = GroupPositions.G2.Yhori;
                                y_relative_vertical = GroupPositions.G2.Yvert;
                                break;
                            case 2:
                                x_relative_horizontal = GroupPositions.G3.Xhori;
                                x_relative_vertical = GroupPositions.G3.Xvert;
                                y_relative_horizontal = GroupPositions.G3.Yhori;
                                y_relative_vertical = GroupPositions.G3.Yvert;
                                break;

                            case 3:
                                x_relative_horizontal = GroupPositions.G4.Xhori;
                                x_relative_vertical = GroupPositions.G4.Xvert;
                                y_relative_horizontal = GroupPositions.G4.Yhori;
                                y_relative_vertical = GroupPositions.G4.Yvert;
                                break;
                            case 4:
                                x_relative_horizontal = GroupPositions.G5.Xhori;
                                x_relative_vertical = GroupPositions.G5.Xvert;
                                y_relative_horizontal = GroupPositions.G5.Yhori;
                                y_relative_vertical = GroupPositions.G5.Yvert;
                                break;

                            case 5:
                                x_relative_horizontal = GroupPositions.G6.Xhori;
                                x_relative_vertical = GroupPositions.G6.Xvert;
                                y_relative_horizontal = GroupPositions.G6.Yhori;
                                y_relative_vertical = GroupPositions.G6.Yvert;
                                break;



                        }
                   
                        Array.Clear(MTFData, 0, MTFData.Length);
                        
                        for (int i = 0; i < locations; i++)
                        {
                            if (_default == true)
                            {
                                if (PositionsToUse[i] == 0)
                                {
                                    continue;
                                }
                            }
                            ///Summary
                            ///For all positions of calibration this loop attempts to move the stage at each one, take a picture, 
                            ///analyze and record MTF and then move to the next one.
                            x = StageCalibrationPositions[i, 0, 0];
                            y = StageCalibrationPositions[i, 1, 0];
                            z = StageCalibrationPositions[i, 0, 1];
                            //Move to Capture Horizontal
                            var destination_hori = new ThreeDPoint(x + x_relative_horizontal, y + y_relative_horizontal, z);
                            MoveStage(destination_hori, Timeouts.ASYNC);
                            camera.SingleImageCapture(ImageDisplay);
                            int x_image = Convert.ToInt32(ImageCalibrationPositions[i, 0]);
                            int y_image = Convert.ToInt32(ImageCalibrationPositions[i, 1]);
                            Bitmap bitmap = (Bitmap)ImageDisplay.Image;
                            GenerateLineArrayHorizontal(x_image, y_image, bitmap, 45);

                            //DateTime _dateTime = DateTime.Now;
                            //string format = "dd MM yy hh-mm";
                            //string dateTime = _dateTime.ToString(format);
                            //string _filename = Path.Combine(dateTime, Convert.ToString(i), "-Horiz.bmp") ;
                            //bitmap.Save(_filename, ImageFormat.Bmp);

                            //Move to capture Vertical
                            var destination_vert = new ThreeDPoint(x + x_relative_vertical, y + y_relative_vertical, z);
                            MoveStage(destination_vert, Timeouts.ASYNC);
                            camera.SingleImageCapture(ImageDisplay);
                            x_image = Convert.ToInt32(ImageCalibrationPositions[i, 0]);
                            y_image = Convert.ToInt32(ImageCalibrationPositions[i, 1]);
                            bitmap = (Bitmap)ImageDisplay.Image;


                            GenerateLineArrayVertical(x_image, y_image, bitmap, 45);
                            //Do Math
                            FindPeaks(ColorAvgHorizontal);
                            MTFCalc(Convert.ToDouble(i), 1);
                            FindPeaks(ColorAvgVertical);
                            MTFCalc(Convert.ToDouble(i), 2);
                            ColorAvgHorizontal.Clear();
                            ColorAvgVertical.Clear();
                            Debug.Print(Convert.ToString(MTFData[i, 0, 0]));
                            Debug.Print(Convert.ToString(MTFData[i, 1, 0]));
                            Debug.Print(Convert.ToString(MTFData[i, 0, 1]));


                        }
                        
                        SaveData();




                    }
                    else
                    {
                        MessageBox.Show("Camera is not connected");
                    }
                }
                else
                {
                    MessageBox.Show("Please calibrate the image first");
                }
            }
            else
            {
                MessageBox.Show("Serial port is not connected");
            }
        }
        private void SaveData()
        {
            //saves data in MTFData[] to a txt file

            try
            {
                string path = @"C:\MyTest.txt";
                MessageBox.Show("Choose a text document to save the results");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";      
                saveFileDialog1.Title = "Save text file";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CreatePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                }
                
                
                // Create the file, or overwrite if the file exists.
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    
                    sw.WriteLine("MTF Value, Position value, Line alignment, Stage X, Stage Y, Stage Z," + GroupSelectionBox.SelectedItem.ToString());
                    //Begin searching the MTF array for any values. 
                    for (int x = 0; x <= (2*locations - 1); x++)
                    {
                     
                        if(MTFData[x,0,0] == 0)
                        {
                            continue; //value is 0, thus nothing is written at this place
                        }
                        else
                        {
                            //Non-zero value found. Get the position of this value, and find its stage coordinates.
                            int position = Convert.ToInt32(MTFData[x,1,0]);
                            double stage_x = StageCalibrationPositions[position, 0, 0] - Convert.ToDouble(stage_x_center);
                            double stage_y = StageCalibrationPositions[position, 1, 0] - Convert.ToDouble(stage_y_center);
                            double stage_z = StageCalibrationPositions[position, 0, 1] - Convert.ToDouble(stage_z_center); 
                            switch(MTFData[x,0,1])
                            {
                                //Finally, write the data to a new line
                                case 2:
                                    
                                    sw.WriteLine(Convert.ToString(MTFData[x, 0, 0]) + "," + Convert.ToString(MTFData[x, 1, 0]) + "," + "Horizontal" + "," + stage_x + "," + stage_y + "," + stage_z );
                                    break;
                                case 1:
                                    sw.WriteLine(Convert.ToString(MTFData[x, 0, 0]) + "," + Convert.ToString(MTFData[x, 1, 0]) + "," + "Vertical" + "," + stage_x + "," + stage_y + "," + stage_z  );
                                    break;
                                
                            }
                            
                        }
                        
                        
                        
                            
                    }
                    
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in savedata : " + ex.ToString());
            }
        }

        private void SaveCalibration()
        {
            try
            {

                ///This function gets the data from the StageCalibration array and ImageCalibration array
                ///and saves it to a comma-seperated file. 
                string path = @"C:\MyTest.txt";
                MessageBox.Show("Choose a text document to save the calibration");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save text file";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CreatePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                }


                // Create the file, or overwrite if the file exists.
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("Stage X center, Stage Y center, Stage Z center, Illumination value, Field size ratio value,");
                    sw.WriteLine(stage_x_center + "," + stage_y_center + "," + stage_z_center + "," + IlluminationControl.Value + "," + FieldSizeRatio.Value);
                    sw.WriteLine("Stage X, Stage Y, Stage Z, Image X, Image Y," + IlluminationControl.Value + "," + FieldSizeRatio.Value);
                    for (int i = 0; i < locations; i++ )
                    {
                        double x_image = ImageCalibrationPositions[i, 0];
                        double y_image = ImageCalibrationPositions[i, 1];
                        double x_stage = StageCalibrationPositions[i, 0, 0];
                        double y_stage = StageCalibrationPositions[i, 1, 0];
                        double z_stage = StageCalibrationPositions[i, 0, 1];
                        sw.WriteLine(x_stage + "," + y_stage + "," + z_stage + "," + x_image + "," + y_image);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in saving calibration : " + ex);
            }
        }

        private void LoadCalibration()
        {
            try
            {   ///<summary>
                ///This function attempts to read a file created by the SaveCalibration() function and
                ///load the data into the arrays
                ///</summary>

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "text file|*.txt";
                DialogResult image = dialog.ShowDialog();
                if (image == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        var line0 = sr.ReadLine(); //Read the first line, containing strings (useless to the program)
                        var line1 = sr.ReadLine();  //Read the second line, containing usefull data
                        var value1 = line1.Split(',');
                        stage_x_center = Convert.ToInt32(value1[0]);
                        stage_y_center = Convert.ToInt32(value1[1]);
                        stage_z_center = Convert.ToInt32(value1[2]);
                        IlluminationControl.Value = Convert.ToDecimal(value1[3]);
                        FieldSizeRatio.Value = Convert.ToDecimal(value1[4]);
                        sr.ReadLine();
                        int i = 0;
                        while (!sr.EndOfStream)
                        {
                            
                            if (i > 0)
                            {
                                var line = sr.ReadLine();
                                var values = line.Split(',');
                                Console.WriteLine(values[0]);
                                Console.WriteLine(i);
                                StageCalibrationPositions[i - 1, 0, 0] = Convert.ToDouble(values[0]);
                                StageCalibrationPositions[i - 1, 1, 0] = Convert.ToDouble(values[1]);
                                StageCalibrationPositions[i - 1, 0, 1] = Convert.ToDouble(values[2]);
                                ImageCalibrationPositions[i - 1, 0] = Convert.ToDouble(values[3]);
                                ImageCalibrationPositions[i - 1, 1] = Convert.ToDouble(values[4]);
                                
                            }
                            i++;
                        }
                    }
                    calibrationcomplete = true;
                    stagecenterfound = true;
                    TestPositionsButton.Enabled = true;
                    CalibrateImageButton.Enabled = true;
                    StartTestButton.Enabled = true ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading calibartion : " + ex);
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
                    if (i == 0 || i == (list.Count - 1) || i == 1 || i== (list.Count - 2) )
                    {
                        Console.WriteLine("No adjacent values");
                    }
                    else
                    {
                        if (list[i] > list[i - 1] && list[i] > list[i + 1] && list[i] > list[i-2] && list[i] > list[i + 2])
                        {
                            Console.WriteLine("Peak found at " + i + " of value " + list[i]);
                            PeakList.Add(list[i]);
                        }

                        if (list[i] < list[i - 1] && list[i] < list[i + 1] && list[i] < list[i - 2] && list[i] < list[i + 2])
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

        private void MTFCalc(double position,int direction)
        {
            ///<summary> 
            ///This function runs through the global PeakList and TroughList and calculates the MTF. 
            ///The function takes in 2 parameters that it uses to help identify at which position the MTF is calculated and
            ///for which direction
            ///</summary> 
            
                if (PeakList.Any() && TroughList.Any())
                {
                    double mtf;
                    double upper;
                    double lower;
                    double peaks = 0 ;
                    double troughs = 0;
                    for (int i = 0; i < PeakList.Count; i++)
                    {
                        peaks += Convert.ToDouble(PeakList[i]);
                    }
                    for (int i = 0; i < TroughList.Count; i++)
                    {
                        troughs += Convert.ToDouble(TroughList[i]);
                    }

                    upper = (peaks/PeakList.Count) - (troughs/TroughList.Count);
                    lower = (peaks/PeakList.Count) + (troughs/TroughList.Count);
                    mtf = upper / lower;
                    
                    for (int x = 0; x <= 2*locations; x++)
                    {
                    //Find the first empty element of the MTF Data 
                        if (MTFData[x, 0, 0] == 0)
                        {
                            ///Write the MTF value to the 1st diemnsion, write the position value to the 2nd, write the direction to the 3rd
                            MTFData[x, 0, 0] = mtf;
                            MTFData[x, 1, 0] = position;
                            MTFData[x, 0, 1] = Convert.ToDouble(direction);
                            break;

                        }
                            
                    }

                    
                }
            
        }

        private void CenterStageButton_Click(object sender, EventArgs e)
        {
            if (stagecenterfound == true)
            {
                double x = Convert.ToDouble(stage_x_center);
                double y = Convert.ToDouble(stage_y_center);
                double z = Convert.ToDouble(stage_z_center);
                var destination = new ThreeDPoint(x, y, z);
                Debug.Print(string.Format("Moving stage to: ({0},{1},{2})", x, y, z));
                MoveStage(destination, Timeouts.ASYNC);
                PositionXYZ();
            }
            else
            {
                double x = Convert.ToDouble(xcenter);
                double y = Convert.ToDouble(ycenter);
                double z = Convert.ToDouble(zcenter);
                var destination = new ThreeDPoint(x, y, z);
                Debug.Print(string.Format("Moving stage to: ({0},{1},{2})", x, y, z));
                MoveStage(destination, Timeouts.ASYNC);
                PositionXYZ();
            }
        }

        private void CalibrateStageButton_Click(object sender, EventArgs e)
        {
            if (StageSerialPort.IsOpen)
            {
                CalibrateStage();
                DialogResult result = MessageBox.Show("Would you like to calibrate stage center now?", "Calibrate stage center", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FindStageCenter();
                }
                
            }
            else
            {
                MessageBox.Show("No COM port connected ");
            }
        }

        private void CalibrateImage(int position, bool _default)
        {
            try
            {
                ///<summary>
                ///This function breaks down to 2 cases, default or not. In both cases the procedure is similar with the difference being
                ///the positions of calibration. The default has some hard-coded positions where as the "custom" allows input of different positions.
                ///The parameter "position" will allow identification of the position number and hence the position.
                ///Once the picturebox is clicked this function is called, which gets the current coordinates of the click. It then stores 
                ///the data to an array which holds all the positions. For the default calibration the stage coordinates are also saved in case the user
                ///has fine-adjusted the stage. The software then attempts to move the stage to the next position to be calibrated
                ///</summary>
                
                if (_default == true)
                {
                    ImageCalibrationPositions[position, 0] = CurrentPosition[0];
                    ImageCalibrationPositions[position, 1] = CurrentPosition[1];
                    PositionXYZ();
                    double x = Convert.ToDouble(xposition);
                    double y = Convert.ToDouble(yposition);
                    double z = Convert.ToDouble(zposition);
                    StageCalibrationPositions[position, 0, 0] = x;
                    StageCalibrationPositions[position, 1, 0] = y;
                    StageCalibrationPositions[position, 0, 1] = z;
                    switch (position)
                    {
                        case 0:
                            ThreeDPoint LeftBottomCorner = new ThreeDPoint(x + (FieldSize.X * ((double)FieldSizeRatio.Value/100) / 2), y - (FieldSize.Y * ((double)FieldSizeRatio.Value/100) / 2), z);
                            MoveStage(LeftBottomCorner, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at the left bottom corner");
                            break;
                        case 1:
                            ThreeDPoint BottomEdge = new ThreeDPoint(x - (FieldSize.X * ((double)FieldSizeRatio.Value)/100)/2, y , z);
                            MoveStage(BottomEdge, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at the bottom edge");
                            break;
                        case 2:
                            ThreeDPoint RightBottomCorner = new ThreeDPoint(x - (FieldSize.X * ((double)FieldSizeRatio.Value)/2 / 100), y, z);
                            MoveStage(RightBottomCorner, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at right bottom corner");
                            break;
                        case 3:
                            ThreeDPoint RightEdge = new ThreeDPoint(x, y + (FieldSize.Y * ((double)FieldSizeRatio.Value) /2 /100), z);
                            MoveStage(RightEdge, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at right edge");
                            break;
                        case 4:
                            ThreeDPoint RightTopCorner = new ThreeDPoint(x, y + (FieldSize.Y * ((double)FieldSizeRatio.Value) / 2 / 100), z);
                            MoveStage(RightTopCorner, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at right top corner");
                            break;
                        case 5:
                            ThreeDPoint TopEdge = new ThreeDPoint(x + (FieldSize.X * ((double)FieldSizeRatio.Value) /2 /100), y, z);
                            MoveStage(TopEdge, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at the upper edge");
                            break;
                        case 6:
                            ThreeDPoint TopLeftCorner = new ThreeDPoint(x + (FieldSize.X * ((double)FieldSizeRatio.Value) / 2 / 100), y, z);
                            MoveStage(TopLeftCorner, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the box is at the top left corner");
                            break;
                        case 7:
                            ThreeDPoint LeftEdge = new ThreeDPoint(x , y - (FieldSize.Y * ((double)FieldSizeRatio.Value) / 2 / 100), z);
                            MoveStage(LeftEdge, Timeouts.ASYNC);
                            MessageBox.Show("Ensure the crosshair is at left edge");
                            break;
                        case 8:
                            MessageBox.Show("Calibration Complete");
                            Clickable = false;
                            StartTestButton.Enabled = true;
                            calibrationcomplete = true;
                            SaveCalibrationButton.Enabled = true;
                            break;
                    }
                }
                if (_default==false)
                {
                    if (position < custom_max_locations - 1 )
                    {
                        ImageCalibrationPositions[position, 0] = CurrentPosition[0];
                        ImageCalibrationPositions[position, 1] = CurrentPosition[1];
                        double x, y, z;
                        x = StageCalibrationPositions[position + 1, 0, 0];
                        y = StageCalibrationPositions[position + 1, 1, 0];
                        z = StageCalibrationPositions[position + 1, 0, 1];
                        ThreeDPoint nextDestination = new ThreeDPoint(x, y, z);
                        MoveStage(nextDestination, Timeouts.MOVE);
                        MessageBox.Show("Click on the top left corner of the white box");
                    }
                    if (position == custom_max_locations - 1 )
                    {
                        ImageCalibrationPositions[position, 0] = CurrentPosition[0];
                        ImageCalibrationPositions[position, 1] = CurrentPosition[1];
                        MessageBox.Show("Calibration Complete");
                        calibrationcomplete = true;
                        Clickable = false;
                        StartTestButton.Visible = true;
                    }
                    
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in image calibration : " + ex);
            }
        
        }

        private void SetStageCenter()
        {
            stagecenterfound = true;
            image_x_center = Convert.ToInt32(CurrentPosition[0]);
            image_y_center = Convert.ToInt32(CurrentPosition[1]);
            PositionXYZ();
            stage_x_center = Convert.ToInt32(xposition);
            stage_y_center = Convert.ToInt32(yposition);
            stage_z_center = Convert.ToInt32(zposition);
            MessageBox.Show("Stage center found and recorded. You may now calibrate the image");
            CalibrateImageButton.Enabled = true;
            Clickable = false;
            camera.SingleImageCapture(ImageDisplay);
            
        }

        private void ImageDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                ///<summary>
                ///Check if the picturebox click must be handled (clickable = true). If so, get the coordinates of the click and ask
                ///the user if the click was indeed intentional + correct. If this is the case write the coordinates to global variables
                ///and call CalibrateImage function.
                /// </summary>
                
                if (Clickable == true)
                {
                    camera.TerminateCapture();
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
                        if (stagecenterfound == true)
                        {
                            CurrentPosition[0] = imagePixelX;
                            CurrentPosition[1] = imagePixelY;
                            paint = true;
                            CalibrateImage(counter, defaultPositions);
                            counter++;
                            camera.LiveImage(ImageDisplay);
                        }
                        else
                        {
                            CurrentPosition[0] = imagePixelX;
                            CurrentPosition[1] = imagePixelY;
                            SetStageCenter();
                        }
                                                                                               
                    }

                }
            }
            catch (Exception ex)
            {

                Debug.Print("Error : " + ex);
            }
        }


        private void FindStageCenter()
        {
            ///<summary>
            ///This functions is used to calibrate the stage in relationship to the center of the field
            /// </summary>
            try
            {
                paint = true;   
                if(StageSerialPort.IsOpen)
                {
                    if (cameraconnected == true)
                    {
                        camera.TerminateCapture();
                        stagecenterfound = false;
                        Clickable = true;
                        MessageBox.Show("Place the top left of the corner on the center of the crosshair");
                        Thread thread = new Thread(() =>
                        {
                            while (!stagecenterfound)
                            {
                                camera.SingleImageCapture(ImageDisplay);
                                DrawRectangle(ImageDisplay, 100, 3, ImageDisplay.Image.Width / 2, ImageDisplay.Image.Height / 2);
                                DrawRectangle(ImageDisplay, 3, 100, ImageDisplay.Image.Width / 2, ImageDisplay.Image.Height / 2);
                            }
                            
                        });
                        thread.Start();
                    }
                    else
                    {
                        MessageBox.Show("Camera is not connected");
                    }
                }
                else
                {
                    MessageBox.Show("Stage is not connected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void CalibrateImageButton_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///Stop camera capture to avoid slow program. Ask the user if s/w should use default positions and if not load the custom positions. 
            ///Either way, this will reset the counter (position identifying variable) and make the picturebox clickable (see ImageDisplay_click). Attempt to move the
            ///stage to the first position. Restart live-capture
            /// </summary>
            camera.TerminateCapture();
            if (stagecenterfound == true)
            {
                paint = true;
                counter = 0;
                Clickable = true;
                DialogResult result = MessageBox.Show("Would you like to use the default calibration positions?", "Calibration", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    defaultPositions = true;
                    TestPositionsButton.Enabled = true;
                    double x = Convert.ToDouble(stage_x_center);
                    double y = Convert.ToDouble(stage_y_center);
                    double z = Convert.ToDouble(stage_z_center);
                    var destination = new ThreeDPoint(x, y, z);
                    MoveStage(destination, Timeouts.ASYNC);
                    MessageBox.Show("Click on the top left corner of the box");
                    camera.LiveImage(ImageDisplay);

                }
                if (result == DialogResult.No)
                {
                    defaultPositions = false;
                    LoadCustomPositions();
                    double x, y, z;
                    x = StageCalibrationPositions[0, 0, 0];
                    y = StageCalibrationPositions[0, 1, 0];
                    z = StageCalibrationPositions[0, 0, 1];
                    ThreeDPoint destination = new ThreeDPoint(x, y, z);
                    MoveStage(destination, Timeouts.ASYNC);
                    MessageBox.Show("Click on the top left corner of the box");
                    camera.LiveImage(ImageDisplay);

                }
            }
            else
            {
                MessageBox.Show("Please calibrate the stage center");

            }
                           

        }

        private void StageConnectButton_Click(object sender, EventArgs e)
        {
            SerialConnection();

        }

        private void LoadCustomPositions()
        {
            try
            {
                //Ask the user to point to a file with the stage values to use
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "text file|*.txt";
                DialogResult file = dialog.ShowDialog();
                if (file == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    int lineCount = File.ReadLines(filename).Count();
                    
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        //Read the file line by line. "Discard" the first line as it is used to help the user know where to place the coords
                        var line1 = sr.ReadLine();
                        int i = 0;
                        while (!sr.EndOfStream)
                        {
                            if (i > 0)
                            {
                                //Write the values in the file to the Stage position array
                                var line = sr.ReadLine();
                                var values = line.Split(',');
                                Console.WriteLine(values[0]);
                                Console.WriteLine(i);
                                StageCalibrationPositions[i - 1, 0, 0] = Convert.ToDouble(values[0]) + Convert.ToDouble(stage_x_center);
                                StageCalibrationPositions[i - 1, 1, 0] = Convert.ToDouble(values[1]) + Convert.ToDouble(stage_y_center);
                                StageCalibrationPositions[i - 1, 0, 1] = Convert.ToDouble(values[2]) + Convert.ToDouble(stage_z_center);
                                custom_max_locations++;

                            }
                            i++;
                        }
                    }
                    locations = custom_max_locations;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading calibartion : " + ex);
            }
        }
        
        private void SetIllumination(Decimal value)
        {
            ///<summary>
            ///Copied from original spotlight test tool. This sends a command to change illumination level of the spotlight LED
            /// </summary>
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


        private void DrawRectangle(PictureBox picbox, int len,int hei,int xpos,int ypos)
        {
            ///<summary>
            ///Function used to draw rectangle of length len, height hei, at xpos,ypos of picbox. Used in testing the software
            /// </summary>
            ///
            if (picbox.InvokeRequired)
            {
                picbox.Invoke(new MethodInvoker( delegate ()
                {
                    if (paint == true)
                    {
                        using (Graphics graphics = Graphics.FromImage(picbox.Image))
                        {
                        Rectangle rectangle = new Rectangle(xpos - (len/2), ypos - (hei/2) , len, hei);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(170, 254, 50, 50));
                        graphics.FillRectangle(brush, rectangle);
                        }
                
                        picbox.Refresh();
                    }

                }));
             }
            else
            {
                if (paint == true)
                {
                    using (Graphics graphics = Graphics.FromImage(picbox.Image))
                    {
                        Rectangle rectangle = new Rectangle(xpos - (len / 2), ypos - (hei / 2), len, hei);
                        SolidBrush brush = new SolidBrush(Color.FromArgb(170, 254, 50, 50));
                        graphics.FillRectangle(brush, rectangle);
                    }

                    picbox.Refresh();
                }
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

        private void PositionButton_Click(object sender, EventArgs e)
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

        private void FindUSAFButton_Click(object sender, EventArgs e)
        {
            if (StageSerialPort.IsOpen)
            {
                if (stagecalibrated == true)
                {
                    double x = 40493;
                    double y = 23199;
                    double z = 9335;
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

        private void TestPositionsButton_Click(object sender, EventArgs e)
        {
            var form = new TestPositionForm();
            form.ShowDialog();
            if( form.Center == true) 
            { 
                PositionsToUse[0] = 1;
            }
            else { PositionsToUse[0] = 0; }
            if (form.LBCorner == true)
            {
                PositionsToUse[1] = 1;
            }
            else { PositionsToUse[1] = 0; }
            if (form.BEdge == true)
            {
                PositionsToUse[2] = 1;
            }
            else { PositionsToUse[2] = 0; }
            if (form.RBCorner == true)
            {
                PositionsToUse[3] = 1;
            }
            else { PositionsToUse[3] = 0; }
            if (form.REdge == true)
            {
                PositionsToUse[4] = 1;
            }
            else { PositionsToUse[4] = 0; }
            if (form.RTCorner == true)
            {
                PositionsToUse[5] = 1;
            }
            else { PositionsToUse[5] = 0; }
            if (form.UEdge == true)
            {
                PositionsToUse[6] = 1;
            }
            else { PositionsToUse[6] = 0; }
            if (form.LTCorner == true)
            {
                PositionsToUse[7] = 1;
            }
            else { PositionsToUse[7] = 0; }
            if (form.LEdge == true)
            {
                PositionsToUse[8] = 1;
            }
            else { PositionsToUse[8] = 0; }
            
        }

        private void SaveCalibrationButton_Click(object sender, EventArgs e)
        {
            if (calibrationcomplete == true)
            {
                camera.TerminateCapture();
                SaveCalibration();
                camera.LiveImage(ImageDisplay);
            }
            
            
        }

        private void CalibrateStageCenterButton_Click(object sender, EventArgs e)
        {
            camera.TerminateCapture();
            paint = true;
            counter = 0;
            FindStageCenter();
        }
    }
}
