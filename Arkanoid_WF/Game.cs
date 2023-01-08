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

        public Game(Rectangle window) 
        {
            allLevels = new AllLevels();
            borders = new Borders(window);
        }

        public void Update(Graphics g, Rectangle _window)
        {
            graphics = g;
            window = _window;

            if (currentLevel == null)
            {
                LoadLevel();
            }

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
            gameIsOver = false;
        }

        private void CheckWin()
        {
            if (!bricks.Any() && !gameIsOver)
            {               
                if(allLevels.CheckEnd())
                {
                    gameIsOver = true;
                    ball.SetLocation(window);
                    ball.Speed = new Point(0, 0);
                    platform.SetLocation(window);

                    if (MessageBox.Show("ПОБЕДА!!!!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.None) == DialogResult.Retry)                                          
                        LoadLevel();
                    else
                        Application.Exit();                    
                }
                else LoadLevel();

            }
        }

        public void CheckBallDeath()
        {
            if (ball.Location.Y + ball.Size.Height > borders.BottonBorder)
            {
                //platform.DefaultValues();
                //ball.DefaultValues();
                ball.SetLocation(window);
                ball.Speed = new Point(0, 0);
                platform.SetLocation(window);

                if (MessageBox.Show("ПОРАЖЕНИЕ!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    gameIsOver = true;
                    
                    ClearBricks(bricks);
                    LoadLevel();
                    //GenerateBricks(/*arkanoid*/);
                }  
                else Application.Exit();

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
