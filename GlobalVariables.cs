using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MTF_Calc
{
    public partial class MainApp

    {
        public string filename;
        public Bitmap SelectedBMP;
        public bool cameraconnected = false;
        //Color[] ColorArray = new Color[100];
        int[] ColorAvgVert = new int[100];
        int[] ColorAvgHori = new int[100];
        List<double> xlist = new List<double>();
        List<double> ylist = new List<double>();
        List<double> zlist = new List<double>();
        List<int> ColorAvgVertical = new List<int>();
        List<int> ColorAvgHorizontal = new List<int>();
        List<int> PeakList = new List<int>();
        List<int> TroughList = new List<int>();
        double[,,] MTFData = new double[2 * max_locations, 2, 2]; //MTF,Position identifier, direction( horizontal = 1,vertical = 2)
        double[,] ImageCalibrationPositions = new double[max_locations, max_locations];
        double[,,] StageCalibrationPositions = new double[max_locations, max_locations, max_locations];
        public const int max_locations = 9;
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
        public int[] PositionsToUse = new int[9];
        /// <summary>
        /// The wait time for the serial port response. Reset during the SendCommand
        /// </summary>
        private DateTime waitTime = DateTime.Now;
        public struct FieldSize
        {
            public const double X = 400;
            public const double Y = 300;
        }
        int counter = 0;
        bool paint = false;

        public struct GroupPositions
        {
            public struct G1
            {
                public const double Xvert = 80;
                public const double Yvert = -5;
                public const double Xhori = 40;
                public const double Yhori = +5;

            }
            public struct G2
            {
                public const double Xvert = 77;
                public const double Yvert = 10;
                public const double Xhori = 44;
                public const double Yhori = -13;

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
