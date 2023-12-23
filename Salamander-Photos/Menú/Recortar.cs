using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Imagen;

namespace WindowsFormsApplication1
{
    public partial class Recortar : Form
    {
        Rectangle rectang;
        Point loc1;
        Point loc2;
        bool mouseDown = false; int alto, ancho;

        Bitmap OriginalImage;
        Bitmap CroppedImage;
        Bitmap DisplayImage;
        Graphics DisplayGraphics;
        bool aplicar;

        public Recortar()
        {
            InitializeComponent();
        }

        public void SetCambios(bool x)
        { this.aplicar = x; }

        public bool GetCambios()
        { return this.aplicar; }

        public void SetImage(PictureBox picture)
        {
            OriginalImage = (Bitmap)picture.Image.Clone();
            DisplayImage = OriginalImage.Clone() as Bitmap;
            CroppedImage = DisplayImage.Clone() as Bitmap;
            DisplayGraphics = Graphics.FromImage(DisplayImage);
        }

        public Bitmap GetImage()
        { return this.DisplayImage; }

        private void Recortar_Load(object sender, EventArgs e)
        {
            pictureBox_original.Image = DisplayImage.Clone() as Image;

            pictureBox_original.Image = DisplayImage.Clone() as Image;

            if (ancho > alto)
            {
                pictureBox_original.Height = ((pictureBox_original.Height * alto) / ancho);
                pictureBox_original.Location = new Point(11, 491 / 2 - pictureBox_original.Height / 2);

            }
            if (ancho < alto)
            {
                pictureBox_original.Width = ((pictureBox_original.Width * ancho) / alto);
                pictureBox_original.Location = new Point(491 / 2 - pictureBox_original.Width / 2, 11);
            }
        }

        public void Medidas(ImagenProperties Element)
        {
            alto = Element.GetAlto();
            ancho = Element.GetAncho();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            loc1 = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                loc2 = e.Location;
                Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                loc2 = e.Location;
                mouseDown = false;

                if (rectang != null)
                {
                    mensaje.Hide();
                    Bitmap pbo = new Bitmap(pictureBox_original.Image, pictureBox_original.Width, pictureBox_original.Height);
                    Bitmap recortar = new Bitmap(rectang.Width, rectang.Height);
                    Graphics g = Graphics.FromImage(recortar);
                    g.DrawImage(pbo, 0, 0, rectang, GraphicsUnit.Pixel);
                    pictureBox_recortada.Image = recortar;
                }

                DisplayImage = pictureBox_recortada.Image as Bitmap;
            }
        }

        private void apli_Click(object sender, EventArgs e)
        {
            this.SetCambios(true);
            Close();
        }

        private void pictureBox_original_Paint(object sender, PaintEventArgs e)
        {
            if (rectang != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private Rectangle GetRect()
        {
            rectang = new Rectangle();
            rectang.X = Math.Min(loc1.X, loc2.X);
            rectang.Y = Math.Min(loc1.Y, loc2.Y);
            rectang.Width = Math.Abs(loc1.X - loc2.X);
            rectang.Height = Math.Abs(loc1.Y - loc2.Y);

            return rectang;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
