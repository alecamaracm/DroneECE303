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

namespace Drone303Plotter
{
    public partial class Form1 : Form
    {
        SerialPort port;
        String data;

        string[] array;

        Thread thread;
        public Form1()
        {
           
          //  CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void buttonReloadSerial_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port = new SerialPort(comboBox1.Text);
            port.BaudRate = 115200;
            port.Open();

            thread = new Thread(DoWork);
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        void DoWork()
        {
            while(true)
            {
                try
                {
                    data= port.ReadTo("O_o");
                    array = data.Split(':');
                    this.Invoke((MethodInvoker)delegate(){

                        chart1.Series[0].Points.Add(int.Parse(array[0]) / 100.0f);
                        chart1.Series[1].Points.Add(int.Parse(array[1]) / 50.0f);
                        chart1.Series[2].Points.Add(int.Parse(array[2]) /50.0f);
                        chart1.Series[3].Points.Add(int.Parse(array[3]) / 50.0f);
                        if(chart1.Series[0].Points.Count> 100) chart1.Series[0].Points.RemoveAt(0);
                        if (chart1.Series[1].Points.Count > 100) chart1.Series[1].Points.RemoveAt(0);
                        if (chart1.Series[2].Points.Count > 100) chart1.Series[2].Points.RemoveAt(0);
                        if (chart1.Series[3].Points.Count > 100) chart1.Series[3].Points.RemoveAt(0);

                        chart1.ChartAreas[0].RecalculateAxesScale();
                    });
              

                }
                catch
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chart1.Series.Count; i++) chart1.Series[i].Points.Clear();
        }
    }
}
