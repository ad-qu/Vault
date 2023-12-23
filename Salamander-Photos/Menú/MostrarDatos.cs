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
    public partial class MostrarDatos : Form
    {
        public MostrarDatos()
        {
            InitializeComponent();
        }
        public void SetAncho2(string x)
        {
            Ancho2.Text = x + "     ";
        }
        public void SetAlto2(string y)
        {
            Alto2.Text = y + "     ";
        }
        public void SetRuta2(string w)
        {
            Ruta2.Text = w + "     ";
        }
        public void SetNombre2(string z)
        {
            Nombre2.Text = z + "     ";
        }
    }
}
