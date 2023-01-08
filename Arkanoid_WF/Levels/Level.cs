using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Arkanoid_WF.GameObjects;

namespace Arkanoid_WF.Levels
{
    public class Level
    {
        public string Name { get; }

        public int BallSize { get; }
        public int BallBottomOffset { get; }
        public Point BallSpeed { get; }

        public int PlatformWidth { get; }
        public int PlatformHeight { get; }
        public int PlatformBottomOffset { get; }
        public int PlatformSpeed { get; }

        public int BrickWidth { get; }
        public int BrickHeight { get; }

        public int BricksMapOffset { get; set; }
        public int[] BricksMap { get; }

        public Ball Ball { get;  set; }
        public Platform Platform { get;  set; }
        public List<Brick> Bricks { get;  set; }

        public Level(string name, int ballSize, int ballBottomOffset, Point ballSpeed, int platformWidth,
            int platformHeight, int platformBottomOffset, int platformSpeed, int brickWidth, int brickHeight, int bricksMapOffset,
            int[] bricksMap)
        {
            Name = name;
            BallSize = ballSize;
            BallBottomOffset = ballBottomOffset;
            BallSpeed = ballSpeed;
            PlatformWidth = platformWidth;
            PlatformHeight = platformHeight;
            PlatformBottomOffset = platformBottomOffset;
            PlatformSpeed = platformSpeed;
            BrickWidth = brickWidth;
            BrickHeight = brickHeight;
            BricksMapOffset = bricksMapOffset;
            BricksMap = bricksMap;
        }

        public void FirstCreate(Rectangle window)
        {
            Ball = new Ball(BallSize, BallBottomOffset, BallSpeed);
            Platform = new Platform(PlatformWidth, PlatformHeight, PlatformBottomOffset, PlatformSpeed);
            Bricks = GenerateBricks(window).ToList();
        }
        public void Create()
        {
            Ball.Size = new Size(BallSize, BallSize); /*= new Ball(BallSize, BallBottomOffset, BallSpeed);*/
            Platform.Size = new Size(PlatformWidth, PlatformHeight);
            
            for(int i = 0; i < Bricks.Count; i++)            
                Bricks[i].Size = new Size(BrickWidth, BrickHeight);
            //Platform = new Platform(PlatformWidth, PlatformHeight, PlatformBottomOffset, PlatformSpeed);
            //Bricks = GenerateBricks(window).ToList();
        }



        private IEnumerable<Brick> GenerateBricks(Rectangle window)
        {
            List<Brick> bricks = new List<Brick>();

            int initialOffsetY = BricksMapOffset;
            int currentY = initialOffsetY;
            int maxBricks = window.Width / BrickWidth;

            foreach (int line in BricksMap)
            {
                int initialOffsetX = 0;
                int tempNum = line;
                if (tempNum > maxBricks)
                {
                    tempNum = maxBricks;
                }
                if (tempNum % 2 == 0)
                {
                    int sideCount = tempNum / 2;
                    int sideWidth = sideCount * BrickWidth;
                    initialOffsetX = window.Width / 2 - sideWidth;

                }
                else
                {
                    int sideCount = (tempNum - 1) / 2;
                    int sideWidth = sideCount * BrickWidth;
                    initialOffsetX = window.Width / 2 - sideWidth - BrickWidth / 2;
                }

                int currentX = initialOffsetX;

                for (int i = 0; i < tempNum; i++)
                {
                    bricks.Add(new Brick(currentX, currentY, BrickWidth, BrickHeight));
                    currentX += BrickWidth + 1;
                }

                currentY += BrickHeight + 1;
            }
            return bricks;
        }
    }
}
