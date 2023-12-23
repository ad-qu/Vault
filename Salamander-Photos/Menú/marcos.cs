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
    public partial class marcos : Form
    {
        Color c;
        float g;
        bool aplicarcambios = false;

        public marcos()
        {
            InitializeComponent();
        }

        private void SetColor(Color color)
        {
            c = color;
        }

        public Color GetColor()
        {
            return c;
        }
        public float GetGrosor()
        {
            return g;
        }

        private void aplicar_Click(object sender, EventArgs e)
        {
            g = GrosorMarco.Value * 10;
            aplicarcambios = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            aplicarcambios = false;
        }

        private void Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SetColor(colorDialog1.Color);
            }
        }

        public bool lehadadoaaplicar()
        {
            return aplicarcambios;
        }
    }
}
