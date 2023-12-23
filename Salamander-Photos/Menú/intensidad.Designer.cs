namespace WindowsFormsApplication1
{
    partial class intensidad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(intensidad));
            this.accept = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.TrackBar();
            this.g = new System.Windows.Forms.TrackBar();
            this.b = new System.Windows.Forms.TrackBar();
            this.panelRGB = new System.Windows.Forms.Panel();
            this.lblred = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblgreen = new System.Windows.Forms.Label();
            this.lblblue = new System.Windows.Forms.Label();
            this.lblRGB = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.accept.Image = ((System.Drawing.Image)(resources.GetObject("accept.Image")));
            this.accept.Location = new System.Drawing.Point(-4, 0);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(41, 41);
            this.accept.TabIndex = 7;
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(66, 21);
            this.r.Maximum = 255;
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(214, 45);
            this.r.TabIndex = 8;
            this.r.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // g
            // 
            this.g.Location = new System.Drawing.Point(66, 75);
            this.g.Maximum = 255;
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(214, 45);
            this.g.TabIndex = 9;
            this.g.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(66, 130);
            this.b.Maximum = 255;
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(214, 45);
            this.b.TabIndex = 10;
            this.b.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panelRGB
            // 
            this.panelRGB.Location = new System.Drawing.Point(11, 5);
            this.panelRGB.Name = "panelRGB";
            this.panelRGB.Size = new System.Drawing.Size(60, 30);
            this.panelRGB.TabIndex = 11;
            // 
            // lblred
            // 
            this.lblred.AutoSize = true;
            this.lblred.Location = new System.Drawing.Point(300, 35);
            this.lblred.Name = "lblred";
            this.lblred.Size = new System.Drawing.Size(35, 13);
            this.lblred.TabIndex = 0;
            this.lblred.Text = "label4";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblgreen
            // 
            this.lblgreen.AutoSize = true;
            this.lblgreen.Location = new System.Drawing.Point(299, 90);
            this.lblgreen.Name = "lblgreen";
            this.lblgreen.Size = new System.Drawing.Size(35, 13);
            this.lblgreen.TabIndex = 12;
            this.lblgreen.Text = "label5";
            // 
            // lblblue
            // 
            this.lblblue.AutoSize = true;
            this.lblblue.Location = new System.Drawing.Point(299, 145);
            this.lblblue.Name = "lblblue";
            this.lblblue.Size = new System.Drawing.Size(35, 13);
            this.lblblue.TabIndex = 13;
            this.lblblue.Text = "label6";
            // 
            // lblRGB
            // 
            this.lblRGB.AutoSize = true;
            this.lblRGB.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblRGB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRGB.Location = new System.Drawing.Point(78, 13);
            this.lblRGB.Name = "lblRGB";
            this.lblRGB.Size = new System.Drawing.Size(35, 13);
            this.lblRGB.TabIndex = 14;
            this.lblRGB.Text = "label6";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(24, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(24, 135);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.panelRGB);
            this.panel1.Controls.Add(this.lblRGB);
            this.panel1.Location = new System.Drawing.Point(-6, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 51);
            this.panel1.TabIndex = 12;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(43, -1);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(41, 41);
            this.cancel.TabIndex = 17;
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cancel);
            this.panel2.Controls.Add(this.accept);
            this.panel2.Location = new System.Drawing.Point(273, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 41);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(73, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 10);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(73, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 10);
            this.panel4.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(73, 105);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 10);
            this.panel5.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(74, 76);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 10);
            this.panel6.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(73, 131);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 10);
            this.panel7.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(73, 161);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 10);
            this.panel8.TabIndex = 18;
            // 
            // intensidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(357, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblblue);
            this.Controls.Add(this.lblgreen);
            this.Controls.Add(this.lblred);
            this.Controls.Add(this.b);
            this.Controls.Add(this.g);
            this.Controls.Add(this.r);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "intensidad";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.TrackBar r;
        private System.Windows.Forms.TrackBar g;
        private System.Windows.Forms.TrackBar b;
        private System.Windows.Forms.Panel panelRGB;
        private System.Windows.Forms.Label lblred;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblgreen;
        private System.Windows.Forms.Label lblblue;
        private System.Windows.Forms.Label lblRGB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
    }
}