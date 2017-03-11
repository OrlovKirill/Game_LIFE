using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace LIFE
    {
    
    public partial class Form1: Form
        {
        public static bool[,] staticTerrain;
        public static bool IsRandom = true;

        public static int size { get; private set; }
        public static int sizeOfWindow { get { return 600; } }
        public static int sizeOfCell { get; }

        ScannerTerrainDecorator scanTerDec;
        StatisticsTerrainDecorator statTerDec;
        FramedTerrainDecorator framTerDec;
        Terrain terrain;
        Form2 f2;
        

        public Form1 ()
            {
            InitializeComponent();
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
            checkBox1.Visible = false;
            }
        private void RAND_Click (object sender , EventArgs e)
            {
            IsRandom = true;
            Show_GO();
            checkBox1.Visible = false;
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
            
            Start(size);

            if (IsRandom)
                Random(trackBar_FOUNDERS.Value);
            else
                Array.Copy(f2.ManuallyTerrain , staticTerrain , size * size);

            terrain = new Terrain(this);
            scanTerDec = new ScannerTerrainDecorator(this);
            statTerDec = new StatisticsTerrainDecorator(this);
            framTerDec = new FramedTerrainDecorator(this);
            scanTerDec.SetTerrain(terrain);
            statTerDec.SetTerrain(scanTerDec);
            if (!checkBox1.Checked)
                {
                framTerDec.SetTerrain(statTerDec);
                framTerDec.Draw(this.pictureBox1);
                }
            else
                {
                terrain.Draw(pictureBox1);
                }
            this.Update();
            
            }

        private void Random (int founders)
            {
            Random rand = new Random();
            for (int i = 0 ; i < founders ; i++)
                {
                int x = rand.Next(0 , size);
                int y = rand.Next(0 , size);
                if (!staticTerrain[x , y])
                    {
                    staticTerrain[x , y] = true;
                    }
                else
                    {
                    i--;
                    continue;
                    }
                }
            }

        private void Start (int size)
            {
            MANUALLY.Enabled = RAND.Enabled = false;
            REPLAY.Visible = true;
            staticTerrain = new bool[size , size];
            
            
            }

        private void REPLAY_Click (object sender , EventArgs e)
            {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            checkBox1.Visible = true;
            MANUALLY.Visible = RAND.Visible = MANUALLY.Enabled = RAND.Enabled = trackBar_SIZE.Enabled = trackBar_FOUNDERS.Enabled = GO.Visible = true;
            REPLAY.Visible = GO.Visible = label_foundersValue.Visible = trackBar_FOUNDERS.Visible = PLAY.Visible = NEXT_STEP.Visible = label_stepsValue.Visible = label_steps.Visible = label_delayValue.Visible = label_delay.Visible = STEPS.Visible = DELAY.Visible = false;
            //turnf = null;
            //step = null;
            }

        private void STEPS_Scroll (object sender , EventArgs e) 
            {
            label_stepsValue.Text = STEPS.Value.ToString();
            }

        private void NEXT_STEP_Click (object sender , EventArgs e)
            {
            if (!checkBox1.Checked)
                framTerDec.MakeTurn();
            else
                statTerDec.MakeTurn();
            
            this.Update();
            //scanTerDec.AfterInBefore();
            //scanTerDec.AfterInFalse();
            }
        
        private void DELAY_Scroll (object sender , EventArgs e)
            {
            label_delayValue.Text = DELAY.Value.ToString();
            }

        private void PLAY_Click (object sender , EventArgs e)
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
