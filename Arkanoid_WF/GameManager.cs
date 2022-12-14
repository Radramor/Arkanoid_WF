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
        private int _rightBorder = 832;
        private int _leftBorder = 0;
        private int _speed = 10;
        public void PaddleMovement(KeyEventArgs e, Paddle paddle)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        if (paddle.PositionX + _speed >= _rightBorder - paddle.Length)
                            paddle.PositionX = _rightBorder - paddle.Length;
                        else
                            paddle.PositionX += _speed;

                        break;
                    }
                case Keys.Left:
                    {
                        if (paddle.PositionX - _speed <= _leftBorder)
                            paddle.PositionX = _leftBorder;
                        else
                            paddle.PositionX -= _speed;
                        break;
                    }
            }
        }
    }
}
