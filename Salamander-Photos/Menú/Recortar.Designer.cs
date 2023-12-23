namespace WindowsFormsApplication1
{
    partial class Recortar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recortar));
            this.pictureBox_original = new System.Windows.Forms.PictureBox();
            this.pictureBox_recortada = new System.Windows.Forms.PictureBox();
            this.apli = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.mensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_recortada)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_original
            // 
            this.pictureBox_original.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_original.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_original.Location = new System.Drawing.Point(11, 11);
            this.pictureBox_original.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_original.Name = "pictureBox_original";
            this.pictureBox_original.Size = new System.Drawing.Size(491, 491);
            this.pictureBox_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_original.TabIndex = 0;
            this.pictureBox_original.TabStop = false;
            this.pictureBox_original.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_original_Paint);
            this.pictureBox_original.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox_original.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox_original.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox_recortada
            // 
            this.pictureBox_recortada.Location = new System.Drawing.Point(506, 11);
            this.pictureBox_recortada.Name = "pictureBox_recortada";
            this.pictureBox_recortada.Size = new System.Drawing.Size(491, 491);
            this.pictureBox_recortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_recortada.TabIndex = 1;
            this.pictureBox_recortada.TabStop = false;
            // 
            // apli
            // 
            this.apli.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.apli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apli.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.apli.Image = ((System.Drawing.Image)(resources.GetObject("apli.Image")));
            this.apli.Location = new System.Drawing.Point(2, -1);
            this.apli.Name = "apli";
            this.apli.Size = new System.Drawing.Size(41, 41);
            this.apli.TabIndex = 2;
            this.apli.UseVisualStyleBackColor = false;
            this.apli.Click += new System.EventHandler(this.apli_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.apli);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(-1, 517);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 41);
            this.panel1.TabIndex = 3;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.Location = new System.Drawing.Point(49, -1);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(41, 41);
            this.cancel.TabIndex = 3;
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // mensaje
            // 
            this.mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mensaje.AutoSize = true;
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mensaje.Location = new System.Drawing.Point(580, 223);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(347, 84);
            this.mensaje.TabIndex = 4;
            this.mensaje.Text = "  Aquí se mostrará \r\nla imagen recortada";
            // 
            // Recortar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1008, 558);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox_recortada);
            this.Controls.Add(this.pictureBox_original);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recortar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Recortar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_recortada)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_original;
        private System.Windows.Forms.PictureBox pictureBox_recortada;
        private System.Windows.Forms.Button apli;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label mensaje;
    }
}