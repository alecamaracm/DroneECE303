﻿using System;
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
        
        string pointData = "";
        string pointsDT = "";

        public Form1()
        {
            communicator = new SerialCommunicator(LogSerialMessage);

            InitializeComponent();
           
        }

        private void AddHanlders()
        {
            communicator.addHandler("POINTS", handleIRPoints);
            communicator.addHandler("POINTSDT", handleIRPointData);
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

            Log("Getting available serial ports...");

            comboBox1.Items.Clear();
            foreach(string str in SerialCommunicator.getSerialPorts())
            {
                comboBox1.Items.Add(str);
            }
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
    }

    public enum flyMode
    {
        Flappy,
        IR,
        GPS,
    }
}
