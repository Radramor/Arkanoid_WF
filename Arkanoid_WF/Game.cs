using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Arkanoid_WF
{
    public class Game
    {
        private Paddle paddle { get; } = new Paddle();
        private Ball ball { get; } = new Ball();
        Borders borders = new Borders();

        public void Update(PictureBox BallPictureBox, PictureBox PaddlePictureBox)
        {
            ball.BallMovement(paddle, this);
            CheckBallDeath();
            BallPictureBox.Location = ball.Body.Location;
            PaddlePictureBox.Location = paddle.Body.Location;
        }

        public void CheckBallDeath()
        {
            if (ball.Body.Bottom > borders.deathBorder)
            {
                paddle.DefaultValues();
                ball.DefaultValues();
            }
        }

        internal void PaddleMovement(KeyEventArgs e)
        { 
            paddle.PaddleMovement(e);
        }
        public void CreatePaddle(PictureBox PaddlePictureBox)
        {
            PaddlePictureBox.Location = paddle.Body.Location;
            PaddlePictureBox.Width = paddle.Body.Width;
            PaddlePictureBox.Height = paddle.Body.Height;
            PaddlePictureBox.BackColor = Color.White; // сравнение размера картинки и picturebox
            PaddlePictureBox.Image = Image.FromFile("C:\\Users\\Дмитрий\\Source\\Repos\\Radramor\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png");
        }
        public void CreateBall(PictureBox BallPictureBox)
        {
            BallPictureBox.Location = ball.Body.Location;
            BallPictureBox.Width = ball.Body.Width;
            BallPictureBox.Height = ball.Body.Height;
            BallPictureBox.BackColor = Color.Transparent;
            BallPictureBox.Image = Image.FromFile("C:\\Users\\Дмитрий\\Source\\Repos\\Radramor\\Arkanoid_WF\\Arkanoid_WF\\Images\\Ball.png");
        }
    }
}
