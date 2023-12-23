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
    public partial class salir : Form
    {
        bool state;
        public salir()
        {
            InitializeComponent();
        }
        public void SetOk(bool x)
        {
            this.state = x;
        }
        public bool Ok()
        {
            return state;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            SetOk(true);
            Close();
        }

        private void segsalir_Click(object sender, EventArgs e)
        {
            SetOk(false);
            Close();
        }
    }
}
