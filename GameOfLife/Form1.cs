﻿using System;
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

        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int cols;
        private int rows;

        public Form1()
        {
            InitializeComponent();
            
        }

        public void StartGame()
        {
            if (timer1.Enabled)
                return;

            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            resolution = (int)nudResolution.Value;
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new bool[cols, rows];

            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)nudDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (field[x,y])
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution,resolution);
                    }
                }
            }

            Random random = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)nudDensity.Value) == 0;
                }
            }

            pictureBox1.Refresh();
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
    }
}
