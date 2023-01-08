using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace Arkanoid_WF
{
    public partial class ArkanoidForm : Form
    {        
        private const int DEFAULT_FPS = 120;

        private readonly Game game;
        private readonly Timer timer;
        public ArkanoidForm()
        {

            timer = new Timer();
            KeyDown += new KeyEventHandler(InputCheck);

            InitializeComponent();            
            SetupTimer(DEFAULT_FPS);
            SetupWindow();

            Rectangle tempRect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);

            game = new Game(tempRect);
            
            //game.Load();
            /*if (game.ball != null && game.Platform != null && game.bricks != null)
                Init();
            else */

        }
        private void SetupTimer(int fps)
        {
            timer.Interval = 1000 / fps;
            timer.Tick += (sender, args) => Refresh();
        }
        private void SetupWindow()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Size = screen.Size; //(Size)new Point(1200, 800);///screen.Size;
            Location = screen.Location;

            BackColor = Color.Navy;
        }
        
        private void Arkanoid_FormClosing(object sender, FormClosingEventArgs e)
        {
            //timer.Stop();
            if (MessageBox.Show("��������� ����?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //game.save();
            }
        }
        private void update(object? sender, EventArgs e)
        {
            //game.Update(BallPictureBox, PaddlePictureBox, this);

        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            game.PlatformMovement();

            if (e.KeyCode == Keys.Enter)  //timer.Enabled)            
                timer.Stop();
            
            else
                timer.Start();
        }
        public void Init()
        {

            //game.CreatePaddle(PaddlePictureBox);
           //game.CreateBall(BallPictureBox);
            //game.GenerateBricks(/*this*/);
            //timer.Interval = 30;
            //timer.Start();
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