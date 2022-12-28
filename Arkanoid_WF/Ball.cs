using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Arkanoid_WF
{
    public class Ball : GameObject
    {
        private readonly Point defaultLocation = new Point(401, 370);
        private readonly Point defaultSpeed = new Point(5, 5);
        private readonly Size defaultSize = new Size(24, 24);

        private Point speed;
        private Borders borders = new Borders();

        
        public Ball()
        {
            Body = new Rectangle(defaultLocation, defaultSize);
            speed = new Point((Size)defaultSpeed);
        }
        public void BallMovement(Paddle paddle, Game game)
        {
            var _body = Body;
            _body.X += speed.X;
            _body.Y -= speed.Y;
            Body = _body;
            WallCollision(game);
            PaddleCollision(paddle);
            //BrickCollision(ball)
        }
        public void WallCollision(Game game)
        {
            //правая и левая стена
            if (Body.Right > borders.rightBorder || Body.Left < borders.leftBorder)
            {
                speed.X = -speed.X;
            }
            //верхняя стена
            if (Body.Top < borders.topBorder)
            {
                speed.Y = -speed.Y;
            }
        }

        public void PaddleCollision(Paddle paddle)
        {
            if (Body.Y  == 375 && Body.Right > paddle.Body.Left && Body.Left < paddle.Body.Right)
            {
                speed.X = -((paddle.Body.X + paddle.Body.Width/2) - (Body.X + Body.Width/2)) / 7;
                speed.Y = -speed.Y;
            }
        }

        public void DefaultValues()
        {
            var _body = Body;
            _body.Location = defaultLocation;
            Body = _body;
            speed = defaultSpeed;
        }

    }
}
