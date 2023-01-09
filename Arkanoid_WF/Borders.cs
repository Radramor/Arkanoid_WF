using System.Drawing;

namespace Arkanoid_WF
{
    public class Borders
    {
        public int RightBorder { get; set; }
        public int LeftBorder { get; set; }
        public int TopBorder { get; set; }
        public int BottonBorder { get; set; }

        public Borders(Rectangle window)
        {
            LeftBorder = window.X;
            RightBorder = LeftBorder + window.Width;
            TopBorder = window.Y;
            BottonBorder = TopBorder + window.Height;
        }
    }
}
