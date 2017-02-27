using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
//Клетка оживает, если: соседних живых клеток ровно 3
//Клетка гаснет, если: соседних живых клеток меньше 2 или больше 3
namespace LIFE
    {

    
    public delegate void Step (int x , int y);
    public delegate void TurnFinished ();
    public delegate void Patterndetected (int x , int y , int pat);
    
    public partial class Form1: Form
        {
        protected bool[,] Terrain;
        public bool[,] GetTerrain { get { return Terrain; } }
        protected bool[,] copyTer;
        protected int size;
        public int GetSize { get { return size; } }
        protected int sizeOfWindow = 600;
        protected int sizeOfCell;
        Bitmap bmp1;
        Bitmap bmp2;
        Bitmap bmp3;
        Graphics g1;
        Graphics g2;
        Form2 f2;
        Graphics layout;
        public static bool IsRandom = true;

        public event Step step = null;
        public event TurnFinished turnf = null;
        public Scanner sc;
        public Form1 ()
            {
            InitializeComponent();
            sc = new Scanner(this);
            }

        private void SIZE_Scroll (object sender , EventArgs e)
            {
            label_sizeValue.Text = trackBar_SIZE.Value.ToString();
            trackBar_FOUNDERS.Maximum = Convert.ToInt32(Math.Pow(trackBar_SIZE.Value , 2));
            label_foundersValue.Text = trackBar_FOUNDERS.Value.ToString();
            }

        private void FOUNDERS_Scroll (object sender , EventArgs e)
            {
            label_foundersValue.Text = trackBar_FOUNDERS.Value.ToString();
            }
        private void MANUALLY_Click (object sender , EventArgs e)
            {
            size = trackBar_SIZE.Value;
            f2 = new Form2(size);
            f2.Owner = this;
            f2.Show();
            }
        private void RAND_Click (object sender , EventArgs e)
            {
            IsRandom = true;
            Show_GO();
            }

        public void Show_GO ()
            {
            MANUALLY.Visible = RAND.Visible = false;
            label_foundersValue.Visible = trackBar_FOUNDERS.Visible = true;
            GO.Visible = REPLAY.Visible = true;
            if (!IsRandom)
               GO.PerformClick();
            }

        public void GO_Click (object sender , EventArgs e)
            {
            trackBar_SIZE.Enabled = trackBar_FOUNDERS.Enabled =  GO.Visible = false;
            PLAY.Visible = NEXT_STEP.Visible = label_stepsValue.Visible = label_steps.Visible = label_delayValue.Visible = label_delay.Visible = STEPS.Visible = DELAY.Visible = true;
            size = trackBar_SIZE.Value;
            start(size);

            if (IsRandom)
                Random(trackBar_FOUNDERS.Value);
            else
                Array.Copy(f2.ManuallyTerrain , Terrain , size * size);

            drawLayout();
            sc.Scan();
            }

        private void Random (int founders)
            {
            Random rand = new Random();
            for (int i = 0 ; i < founders ; i++)
                {
                int x = rand.Next(0 , size);
                int y = rand.Next(0 , size);
                if (!Terrain[x , y])
                    {
                    Terrain[x , y] = true;
                    }
                else
                    {
                    i--;
                    continue;
                    }
                }
            }

        private void drawLayout ()
            {
            sizeOfCell = sizeOfWindow / size;
            bmp1 = new Bitmap(pictureBox1.Height , pictureBox1.Width);
            bmp2 = new Bitmap(pictureBox2.Height , pictureBox2.Width);
            bmp3 = new Bitmap(pictureBox2.Height , pictureBox2.Width);
            g1 = Graphics.FromImage(bmp1);
            g2 = Graphics.FromImage(bmp2);
            layout = Graphics.FromImage(bmp3);
            Pen pen = new Pen(Color.LightGray , 1);

            for (int i = 0 ; i < size ; i++)
                {
                g1.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g1.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                g2.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g2.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                layout.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                layout.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                }

            pictureBox1.Image = bmp1;
            pictureBox2.Image = bmp2;
            int k, j;
            for (k = 0 ; k < size ; k++)
                for (j = 0 ; j < size ; j++)
                    if (Terrain[k , j])
                        {
                        SolidBrush sbGreen = new SolidBrush(Color.Green);
                        g1.FillRectangle(sbGreen , new Rectangle(new Point(Convert.ToInt32(k * sizeOfWindow / size) + 1 , Convert.ToInt32(j * sizeOfWindow / size) + 1) , new Size(Convert.ToInt32(sizeOfWindow / size) - 1 , Convert.ToInt32(sizeOfWindow / size) - 1)));
                        }
            }

        private void start (int size)
            {
            MANUALLY.Enabled = RAND.Enabled = false;
            REPLAY.Visible = true;
            Terrain = new bool[size , size];
            copyTer = new bool[size , size];
            step += birth;
            step += death;
            turnf += LifeForm;
            turnf += sc.Scan;
            sc.PatternDetected += FavoritesForm;
            }

        private void REPLAY_Click (object sender , EventArgs e)
            {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            MANUALLY.Visible = RAND.Visible = MANUALLY.Enabled = RAND.Enabled = trackBar_SIZE.Enabled = trackBar_FOUNDERS.Enabled = GO.Visible = true;
            REPLAY.Visible = GO.Visible = label_foundersValue.Visible = trackBar_FOUNDERS.Visible = PLAY.Visible = NEXT_STEP.Visible = label_stepsValue.Visible = label_steps.Visible = label_delayValue.Visible = label_delay.Visible = STEPS.Visible = DELAY.Visible = false;
            turnf = null;
            step = null;
            }

        public void NewStep (int x, int y)
            {
            step(x , y);
            }

        private void dLayoutPb (ref Graphics g, ref Bitmap bmp, ref Pen pen, ref PictureBox pb)
            {
            g.Clear(Color.White);
            bmp = new Bitmap(pb.Height , pb.Width);
            g = Graphics.FromImage(bmp);
            //Pen pen = new Pen(Color.LightGray , 1);

            for (int i = 0 ; i < size ; i++)
                {
                g.DrawLine(pen , new Point(Convert.ToInt32(i * sizeOfWindow / size) , 0) , new Point(Convert.ToInt32(i * sizeOfWindow / size) , sizeOfWindow));
                g.DrawLine(pen , new Point(0 , Convert.ToInt32(i * sizeOfWindow / size)) , new Point(sizeOfWindow , Convert.ToInt32(i * sizeOfWindow / size)));
                }
            pb.Image = bmp;
            }

        private int neighbors (int x, int y)
            {
            int n = 0;
            if (x + 1 < size)
                if (Terrain[x + 1 , y])
                    n++;
            if (x - 1 >= 0)
                if (Terrain[x - 1 , y])
                    n++;
            if (y + 1 < size)
                if (Terrain[x , y + 1])
                    n++;
            if (y - 1 >= 0)
                if (Terrain[x , y - 1])
                    n++;
            if (x + 1 < size && y + 1 < size)
                if (Terrain[x + 1 , y + 1])
                    n++;
            if (x - 1 >= 0 && y - 1 >= 0)
                if (Terrain[x - 1 , y - 1])
                    n++;
            if (x + 1 < size && y - 1 >= 0)
                if (Terrain[x + 1 , y - 1])
                    n++;
            if (x - 1 >= 0 && y + 1 < size)
                if (Terrain[x - 1 , y + 1])
                    n++;
            return n;
            }

        private void birth (int x, int y)
            {
            if (!Terrain[x , y])
                if (neighbors(x , y) == 3)
                    copyTer[x , y] = true;
            }

        private void death (int x , int y)
            {
            if (Terrain[x , y])
                {
                int n = neighbors(x , y);
                if (n < 2 || n > 3)
                    copyTer[x , y] = false;
                else
                    copyTer[x , y] = true;
                }
            }

        private void LifeForm ()
            {
            SolidBrush sbGreen = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.LightGray , 1);
            dLayoutPb(ref g1 , ref bmp1 , ref pen , ref pictureBox1);
            for (int x = 0 ; x < size ; x++)
                for (int y = 0 ; y < size ; y++)
                    if (copyTer[x , y])
                        g1.FillRectangle(sbGreen , new Rectangle(new Point(Convert.ToInt32(x * sizeOfWindow / size) + 1 , Convert.ToInt32(y * sizeOfWindow / size) + 1) , new Size(Convert.ToInt32(sizeOfWindow / size) - 1 , Convert.ToInt32(sizeOfWindow / size) - 1)));
            
            Array.Copy(copyTer , Terrain , size * size);
            copyTer = new bool[size , size];
            
            pictureBox1.Image = bmp1;

            dLayoutPb(ref g2 , ref bmp2 , ref pen , ref pictureBox2);
            }

        private void FavoritesForm(int x, int y, int pat)
            {
            SolidBrush sbRed = new SolidBrush(Color.Red);
            SolidBrush sbOrange = new SolidBrush(Color.DarkOrange);
            SolidBrush sbMagenta = new SolidBrush(Color.Magenta);
            SolidBrush sbBlue = new SolidBrush(Color.Blue);
            SolidBrush sbBlack = new SolidBrush(Color.Black);

            switch (pat)
                {
                case 0:
                    
                    FillCell(x , y, sbRed);
                    FillCell(x+1 , y , sbRed);
                    FillCell(x , y+1 , sbRed);
                    FillCell(x+1 , y+1 , sbRed);
                    break;
                case 11:
                    FillCell(x , y, sbOrange);
                    FillCell(x - 1 , y+1 , sbOrange);
                    FillCell(x +1, y + 1 , sbOrange);
                    FillCell(x + 1 , y + 2 , sbOrange);
                    FillCell(x - 1 , y + 2 , sbOrange);
                    FillCell(x  , y + 3 , sbOrange);
                    break;
                case 12:
                    FillCell(x , y , sbOrange);
                    FillCell(x + 1 , y - 1 , sbOrange);
                    FillCell(x + 1 , y + 1 , sbOrange);
                    FillCell(x +2 , y -1 , sbOrange);
                    FillCell(x +2 , y + 1 , sbOrange);
                    FillCell(x+3 , y  , sbOrange);
                    break;
                case 21:
                    FillCell(x , y , sbMagenta);
                    FillCell(x + 1 , y , sbMagenta);
                    FillCell(x + 2 , y , sbMagenta);
                    break;
                case 22:
                    FillCell(x , y , sbMagenta);
                    FillCell(x  , y +1, sbMagenta);
                    FillCell(x  , y +2, sbMagenta);
                    break;
                case 31:
                    FillCell(x , y , sbBlue);
                    FillCell(x +1, y + 1 , sbBlue);
                    FillCell(x -1, y + 2 , sbBlue);
                    FillCell(x  , y + 2 , sbBlue);
                    FillCell(x + 1 , y + 2 , sbBlue);
                    break;
                case 32:
                    FillCell(x , y , sbBlue);
                    FillCell(x - 1 , y + 1 , sbBlue);
                    FillCell(x - 2 , y + 1 , sbBlue);
                    FillCell(x -2, y -1 , sbBlue);
                    FillCell(x -2 , y , sbBlue);
                    break;
                case 33:
                    FillCell(x , y , sbBlue);
                    FillCell(x + 1 , y -2 , sbBlue);
                    FillCell(x - 1 , y -2 , sbBlue);
                    FillCell(x  , y -2 , sbBlue);
                    FillCell(x - 1 , y-1 , sbBlue);
                    break;
                case 34:
                    FillCell(x , y , sbBlue);
                    FillCell(x + 1 , y - 1 , sbBlue);
                    FillCell(x + 2 , y +1 , sbBlue);
                    FillCell(x+2 , y -1 , sbBlue);
                    FillCell(x + 2 , y  , sbBlue);
                    break;
                case 41:
                    FillCell(x , y , sbBlack);
                    FillCell(x +1, y , sbBlack);
                    FillCell(x+2 , y-1 , sbBlack);
                    FillCell(x+2 , y+1 , sbBlack);
                    FillCell(x+3 , y , sbBlack);
                    FillCell(x+4 , y , sbBlack);
                    FillCell(x +5, y , sbBlack);
                    FillCell(x+6 , y , sbBlack);
                    FillCell(x +7, y-1 , sbBlack);
                    FillCell(x +7, y+1 , sbBlack);
                    FillCell(x +8, y , sbBlack);
                    FillCell(x+9 , y , sbBlack);
                    break;
                case 42:
                    FillCell(x , y , sbBlack);
                    FillCell(x , y +1, sbBlack);
                    FillCell(x+1 , y+2 , sbBlack);
                    FillCell(x-1 , y+2 , sbBlack);
                    FillCell(x , y+3 , sbBlack);
                    FillCell(x , y+4 , sbBlack);
                    FillCell(x , y+5 , sbBlack);
                    FillCell(x , y+6 , sbBlack);
                    FillCell(x+1 , y+7 , sbBlack);
                    FillCell(x -1, y+7 , sbBlack);
                    FillCell(x , y+8 , sbBlack);
                    FillCell(x , y+9 , sbBlack);
                    break;
                }

            pictureBox2.Image = bmp2;
            pictureBox2.Update();
            }

        private void FillCell (int x, int y, SolidBrush sb)
            {
            g2.FillRectangle(sb , new Rectangle(new Point(Convert.ToInt32(x * sizeOfWindow / size) + 1 , Convert.ToInt32(y * sizeOfWindow / size) + 1) , new Size(Convert.ToInt32(sizeOfWindow / size) - 1 , Convert.ToInt32(sizeOfWindow / size) - 1)));
            }

        private void STEPS_Scroll (object sender , EventArgs e) 
            {
            label_stepsValue.Text = STEPS.Value.ToString();
            }

        private void NEXT_STEP_Click (object sender , EventArgs e)
            {

            for (int x = 0 ; x < size ; x++)
                for (int y = 0 ; y < size ; y++)
                    NewStep(x , y);

                turnf();
                
            }
        
        private void DELAY_Scroll (object sender , EventArgs e)
            {
            label_delayValue.Text = DELAY.Value.ToString();
            }

        private void PLAY_Click_1 (object sender , EventArgs e)
            {
            for (int i = 0 ; i < STEPS.Value ; i++)
                {
                NEXT_STEP.PerformClick();
                pictureBox1.Update();
                Thread.Sleep(DELAY.Value);
                }
            }

        private void NEXT_STEP_KeyDown (object sender , KeyEventArgs e)
            {
            NEXT_STEP.PerformClick();
            }
        }
    }
