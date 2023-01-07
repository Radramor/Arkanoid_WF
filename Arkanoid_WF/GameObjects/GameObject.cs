using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF.GameObjects
{
    public class GameObject
    {
        public Point Location { get;  set; }
        public Size Size { get; protected set; }
        public Color Color { get; protected set; }
        public Rectangle Body { get; protected set; } /////

    }
}
