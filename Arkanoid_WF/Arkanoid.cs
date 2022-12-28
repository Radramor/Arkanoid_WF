using System.Reflection.PortableExecutable;

namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        Game game = new Game();
        public Arkanoid()
        {
            InitializeComponent();
            Init();
            timer.Tick += new EventHandler(update);
            KeyDown += new KeyEventHandler(InputCheck);

        }

        private void update(object? sender, EventArgs e)
        {
            game.Update(BallPictureBox, PaddlePictureBox);
            
        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            game.PaddleMovement(e);   
        }
        private void Init()
        {
            game.CreatePaddle(PaddlePictureBox);
            game.CreateBall(BallPictureBox);
            timer.Interval = 30;
            timer.Start();
        }
    }
}