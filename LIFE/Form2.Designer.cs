namespace LIFE
    {
    partial class Form2
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CANCEL = new System.Windows.Forms.Button();
            this.APPLY = new System.Windows.Forms.Button();
            this.CLEAN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 900);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CANCEL
            // 
            this.CANCEL.FlatAppearance.BorderSize = 2;
            this.CANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CANCEL.ForeColor = System.Drawing.Color.Maroon;
            this.CANCEL.Location = new System.Drawing.Point(588, 906);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(312, 60);
            this.CANCEL.TabIndex = 1;
            this.CANCEL.Text = "CANCEL";
            this.CANCEL.UseVisualStyleBackColor = true;
            this.CANCEL.Click += new System.EventHandler(this.CANCEL_Click);
            // 
            // APPLY
            // 
            this.APPLY.FlatAppearance.BorderSize = 4;
            this.APPLY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.APPLY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.APPLY.ForeColor = System.Drawing.Color.Green;
            this.APPLY.Location = new System.Drawing.Point(318, 906);
            this.APPLY.Name = "APPLY";
            this.APPLY.Size = new System.Drawing.Size(264, 60);
            this.APPLY.TabIndex = 2;
            this.APPLY.Text = "APPLY";
            this.APPLY.UseVisualStyleBackColor = true;
            this.APPLY.Click += new System.EventHandler(this.APPLY_Click);
            // 
            // CLEAN
            // 
            this.CLEAN.FlatAppearance.BorderSize = 2;
            this.CLEAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLEAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CLEAN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.CLEAN.Location = new System.Drawing.Point(0, 906);
            this.CLEAN.Name = "CLEAN";
            this.CLEAN.Size = new System.Drawing.Size(312, 60);
            this.CLEAN.TabIndex = 3;
            this.CLEAN.Text = "CLEAN";
            this.CLEAN.UseVisualStyleBackColor = true;
            this.CLEAN.Click += new System.EventHandler(this.CLEAN_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(901, 972);
            this.Controls.Add(this.CLEAN);
            this.Controls.Add(this.APPLY);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CANCEL;
        private System.Windows.Forms.Button APPLY;
        private System.Windows.Forms.Button CLEAN;
        }
    }