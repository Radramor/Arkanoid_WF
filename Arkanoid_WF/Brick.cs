using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class Brick : GameObject
    {
        /// <summary>
        /// Количество хитпоинтов
        /// </summary>
        public virtual int HitPoints { get; protected set; }

        public Brick(int x, int y, int width, int height)
        {
            Size = new Size(width, height);
            Color = Color.DarkOliveGreen;
            Location = new Point(x, y);
            HitPoints = 1;
        }
    }
}
