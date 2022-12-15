using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    internal class GameManager
    {
        private int _rightBorder = 832,
        _leftBorder = 0,
        _topBorder = 0,
        _deathBorder = 430,
        _speedPaddle = 10;

        public int _speedBallX = 5,
        _speedBallY = 5;
        public void PaddleMovement(KeyEventArgs e, Paddle paddle)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        if (paddle.PositionX + _speedPaddle >= _rightBorder - paddle.Length)
                            paddle.PositionX = _rightBorder - paddle.Length;
                        else
                            paddle.PositionX += _speedPaddle;

                        break;
                    }
                case Keys.Left:
                    {
                        if (paddle.PositionX - _speedPaddle <= _leftBorder)
                            paddle.PositionX = _leftBorder;
                        else
                            paddle.PositionX -= _speedPaddle;
                        break;
                    }
            }
        }
        public void BallMovement(Ball ball, Arkanoid arkanoid, Paddle paddle)
        {
            ball.PositionX += _speedBallX;
            ball.PositionY -= _speedBallY;
            WallCollision(ball, arkanoid);
            PaddleCollision(ball, paddle);
            //BrickCollision(ball)
        }
        public void WallCollision(Ball ball,Arkanoid arkanoid)
        {
            //правая и левая стена
            if (ball.PositionX > _rightBorder - ball.Size || ball.PositionX  < _leftBorder)
            {
                _speedBallX = -_speedBallX;
            }
            //верхняя стена
            if (ball.PositionY < _topBorder)
            {
                _speedBallY = -_speedBallY;
            }
            //нижняя стена
            if(ball.PositionY > _deathBorder)
            {
                _speedBallY = -_speedBallY;
                arkanoid.BallDeath();
            }
        }
        public void PaddleCollision(Ball ball, Paddle paddle)
        {
            if (ball.PositionY == 380 && ball.PositionX > paddle.PositionX && ball.PositionX < paddle.PositionX + paddle.Length)
            {
                _speedBallX = -(paddle.PositionX + paddle.Center - ball.PositionX)/6;
                _speedBallY = -_speedBallY;
            }
        }
    }
}
