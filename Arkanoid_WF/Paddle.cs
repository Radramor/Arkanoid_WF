using Microsoft.VisualBasic.Devices;
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


        public Rectangle BoundsPaddle { get; set; }
        public int Speed { get; set; }
        public Point Velocity { get; set; }

        public Paddle()
        {
            Speed = 1;
        }
        public void PaddleMovement(KeyEventArgs e)
        {
            Velocity = new Point();
            if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
                Velocity = new Point(-Speed, 0);
            if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
                Velocity = new Point(Speed, 0);

            //сдвигаем ракетку
            var bounds = BoundsPaddle;
            bounds.Offset(Velocity.X, Velocity.Y);

            //проверка на выход за пределы поля
            if (bounds.Left >= /*левая граница поля*/ && bounds.Right <= /*правая граница поля*/)
            {
                BoundsPaddle = bounds;
            }
        }

        public void DefaultValues()
        {
            PositionX = 362;
            PositionY = 400;
        }
    }
}
