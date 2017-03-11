using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {
    class FramedTerrainDecorator: AbstractTerrainDecorator
        {
        Form1 f1;
        Graphics g;
        public FramedTerrainDecorator (Form1 f1) : base(f1)
            {
            this.f1 = f1;
            }
        public override void MakeTurn ()
            {
            terrain.AfterInBefore();
            terrain.AfterInFalse();
            foreach (Cell cell in terrain.cells)
                cell.Turn();
            Draw(f1.pictureBox1);
            }

        public override void Draw (PictureBox p)
            {

            Image img = new Bitmap(sizeOfWindow , sizeOfWindow);
            SolidBrush sbGreen = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.LightGray , 1);

            DrawLayout(ref img);

            foreach (Cell cell in terrain.cells)
                if (cell.stateAfter)
                    g.FillRectangle(sbGreen , new Rectangle(new Point(Convert.ToInt32(cell.x * img.Height / Form1.size) + 1 , Convert.ToInt32(cell.y * img.Height / Form1.size) + 1) , new Size(Convert.ToInt32(img.Height / Form1.size) - 1 , Convert.ToInt32(img.Height / Form1.size) - 1)));

            p.Image = img;
            }

        private void DrawLayout (ref Image bmp)
            {

            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.White , 1);

            for (int i = 0 ; i < Form1.size ; i++)
                {
                g.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / Form1.size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / Form1.size) , sizeOfWindow));
                g.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / Form1.size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / Form1.size)));
                }
            }
        
        }
    }
