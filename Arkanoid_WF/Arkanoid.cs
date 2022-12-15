using System.Reflection.PortableExecutable;

namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        GameManager GM = new GameManager();
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
            //Controls.Clear();
            GM.BallMovement(ball, this, paddle);
            PaddlePictureBox.Location = new Point(paddle.PositionX, paddle.PositionY);
            BallPictureBox.Location = new Point(ball.PositionX, ball.PositionY);
        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            GM.PaddleMovement(e, paddle);
            
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
            PaddlePictureBox.Width = paddle.Length;
            PaddlePictureBox.Height = paddle.Height;
            PaddlePictureBox.BackColor = Color.White; // сравнение размера картинки и picturebox
            PaddlePictureBox.Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png");
        }
        private void CreateBall()
        {
            BallPictureBox.Location = new Point(ball.PositionX, ball.PositionY);
            BallPictureBox.Width = ball.Size;
            BallPictureBox.Height = ball.Size;
            BallPictureBox.BackColor = Color.Gray;
            BallPictureBox.Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Ball.png");
        }

        public void BallDeath()
        {
            Controls.Clear();
            //начальные значения
            paddle.PositionX = 362;
            paddle.PositionY = 400;
            ball.PositionX = 413;
            ball.PositionY = 370;
            GM._speedBallX = 5;
            GM._speedBallY = 5;
            Init();
        }
    }
}