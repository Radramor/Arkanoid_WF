using System.Windows.Forms;
using System.Drawing;
using System;

namespace Arkanoid_WF
{
    public partial class ArkanoidForm : Form
    {        
        private const int DEFAULT_INTERVAL = 1000 / 120;

        private readonly IGame game;
        private readonly Timer timer;
        public ArkanoidForm()
        {
            timer = new Timer();
            KeyDown += new KeyEventHandler(InputCheck);
            
            InitializeComponent();         
            SetupWindow();

            Rectangle tempRect = new(Location.X, Location.Y, Size.Width, Size.Height);
            game = new Game(tempRect);

            if (game.CheckFiles())
            {
                if (MessageBox.Show("Продолжить игру?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    game.Load();                    
                }
            }
            SetupTimer(DEFAULT_INTERVAL);
        }
        private void SetupTimer(int interval)
        {
            timer.Interval = interval;
            timer.Tick += (sender, args) => Refresh();
        }
        private void SetupWindow()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Size = screen.Size; 
            Location = screen.Location;

            BackColor = Color.FromArgb(0,0,45);
        }
        
        private void Arkanoid_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            if (!game.GetGameIsOver())
            {
                if (MessageBox.Show("Сохранить игру?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    game.Save();
                else
                    game.Clear();
            }
            else game.Clear();
        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            game.PlatformMovement();

            if (e.KeyCode == Keys.Enter)  //timer.Enabled)            
                timer.Stop();
            
            else
                timer.Start();
        }
        private void ArkanoidForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void ArkanoidForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle window = e.ClipRectangle;
            Graphics g = e.Graphics;

            game.Update(g, window);
        }
    }
}