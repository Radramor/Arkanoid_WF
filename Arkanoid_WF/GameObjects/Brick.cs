using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid_WF.GameObjects
{
    public class Brick : GameObject
    {
        public bool IsSmashed { get; set; }

        public Brick(int x, int y, int width, int height)
        {
            Size = new Size(width, height);
            Color = Color.Tomato;
            Location = new Point(x, y);
        }

    }
}
