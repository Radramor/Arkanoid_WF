using Arkanoid_WF.GameObjects;
using Arkanoid_WF.Levels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Arkanoid_WF
{
    public class Game
    {
        private readonly AllLevels allLevels;
        private Level currentLevel;
        private Platform platform;
        private Ball ball;
        private List<Brick> bricks;

        private Borders borders;
        private Graphics graphics;
        private Rectangle window;

        private bool gameIsOver;
        private bool messageVisible;

        public bool IsPaused { get; private set; }
        public Game(Rectangle window) 
        {
            allLevels = new AllLevels();
            borders = new Borders(window);
        }

        //public Game(Rectangle window)
        //{
        //    ball = new Ball();
        //    platform = new Platform();
        //    borders = new Borders(window);
        //    bricks = new List<Brick>();
        //}
        //public void Update(PictureBox BallPictureBox, PictureBox PaddlePictureBox, ArkanoidForm arkanoid)
        //{
        //    ball.BallMovement(platform, this, bricks);
        //    CheckBallDeath(arkanoid);
        //    BallPictureBox.Location = ball.Body.Location;
        //    PaddlePictureBox.Location = platform.Body.Location;
        //    CheckWin(arkanoid);
        //}

        public void Update(Graphics g, Rectangle _window)
        {
            graphics = g;
            window = _window;

            if (currentLevel == null)
            {
                LoadLevel();
            }

            if (gameIsOver)
            {
                //ShowGameOverMessage();
                MessageBox.Show("ПОРАЖЕНИЕ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (IsPaused)
            //{

            //}

            BallUpdate(graphics, window);
            PlatformUpdate(graphics, window);

            BricksUpdate(graphics);

            bricks.RemoveAll(b =>
            {             
                return b.IsSmashed;
            });     

            CheckBallDeath();            
            CheckWin();


        }

        private void BallUpdate(Graphics g, Rectangle _window)
        {
            if (ball.Location.X == 0 && ball.Location.Y == 0)
            {
                ball.SetLocation(window);
            }

            ball.BallMovement(platform, bricks, borders);

            graphics.FillEllipse(new SolidBrush(ball.Color), new Rectangle(ball.Location, ball.Size));
        }
        private void PlatformUpdate(Graphics g, Rectangle _window)
        {
            if (platform.Location.X == 0 && platform.Location.Y == 0)
            {
                platform.SetLocation(window);
            }
            graphics.FillRectangle(new SolidBrush(platform.Color), new Rectangle(platform.Location, platform.Size));
        }

        private void BricksUpdate(Graphics g)
        {
            foreach(var b in bricks)
            {
                if(!b.IsSmashed)
                {
                    g.FillRectangle(new SolidBrush(Color.Tomato), new Rectangle(b.Location, b.Size));
                }
            }
        }

        private void LoadLevel()
        {
            if (gameIsOver || currentLevel == null)
                currentLevel = allLevels.LoadFirstLevel();
            else currentLevel = allLevels.LoadNextLevel();

            currentLevel.Create(window);
            ball = currentLevel.Ball;
            platform = currentLevel.Platform;
            bricks = currentLevel.Bricks;

            //gameOver

        }

        private void CheckWin(/*ArkanoidForm arkanoid*/)
        {
            if (!bricks.Any() && !messageVisible)
            {
                messageVisible = true;
                ball.Speed = new Point(0, 0);
                if (MessageBox.Show("ПОБЕДА!!!!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.None) == DialogResult.Retry)
                {
                    //platform.DefaultValues();
                    //ball.DefaultValues();
                    //ball.Speed = new Point(5, 5);
                    ClearBricks(bricks);
                    //GenerateBricks(/*arkanoid*/);
                    messageVisible = false;
                }
                else 
                    Application.Exit();

            }
        }

        public void CheckBallDeath(/*ArkanoidForm arkanoid*/)
        {
            if (ball.Location.Y + ball.Size.Height > borders.BottonBorder)
            {
                //platform.DefaultValues();
                //ball.DefaultValues();
                ball.Speed = new Point(0, 0);
                
                if (MessageBox.Show("ПОРАЖЕНИЕ", "", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    ball.Speed = new Point(5, 5);
                    ClearBricks(bricks);
                    //GenerateBricks(/*arkanoid*/);
                }  
            }
        }

        private void ClearBricks(List<Brick> bricks)
        {
            bricks.RemoveAll(b =>
            {                
                return b.IsSmashed;
            });
            bricks.Clear();
        }

        internal void PlatformMovement()
        {
            bool isMovementLeft;
            if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
            {
                isMovementLeft = true;
                platform.PlatformMovement(isMovementLeft, borders);
            }
                
            else if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
            {
                isMovementLeft = false;
                platform.PlatformMovement(isMovementLeft, borders);
            }
            
        }
        //public void PlatformMovement(KeyEventArgs e)
        //{
        //    var _body = Body;
        //    if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
        //        _body.Offset(-Speed, 0);
        //    if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
        //        _body.Offset(Speed, 0);

        //    //проверка на выход за пределы поля
        //    if (_body.Left >= borders.LeftBorder && _body.Right <= borders.RightBorder)
        //    {
        //        Body = _body;
        //    }
        //}
        public void CreatePaddle(PictureBox PaddlePictureBox)
        {
            PaddlePictureBox.Location = platform.Body.Location;
            PaddlePictureBox.Width = platform.Body.Width;
            PaddlePictureBox.Height = platform.Body.Height;
            PaddlePictureBox.BackColor = Color.White; // сравнение размера картинки и picturebox
            PaddlePictureBox.Image = Image.FromFile("C:\\Users\\Admin\\source\\repos\\3 семестр\\Arkanoid\\Arkanoid_WF\\Images\\Platform.png");
        }
        public void CreateBall(PictureBox BallPictureBox)
        {
            BallPictureBox.Location = ball.Body.Location;
            BallPictureBox.Width = ball.Body.Width;
            BallPictureBox.Height = ball.Body.Height;
            BallPictureBox.BackColor = Color.Transparent;
            BallPictureBox.Image = Image.FromFile("C:\\Users\\Admin\\source\\repos\\3 семестр\\Arkanoid\\Arkanoid_WF\\Images\\Ball.png");
        }

        public void CreateBricks(List<Brick> bricks/*, ArkanoidForm arkanoid*/)
        {
            //for (int i = 0; i < bricks.Count; i++)
            //{
            //    PictureBox brickBox = new PictureBox()
            //    {
            //        Location = bricks[i].Body.Location,
            //        Size = bricks[i].Body.Size,
            //        Image = Image.FromFile("C:\\Users\\Admin\\source\\repos\\3 семестр\\Arkanoid\\Arkanoid_WF\\Images\\resources.png")
            //    };
            //    //bricks[i].pictureBox.Image = true;
            //    bricks[i].pictureBox = brickBox;
            //    arkanoid.Controls.Add(bricks[i].pictureBox);
            //}
        }

        public void GenerateBricks(/*ArkanoidForm arkanoid*/)
        {
            Point location = new Point(80, 50);
            Size size = new Size(70, 30);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //bricks.Add(new Brick(location, size));

                    location.X += 80;
                }
                location.Y += 50;
                location.X = 80;
            }
            //if (bricks.Last().HitPoints != 0)
            //CreateBricks(bricks/*, arkanoid*/);
        }

        //internal void save()
        //{
        //    File.Delete("saveBricks.json");
        //    File.WriteAllText("saveBricks.json", JsonConvert.SerializeObject(bricks));
        //}

        //public void LoadChanges<T>(out T obj, string filename)
        //{
        //    if (File.Exists(filename))
        //    {
        //        var textfile = File.ReadAllText(filename);
        //        obj = JsonConvert.DeserializeObject<T>(textfile);
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Не удалось найти '{filename}'!", "Критическая ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Environment.Exit(1);
        //        throw new FileNotFoundException($"'{filename}' не существует.");
        //    }
        //}
        //public void Load()
        //{
        //    LoadChanges(out bricks, "saveBricks.json");
        //}
    }
}
