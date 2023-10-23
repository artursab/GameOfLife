using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private int currentGeneration = 0;
        private Graphics graphics;
        private int resolution;
        

        public Form1()
        {
            InitializeComponent();
            
        }

        public void StartGame()
        {
            if (timer1.Enabled)
                return;

            currentGeneration = 0;
            Text = $"Generation {currentGeneration}";

            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            resolution = (int)nudResolution.Value;
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            

            

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;

            timer1.Stop();
            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
           StartGame();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                    field[x, y] = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);
                if (validationPassed)
                    field[x, y] = false;
            }
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Generation {currentGeneration}";
        }

        private void nudDensity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
