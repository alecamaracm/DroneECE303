using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneUI
{
    public class IRReceivedData
    {
        public int pLeft = -1;  //Point on the top left of the T
        public int pRight = -1;
        public int pMiddle = -1;
        public int pBack = -1;

        public Point[] points=new Point[4];
    }
}
