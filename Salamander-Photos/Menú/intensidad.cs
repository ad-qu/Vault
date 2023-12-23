using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class intensidad : Form
    {
        int rojo, verde, azul; bool aplicarcambios = false;

        public intensidad()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void SetRojo(int text)
        {
            this.rojo = text;
        }
        public int GetRojo()
        {
            return this.rojo;
        }
        public void SetVerde(int text)
        {
            this.verde = text;
        }
        public int GetVerde()
        {
            return this.verde;
        }
        public void SetAzul(int text)
        {
            this.azul = text;
        }
        public int GetAzul()
        {
            return this.azul;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelRGB.BackColor = Color.FromArgb(r.Value, g.Value, b.Value);
            lblred.Text = r.Value.ToString();
            lblgreen.Text = g.Value.ToString();
            lblblue.Text = b.Value.ToString();
            lblRGB.Text = ("RGB (" + r.Value.ToString() + ", " + g.Value.ToString() + ", " + b.Value.ToString() + ")");
        }

        private void accept_Click(object sender, EventArgs e)
        {
            SetRojo(Convert.ToInt32(lblred.Text));
            SetVerde(Convert.ToInt32(lblgreen.Text));
            SetAzul(Convert.ToInt32(lblblue.Text));
            aplicarcambios = true; //
            Close();
        }

        public bool lehadadoaaplicar()
        {
            return aplicarcambios;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
