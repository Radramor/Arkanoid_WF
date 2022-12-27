﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public class AllLevels
    {
        private readonly List<Level> Levels;
        private int CurrentIndex;

        public AllLevels()
        {
            CurrentIndex = -1;

            Levels = new List<Level>
            {
                new Level(
                    name: "Первый",
                    ballSize: 20,
                    ballBottomOffset: 100,
                    ballMaxAcceleration: 10,
                    platformWidth: 200,
                    platformHeight: 10,
                    platformBottomOffset: 20,
                    platformMaxAcceleration: 40,
                    brickWidth: 90,
                    brickHeight: 20,
                    bricksMapOffset: 300,
                    bricksMap: new[] {4}),
                new Level(
                    name: "Второй",
                    ballSize: 20,
                    ballBottomOffset: 100,
                    ballMaxAcceleration: 10,
                    platformWidth: 100,
                    platformHeight: 10,
                    platformBottomOffset: 20,
                    platformMaxAcceleration: 20,
                    brickWidth: 90,
                    brickHeight: 20,
                    bricksMapOffset: 300,
                    bricksMap: new[] {2, 4, 0, 6, 8})
            };

        }

        public Level LoadCurrentLevel()
        {
            return Levels[CurrentIndex];
        }

        public Level LoadFirstLevel()
        {
            CurrentIndex = 0;
            return Levels[0];
        }

        public Level LoadNextLevel()
        {
            CurrentIndex++;

            if (CurrentIndex > Levels.Count - 1)
            {
                return LoadFirstLevel();
            }

            return Levels[CurrentIndex];
        }
    }
}
