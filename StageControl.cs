using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MTF_Calc
{
    public partial class MainApp
    {
        public bool MoveStage(ThreeDPoint point, double timeout)
        {
            /* This class converts the "input" from ThreeDPoint, 3 arrays, x y and z. The arrays are then manupulated 
             * and converted to hexadecimal. Each array is appended on a Prefix that determines the coordinate to move to
             * Once an array "byteArray" is set up such that it contains information on where to move each axis it is sent
             * to SerialWrite() class to be sent to the stage controller.
             */
            ASCIIEncoding ascii = new ASCIIEncoding();
            Byte[] xArray = ascii.GetBytes(Math.Floor(point.X + 0.5).ToString().ToCharArray());
            Byte[] yArray = ascii.GetBytes(Math.Floor(point.Y + 0.5).ToString().ToCharArray());
            Byte[] zArray = ascii.GetBytes(Math.Floor(point.Z + 0.5).ToString().ToCharArray());
            int arraySize = 16 + xArray.Length + yArray.Length + zArray.Length;

            Byte[] byteArray = new byte[arraySize];
            byteArray[0] = 0x55;
            byteArray[1] = 0x07;
            byteArray[2] = 0x72;
            byteArray[3] = 0x0D;
            byteArray[4] = 0x55;
            byteArray[5] = 0x00;

            for (int x = 0; x < xArray.Length; x++)
            {
                byteArray[6 + x] = xArray[x];
            }

            byteArray[6 + xArray.Length] = 0x0D;
            byteArray[6 + xArray.Length + 1] = 0x55;
            byteArray[6 + xArray.Length + 2] = 0x01;

            for (int y = 0; y < yArray.Length; y++)
            {
                byteArray[6 + xArray.Length + 3 + y] = yArray[y];
            }

            byteArray[6 + xArray.Length + 3 + yArray.Length] = 0x0D;
            byteArray[6 + xArray.Length + 3 + yArray.Length + 1] = 0x55;
            byteArray[6 + xArray.Length + 3 + yArray.Length + 2] = 0x02;

            for (int z = 0; z < zArray.Length; z++)
            {
                byteArray[6 + xArray.Length + 3 + yArray.Length + 3 + z] = zArray[z];
            }

            byteArray[6 + xArray.Length + 3 + yArray.Length + 3 + zArray.Length] = 0x0D;
            byteArray[6 + xArray.Length + 3 + yArray.Length + 3 + zArray.Length + 1] = 0x55;
            byteArray[6 + xArray.Length + 3 + yArray.Length + 3 + zArray.Length + 2] = 0x50;
            byteArray[6 + xArray.Length + 3 + yArray.Length + 3 + zArray.Length + 3] = 0x0D;

            return SerialWrite(byteArray, Timeouts.CLASH_PROTECT);

        }

        public void PositionXYZ()
        { //Command used to determine the position of the stage

            if (StageSerialPort.IsOpen)
            {
                try
                {

                    Byte[] byteArray = new byte[3];                     //Create an array that will be used to store commands

                    byteArray[0] = 0x55;
                    byteArray[1] = 0x43;
                    byteArray[2] = 0x0D;                            //Command to get positon of x
                    SerialWrite(byteArray, Timeouts.READ_STATUS);   //send command
                    if (StageSerialPort.IsOpen)
                    {

                        xpos = new int[readbuffer.Length];
                        for (int i = 0; i < readbuffer.Length; i++)
                        {
                            xpos[i] = readbuffer[i];
                            Console.Write(xpos[i]);
                        }                                               //Write the positon of x to a local array

                        byteArray[0] = 0x55;                            //same as above, but for y
                        byteArray[1] = 0x44;
                        byteArray[2] = 0x0D;
                        SerialWrite(byteArray, Timeouts.READ_STATUS);
                        ypos = new int[readbuffer.Length];
                        for (int i = 0; i < readbuffer.Length; i++)
                        {
                            ypos[i] = readbuffer[i];
                            Console.Write(ypos[i]);
                        }

                        byteArray[0] = 0x55;                            //same as above but for z
                        byteArray[1] = 0x45;
                        byteArray[2] = 0x0D;
                        SerialWrite(byteArray, Timeouts.READ_STATUS);
                        zpos = new int[readbuffer.Length];
                        for (int i = 0; i < readbuffer.Length; i++)
                        {
                            zpos[i] = readbuffer[i];
                            Console.Write(zpos[i]);
                        }

                        /*  Now create 3 new strings from the 3 arrays created above. The strings are then 
                        *  used to store the position of xyz in a global variable This has been done so 
                        *  in order to help capture start/end stop absolut positions and store them as well as display
                        *  position to user
                        */
                        var xposition = new StringBuilder();
                        foreach (int digit in xpos)
                        {
                            if (digit == 13) break;
                            xposition.Append(((char)digit).ToString());

                        }

                        //SetTextx(xposition.ToString());
                        this.xposition = xposition.ToString();

                        var yposition = new StringBuilder();
                        foreach (int digit in ypos)
                        {
                            if (digit == 13) break;
                            yposition.Append(((char)digit).ToString());
                        }

                        //SetTexty(yposition.ToString());
                        this.yposition = yposition.ToString();

                        var zposition = new StringBuilder();
                        foreach (int digit in zpos)
                        {
                            if (digit == 13) break;
                            zposition.Append(((char)digit).ToString());
                        }

                        //SetTextz(zposition.ToString());
                        this.zposition = zposition.ToString();
                        Debug.Print(this.xposition);
                        Debug.Print(this.yposition);
                        Debug.Print(this.zposition);



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to get position : " + ex.Message);

                }
            }


        }
        private void StageStartEndStops()
        {
            if (StageSerialPort.IsOpen)
            {
                PositionXYZ();  //Ask for current position, @start end stops, and write it to global variables
                x_start = Int32.Parse(xposition.ToString());
                y_start = Int32.Parse(yposition.ToString());
                z_start = Int32.Parse(zposition.ToString());
            }

        }
        private void StageFarEndStops()
        {
            if (StageSerialPort.IsOpen)
            {
                PositionXYZ();  //Ask for current position, @start end stops, and write it to global variables
                x_end = Int32.Parse(xposition.ToString());
                y_end = Int32.Parse(yposition.ToString());
                z_end = Int32.Parse(zposition.ToString());
            }

        }
        private void CalibrateStage()
        {
            try
            {
                Byte[] byteArray = new byte[7];

                byteArray[0] = 0x55;    // command for calibration, takes stage to 0,0 and registers positon
                byteArray[1] = 0x07;    //U;Character(7);c;Character(0D);U;Character(80);Character(0D)  
                byteArray[2] = 0x63;    //Character(0D) = 0x0D is the Carriage Return
                byteArray[3] = 0x0D;
                byteArray[4] = 0x55;
                byteArray[5] = 0x50;
                byteArray[6] = 0x0D;
                SerialWrite(byteArray, Timeouts.MOVE);


                StageStartEndStops();       //stage is now @0,0,0 (start end points). Save the absolute positon
                if (StageSerialPort.IsOpen)
                {


                    byteArray[0] = 0x55;    //command to move at far end stops
                    byteArray[1] = 0x07;    //U;Character(7);Character(6c);Character(0D);U;Character(80);Character(0D)
                    byteArray[2] = 0x6c;
                    byteArray[3] = 0x0D;
                    byteArray[4] = 0x55;
                    byteArray[5] = 0x50;
                    byteArray[6] = 0x0D;
                    SerialWrite(byteArray, Timeouts.MOVE);

                    StageFarEndStops();         //stage is now @X,Y,Z   far end points. Save the absolute positon
                    if (StageSerialPort.IsOpen)
                    {
                        if (x_end < 90000 && y_end < 90000 && z_end < 90000 && x_start > 480 && y_start > 480 && z_start > 480)
                        {
                            xcenter = (x_end - x_start) / 2;
                            ycenter = (y_end - y_start) / 2;
                            zcenter = (z_end - z_start) / 2;
                            CenterStageButton.Visible = true;
                            //CalibrateImageButton.Visible = true;
                            FindUSAFButton.Visible = true;
                            FindGraticuleButton.Visible = true;
                            stagecalibrated = true;
                            DialogResult result = MessageBox.Show("Calibration Complete. Send stage to center?", "Calibration complete", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                try
                                {

                                    //Get X,Y,Z -> convert to double
                                    double x = Convert.ToDouble((x_end - x_start) / 2);
                                    double y = Convert.ToDouble((y_end - y_start) / 2);
                                    double z = Convert.ToDouble((z_end - z_start) / 2);
                                    var destination = new ThreeDPoint(x, y, z);
                                    Debug.Print(string.Format("Moving stage to: ({0},{1},{2})", x, y, z));
                                    MoveStage(destination, Timeouts.ASYNC);

                                }

                                catch (Exception ex)
                                {
                                    Debug.Print("Stage error " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Calibration looks bad. Retry?", "Calibration complete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.Yes)
                            {
                                CalibrateStage();
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting calibration : " + ex.Message);
            }
        }
        public void SerialConnection()
        {
            try
            {
                if (SerialSelect.Text == "")
                {
                    MessageBox.Show("Please select a COM port");

                }
                else
                {
                    StageSerialPort.PortName = SerialSelect.Text;
                    StageSerialPort.BaudRate = 9600;
                    StageSerialPort.Parity = Parity.None;
                    StageSerialPort.DataBits = 8;
                    StageSerialPort.StopBits = StopBits.Two;
                    StageSerialPort.Handshake = Handshake.RequestToSend;
                    StageSerialPort.WriteTimeout = 500;
                    StageSerialPort.Open();
                    CalibrateStageButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in opening the serial port : " + ex);
            }

        }

        private bool SerialWrite(Byte[] commandBytes, int timeout, bool showTrace = false, bool waitForResponse = true)
        {
            /* SerialWrite is the command that sends data via the comport to the stage controller. The command discards In/Out buffer and initializes
             * an event handler to wait for a response. It then proceeds to send out the input. If a response is recieved in time it is captured and printed
             * through Debug.Print
             */
            bool retValue = false;
            try
            {
                string commandString = Encoding.UTF8.GetString(commandBytes, 0, commandBytes.Length);
                DateTime startTime = DateTime.Now;
                if (showTrace)
                {
                    WriteTraceOutput(String.Format("{0} - SendCommand2() SEND {1}", DateTime.Now.ToString(), commandString));
                }

                this.commandResponse = String.Empty;
                this.readBufferBytes.Initialize();
                this.readbuffer.Initialize();
                this.serialDataReceived = false;
                this.serialCommandTimedOut = false;

                this.StageSerialPort.DiscardOutBuffer();
                this.StageSerialPort.DiscardInBuffer();
                this.StageSerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                this.StageSerialPort.Write(commandBytes, 0, commandBytes.Length);

                if (waitForResponse)
                {
                    retValue = WaitForCommandResponse(timeout);
                    if (!retValue)
                    {
                        //this.commandControlMessage = LString(ResIds.IDS_SERIAL_PORT_COMMAND_TIMEOUT);
                        MessageBox.Show("SerialPort Timeout ");
                    }

                    // Check reply signature is correct
                    string readBufferString = new string(this.readbuffer);
                    this.commandResponse = readBufferString;

                    if (showTrace)
                    {
                        double responseTime = (DateTime.Now - startTime).TotalMilliseconds;
                        WriteTraceOutput(String.Format("{0} - SendCommand2() RECEIVE {1}, time taken = {2}ms", DateTime.Now.ToString(), readBufferString, responseTime.ToString()));
                    }
                    for (int i = 0; i < readbuffer.Length; i++)
                    {
                        Debug.Print("{0}", readbuffer[i]);
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
                //string message = String.Format(LString(ResIds.IDS_COM_PORT_SEND_ERROR), ex.Message);
                MessageBox.Show("COM Write error : " + ex.Message + " The connection will now be terminated");
                StageSerialPort.Close();
                return retValue;


            }
            finally
            {
                // Always disconnect from the event
                this.StageSerialPort.DataReceived -= this.SerialPort_DataReceived;
            }

            return retValue;
        }

        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /* This class is used to monitor the replies from the stage controller and append
             * them on readbuffer.
             */
            bool terminatorFound = false;
            int index = 0;

            //lock (this.StageSerialPort)
            lock (lockObject)
            {
                do
                {
                    if (this.StageSerialPort.IsOpen)
                    {
                        if (this.StageSerialPort.BytesToRead > 0)
                        {
                            Byte readByte = (Byte)this.StageSerialPort.ReadByte();
                            this.readBufferBytes[index] = readByte;
                            this.readbuffer[index] = (char)readByte;
                            terminatorFound = (readByte == 0x0D);
                            index++;
                        }
                    }
                }
                while ((!terminatorFound) && (!this.stageStopWaiting));
            }
            if (!this.stageStopWaiting)
            {
                this.serialDataReceived = true;
            }

            this.stageStopWaiting = false;


        }

        private void WriteTraceOutput(string traceOutput)
        {

            {
                Trace.WriteLine(traceOutput);
            }
        }

        public bool WaitForCommandResponse(int timeout)
        {
            System.Windows.Forms.Timer waitTimer = new System.Windows.Forms.Timer();
            if (waitTimer != null)
            {
                waitTimer.Interval = timeout * 100;
                waitTimer.Tick += new EventHandler(WaitTimer_Tick);
                waitTimer.Start();

                do
                {
                    Thread.Sleep(10);
                    Application.DoEvents();

                    if (this.serialDataReceived)
                        break;
                }
                while ((!this.serialCommandTimedOut) && (this.StageSerialPort != null) && (this.StageSerialPort.IsOpen));

                waitTimer.Stop();
                waitTimer.Tick -= this.WaitTimer_Tick;
                waitTimer.Dispose();
                waitTimer = null;

                // Break the loop in the DataReceived event handler
                if (this.serialCommandTimedOut)
                {
                    this.stageStopWaiting = true;
                }
            }

            return (this.serialCommandTimedOut == false);
        }

        public struct Timeouts
        {
            public const int READ_STATUS = 100;
            public const int ASYNC = 1001;
            public const int CLASH_PROTECT = 10000;
            public const int CONTROLLER = 1000;
            public const int ATR = 1000;
            public const int DISABLE_JOYSTICK = 5000;
            public const int MIN_MOVE = 4000;
            public const int MOVE = 22000;
            public const int AUTOMATED_ATR = 4000;
        }

        private string commandResponse = String.Empty;
        private char[] readbuffer = new char[100];
        private bool serialDataReceived = false;
        private bool stageStopWaiting = false;
        private bool serialCommandTimedOut = false;

        public SerialPort StageSerialPort = new SerialPort();

        void WaitTimer_Tick(object sender, EventArgs e)
        {
            WriteTraceOutput(String.Format("{0} - *** STAGE COMMAND TIMEOUT ***", DateTime.Now.ToString()));
            this.serialCommandTimedOut = true;
        }
        private readonly Byte[] readBufferBytes = new Byte[100];
        public readonly object lockObject = new object();


    }
}
