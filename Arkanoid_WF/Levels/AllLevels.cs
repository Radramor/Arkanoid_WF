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
        public List<Level> Levels { get; set; }

        public int CurrentIndex { get; set; }

        public AllLevels()
        {
            CurrentIndex = -1;

            Levels = new List<Level>();
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
