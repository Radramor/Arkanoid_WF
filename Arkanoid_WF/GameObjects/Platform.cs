using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Arkanoid_WF.GameObjects
{
    public class Platform : GameObject
    {
        public int Speed { get; set; }
        public int BottomOffset { get; set; }

        public Platform(Size size, int bottomOffset, int speed)
        {
            Size = size;
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
