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
            Controls.Clear();
            GM.BallMovement(ball, this, paddle);
            CreatePaddle();
            CreateBall();
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
            PictureBox PaddleBox = new PictureBox()
            {
                Location = new Point(paddle.PositionX, paddle.PositionY),
                Width = paddle.Length,
                Height = paddle.Height,
                BackColor = Color.White, // сравнение размера картинки и picturebox
                Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png")
            };
            Controls.Add(PaddleBox);
        }
        private void CreateBall()
        {
            PictureBox BallBox = new PictureBox()
            {
                Location = new Point(ball.PositionX, ball.PositionY),
                Width = ball.Size,
                Height = ball.Size,
                BackColor = Color.Gray,
                Image = Image.FromFile("D:\\Arkanoid_WF\\Arkanoid_WF\\Images\\Ball.png")
            };
            Controls.Add(BallBox);
        }

        public void BallDeath()
        {
            Controls.Clear();
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