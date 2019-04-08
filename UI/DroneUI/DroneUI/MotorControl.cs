using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneUI
{
    public partial class MotorControl : UserControl
    {
        int currentPower = 100;

        public MotorControl()
        {
            InitializeComponent();
        }

        public void setPower(int power)
        {
            currentPower = power;
            label1.Text = power + "%";
            pictureBox1.Invalidate();
        }

        public void setAmps(float amps)
        {
            label2.Text = Math.Round(amps, 2) + " A";
        }

        public void setEnable(bool enabled)
        {
            checkBox1.Checked = enabled;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.FromArgb((int)(255*(currentPower/100.0)),(int)(255- 255 * (currentPower / 100.0)),0));

            e.Graphics.FillRectangle(brush,0, e.ClipRectangle.Height * (1-(currentPower / 100.0f)),e.ClipRectangle.Width, e.ClipRectangle.Height * ((currentPower / 100.0f)));
        }
    }
}
