namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        GameManager GM = new GameManager();
        Paddle paddle = new Paddle();
        public Arkanoid()
        {
            InitializeComponent();
            init();
            KeyDown += new KeyEventHandler(inputCheck);

        }

        private void inputCheck(object? sender, KeyEventArgs e)
        {
            GM.PaddleMovement(e, paddle);
            Controls.Clear();
            CreatePaddle();
        }
        private void init()
        {
            //timer.Interval = 50;
            CreatePaddle();
            //timer.Start();
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
    }
}