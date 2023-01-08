using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;


namespace Arkanoid_WF.GameObjects
{
    public class Platform : GameObject
    {
        private int Speed { get; set; }
        private int BottomOffset { get; set; }
        //private Borders borders; //

        public Platform(int width, int height, int bottomOffset, int speed)
        {
            Size = new Size(width, height);
            Color = Color.Aquamarine;
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
        public void PlatformMovement(bool isMovementLeft, Borders borders)
        {
            if (isMovementLeft && (Location.X - Speed >= borders.LeftBorder)) //проверка на выход за левый край поля
                Location = new Point(Location.X - Speed, Location.Y);
            else if (isMovementLeft) Location = new Point(borders.LeftBorder, Location.Y); 

            if (!isMovementLeft && Location.X + Size.Width + Speed <= borders.RightBorder) //проверка на выход за правый край поля
                Location = new Point(Location.X + Speed, Location.Y);
            else if (!isMovementLeft) Location = new Point(borders.RightBorder - Size.Width, Location.Y);
        }
    }
}
