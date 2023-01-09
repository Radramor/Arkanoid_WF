using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arkanoid_WF.Levels
{
    public class AllLevels
    {
        private List<Level> Levels { get; set; }

        public int CurrentIndex { get; set; }

        public AllLevels()
        {
            CurrentIndex = -1;

            Levels = new List<Level>
            {
                new Level(
                    name: "Первый",
                    ballSize: 25,
                    ballBottomOffset: 110,
                    ballSpeedX: 0,
                    ballSpeedY: 5,
                    platformWidth: 200,
                    platformHeight: 20,
                    platformBottomOffset: 80,
                    platformSpeed: 40,
                    brickWidth: 90,
                    brickHeight: 25,
                    bricksMapOffset: 300,
                    bricksMap: new[] {2}),
                new Level(
                    name: "Второй",
                    ballSize: 20,
                    ballBottomOffset: 100,
                    ballSpeedX: 0,
                    ballSpeedY: 5,
                    platformWidth: 100,
                    platformHeight: 10,
                    platformBottomOffset: 80,
                    platformSpeed: 20,
                    brickWidth: 90,
                    brickHeight: 20,
                    bricksMapOffset: 300,
                    bricksMap: new[] {2})
            };

        }

        public Level LoadFirstLevel()
        {
            CurrentIndex = 0;
            return Levels[0];
        }

        public Level LoadNextLevel()
        {
            CurrentIndex++;
            return Levels[CurrentIndex];
        }
        public bool CheckEnd()
        {
            if (CurrentIndex == Levels.Count - 1)
                return true;
            return false;
        }
    }
}
