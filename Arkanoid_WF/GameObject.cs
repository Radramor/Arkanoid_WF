using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class GameObject
    {
        public Point Location { get; protected set; }
        public Size Size { get; protected set; }
        public Color Color { get; protected set; }
    }
}
