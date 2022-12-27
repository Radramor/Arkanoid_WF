using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    internal class Ball
    {
        public int PositionX { get; private set; } = 413; 
        public int PositionY { get; private set; } = 370;
        public const int Size = 24;
        private int center = 12;
        private int speedBallX = 5;
        private int speedBallY = 5;
        private Borders borders = new Borders();

        
        public void BallMovement(Arkanoid arkanoid, Paddle paddle)
        {
            PositionX += speedBallX;
            PositionY -= speedBallY;
            WallCollision(arkanoid);
            PaddleCollision(paddle);
            //BrickCollision(ball)
        }
        public void WallCollision(Arkanoid arkanoid)
        {
            //правая и левая стена
            if (PositionX > borders.rightBorder - Size || PositionX < borders.leftBorder)
            {
                speedBallX = -speedBallX;
            }
            //верхняя стена
            if (PositionY < borders.topBorder)
            {
                speedBallY = -speedBallY;
            }
            //нижняя стена
            if (PositionY > borders.deathBorder)
            {
                speedBallY = -speedBallY;
                arkanoid.BallDeath();
            }
        }

        public void PaddleCollision(Paddle paddle)
        {
            if (PositionY == 380 && PositionX + center > paddle.PositionX && PositionX + center < paddle.PositionX + Paddle.Length)
            {
                speedBallX = -(paddle.PositionX + Paddle.Center - PositionX) / 7;
                speedBallY = -speedBallY;
            }
        }

        public void DefaultValues()
        {
            PositionX = 413;
            PositionY = 370;
            speedBallX = 5;
            speedBallY = 5;
        }
    }
}
