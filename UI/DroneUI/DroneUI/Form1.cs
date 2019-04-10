using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DroneUI
{
    public partial class Form1 : Form
    {
        public const int SERIAL_SPEED = 115200;

        public bool logEverything=false;

        SerialCommunicator communicator;        
        flyMode flyMode = flyMode.Flappy;

        IRReceivedData IRdata = new IRReceivedData();

        float loopTimeTOAverage = 0;
        int loopTimesFORAveraging = 0;

        float motorPower; //0-100

        public bool gamepadConnected = false;

        public float voltage = 0f;
        Controller controller;
        Gamepad gamepad;

        public Form1()
        {
            communicator = new SerialCommunicator(LogSerialMessage,Log);

            InitializeComponent();
           
        }

        private void AddHanlders()
        {
            communicator.addHandler("POINTS", handleIRPoints);
            communicator.addHandler("POINTSDT", handleIRPointData);
            communicator.addHandler("LOOPTIME", handleLoopTime);
            communicator.addHandler("MAINVOLTS", handleMainVolts);
        }

        private void handleMainVolts(string arg1, string[] arg2)
        {
            voltage =(float)((int.Parse(arg2[0])/4095.0)*13.2);
        }

        private void handleLoopTime(string arg1, string[] arg2)
        {
            loopTimeTOAverage += int.Parse(arg2[0]);
            loopTimesFORAveraging++;
        }

        private void handleIRPointData(string arg1, string[] arg2)
        {
            IRdata.pLeft = int.Parse(arg2[0]);
            IRdata.pRight = int.Parse(arg2[1]);
            IRdata.pMiddle = int.Parse(arg2[2]);
            IRdata.pBack = int.Parse(arg2[3]);
        }

        private void handleIRPoints(string arg1, string[] arg2)
        {
            for (int i = 0; i < 4; i++) IRdata.points[i] = new Point(int.Parse(arg2[i*2]), int.Parse(arg2[(i * 2)+1]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            communicator.Connect(comboBox1.SelectedItem.ToString(), SERIAL_SPEED);
        }                

        void DrawIRSSensor()
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float xMultiplier = pictureBox1.Width / 800.0f;
            float yMultiplier = pictureBox1.Height / 800.0f;

            for (int i = 0; i < 4; i++)
            {
                if (IRdata.points[i].X != 1023 && IRdata.points[i].Y != 1023)
                {
                    if (i == IRdata.pLeft)
                    {
                        e.Graphics.FillPie(Brushes.Red, new Rectangle((int)(IRdata.points[i].X* xMultiplier), (int)(IRdata.points[i].Y * yMultiplier), 10, 10), 0, 360);
                    }
                    else if (i == IRdata.pRight)
                    {
                        e.Graphics.FillPie(Brushes.Green, new Rectangle((int)(IRdata.points[i].X * xMultiplier), (int)(IRdata.points[i].Y * yMultiplier), 10, 10), 0, 360);
                    }
                    else if (i == IRdata.pBack)
                    {
                        e.Graphics.FillPie(Brushes.Blue, new Rectangle((int)(IRdata.points[i].X * xMultiplier), (int)(IRdata.points[i].Y * yMultiplier), 10, 10), 0, 360);
                    }
                    else
                    {
                        e.Graphics.FillPie(Brushes.Gray, new Rectangle((int)(IRdata.points[i].X * xMultiplier), (int)(IRdata.points[i].Y * yMultiplier), 10, 10), 0, 360);
                    }
                }
            }
        }

        private void buttonModeFlappy_Click(object sender, EventArgs e)
        {
            buttonModeFlappy.BackColor = Color.Lime;
            buttonModeIR.BackColor = pictureBox1.BackColor;
            buttonModeGPS.BackColor = pictureBox1.BackColor;
            flyMode = flyMode.Flappy;
        }

        private void buttonModeIR_Click(object sender, EventArgs e)
        {
            buttonModeFlappy.BackColor = pictureBox1.BackColor;
            buttonModeIR.BackColor = Color.Lime;
            buttonModeGPS.BackColor = pictureBox1.BackColor;
            flyMode = flyMode.IR;
        }

        private void buttonModeGPS_Click(object sender, EventArgs e)
        {
            buttonModeFlappy.BackColor = pictureBox1.BackColor;
            buttonModeIR.BackColor = pictureBox1.BackColor;
            buttonModeGPS.BackColor = Color.Lime;
            flyMode = flyMode.GPS;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log("Addding function handlers...");
            AddHanlders();

            buttonReloadSerial.PerformClick();
        }

        private void timerIRDraw_Tick(object sender, EventArgs e)
        {
            DrawIRSSensor();
        }

        public void Log(string key,string data)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                textBoxLog.AppendText(String.Format("[{0}] - {1} - {2}{3}", DateTime.Now.ToShortTimeString(), key, data, Environment.NewLine));
            });
        }
        public void Log(string data)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                textBoxLog.AppendText(String.Format("[{0}] - {1} - {2}{3}", DateTime.Now.ToShortTimeString(), "DEFAULT", data, Environment.NewLine));
            });
        }

        public void LogSerialMessage(string key,string data)
        {
            this.Invoke((MethodInvoker)delegate () {
                if (logEverything) textBoxLog.AppendText(String.Format("[{0}] - {1} - {2}{3}", DateTime.Now.ToShortTimeString(), "SERIAL (" + key + ")", data, Environment.NewLine));
            });

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            logEverything = checkBox1.Checked;
        }

        private void timerUpdateUI_Tick(object sender, EventArgs e)
        {
            labelFPS.Text = (int)(1000/(loopTimeTOAverage/loopTimesFORAveraging))+"";
            loopTimesFORAveraging = 0;
            loopTimeTOAverage = 0;
            labelMainVolts.Text = Math.Round(voltage, 2) + " V";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void inputAdquireTimer_Tick(object sender, EventArgs e)
        {
            if (gamepadConnected==false || controller.IsConnected==false)
                return;

            gamepad = controller.GetState().Gamepad;
            controller.SetVibration(new Vibration() { LeftMotorSpeed = (ushort)(65535 * (gamepad.LeftTrigger / 255)), RightMotorSpeed = (ushort)(65535 * (gamepad.RightTrigger / 255)) });


            //motorControl1.setPower((int)(gamepad.LeftTrigger / 2.55));
            //motorControl2.setPower((int)(gamepad.RightTrigger / 2.55));
            //
            // motorControl3.setPower((int)((gamepad.LeftThumbY+32768 )/ 655.55));

            motorPower += gamepad.RightTrigger * 0.01f;
            motorPower -= gamepad.LeftTrigger * 0.01f;
          
            if(gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
            {
                motorPower -= 10;
            }
            if (motorPower < 0) motorPower = 0;
            if (motorPower > 100) motorPower = 100;


            motorControl4.setPower((int)motorPower);

            Console.WriteLine(gamepad.RightTrigger + "");

          
        }



        private void buttonReloadSerial_Click(object sender, EventArgs e)
        {
            Log("Getting available serial ports...");

            comboBox1.Items.Clear();
            foreach (string str in SerialCommunicator.getSerialPorts())
            {
                comboBox1.Items.Add(str);
            }
        }

        private void buttonStartXBOX_Click(object sender, EventArgs e)
        {
            controller = new Controller(UserIndex.One);
            gamepadConnected = controller.IsConnected;
            Log("Gamepad status: " + (gamepadConnected ? "Connected" : "Disconnected"));
        }

        private void inputSendTimer_Tick(object sender, EventArgs e)
        {
            communicator.sendMessage("MANPWR", (int)(motorPower*10) + "");
        }
    }

    public enum flyMode
    {
        Flappy,
        IR,
        GPS,
    }
}
