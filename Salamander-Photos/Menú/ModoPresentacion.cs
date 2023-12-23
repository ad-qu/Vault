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
    public partial class ModoPresentacion : Form
    {
        public ModoPresentacion()
        {
            InitializeComponent();
        }

        private void ModoPresentacion_Load(object sender, EventArgs e)//Asigna el intervalo a 1s por defecto
        {
            timer1.Interval = 1000;
        }

        private void IniciarBtn_Click(object sender, EventArgs e)//Inicia el timer
        {
            timer1.Enabled = true;
        }

        List<Bitmap> Fotos = new List<Bitmap>();
        string[] extensiones = new string[] { ".bmp", ".jpg", ".gif", ".png",".jfif",".ppm"};
        ImagenProperties pp = new ImagenProperties();

        private void CargarBtn_Click(object sender, EventArgs e)//Carga las imagenes de la carpeta deseada, crea un bitmap y lo mete en la cola
        {
            var carpeta = new System.Windows.Forms.FolderBrowserDialog();
            if (carpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var foto in Directory.GetFiles(carpeta.SelectedPath).Where(f => extensiones.Contains(Path.GetExtension(f))))
                {

                    if (Path.GetExtension(foto) == ".ppm")
                    {
                        pp.CargarImagenPPM(foto);
                        Bitmap bmppm = pp.CreateBitmapPPM();
                        Fotos.Add(bmppm);
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(foto);
                        Fotos.Add(bmp);
                    }
                    }
                }
            }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)//A cada tick del timer se muestra una foto
        {
            try
            {
                pictureBox1.Image = (Image)Fotos[i];
                pictureBox1.Refresh();
                i++;
                if (i==Fotos.Count)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Fin de la presentación.");
                    i = 0;
                }
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("Primero tienes que cargar las imágenes al programa.");
            }
           
        }

        private void AceptarBtn_Click(object sender, EventArgs e)//Establece el intervalo (mínimo 1s)
        {
            try
            {
                if (Convert.ToDouble(IntervaloIn.Text) < 1)
                    timer1.Interval = 1000;
                if (Convert.ToDouble(IntervaloIn.Text) > 1000)
                    timer1.Interval = 1000000;
                else timer1.Interval = Convert.ToInt32(IntervaloIn.Text) * 1000;
                int x = timer1.Interval / 1000;
                MessageBox.Show("Intervalo establecido a" + " " + x + " " + "segundos.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduce un número.");
            }
        }
        private void ReiniciarBtn_Click(object sender, EventArgs e)
        {
            i = 0;
            timer1.Stop();
            timer1.Start();

        }

        private void DetenerBtn_Click(object sender, EventArgs e)//Detiene la presentación
        {
            timer1.Stop();
        }

        private void yesfullscreen_Click(object sender, EventArgs e)
        {
            try
            {
                yesfullscreen.Hide();
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void nofullscreen_Click(object sender, EventArgs e)
        {
            try
            {
                yesfullscreen.Show();
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
            catch { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void showicons_Click(object sender, EventArgs e)
        {
            hideicons.Show();
            panel1.Show();
            panel3.Hide();
        }

        private void hideicons_Click(object sender, EventArgs e)
        {
            hideicons.Hide();
            panel1.Hide();
            panel3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IniciarBtn_MouseHover(object sender, EventArgs e)
        {
            iniciarinfo.Show();
        }

        private void IniciarBtn_MouseLeave(object sender, EventArgs e)
        {
            iniciarinfo.Hide();
        }

        private void DetenerBtn_MouseHover(object sender, EventArgs e)
        {
            pararinfo.Show();
        }

        private void DetenerBtn_MouseLeave(object sender, EventArgs e)
        {
            pararinfo.Hide();
        }

        private void CargarBtn_MouseHover(object sender, EventArgs e)
        {
            cargarinfo.Show();              
        }

        private void CargarBtn_MouseLeave(object sender, EventArgs e)
        {
            cargarinfo.Hide();
        }

        private void AceptarBtn_MouseHover(object sender, EventArgs e)
        {
            aceptarinfo.Show();
        }

        private void AceptarBtn_MouseLeave(object sender, EventArgs e)
        {
            aceptarinfo.Hide(); 
        }

        private void showicons_MouseHover(object sender, EventArgs e)
        {
            vericonosinfo.Show();
        }

        private void showicons_MouseLeave(object sender, EventArgs e)
        {
            vericonosinfo.Hide();
        }

        private void hideicons_MouseHover(object sender, EventArgs e)
        {
            ocultariconosinfo.Show();
        }

        private void hideicons_MouseLeave(object sender, EventArgs e)
        {
            ocultariconosinfo.Hide();
        }

        private void yesfullscreen_MouseHover(object sender, EventArgs e)
        {
            yesfullscreeninfo.Show();
        }

        private void yesfullscreen_MouseLeave(object sender, EventArgs e)
        {
            yesfullscreeninfo.Hide();
        }

        private void nofullscreen_MouseHover(object sender, EventArgs e)
        {
            nofullscreeninfo.Show();
        }

        private void nofullscreen_MouseLeave(object sender, EventArgs e)
        {
            nofullscreeninfo.Hide();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            salirinfo.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            salirinfo.Hide();
        }

        private void IntervaloIn_Click(object sender, EventArgs e)
        {
            IntervaloIn.Text = " ";
        }

        private void ReiniciarBtn_MouseHover(object sender, EventArgs e)
        {
            reiniciarinfo.Show();
        }

        private void ReiniciarBtn_MouseLeave(object sender, EventArgs e)
        {
            reiniciarinfo.Hide();
        }

       
    }
}
