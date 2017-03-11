namespace LIFE
    {
    partial class Form1
        {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ()
            {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.trackBar_SIZE = new System.Windows.Forms.TrackBar();
            this.label_size = new System.Windows.Forms.Label();
            this.label_sizeValue = new System.Windows.Forms.Label();
            this.label_foundersValue = new System.Windows.Forms.Label();
            this.label_founders = new System.Windows.Forms.Label();
            this.trackBar_FOUNDERS = new System.Windows.Forms.TrackBar();
            this.label_stepsValue = new System.Windows.Forms.Label();
            this.label_steps = new System.Windows.Forms.Label();
            this.STEPS = new System.Windows.Forms.TrackBar();
            this.GO = new System.Windows.Forms.Button();
            this.REPLAY = new System.Windows.Forms.Button();
            this.NEXT_STEP = new System.Windows.Forms.Button();
            this.label_delayValue = new System.Windows.Forms.Label();
            this.label_delay = new System.Windows.Forms.Label();
            this.DELAY = new System.Windows.Forms.TrackBar();
            this.PLAY = new System.Windows.Forms.Button();
            this.MANUALLY = new System.Windows.Forms.Button();
            this.RAND = new System.Windows.Forms.Button();
            this.NumOfCells = new System.Windows.Forms.Label();
            this.Growth = new System.Windows.Forms.Label();
            this.TurnTime = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FOUNDERS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STEPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DELAY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(618, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(600, 600);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // trackBar_SIZE
            // 
            this.trackBar_SIZE.AutoSize = false;
            this.trackBar_SIZE.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_SIZE.Location = new System.Drawing.Point(1224, 44);
            this.trackBar_SIZE.Maximum = 300;
            this.trackBar_SIZE.Minimum = 10;
            this.trackBar_SIZE.Name = "trackBar_SIZE";
            this.trackBar_SIZE.Size = new System.Drawing.Size(239, 37);
            this.trackBar_SIZE.SmallChange = 5;
            this.trackBar_SIZE.TabIndex = 2;
            this.trackBar_SIZE.TickFrequency = 50;
            this.trackBar_SIZE.Value = 10;
            this.trackBar_SIZE.Scroll += new System.EventHandler(this.SIZE_Scroll);
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_size.Location = new System.Drawing.Point(1224, 12);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(73, 26);
            this.label_size.TabIndex = 3;
            this.label_size.Text = "SIZE :";
            this.label_size.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_sizeValue
            // 
            this.label_sizeValue.AutoSize = true;
            this.label_sizeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sizeValue.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_sizeValue.Location = new System.Drawing.Point(1374, 12);
            this.label_sizeValue.Name = "label_sizeValue";
            this.label_sizeValue.Size = new System.Drawing.Size(43, 29);
            this.label_sizeValue.TabIndex = 4;
            this.label_sizeValue.Text = "10";
            this.label_sizeValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_foundersValue
            // 
            this.label_foundersValue.AutoSize = true;
            this.label_foundersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_foundersValue.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_foundersValue.Location = new System.Drawing.Point(1374, 84);
            this.label_foundersValue.Name = "label_foundersValue";
            this.label_foundersValue.Size = new System.Drawing.Size(28, 29);
            this.label_foundersValue.TabIndex = 7;
            this.label_foundersValue.Text = "5";
            this.label_foundersValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_foundersValue.Visible = false;
            // 
            // label_founders
            // 
            this.label_founders.AutoSize = true;
            this.label_founders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_founders.Location = new System.Drawing.Point(1229, 84);
            this.label_founders.Name = "label_founders";
            this.label_founders.Size = new System.Drawing.Size(148, 26);
            this.label_founders.TabIndex = 6;
            this.label_founders.Text = "FOUNDERS :";
            this.label_founders.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBar_FOUNDERS
            // 
            this.trackBar_FOUNDERS.AutoSize = false;
            this.trackBar_FOUNDERS.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_FOUNDERS.LargeChange = 1;
            this.trackBar_FOUNDERS.Location = new System.Drawing.Point(1224, 116);
            this.trackBar_FOUNDERS.Maximum = 100;
            this.trackBar_FOUNDERS.Minimum = 5;
            this.trackBar_FOUNDERS.Name = "trackBar_FOUNDERS";
            this.trackBar_FOUNDERS.Size = new System.Drawing.Size(239, 29);
            this.trackBar_FOUNDERS.TabIndex = 5;
            this.trackBar_FOUNDERS.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_FOUNDERS.Value = 5;
            this.trackBar_FOUNDERS.Visible = false;
            this.trackBar_FOUNDERS.Scroll += new System.EventHandler(this.FOUNDERS_Scroll);
            // 
            // label_stepsValue
            // 
            this.label_stepsValue.AutoSize = true;
            this.label_stepsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_stepsValue.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_stepsValue.Location = new System.Drawing.Point(1369, 294);
            this.label_stepsValue.Name = "label_stepsValue";
            this.label_stepsValue.Size = new System.Drawing.Size(58, 29);
            this.label_stepsValue.TabIndex = 10;
            this.label_stepsValue.Text = "100";
            this.label_stepsValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_stepsValue.Visible = false;
            // 
            // label_steps
            // 
            this.label_steps.AutoSize = true;
            this.label_steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_steps.Location = new System.Drawing.Point(1224, 294);
            this.label_steps.Name = "label_steps";
            this.label_steps.Size = new System.Drawing.Size(96, 26);
            this.label_steps.TabIndex = 9;
            this.label_steps.Text = "STEPS :";
            this.label_steps.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_steps.Visible = false;
            // 
            // STEPS
            // 
            this.STEPS.AutoSize = false;
            this.STEPS.BackColor = System.Drawing.SystemColors.Control;
            this.STEPS.Location = new System.Drawing.Point(1219, 326);
            this.STEPS.Maximum = 1000;
            this.STEPS.Minimum = 1;
            this.STEPS.Name = "STEPS";
            this.STEPS.Size = new System.Drawing.Size(239, 28);
            this.STEPS.SmallChange = 2;
            this.STEPS.TabIndex = 8;
            this.STEPS.TickStyle = System.Windows.Forms.TickStyle.None;
            this.STEPS.Value = 100;
            this.STEPS.Visible = false;
            this.STEPS.Scroll += new System.EventHandler(this.STEPS_Scroll);
            // 
            // GO
            // 
            this.GO.BackColor = System.Drawing.Color.White;
            this.GO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GO.ForeColor = System.Drawing.Color.Red;
            this.GO.Location = new System.Drawing.Point(1229, 154);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(226, 42);
            this.GO.TabIndex = 11;
            this.GO.Text = "GO!";
            this.GO.UseVisualStyleBackColor = false;
            this.GO.Visible = false;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // REPLAY
            // 
            this.REPLAY.BackColor = System.Drawing.Color.White;
            this.REPLAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.REPLAY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.REPLAY.Location = new System.Drawing.Point(1229, 572);
            this.REPLAY.Name = "REPLAY";
            this.REPLAY.Size = new System.Drawing.Size(226, 40);
            this.REPLAY.TabIndex = 12;
            this.REPLAY.Text = "REPLAY";
            this.REPLAY.UseVisualStyleBackColor = false;
            this.REPLAY.Visible = false;
            this.REPLAY.Click += new System.EventHandler(this.REPLAY_Click);
            // 
            // NEXT_STEP
            // 
            this.NEXT_STEP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NEXT_STEP.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NEXT_STEP.ForeColor = System.Drawing.Color.DarkGreen;
            this.NEXT_STEP.Location = new System.Drawing.Point(1229, 201);
            this.NEXT_STEP.Name = "NEXT_STEP";
            this.NEXT_STEP.Size = new System.Drawing.Size(226, 86);
            this.NEXT_STEP.TabIndex = 13;
            this.NEXT_STEP.Text = "NEXT STEP \r\n>>>";
            this.NEXT_STEP.UseVisualStyleBackColor = true;
            this.NEXT_STEP.Visible = false;
            this.NEXT_STEP.Click += new System.EventHandler(this.NEXT_STEP_Click);
            this.NEXT_STEP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NEXT_STEP_KeyDown);
            // 
            // label_delayValue
            // 
            this.label_delayValue.AutoSize = true;
            this.label_delayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_delayValue.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_delayValue.Location = new System.Drawing.Point(1369, 357);
            this.label_delayValue.Name = "label_delayValue";
            this.label_delayValue.Size = new System.Drawing.Size(58, 29);
            this.label_delayValue.TabIndex = 16;
            this.label_delayValue.Text = "100";
            this.label_delayValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_delayValue.Visible = false;
            // 
            // label_delay
            // 
            this.label_delay.AutoSize = true;
            this.label_delay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_delay.Location = new System.Drawing.Point(1224, 357);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(98, 26);
            this.label_delay.TabIndex = 15;
            this.label_delay.Text = "DELAY :";
            this.label_delay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_delay.Visible = false;
            // 
            // DELAY
            // 
            this.DELAY.AutoSize = false;
            this.DELAY.BackColor = System.Drawing.SystemColors.Control;
            this.DELAY.Location = new System.Drawing.Point(1219, 389);
            this.DELAY.Maximum = 5000;
            this.DELAY.Minimum = 1;
            this.DELAY.Name = "DELAY";
            this.DELAY.Size = new System.Drawing.Size(239, 30);
            this.DELAY.SmallChange = 2;
            this.DELAY.TabIndex = 14;
            this.DELAY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DELAY.Value = 100;
            this.DELAY.Visible = false;
            this.DELAY.Scroll += new System.EventHandler(this.DELAY_Scroll);
            // 
            // PLAY
            // 
            this.PLAY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PLAY.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PLAY.ForeColor = System.Drawing.Color.DarkGreen;
            this.PLAY.Location = new System.Drawing.Point(1229, 154);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(226, 44);
            this.PLAY.TabIndex = 17;
            this.PLAY.Text = "PLAY";
            this.PLAY.UseVisualStyleBackColor = true;
            this.PLAY.Visible = false;
            this.PLAY.Click += new System.EventHandler(this.PLAY_Click);
            // 
            // MANUALLY
            // 
            this.MANUALLY.Location = new System.Drawing.Point(1345, 113);
            this.MANUALLY.Name = "MANUALLY";
            this.MANUALLY.Size = new System.Drawing.Size(110, 32);
            this.MANUALLY.TabIndex = 19;
            this.MANUALLY.Text = "MANUALLY";
            this.MANUALLY.UseVisualStyleBackColor = true;
            this.MANUALLY.Click += new System.EventHandler(this.MANUALLY_Click);
            // 
            // RAND
            // 
            this.RAND.Location = new System.Drawing.Point(1232, 113);
            this.RAND.Name = "RAND";
            this.RAND.Size = new System.Drawing.Size(110, 32);
            this.RAND.TabIndex = 20;
            this.RAND.Text = "RANDOM";
            this.RAND.UseVisualStyleBackColor = true;
            this.RAND.Click += new System.EventHandler(this.RAND_Click);
            // 
            // NumOfCells
            // 
            this.NumOfCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumOfCells.ForeColor = System.Drawing.Color.Green;
            this.NumOfCells.Location = new System.Drawing.Point(13, 619);
            this.NumOfCells.Name = "NumOfCells";
            this.NumOfCells.Size = new System.Drawing.Size(596, 23);
            this.NumOfCells.TabIndex = 21;
            this.NumOfCells.Text = "NumOfCells";
            // 
            // Growth
            // 
            this.Growth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Growth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Growth.Location = new System.Drawing.Point(13, 653);
            this.Growth.Name = "Growth";
            this.Growth.Size = new System.Drawing.Size(596, 17);
            this.Growth.TabIndex = 22;
            this.Growth.Text = "Growth";
            // 
            // TurnTime
            // 
            this.TurnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TurnTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TurnTime.Location = new System.Drawing.Point(615, 619);
            this.TurnTime.Name = "TurnTime";
            this.TurnTime.Size = new System.Drawing.Size(603, 17);
            this.TurnTime.TabIndex = 23;
            this.TurnTime.Text = "TurnTime";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1229, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "LAYOUT";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1472, 679);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TurnTime);
            this.Controls.Add(this.Growth);
            this.Controls.Add(this.NumOfCells);
            this.Controls.Add(this.RAND);
            this.Controls.Add(this.MANUALLY);
            this.Controls.Add(this.PLAY);
            this.Controls.Add(this.label_delayValue);
            this.Controls.Add(this.label_delay);
            this.Controls.Add(this.DELAY);
            this.Controls.Add(this.NEXT_STEP);
            this.Controls.Add(this.REPLAY);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.label_stepsValue);
            this.Controls.Add(this.label_steps);
            this.Controls.Add(this.STEPS);
            this.Controls.Add(this.label_foundersValue);
            this.Controls.Add(this.label_founders);
            this.Controls.Add(this.trackBar_FOUNDERS);
            this.Controls.Add(this.label_sizeValue);
            this.Controls.Add(this.label_size);
            this.Controls.Add(this.trackBar_SIZE);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "                                                                                 " +
    "                                    I      N      C      U      B      A      T " +
    "     O      R";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_SIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FOUNDERS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STEPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DELAY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.Label label_sizeValue;
        private System.Windows.Forms.Label label_foundersValue;
        private System.Windows.Forms.Label label_founders;
        private System.Windows.Forms.TrackBar trackBar_FOUNDERS;
        private System.Windows.Forms.Label label_stepsValue;
        private System.Windows.Forms.Label label_steps;
        private System.Windows.Forms.TrackBar STEPS;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.Button REPLAY;
        private System.Windows.Forms.Button NEXT_STEP;
        private System.Windows.Forms.Label label_delayValue;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.TrackBar DELAY;
        private System.Windows.Forms.Button PLAY;
        private System.Windows.Forms.Button MANUALLY;
        private System.Windows.Forms.Button RAND;
        private System.Windows.Forms.TrackBar trackBar_SIZE;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label NumOfCells;
        public System.Windows.Forms.Label Growth;
        public System.Windows.Forms.Label TurnTime;
        private System.Windows.Forms.CheckBox checkBox1;
        }
    }

