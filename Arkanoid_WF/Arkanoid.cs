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
            ball.BallMovement(this, paddle);
            PaddlePictureBox.Location = new Point(paddle.PositionX, paddle.PositionY);
            BallPictureBox.Location = new Point(ball.PositionX, ball.PositionY);
        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            paddle.PaddleMovement(e);
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
            PaddlePictureBox.Location = new Point(paddle.PositionX, paddle.PositionY);
            PaddlePictureBox.Width = Paddle.Length;
            PaddlePictureBox.Height = Paddle.Height;
            PaddlePictureBox.BackColor = Color.White; // сравнение размера картинки и picturebox
            PaddlePictureBox.Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png");
        }
        private void CreateBall()
        {
            BallPictureBox.Location = new Point(ball.PositionX, ball.PositionY);
            BallPictureBox.Width = Ball.Size;
            BallPictureBox.Height = Ball.Size;
            BallPictureBox.BackColor = Color.Gray;
            BallPictureBox.Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Ball.png");
        }

        public void BallDeath()
        {
            //начальные значения
            paddle.DefaultValues();
            ball.DefaultValues();
            Init();
        }
    }
}