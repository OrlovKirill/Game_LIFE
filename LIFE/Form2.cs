using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {

    

    public partial class Form2: Form
        {
        protected int sizeOfWindow;
        protected int sizeOfCell;
        public bool[,] ManuallyTerrain;
        protected int size ;
        
        SolidBrush sbGreen = new SolidBrush(Color.Green);
        SolidBrush sbWhite = new SolidBrush(Color.White);

        Bitmap bmp1;
        Graphics g1;

        public Form2 (int size)
            {
            this.size = size;
            InitializeComponent();
            ManuallyTerrain = new bool[size , size];
            sizeOfCell = sizeOfWindow / size;
            bmp1 = new Bitmap(pictureBox1.Height , pictureBox1.Width);
            g1 = Graphics.FromImage(bmp1);
            sizeOfWindow = pictureBox1.Height;
            Pen pen = new Pen(Color.LightGray , 1);
            for (int i = 0 ; i < size ; i++)
                {
                g1.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g1.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                }
            pictureBox1.Image = bmp1;
            }

        private void CANCEL_Click (object sender , EventArgs e)
            {
            Array.Clear(ManuallyTerrain , 0 , size * size);
            g1.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray , 1);
            for (int i = 0 ; i < size ; i++)
                {
                g1.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g1.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                }
            pictureBox1.Image = bmp1;
            this.Hide();
            }

        private void pictureBox1_Click (object sender , EventArgs e)
            {
            int x = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(Cursor.Position.X) / (Convert.ToDecimal(sizeOfWindow) / size)));
            int y = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(Cursor.Position.Y) / (Convert.ToDecimal(sizeOfWindow) / size)));
            if (!ManuallyTerrain[x , y])
                {
                ManuallyTerrain[x , y] = true;
                g1.FillRectangle(sbGreen , new Rectangle(new Point(Convert.ToInt32(x * sizeOfWindow / size) + 1 , Convert.ToInt32(y * sizeOfWindow / size) + 1) , new Size(Convert.ToInt32(sizeOfWindow / size) - 1 , Convert.ToInt32(sizeOfWindow / size) - 1)));
                }
            else
                {
                ManuallyTerrain[x , y] = false;
                g1.FillRectangle(sbWhite , new Rectangle(new Point(Convert.ToInt32(x * sizeOfWindow / size) + 1 , Convert.ToInt32(y * sizeOfWindow / size) + 1) , new Size(Convert.ToInt32(sizeOfWindow / size) - 1 , Convert.ToInt32(sizeOfWindow / size) - 1)));
                }
            pictureBox1.Image = bmp1;
            pictureBox1.Update();
            }

        private void APPLY_Click (object sender , EventArgs e)
            {
            Form1 f1 = (Form1)Owner;
            Form1.IsRandom = false;
            f1.Show_GO();
            this.Hide();
            f1.Update();
            }

        private void CLEAN_Click (object sender , EventArgs e)
            {
            Array.Clear(ManuallyTerrain , 0 , size * size);
            g1.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray , 1);
            for (int i = 0 ; i < size ; i++)
                {
                g1.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g1.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                }
            pictureBox1.Image = bmp1;
            }
        }
    }
