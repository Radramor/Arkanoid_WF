namespace Arkanoid_WF
{
    public partial class Arkanoid : Form
    {
        public Arkanoid()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(update);
            init();
        }



        private void update(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void init()
        {
            timer.Interval = 50;
            CreatePaddle()
        }

        private void CreatePaddle()
        {
            
        }

        private void DrawMap(Graphics g)
        {

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {

        }
    }
}