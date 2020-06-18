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
        Color[] ColorArray = new Color[100];
        int[] ColorAvgVert = new int[100];
        int[] ColorAvgHori = new int[100];
        List<double> xlist = new List<double>();
        List<double> ylist = new List<double>();
        List<double> zlist = new List<double>();
        List<int> ColorAvgVertical = new List<int>();
        List<int> PeakList = new List<int>();
        List<int> TroughList = new List<int>();
        double[,] MTFData = new double[30, 2];
        double[,] ImageCalibrationPositions = new double[5, 5];
        double[,,] StageCalibrationPositions = new double[5, 5, 5];
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
        double FieldSize;
        bool ImageCalibrationStarted = false;
        int counter = 0;


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
