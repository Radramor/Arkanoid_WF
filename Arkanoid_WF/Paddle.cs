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
    public class Paddle : GameObject
    {
        private readonly Point defaultLocation = new Point(362, 400);
        private readonly Size defaultSize = new Size(126, 24);
        private readonly int Speed = 10;
        private Borders borders = new Borders();

        public Paddle()
        {
            Body = new Rectangle(defaultLocation, defaultSize);
        }
        public void PaddleMovement(KeyEventArgs e)
        {
            var _body = Body;
            if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
                _body.Offset(-Speed, 0);
            if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
                _body.Offset(Speed, 0);

            //проверка на выход за пределы поля
            if (_body.Left >= borders.leftBorder && _body.Right <= borders.rightBorder)
            {
                Body = _body;
            }
        }

        public void DefaultValues()
        {
            var _body = Body;
            _body.Location = defaultLocation;
            Body = _body;
        }
    }
}
