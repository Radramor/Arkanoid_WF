using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class Paddle
    {
        public int PositionX { get; private set; } = 362; // формула: (ArkanoidForm.size.x/2) - (length/2)
        public int PositionY { get; private set; } = 400; // рандомное число
        public const int Length = 126; // размер картинки
        public const int Height = 24; // размер картинки
        public const int Center = 63;
        private int speedPaddle = 10;
        private Borders borders = new Borders();

        public void PaddleMovement(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        if (PositionX + speedPaddle >= borders.rightBorder - Length)
                            PositionX = borders.rightBorder - Length;
                        else
                            PositionX += speedPaddle;

                        break;
                    }
                case Keys.Left:
                    {
                        if (PositionX - speedPaddle <= borders.leftBorder)
                            PositionX = borders.leftBorder;
                        else
                            PositionX -= speedPaddle;
                        break;
                    }
            }
        }

        public void DefaultValues()
        {
            PositionX = 362;
            PositionY = 400;
        }
    }
}
