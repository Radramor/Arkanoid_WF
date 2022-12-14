using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class Paddle
    {
        public int PositionX = 362; // формула: (ArkanoidForm.size.x/2) - (length/2)
        public int PositionY = 400; // рандомное число
        public int Length = 126; // размер картинки
        public int Height = 24; // размер картинки
    }
}
