using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class Level
    {
        public string Name { get; }

        public int BallSize { get; }
        public int BallBottomOffset { get; }
        public int BallMaxAcceleration { get; }

        public int PlatformWidth { get; }
        public int PlatformHeight { get; }
        public int PlatformBottomOffset { get; }
        public int PlatformMaxAcceleration { get; }

        public int BrickWidth { get; }
        public int BrickHeight { get; }

        public int BricksMapOffset { get; set; }
        public int[] BricksMap { get; }

        public Ball Ball { get; private set; }
        public Paddle Paddle { get; private set; }
        public List<Brick> Bricks { get; private set; }

        public Level(string name, int ballSize, int ballBottomOffset, int ballMaxAcceleration, int platformWidth,
            int platformHeight, int platformBottomOffset, int platformMaxAcceleration, int brickWidth, int brickHeight, int bricksMapOffset,
            int[] bricksMap)
        {
            Name = name;
            BallSize = ballSize;
            BallBottomOffset = ballBottomOffset;
            BallMaxAcceleration = ballMaxAcceleration;
            PlatformWidth = platformWidth;
            PlatformHeight = platformHeight;
            PlatformBottomOffset = platformBottomOffset;
            PlatformMaxAcceleration = platformMaxAcceleration;
            BrickWidth = brickWidth;
            BrickHeight = brickHeight;
            BricksMapOffset = bricksMapOffset;
            BricksMap = bricksMap;
        }


    }
}
