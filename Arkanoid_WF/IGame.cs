using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_WF
{
    public interface IGame
    {
        bool CheckFiles();
        void Clear();
        bool GetGameIsOver();
        void Load();
        void Save();
        void Update(Graphics g, Rectangle _window);
        void PlatformMovement();
    }
}
