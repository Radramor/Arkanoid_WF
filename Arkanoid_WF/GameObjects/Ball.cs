using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace Arkanoid_WF.GameObjects
{
    public class Ball : GameObject
    {
        public Point Speed { get; set; }
        public int BottomOffset { get; set; }

        public Ball(Size size, int bottomOffset, Point speed)
        {
            Size = size;
            Color = Color.HotPink;
            Speed = speed;
            BottomOffset = bottomOffset;
        }
        public void SetLocation(Rectangle window)
        {
            Location = new Point(window.Width / 2 - Size.Width / 2,
                window.Height - Size.Height - BottomOffset);
        }

        public void BallMovement(Platform platform, List<Brick> bricks, Borders borders)
        {            
            Location = new Point(Location.X + Speed.X, Location.Y + Speed.Y);            
            WallCollision(borders);
            PlatformCollision(platform);
            BrickCollision(bricks);
        }

        private void BrickCollision(List<Brick> bricks)
        {
            foreach (Brick b in bricks.ToList())
            {
                bool hit = Location.Y < b.Location.Y + b.Size.Height &&
                              Location.X + Size.Width > b.Location.X &&
                               Location.X < b.Location.X + b.Size.Width &&
                               Location.Y + Size.Height > b.Location.Y;
                if (hit)
                {
                    Speed = new Point(Speed.X, -Speed.Y);
                    b.IsSmashed = true;
                    break;
                }
            }
        }

        private void WallCollision(Borders borders)
        {
            //правая и левая стена
            if (Location.X + Size.Width > borders.RightBorder || Location.X < borders.LeftBorder)
            {
                Speed = new Point(-Speed.X, Speed.Y);
            }
            //верхняя стена
            if (Location.Y < borders.TopBorder)
            {
                Speed = new Point(Speed.X, -Speed.Y);
            }
        }

        private void PlatformCollision(Platform platform)
        {
            if (Location.Y + Size.Height == platform.Location.Y && Location.X + Size.Width > platform.Location.X && Location.X < platform.Location.X + platform.Size.Width)
            {
                int newX = -((platform.Location.X + platform.Size.Width / 2) - (Location.X + Size.Width / 2)) / 7;                
                Speed = new Point(newX, -Speed.Y);
            }
        }
    }
}
