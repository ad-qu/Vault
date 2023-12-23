using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Imagen;

namespace WindowsFormsApplication1
{
    public partial class CellInformation : Form
    {
        string ruta, ultimavez;
        ImagenProperties Element = new ImagenProperties();

        public CellInformation()
        {
            InitializeComponent();
        }

        public void SetRuta(string ubicacion)
        {
            this.ruta = ubicacion;
            label1.Text = this.ruta + "      ";
        }

        public void SetUltimaVez(int fecha)
        {
            this.ultimavez = "Última vez abierto: " + Convert.ToString(fecha).Remove(0,6) + " / " + Convert.ToString(fecha).Remove(0,4).Remove(2) + " / " + Convert.ToString(fecha).Remove(4) + "      ";
            label2.Text = this.ultimavez;
        }

        private void CellInformation_Load(object sender, EventArgs e)
        {
            if((Path.GetExtension(this.ruta) == ".png")||(Path.GetExtension(this.ruta) == ".jpg")||(Path.GetExtension(this.ruta) == ".PNG"))
            {
                Bitmap bmp = new Bitmap(this.ruta);
                pictureBox1.Image = (Image)bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (Path.GetExtension(this.ruta) == ".ppm")
            {
                Bitmap bmp;
                Element.CargarImagenPPM(ruta);
                bmp = Element.CreateBitmapPPM();
                pictureBox1.Image = (Image)bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                Element.SetLoadTrue();
            }
        }

    }
}
