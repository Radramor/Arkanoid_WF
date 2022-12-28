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
        private List<Brick> bricks = new List<Brick>();
        Borders borders = new Borders();

        public void Update(PictureBox BallPictureBox, PictureBox PaddlePictureBox, Arkanoid arkanoid)
        {
            ball.BallMovement(paddle, this, bricks);
            CheckBallDeath(arkanoid);
            BallPictureBox.Location = ball.Body.Location;
            PaddlePictureBox.Location = paddle.Body.Location;
        }

        public void CheckBallDeath(Arkanoid arkanoid)
        {
            if (ball.Body.Bottom > borders.deathBorder)
            {
                paddle.DefaultValues();
                ball.DefaultValues();
                ClearBricks(bricks);
                GenerateBricks(arkanoid);
            }
        }

        private void ClearBricks(List<Brick> bricks)
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].pictureBox.Visible = false;
            }
            bricks.Clear();
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

        public void CreateBricks(List<Brick> bricks, Arkanoid arkanoid)
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                PictureBox brickBox = new PictureBox()
                {
                    Location = bricks[i].Body.Location,
                    Size = bricks[i].Body.Size,
                    Image = Image.FromFile("C:\\Users\\Дмитрий\\Source\\Repos\\Radramor\\Arkanoid_WF\\Arkanoid_WF\\Images\\Paddle.png")
                };
                //bricks[i].pictureBox.Image = true;
                bricks[i].pictureBox = brickBox;
                arkanoid.Controls.Add(bricks[i].pictureBox);
            }
        }

        public void GenerateBricks(Arkanoid arkanoid)
        {
            Point location = new Point(150, 50);
            Size size = new Size(126, 24);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bricks.Add(new Brick(location, size));

                    location.X += 150;
                }
                location.Y += 50;
                location.X = 150;
            }
            CreateBricks(bricks, arkanoid);
        }
    }
}
