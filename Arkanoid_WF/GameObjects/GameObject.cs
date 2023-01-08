using Newtonsoft.Json;
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

        [JsonIgnore]
        public Size Size { get;  set; }
        public Color Color { get;  set; }
    }
}
