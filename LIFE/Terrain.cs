using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {
    //staticTerrain хранит матрицу cells, делает ход (переадресуя действия всем Cell, а потом снабжает каждую из них соседями), рисует каждую Cell.
    class Terrain 
        {
        public Cell[,] cells { get; set; }
        int size;
        protected int sizeOfWindow = 600;
        protected int sizeOfCell;
        Graphics g;
        Form1 f1;

        public Terrain (Form1 f1)
            {
            this.f1 = f1;
            size = Form1.staticTerrain.GetLength(0);
            sizeOfCell = sizeOfWindow / size;
            cells = new Cell[size,size];
            for (int i = 0 ; i < size ; i++)
                for (int j = 0 ; j < size ; j++)
                        cells[i,j] = new Cell(i , j, Form1.staticTerrain[i,j]);
            

            // соседи
                {
                cells[0 , 0].SetNeighbors(cells[0 , 1] , cells[1 , 1] , cells[1 , 0] , null , null , null , null , null);
                cells[0 , size - 1].SetNeighbors(cells[0 , size - 2] , cells[1 , size - 1] , cells[1 , size - 2] , null , null , null , null , null);
                cells[size - 1 , 0].SetNeighbors(cells[size - 2 , 0] , cells[size - 1 , 1] , cells[size - 2 , 1] , null , null , null , null , null);
                cells[size - 1 , size - 1].SetNeighbors(cells[size - 2 , size - 2] , cells[size - 2 , size - 1] , cells[size - 1 , size - 2] , null , null , null , null , null);

                for (int i = 1 ; i < size - 1 ; i++)
                    cells[0 , i].SetNeighbors(cells[0 , i - 1] , cells[0 , i + 1] , cells[1 , i - 1] , cells[1 , i] , cells[1 , i + 1] , null , null , null);

                for (int i = 1 ; i < size - 1 ; i++)
                    cells[size - 1 , i].SetNeighbors(cells[size - 1 , i - 1] , cells[size - 1 , i + 1] , cells[size - 2 , i - 1] , cells[size - 2 , i] , cells[size - 2 , i + 1] , null , null , null);

                for (int i = 1 ; i < size - 1 ; i++)
                    cells[i , 0].SetNeighbors(cells[i - 1 , 0] , cells[i + 1 , 0] , cells[i - 1 , 1] , cells[i + 1 , 1] , cells[i , 1] , null , null , null);

                for (int i = 1 ; i < size - 1 ; i++)
                    cells[i , size - 1].SetNeighbors(cells[i - 1 , size - 1] , cells[i + 1 , size - 1] , cells[i - 1 , size - 2] , cells[i + 1 , size - 2] , cells[i , size - 2] , null , null , null);

                for (int i = 1 ; i < size - 1 ; i++)
                    for (int j = 1 ; j < size - 1 ; j++)
                        cells[i , j].SetNeighbors(cells[i - 1 , j] , cells[i + 1 , j] , cells[i , j - 1] , cells[i , j + 1] , cells[i - 1 , j - 1] , cells[i + 1 , j + 1] , cells[i - 1 , j + 1] , cells[i + 1 , j - 1]);
                }
                
            }
        
        public virtual void MakeTurn ()
            {
            AfterInBefore();
            AfterInFalse();
            foreach (Cell cell in cells)
                cell.Turn();
            Draw(f1.pictureBox1);
            }

        public virtual void Draw (PictureBox p)   
            {

            Image img = new Bitmap(sizeOfWindow , sizeOfWindow);
            SolidBrush sbGreen = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.LightGray , 1);

            DrawLayout(ref img);

            foreach (Cell cell in cells)
                    if (cell.stateAfter)
                        g.FillRectangle(sbGreen , new Rectangle(new Point(Convert.ToInt32(cell.x * img.Height / size) + 1 , Convert.ToInt32(cell.y * img.Height / size) + 1) , new Size(Convert.ToInt32(img.Height / size) - 1 , Convert.ToInt32(img.Height / size) - 1)));
            
            p.Image = img;
           
            }

        private void DrawLayout (ref Image bmp)
            {
            
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray , 1);

            for (int i = 0 ; i < size ; i++)
                {
                g.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                }
            }

        public void AfterInFalse ()
            {
            foreach (Cell cell in cells)
                cell.AfterInFalse();
            }
        public void AfterInBefore (){
            foreach (Cell cell in cells)
                cell.AfterInBefore();
            }
        public void BeforeInFalse ()
            {
            foreach (Cell cell in cells)
                cell.BeforeInFalse();
            }
        public void BeforeInAfter ()
            {
            foreach (Cell cell in cells)
                cell.BeforeInAfter();
            }
        }

    abstract class AbstractTerrain
        {
        Form f;
        public Cell[,] cells { get; protected set;}
        public AbstractTerrain (Form f)
            {
            this.f = f;
            }
        public abstract void MakeTurn ();
        //public abstract void BeforeInFalse ();
        //public abstract void Draw (PictureBox p);
        //public abstract void EndTurn ();
        }


    }
