using System.Reflection.PortableExecutable;

namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        Paddle paddle = new Paddle();
        Ball ball = new Ball();
        public Arkanoid()
        {
            InitializeComponent();
            Init();
            timer.Tick += new EventHandler(update);
            KeyDown += new KeyEventHandler(InputCheck);

        }

        private void update(object? sender, EventArgs e)
        {
            ball.BallMovement(paddle); 
            BallPictureBox.Location = ball.Body.Location;
        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            paddle.PaddleMovement(e);
            PaddlePictureBox.Location = paddle.Body.Location;
        }
        private void Init()
        {
            CreatePaddle();
            CreateBall();
            timer.Interval = 30;
            timer.Start();
        }

        private void CreatePaddle()
        {
            PaddlePictureBox.Location = paddle.Body.Location;
            PaddlePictureBox.Width = paddle.Body.Width;
            PaddlePictureBox.Height = paddle.Body.Height;
            PaddlePictureBox.BackColor = Color.White; // сравнение размера картинки и picturebox
            PaddlePictureBox.Image = Image.FromFile("C:\\Users\\ƒмитрий\\Source\\Repos\\Radramor\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png");
        }
        private void CreateBall()
        {
            BallPictureBox.Location = ball.Body.Location;
            BallPictureBox.Width = ball.Body.Width;
            BallPictureBox.Height = ball.Body.Height;
            BallPictureBox.BackColor = Color.Transparent;
            BallPictureBox.Image = Image.FromFile("C:\\Users\\ƒмитрий\\Source\\Repos\\Radramor\\Arkanoid_WF\\Arkanoid_WF\\Images\\Ball.png");
        }


    }
}