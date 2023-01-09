using Arkanoid_WF.GameObjects;
using Arkanoid_WF.Levels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Arkanoid_WF
{
    public class Game : IGame
    {
        private  AllLevels allLevels;
        private Level currentLevel;

        private Borders borders;
        private Graphics graphics;
        private Rectangle window;

        private bool gameIsOver;

        private readonly string filenameIndexLevel = "C:\\Users\\Admin\\source\\repos\\3 семестр\\Arkanoid\\IndexLevelData.json";
        private readonly string filenameCurrentLevel = "C:\\Users\\Admin\\source\\repos\\3 семестр\\Arkanoid\\CurrentLevelData.json";

        public Game(Rectangle window) 
        {
            allLevels = new AllLevels();
            borders = new Borders(window);
        }
        public bool GetGameIsOver()
        {
            return gameIsOver;
        }
        public void Update(Graphics g, Rectangle _window)
        {
            graphics = g;
            window = _window;

            if (currentLevel == null)
            {
                LoadLevel();
            }

            BallUpdate();
            PlatformUpdate();
            BricksUpdate();

            currentLevel.Bricks.RemoveAll(b =>
            {             
                return b.IsSmashed;
            });     

            CheckBallDeath();            
            CheckWin();
        }

        private void BallUpdate()
        {
            if (currentLevel.Ball.Location.X == 0 && currentLevel.Ball.Location.Y == 0)
            {
                currentLevel.Ball.SetLocation(window);
            }

            currentLevel.Ball.BallMovement(currentLevel.Platform, currentLevel.Bricks, borders);

            graphics.FillEllipse(new SolidBrush(currentLevel.Ball.Color), new Rectangle(currentLevel.Ball.Location, currentLevel.Ball.Size));
        }
        private void PlatformUpdate()
        {
            if (currentLevel.Platform.Location.X == 0 && currentLevel.Platform.Location.Y == 0)
            {
                currentLevel.Platform.SetLocation(window);
            }
            graphics.FillRectangle(new SolidBrush(currentLevel.Platform.Color), new Rectangle(currentLevel.Platform.Location, currentLevel.Platform.Size));
        }

        private void BricksUpdate()
        {
            foreach(var b in currentLevel.Bricks)
            {
                if(!b.IsSmashed)
                {
                    graphics.FillRectangle(new SolidBrush(b.Color), new Rectangle(b.Location, b.Size));
                }
            }
        }

        private void LoadLevel()
        {
            if (gameIsOver || currentLevel == null)
                currentLevel = allLevels.LoadFirstLevel();
            else currentLevel = allLevels.LoadNextLevel();

            currentLevel.FirstCreate(window);
            gameIsOver = false;
        }

        private void CheckWin()
        {
            if (!currentLevel.Bricks.Any() && !gameIsOver)
            {               
                if(allLevels.CheckEnd())
                {
                    gameIsOver = true;
                    currentLevel.Ball.SetLocation(window);
                    currentLevel.Ball.Speed = new Point(0, 0);
                    currentLevel.Platform.SetLocation(window);

                    if (MessageBox.Show("ПОБЕДА!!!!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.None) == DialogResult.Retry)                                          
                        LoadLevel();
                    else
                        Application.Exit();                    
                }
                else LoadLevel();

            }
        }
        private void CheckBallDeath()
        {
            if (currentLevel.Ball.Location.Y + currentLevel.Ball.Size.Height > borders.BottonBorder)
            {
                currentLevel.Ball.SetLocation(window);
                currentLevel.Ball.Speed = new Point(0, 0);
                currentLevel.Platform.SetLocation(window);
                gameIsOver = true;
                if (MessageBox.Show("ПОРАЖЕНИЕ!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    ClearBricks();
                    LoadLevel();
                }  
                else Application.Exit();

            }
        }
        private void ClearBricks()
        {
            currentLevel.Bricks.RemoveAll(b =>
            {                
                return b.IsSmashed;
            });
            currentLevel.Bricks.Clear();
        }

        public void PlatformMovement()
        {
            bool isMovementLeft;
            if (Keyboard.IsKeyDown(Keys.Left) || Keyboard.IsKeyDown(Keys.A))
            {
                isMovementLeft = true;
                currentLevel.Platform.PlatformMovement(isMovementLeft, borders);
            }
                
            else if (Keyboard.IsKeyDown(Keys.Right) || Keyboard.IsKeyDown(Keys.D))
            {
                isMovementLeft = false;
                currentLevel.Platform.PlatformMovement(isMovementLeft, borders);
            }            
        }

        public void Save()
        {
            Clear();
            File.WriteAllText(filenameCurrentLevel, JsonConvert.SerializeObject(currentLevel));
            File.WriteAllText(filenameIndexLevel, JsonConvert.SerializeObject(allLevels));
        }

        public void Clear()
        {
            File.WriteAllText(filenameCurrentLevel, string.Empty);
            File.WriteAllText(filenameIndexLevel, string.Empty);
        }
        private void LoadChanges<T>(out T obj, string filename)
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
            LoadChanges(out currentLevel, filenameCurrentLevel);
            LoadChanges(out allLevels, filenameIndexLevel);
        }
        public bool CheckFiles()
        {
            if (new FileInfo(filenameCurrentLevel).Length == 0 &&
                new FileInfo(filenameIndexLevel).Length == 0)
                return false;
            else return true;
        }
    }
}
