using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Arkanoid_WF
{
    public class Game
    {
        public Paddle paddle { get; set; }
        public Ball ball { get; set; }
        public List<Brick> bricks;
        Borders borders = new Borders();
        public bool messageVisible;

        public Game()
        { 
            ball = new Ball();
            paddle = new Paddle();
            bricks = new List<Brick>();
        }
        public void Update(PictureBox BallPictureBox, PictureBox PaddlePictureBox, Arkanoid arkanoid)
        {
            ball.BallMovement(paddle, this, bricks);
            CheckBallDeath(arkanoid);
            BallPictureBox.Location = ball.Body.Location;
            PaddlePictureBox.Location = paddle.Body.Location;
            CheckWin(arkanoid);
        }

        private void CheckWin(Arkanoid arkanoid)
        {
            if (!bricks.Any() && !messageVisible)
            {
                messageVisible = true;
                ball.speed = new Point(0, 0);
                if (MessageBox.Show("ПОБЕДА!!!!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.None) == DialogResult.Retry)
                {
                    paddle.DefaultValues();
                    ball.DefaultValues();
                    ball.speed = new Point(5, 5);
                    ClearBricks(bricks);
                    GenerateBricks(arkanoid);
                    messageVisible = false;
                }
                else 
                    Application.Exit();

            }
        }

        public void CheckBallDeath(Arkanoid arkanoid)
        {
            if (ball.Body.Bottom > borders.deathBorder)
            {
                paddle.DefaultValues();
                ball.DefaultValues();
                ball.speed = new Point(0, 0);
                
                if (MessageBox.Show("ПОРАЖЕНИЕ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    ball.speed = new Point(5, 5);
                    ClearBricks(bricks);
                    GenerateBricks(arkanoid);
                }  
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
                    Image = Image.FromFile("C:\\Users\\Дмитрий\\Source\\Repos\\Arkanoid_WF\\Arkanoid_WF\\Images\\resources.png")
                };
                //bricks[i].pictureBox.Image = true;
                bricks[i].pictureBox = brickBox;
                arkanoid.Controls.Add(bricks[i].pictureBox);
            }
        }

        public void GenerateBricks(Arkanoid arkanoid)
        {
            Point location = new Point(80, 50);
            Size size = new Size(70, 30);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bricks.Add(new Brick(location, size));

                    location.X += 80;
                }
                location.Y += 50;
                location.X = 80;
            }
            if (bricks.Last().HitPoints != 0)
            CreateBricks(bricks, arkanoid);
        }

        internal void save()
        {
            File.Delete("saveBricks.json");
            File.WriteAllText("saveBricks.json", JsonConvert.SerializeObject(bricks));
        }

        public void LoadChanges<T>(out T obj, string filename)
        {
            if (File.Exists(filename))
            {
                var textfile = File.ReadAllText(filename);
                obj = JsonConvert.DeserializeObject<T>(textfile);
            }
            else
            {
                MessageBox.Show($"Не удалось найти '{filename}'!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                throw new FileNotFoundException($"'{filename}' не существует.");
            }
        }
        public void Load()
        {
            LoadChanges(out bricks, "saveBricks.json");
        }
    }
}
