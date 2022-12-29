using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Arkanoid_WF
{
    public class Brick : GameObject
    {
        /// <summary>
        /// Количество хитпоинтов
        /// </summary>
        public int HitPoints { get; set; }
        [JsonIgnore]
        public PictureBox pictureBox;

        public Brick()
        {
            Body = new Rectangle();
            HitPoints = new int();
        }
        public Brick(Point point, Size size)
        {
            Body = new Rectangle(point, size);
            HitPoints = 1;
        }
        public Brick(int x, int y, int width, int height)
        {
            Body = new Rectangle(x, y, width, height);
            HitPoints = 1;
        }
    }
}
