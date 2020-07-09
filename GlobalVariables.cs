using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace MTF_Calc
{
    public partial class MainApp

    {
        public string filename;
        public Bitmap SelectedBMP;                      //Bitmap object to hold bitmap loaded
        public bool cameraconnected = false;            //Boolean to check whether camera is connected to avoid exceptions
        int[] ColorAvgVert = new int[100];              //Arrays to hold pixel data
        int[] ColorAvgHori = new int[100];
        List<double> xlist = new List<double>();
        List<double> ylist = new List<double>();
        List<double> zlist = new List<double>();
        List<int> ColorAvgVertical = new List<int>();
        List<int> ColorAvgHorizontal = new List<int>();
        List<int> PeakList = new List<int>();
        List<int> TroughList = new List<int>();
        double[,,] MTFData = new double[2 * array_size, 2, 2];              //MTF,Position identifier, direction( horizontal = 1,vertical = 2)
        double[,] ImageCalibrationPositions = new double[array_size, 2];    //Pixel coordinates 
        double[,,] StageCalibrationPositions = new double[array_size, 2, 2];    //Stage coordinates
        public const int max_locations = 9;
        public const int array_size = 30;
        public int locations = max_locations;
        public int xcenter;
        public int ycenter;
        public int zcenter;
        public int[] xpos;
        public int[] ypos;
        public int[] zpos;
        public int x_start = 0;
        public int y_start = 0;
        public int z_start = 0;
        public int x_end = 0;
        public int y_end = 0;
        public int z_end = 0;
        string xposition;
        string yposition;
        string zposition;
        double[] CurrentPosition = new double[2];
        bool Clickable = false;
        int positivetarget;
        int negativetarget;
        bool stagecalibrated = false;
        bool calibrationcomplete = false;
        bool stagecenterfound = false;
        public int stage_x_center = 0;
        public int stage_y_center = 0;
        public int stage_z_center = 0;
        public int image_x_center = 0;
        public int image_y_center = 0;
        public int[] PositionsToUse = new int[9];
        /// <summary>
        /// The wait time for the serial port response. Reset during the SendCommand
        /// </summary>
        private DateTime waitTime = DateTime.Now;
        bool defaultPositions = true;
        public struct FieldSize
        {
            public const double X = 400;
            public const double Y = 300;
        }
        int counter = 0;
        bool paint = false;
        public int custom_max_locations = 0;

        public struct GroupPositions
        {
            /// <summary>
            /// Struct will hold the different Groups as objects within, and within each groups the relative coordinates of each line pair
            /// with regard to the top left of the box are saved. 
            /// </summary>
            public struct G1
            {
                public const double Xvert = 80;
                public const double Yvert = -5;
                public const double Xhori = 40;
                public const double Yhori = +5;

            }
            public struct G2
            {
                public const double Xvert = 81;
                public const double Yvert = 22;
                public const double Xhori = 45;
                public const double Yhori = 35;

            }
            public struct G3
            {
                public const double Xvert = 83;
                public const double Yvert = 48;
                public const double Xhori = 52;
                public const double Yhori = 59;

            }
            public struct G4
            {
                public const double Xvert = 83;
                public const double Yvert = 67;
                public const double Xhori = 54;
                public const double Yhori = 79;

            }
            public struct G5
            {
                public const double Xvert = 85;
                public const double Yvert = 89;
                public const double Xhori = 58;
                public const double Yhori = 98;

            }
            public struct G6
            {
                public const double Xvert = 86;
                public const double Yvert = 106;
                public const double Xhori = 62;
                public const double Yhori = 114;

            }



        }



        private void NumberCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //Only allow user to input numbers, otherwise there are exception errors
        }


    }
}
