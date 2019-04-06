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
        SerialPort port;

        StringBuilder builder = new StringBuilder(10000);

        string pointData = "";
        string pointsDT = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port = new SerialPort(textBox1.Text);
            port.BaudRate = 115200;
            port.NewLine = "\r\n";
            port.Open();

            Thread thead = new Thread(DoWork);
            thead.IsBackground = true;
            thead.SetApartmentState(ApartmentState.STA);
            thead.Start();
        }


        void DoWork()
        {
            while(true)
            {
                if(port.BytesToRead>0)
                {
                    char readed = (char)port.ReadChar();
                    if(readed=='|')
                    {
                        processMessage(builder.ToString());
                        builder.Clear();
                    }else
                    {
                        builder.Append(readed);
                    }                   

                }
            }
        }

        void processMessage(string str)
        {
            if (str.Contains("@"))
            {
                try
                {
                    switch (str.Split('@')[0])
                    {
                        case "POINTS":
                            Console.WriteLine("Got point data: " + str); 
                            pointData = str.Split('@')[1];
                            DrawIRSSensor();
                            break;
                        case "POINTSDT":
                            Console.WriteLine("Got point processed data: "+str);
                            pointsDT=str.Split('@')[1];
                            break;
                    }
                }
                catch
                {

                }
            }
        }


        void DrawIRSSensor()
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float xMultiplier = pictureBox1.Width / 800.0f;
            float yMultiplier = pictureBox1.Height / 800.0f;

            int pLeft = -1;
            int pRight = -1;
            int pMiddle = -1;
            int pBack = -1;

            if (pointsDT.Contains(",") && pointsDT.Split(',').Length==4)
            {
                pLeft = int.Parse(pointsDT.Split(',')[0]);
                pRight = int.Parse(pointsDT.Split(',')[1]);
                pMiddle = int.Parse(pointsDT.Split(',')[2]);
                pBack = int.Parse(pointsDT.Split(',')[3]);
            }

            if (pointData.Contains(","))
            {
                string[] points = pointData.Split(',');
                if(points.Length==8)
                {
                    for(int i=0;i<8;i+=2)
                    {
                        if(int.Parse(points[i])!=1023 && int.Parse(points[i + 1])!=1023)
                        {
                            if(i/2==pLeft)
                            {
                                e.Graphics.FillPie(Brushes.Red, new Rectangle((int)(int.Parse(points[i]) * xMultiplier), (int)(int.Parse(points[i + 1]) * yMultiplier), 10, 10), 0, 360);
                            }
                            else if(i/2==pRight)
                            {
                                e.Graphics.FillPie(Brushes.Green, new Rectangle((int)(int.Parse(points[i]) * xMultiplier), (int)(int.Parse(points[i + 1]) * yMultiplier), 10, 10), 0, 360);
                            }else if(i/2==pBack)
                            {
                                e.Graphics.FillPie(Brushes.Blue, new Rectangle((int)(int.Parse(points[i]) * xMultiplier), (int)(int.Parse(points[i + 1]) * yMultiplier), 10, 10), 0, 360);
                            }
                            else
                            {
                                e.Graphics.FillPie(Brushes.Gray, new Rectangle((int)(int.Parse(points[i]) * xMultiplier), (int)(int.Parse(points[i + 1]) * yMultiplier), 10, 10), 0, 360);
                            }
                        }
                  
                    }
                }
            }

         
        }
    }
}
