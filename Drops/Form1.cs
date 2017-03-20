using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drops
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        SolidBrush brush;
        SolidBrush mapBrush;
        Color backgroundColor = Color.FromArgb(230, 230, 230);
        int xPosition, yPosition;
        int dropBits, drops;
        Rectangle mainCube;
        List<Rectangle> dropsRect;
        List<int> dropsAmount;
        List<int> dropsPositionY;
        int[] dropsY;
        Graphics graphics;
        Graphics graphicsOverride;

        public Form1()
        {
            InitializeComponent();
            LoadInstances();
            //FillCubes();
        }

        void LoadInstances()
        {
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(250, 250, 250));
            mapBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(150, 150, 150));
            bitmap = new Bitmap(this.Width, this.Height);
            graphics = Graphics.FromImage(bitmap);
            graphicsOverride = this.CreateGraphics();
            dropBits = 0;
            drops = 0;
            dropsRect = new List<Rectangle>();
            dropsAmount = new List<int>();
            dropsAmount.Add(drops);
            dropsPositionY = new List<int>();
            dropsPositionY.Add(0);
            //dropsRect.Add(new Rectangle(RandomRowDrop(), dropBits, 9, 9));
            timer.Start();
            //mainCube = new Rectangle(xPosition, yPosition, 9, 9);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FillCubes();

            
        }

        void FillCubes()
        {
            graphics.Clear(backgroundColor);

            int sideRow = 0;

            // draw field of large "pixels"
            while (sideRow < 460)
            {
                for (int i = 0; i < 500; i += 10)
                {
                    mainCube = new Rectangle(i, sideRow, 9, 9);
                    graphics.FillRectangle(mapBrush, mainCube);
                }
                sideRow += 10;
            }

            // draw drops
            foreach(int rectPlace in dropsAmount)
            {
                mainCube = new Rectangle(rectPlace, dropBits, 9, 9);
                graphics.FillRectangle(brush, mainCube);
            }
            
            if (RandomNumber())
            {
                int dropRandom = RandomRowDrop();
                Console.WriteLine(dropRandom.ToString());
                this.Text = dropRandom.ToString();
                dropsAmount.Add(dropRandom);
                dropsPositionY.Add(0);
            }
            foreach(int amount in dropsPositionY)
            {
                //amount.
            }

            
            dropBits += 10;
            drops += 1;
            if(dropBits > 460)
            {
                dropBits = 0;
            }

            graphicsOverride.DrawImage(bitmap, 0, 0, this.Width, this.Height);
        }

        bool RandomNumber()
        {
            Random random = new Random();
            bool giveNumber = false;

            int number = random.Next(2);
            if (number == 0)
            {
                giveNumber = true;
            }

            return giveNumber;
        }

        int RandomRowDrop()
        {
            Random random = new Random();

            int number = random.Next(49);
            number = number * 10;
            return number;
        }
    }
}
