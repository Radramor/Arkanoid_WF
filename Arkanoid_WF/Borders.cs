using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arkanoid_WF
{
    public class Borders
    {
        public int RightBorder { get; set; }
        public int LeftBorder { get; set; }
        public int TopBorder { get; set; }
        public int BottonBorder { get; set; }

        public Borders() { }   

        public Borders(Rectangle window)
        {
            LeftBorder = window.X;
            RightBorder = LeftBorder + window.Width;
            TopBorder = window.Y;
            BottonBorder = TopBorder + window.Height;
        }
    }
}
