using System.Drawing;

namespace Arkanoid_WF.GameObjects
{
    public class Brick : GameObject
    {
        public bool IsSmashed { get; set; }
        public Brick(int x, int y, Size size)
        {
            Size = size;
            Color = Color.Coral;
            Location = new Point(x, y);
        }
    }
}
