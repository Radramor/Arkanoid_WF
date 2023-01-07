using System;
using System.Windows.Forms;

namespace Arkanoid_WF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ArkanoidForm());
        }
    }
}