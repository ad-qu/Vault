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
    public partial class info : Form
    {

        public info()
        {
            InitializeComponent();
        }

        private void abrirdocumento_Click(object sender, EventArgs e)
        {
            mensaje.Hide();
            pictureBox1.ImageLocation = "abrirdochelp.png";
        }

        private void aumentar_Click(object sender, EventArgs e)
        {
            mensaje.Hide();
            pictureBox1.ImageLocation = "aumentarhelp.png";
        }

        private void presentacion_Click(object sender, EventArgs e)
        {
            mensaje.Hide();
            pictureBox1.ImageLocation = "modohelp.png";
        }

        private void listadefotos_Click(object sender, EventArgs e)
        {
            mensaje.Hide();
            pictureBox1.ImageLocation = "listahelp.png";
        }
    }
}
