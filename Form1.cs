
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class Form1 : Form
    {
        Mover mover;
        List<Mover> movers = new List<Mover>();

        public Form1()
        {
            InitializeComponent();
        }


        Random random = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 5;
            timer.Tick += Timer_Tick;
            this.Paint += Form1_Paint;
            for (int i = 0; i < 1000; i++)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                mover = new Mover(this.Width, this.Height, this, randomColor);
                movers.Add(mover);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //mover.Update();
            //mover.Display(e.Graphics);
            foreach (var mover in movers)
            {
                mover.Update();
                mover.Display(e.Graphics);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}