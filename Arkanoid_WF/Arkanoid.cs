using System.Reflection.PortableExecutable;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        Game game = new Game();
        public Arkanoid()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(update);
            KeyDown += new KeyEventHandler(InputCheck);
            //Init();
            game.Load();
            Init();
            /*if (game.ball != null && game.paddle != null && game.bricks != null)
                Init();
            else */

        }
        private void Arkanoid_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            if (MessageBox.Show("Сохранить игру?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                game.save();
            }
        }
        private void update(object? sender, EventArgs e)
        {
            game.Update(BallPictureBox, PaddlePictureBox, this);

        }

        private void InputCheck(object? sender, KeyEventArgs e)
        {
            game.PaddleMovement(e);
            if (e.KeyCode == Keys.Enter && timer.Enabled)
            {
                timer.Stop();
            }
            else
                timer.Start();
        }
        public void Init()
        {

            game.CreatePaddle(PaddlePictureBox);
            game.CreateBall(BallPictureBox);
            game.GenerateBricks(this);
            timer.Interval = 30;
            timer.Start();
        }

        
    }
}