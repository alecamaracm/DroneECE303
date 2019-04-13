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

        public static SerialCommunicator communicator;        
        flyMode flyMode = flyMode.Flappy;

        IRReceivedData IRdata = new IRReceivedData();

       


        float motorPower; //0-100

        int lastFPS = 0;

        float yawGoal = 0f;
        float pitchGoal = 0f;
        float rollGoal = 0;

        float currentPitch = 0f;
        float currentRoll = 0f;
        float currentYaw = 0f;

        int calGyro, calAccel, calMagnet = 0;

        public bool gamepadConnected = false;

        public float voltage = 0f;
        Controller controller;
        Gamepad gamepad;

        float ampsM1, ampsM2, ampsM3, ampsM4, amps5V;

        public Form1()
        {
            communicator = new SerialCommunicator(LogSerialMessage,Log);

            InitializeComponent();
           
        }

        private void AddHanlders()
        {
            communicator.addHandler("POINTS", handleIRPoints);
            communicator.addHandler("POINTSDT", handleIRPointData);
            communicator.addHandler("FPS", handleFPS);
            communicator.addHandler("MAINVOLTS", handleMainVolts);
            communicator.addHandler("MPOWS", handleMotorPowers);
            communicator.addHandler("IMUDATA", handleIMUData);
            communicator.addHandler("SERIALERR", handleSerialError);
            communicator.addHandler("AMPS", ampsHandler);
            communicator.addHandler("CAL", calHandler);
        }

        private void calHandler(string arg1, string[] arg2)
        {
            calGyro = int.Parse(arg2[0]);
            calAccel = int.Parse(arg2[1]);
            calMagnet = int.Parse(arg2[2]);
        }

        private void ampsHandler(string arg1, string[] arg2)
        {
            //amps5V =(float)(((((int.Parse(arg2[0]) - 2418)/4096.0f)*3.3)*1.6061f)/0.066);
            ampsM1 = (float)(((((int.Parse(arg2[1]) - 2314) / 4096.0f) * 3.3) * 1.6061f) / 0.066);
            ampsM2 = (float)(((((int.Parse(arg2[2]) - 2314) / 4096.0f) * 3.3) * 1.6061f) / 0.066);
            ampsM3 = (float)(((((int.Parse(arg2[3]) - 2314) / 4096.0f) * 3.3) * 1.6061f) / 0.066);
            ampsM4 = (float)(((((int.Parse(arg2[4]) - 2314) / 4096.0f) * 3.3) * 1.6061f) / 0.066);
        }

        private void handleSerialError(string arg1, string[] arg2)
        {
            communicator.errorsSerialDrone++;
        }

        private void handleIMUData(string arg1, string[] arg2)
        {
            currentPitch=(float)(int.Parse(arg2[0])/100.0);
            currentRoll = (float)(int.Parse(arg2[1]) / 100.0);
            currentYaw = (float)(int.Parse(arg2[2]) / 100.0);
        }

        private void handleMotorPowers(string arg1, string[] arg2)
        {
            this.Invoke((MethodInvoker)delegate () {
                motorControl1.setPower(int.Parse(arg2[0]));
                motorControl2.setPower(int.Parse(arg2[1]));
                motorControl3.setPower(int.Parse(arg2[2]));
                motorControl4.setPower(int.Parse(arg2[3]));
            });
        }

        private void handleMainVolts(string arg1, string[] arg2)
        {
            voltage =(float)((int.Parse(arg2[0])/4095.0)*13.2);
        }

        private void handleFPS(string arg1, string[] arg2)
        {
            lastFPS = int.Parse(arg2[0]);
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
            motorControl1.setEnable(false);
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
            labelFPS.Text = lastFPS + "";

            label5VAmps.Text = amps5V+"";
            motorControl1.setAmps(ampsM1);
            motorControl2.setAmps(ampsM2);
            motorControl3.setAmps(ampsM3);
            motorControl4.setAmps(ampsM4);

            labelMainVolts.Text = Math.Round(voltage, 2) + " V";

            goalPitch.Text = Math.Round(pitchGoal, 2)+"°";
            goalRoll.Text = Math.Round(rollGoal, 2) + "°";
            goalYaw.Text = Math.Round(yawGoal, 2) + "°";
            currentPitchV.Text = Math.Round(currentPitch, 2) + "°";
            currentRollV.Text = Math.Round(currentRoll, 2) + "°";
            currentYawV.Text = Math.Round(currentYaw, 2) + "°";

            labelUploadSpeed.Text = Math.Round((double)communicator.uploadSpeed / 1000,2)+"KB/s";
            labelDownloadSpeed.Text = Math.Round((double)communicator.downloadSpeed / 1000, 2) + "KB/s";

            labelErrorsDrone.Text = communicator.errorsSerialDroneSec + " err/min";
            labelErrorsPC.Text = communicator.errorsSerialPCSec + " err/min";

            labelCalAccel.Text = calAccel + "";
            labelCalGyro.Text = calGyro + "";
            labelCalMagnet.Text = calMagnet  + "";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            motorPower = trackBarThrottle.Value;
        }

        private void inputAdquireTimer_Tick(object sender, EventArgs e)
        {
            if (gamepadConnected==false || controller.IsConnected==false)
                return;

            gamepad = controller.GetState().Gamepad;
            controller.SetVibration(new Vibration() { LeftMotorSpeed = (ushort)(65535 * (gamepad.LeftTrigger / 255)), RightMotorSpeed = (ushort)(65535 * (gamepad.RightTrigger / 255)) });

            motorPower += gamepad.RightTrigger * 0.01f;
            motorPower -= gamepad.LeftTrigger * 0.01f;
          
            if(gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder))
            {
                motorPower -= 10;
            }
            if (motorPower < 0) motorPower = 0;
            if (motorPower > 100) motorPower = 100;

            trackBarThrottle.Value = (int)motorPower;


            //Do axis goals
            if (gamepad.LeftThumbX == -32768) gamepad.LeftThumbX = -32767;
            if (gamepad.LeftThumbY == -32768) gamepad.LeftThumbY = -32767;
            if (gamepad.RightThumbX == -32768) gamepad.RightThumbX = -32767;
            if (gamepad.RightThumbY == -32768) gamepad.RightThumbY = -32767;

            if (Math.Abs(gamepad.LeftThumbX)<5000)
            {
                rollGoal = 0;
            }
            else
            {
                if (gamepad.LeftThumbY > 0)
                {
                    rollGoal = Map(gamepad.LeftThumbX, 5000, 32790, 0, 25);
                }
                else
                {
                    rollGoal = Map(gamepad.LeftThumbX, -32790, -5000, -25, 0);
                }
            }

            if (Math.Abs(gamepad.LeftThumbY) < 5000)
            {
                pitchGoal = 0;
            }
            else
            {
                if(gamepad.LeftThumbY>0)
                {
                    pitchGoal = Map(gamepad.LeftThumbY, 5000, 32790, 0, 25);
                }
                else
                {
                    pitchGoal = Map(gamepad.LeftThumbY, -32790, -5000, -25, 0);
                }
       
            }


            if (Math.Abs(gamepad.RightThumbX) > 5000)
            {
                if (gamepad.RightThumbX > 0)
                {
                    yawGoal += Map(gamepad.RightThumbX,5000,32767,0,2.1f);
                }
                else
                {
                    yawGoal += Map(gamepad.RightThumbX, -32790, -5000, -2.1f, 0);
                }
            }
                


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

        ulong cycle = 0;
        private void inputSendTimer_Tick(object sender, EventArgs e)
        {
        
            if(cycle%(50/4)==0)communicator.sendMessage("MANPWR", (int)(motorPower*10) + "");
            if (cycle % (50 / 4) == 7)  communicator.sendMessage("CDATA",(int)(pitchGoal*-100)+"|"+(int)(rollGoal*-100)+"|"+(int)(yawGoal*100));
            cycle++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            communicator.Disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            motorControl1.setEnable(true);
            motorControl3.setEnable(true);
            motorControl2.setEnable(true);
            motorControl4.setEnable(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            motorControl1.setEnable(false);
            motorControl3.setEnable(false);
            motorControl2.setEnable(false);
            motorControl4.setEnable(false);
        }

        private void numericUpDownkP_ValueChanged(object sender, EventArgs e)
        {
            communicator.sendMessage("KP", numericUpDownkP.Value*100 + "");
        }

        private void numericUpDownkD_ValueChanged(object sender, EventArgs e)
        {
            communicator.sendMessage("KD", numericUpDownkD.Value * 100 + "");
        }

        private void numericUpDownFPSGoal_ValueChanged(object sender, EventArgs e)
        {
            communicator.sendMessage("FPSGOAL", numericUpDownFPSGoal.Value+"");
        }

        public static float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void labelErrorsPC_Click(object sender, EventArgs e)
        {

        }
    }

    public enum flyMode
    {
        Flappy,
        IR,
        GPS,
    }
}
