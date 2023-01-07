using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Arkanoid_WF.GameObjects
{
    public class Ball : GameObject
    {
        private readonly Point defaultLocation = new Point(401, 370);
        private readonly Point defaultSpeed = new Point(5, 5);
        private readonly Size defaultSize = new Size(24, 24);

        public Point Speed { get; set; }
        private int BottomOffset { get; set; }

        private Borders borders = new Borders(); //////
        
        public Ball()
        {
            Body = new Rectangle(defaultLocation, defaultSize);
            Speed = new Point(5, 5);
        }
        public Ball(int size, int bottomOffset, Point speed)
        {            
            Size = new Size(size, size);
            Color = Color.DarkBlue;
            Speed = speed;
            BottomOffset = bottomOffset;
        }
        public void SetLocation(Rectangle window)
        {
            Location = new Point(
                window.Width / 2 - Size.Width / 2,
                window.Height - Size.Height - BottomOffset
                );
        }

        //public void BallMovement(Platform platform, Game game, List<Brick> bricks)
        //{
        //    var _body = Body;
        //    _body.X += Speed.X;
        //    _body.Y -= Speed.Y;
        //    Body = _body;
        //    WallCollision(game);
        //    PlatformCollision(platform);
        //    BrickCollision(bricks, game);
        //}

        public void BallMovement(Platform platform, List<Brick> bricks, Borders borders)
        {            
            Location = new Point(Location.X + Speed.X, Location.Y + Speed.Y);            
            WallCollision(borders);
            PlatformCollision(platform);
            BrickCollision(bricks);
        }

        private void BrickCollision(List<Brick> bricks)
        {
            //for (int i = 0; i < bricks.Count; i++)
            foreach (Brick b in bricks.ToList())
            {
                //bool hit = Body.Top < b.Body.Bottom &&
                //              Body.Right > b.Body.Left &&
                //              Body.Left < b.Body.Right &&
                //              Body.Bottom > b.Body.Top;
                bool hit = Location.Y < b.Location.Y + b.Size.Height &&
                              Location.X + Size.Width > b.Location.X &&
                               Location.X < b.Location.X + b.Size.Width &&
                               Location.Y + Size.Height > b.Location.Y;
                if (hit)
                {
                    //b.HitPoints = 0;
                    //b.pictureBox.Visible = false;
                    //bricks.Remove(b);
                    
                    Speed = new Point(Speed.X, -Speed.Y);
                    b.IsSmashed = true;
                    break;
                }
            }
        }

        public void WallCollision(Borders borders)
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

        public void PlatformCollision(Platform platform)
        {
            //if (platform.Location.Y <= Location.Y + Size.Height &&
            //   platform.Location.X < Location.X + Size.Width &&
            //   platform.Location.X + platform.Size.Width > Location.X)
            //{
            //    double PieceLength = platform.Size.Width / 3;

            //    if (Location.X < platform.Location.X + PieceLength)
            //        Speed = 
            //}
            if (Location.Y + Size.Height == platform.Location.Y && Location.X + Size.Width > platform.Location.X && Location.X < platform.Location.X + platform.Size.Width)
            {
                int newX = -((platform.Location.X + platform.Size.Width / 2) - (Location.X + Size.Width / 2)) / 7;                
                Speed = new Point(newX, -Speed.Y);
            }
        }

        public void DefaultValues()
        {
            var _body = Body;
            _body.Location = defaultLocation;
            Body = _body;
            Speed = defaultSpeed;
        }

    }
}
