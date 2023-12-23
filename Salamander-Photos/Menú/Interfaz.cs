using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Imagen;


namespace WindowsFormsApplication1
{
    public partial class Interfaz : Form
    {
        //Propiedades y objetos del form de la interfaz.

        ImagenProperties Element = new ImagenProperties();
        bool auxiliar = false;
        int x = 44, y = 3, mx, my, pan = 0;

        //Funciones de la interfaz.

        public Interfaz()
        {
            InitializeComponent();
            paneldecarga.BackgroundImage = new Bitmap("imagendecarga.png");
        }

        private void dashbutton_Click(object sender, EventArgs e)
        {
            if (panel.Width == 41)
            {
                panel.Width = 131;
            }

            else
            {
                panel.Width = 41;
            }
        }

        private void Interfaz_Load(object sender, EventArgs e)
        {
            pictureBox.AllowDrop = true;
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Element.Reset();
                var data = e.Data.GetData(DataFormats.FileDrop);
                var fileNames = data as string[];
                Element.SetUbicacion(fileNames[0]);
                Bitmap bmp;
                if ((Element.GetExtension() == ".png") || (Element.GetExtension() == ".jpg"))
                {
                    bmp = new Bitmap(fileNames[0]);
                    pictureBox.Image = Image.FromFile(fileNames[0]);
                    Element.SetLoadTrue();
                    Element.SetAlto(bmp.Height);
                    Element.SetAncho(bmp.Width);
                    bmp.Dispose();
                }
                else if (Element.GetExtension() == ".ppm")
                {
                    Element.CargarImagenPPM(fileNames[0]);
                    pictureBox.Image = (Image)Element.CreateBitmapPPM();
                }
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        } // Puedes abrir una imagen arrastrando el fichero.

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Interfaz_FormClosing(object sender, FormClosingEventArgs e)
        {
            salir f = new salir();
            if ((DetectarCambios())&&(!Element.GetSaved()))
            {
                f.ShowDialog();
                if (f.Ok())
                {
                    
                }
                else
                {
                    Element.SalvarComo(pictureBox);
                }
            }
        } // Al cerrarse, se enciende este evento, que detecta los cambios y decide si va a dejarte salir o no.

        public bool DetectarCambios()
        {
            try
            {
                Bitmap bmp = (Bitmap)pictureBox.Image.Clone();
                bool cambio = false;
                paneldecarga.Show();
                if (((Element.GetLoad()) && (Element.CompareBitmaps(bmp))))
                {
                    cambio = true;
                }
                paneldecarga.Hide();
                return cambio;
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
                return false;
            }
        } // Detecta cambios en el propio Bitmap, en un registro de versiones anteriores.

        private void pictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Element.GetLoad())
                {
                    Element.FiltroDeCarga(pictureBox);
                    paneldecarga.Show();
                    Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                    paneldecarga.Hide();
                }
            }
            catch { }
        }

        private void abrirdocumento_Click(object sender, EventArgs e)
        {
            try
            {
                Element.FiltroDeCarga(pictureBox);
                paneldecarga.Show();
                if (Element.GetLoad())
                {
                    Element.Reset();
                }
                Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                paneldecarga.Hide();
            }
            catch { }
        } // Abre un documento.

        private void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bmp = (Bitmap)pictureBox.Image.Clone();
                    if ((Element.GetExtension() == ".png") || (Element.GetExtension() == ".jpg"))
                    {
                        paneldecarga.Show();
                        Element.Salvar(bmp);
                        Element.SetSaved(true);
                        paneldecarga.Hide();
                    }
                    else if (Element.GetExtension() == ".ppm")
                    {
                        paneldecarga.Show();
                        Element.SobreescribirPPM(bmp, Element.GetUbicacion());
                        paneldecarga.Hide();
                    }
                    Element.ActualizarDatabase();
                }
                else
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        } // Guardado simple.

        private void guardarcomo_Click(object sender, EventArgs e) // Guardar como.
        {
            try
            {
                if (Element.GetLoad())
                {
                    Element.SalvarComo(pictureBox);
                    Element.ActualizarDatabase();
                    Element.SetSaved(false);
                }
                else
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void editar_Click(object sender, EventArgs e) // Abre el modo edición.
        {
            if ((pan == 0) || (pan == 2))
            {
                verdetalles.Hide(); presentacion.Hide(); listadefotos.Hide();
                paneldeherr.Show(); marcos.Show(); recortar.Show(); escala.Show();
                intensidades.Show(); volteohor.Show(); volteover.Show(); giroizq.Show(); giroder.Show(); pantallacompleta.Show(); quitarpantallacompleta.Show();
                pan = 1;
            }
            else
            {
                paneldeherr.Hide(); marcos.Hide(); recortar.Hide(); escala.Hide();
                intensidades.Hide(); volteohor.Hide(); volteover.Hide(); giroizq.Hide(); giroder.Hide(); pantallacompleta.Hide(); quitarpantallacompleta.Hide();
                pan = 0;
            }
        }

        private void ver_Click(object sender, EventArgs e) // Abre el modo ver.
        {
            if ((pan == 0) || (pan == 1))
            {
                marcos.Hide(); recortar.Hide(); escala.Hide();
                intensidades.Hide(); volteohor.Hide(); volteover.Hide(); giroizq.Hide(); giroder.Hide();
                paneldeherr.Show(); verdetalles.Show(); presentacion.Show(); listadefotos.Show(); pantallacompleta.Show(); quitarpantallacompleta.Show();
                pan = 2;
            }
            else
            {
                paneldeherr.Hide(); verdetalles.Hide(); presentacion.Hide(); listadefotos.Hide(); pantallacompleta.Hide(); quitarpantallacompleta.Hide();
                pan = 0;
            }
        }

        private void ayuda_Click(object sender, EventArgs e) // Da información del programa al usuario.
        {
            info inf = new info();
            inf.ShowDialog();
        }

        private void equipo_Click(object sender, EventArgs e) // Muestra los créditos, és decir, quien ha realizado el proyecto.
        {
            creditos cr = new creditos();
            cr.ShowDialog();
        }

        private void ajustes_Click_1(object sender, EventArgs e)
        {
            opciones op = new opciones();
            op.visibleaumre(panel1);
            op.visibledesre(panel2);
            op.ShowDialog();
            auxiliar = op.lehadadoaaplicar();

            if (auxiliar == true)
            {
                if (op.desre() == 1)
                {
                    panel2.Show();
                }
                else
                {
                    panel2.Hide();
                }

                if (op.aumre() == 1)
                {
                    panel1.Show();
                }
                else
                {
                    panel1.Hide();
                }

                auxiliar = false;
            }
        }

        private void deshacer_Click_1(object sender, EventArgs e) // Deshacer el último cambio.
        {
            try
            {
                if (Element.GetLoad())
                {
                    pictureBox.Image = (Bitmap)Element.Deshacer();
                }
                else
                { }
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void rehacer_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    pictureBox.Image = (Bitmap)Element.Rehacer();
                }
                else
                { }
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void aumentar_Click(object sender, EventArgs e)
        {
            if (Element.GetLoad())
            {
                x = pictureBox.Location.X - 25; ; y = pictureBox.Location.Y - 25;
                pictureBox.Width = pictureBox.Width + 50;
                pictureBox.Height = pictureBox.Height + 50;
                pictureBox.Location = new Point(x, y);
            }
        }

        private void alejar_Click(object sender, EventArgs e)
        {
            if ((pictureBox.Height > 100) && (pictureBox.Width > 100))
            {
                if (Element.GetLoad())
                {
                    x = pictureBox.Location.X + 25; ; y = pictureBox.Location.Y + 25;
                    pictureBox.Width = pictureBox.Width - 50;
                    pictureBox.Height = pictureBox.Height - 50;
                    pictureBox.Location = new Point(x, y);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Element.GetLoad())
            {
                if (e.Button == MouseButtons.Left)
                {
                    mx = e.X;
                    my = e.Y;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Element.GetLoad())
            {
                if (e.Button == MouseButtons.Left)
                {
                    pictureBox.Left += (e.X - mx);
                    pictureBox.Top += (e.Y - my);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Element.GetLoad())
            {
                pictureBox.Location = new Point(x, y);
            }
        } 

        private void marcos_Click(object sender, EventArgs e) // Permite añadir un marco, gracias a otro form que recoge el color deseado.
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bmp = (Bitmap)pictureBox.Image.Clone();
                    marcos marco = new marcos();
                    marco.ShowDialog();
                    auxiliar = marco.lehadadoaaplicar();

                    if (auxiliar == true)
                    {
                        paneldecarga.Show();
                        Color color = new Color();
                        float grosor;
                        color = marco.GetColor();
                        string[] vectorRGB = new string[3];
                        vectorRGB[0] = color.R.ToString();
                        vectorRGB[1] = color.G.ToString();
                        vectorRGB[2] = color.B.ToString();
                        grosor = marco.GetGrosor();

                        for (int y = 0; y < Element.GetAlto(); y++)
                        {
                            for (int x = 0; x < Element.GetAncho(); x++)
                            {
                                if (y < grosor)
                                {
                                    bmp.SetPixel(x, y, Color.FromArgb(color.A, Convert.ToInt32(vectorRGB[0]), Convert.ToInt32(vectorRGB[1]), Convert.ToInt32(vectorRGB[2])));
                                }
                                else if (x < grosor)
                                {
                                    bmp.SetPixel(x, y, Color.FromArgb(color.A, Convert.ToInt32(vectorRGB[0]), Convert.ToInt32(vectorRGB[1]), Convert.ToInt32(vectorRGB[2])));
                                }


                                else if (x >= bmp.Width - grosor) { bmp.SetPixel(x, y, Color.FromArgb(color.A, Convert.ToInt32(vectorRGB[0]), Convert.ToInt32(vectorRGB[1]), Convert.ToInt32(vectorRGB[2]))); }


                                else if (y >= bmp.Height - grosor) { bmp.SetPixel(x, y, Color.FromArgb(color.A, Convert.ToInt32(vectorRGB[0]), Convert.ToInt32(vectorRGB[1]), Convert.ToInt32(vectorRGB[2]))); }

                            }
                        }

                        pictureBox.Image = (Image)bmp;
                        paneldecarga.Hide();
                        Element.SetSaved(false);
                        Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                        auxiliar = false;
                    }
                }
                else
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }

        }
        private void recortar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    Recortar form = new Recortar();
                    form.SetImage(pictureBox);
                    form.Medidas(Element);
                    form.ShowDialog();
                    if (form.GetCambios())
                    {
                        pictureBox.Image = (Image)form.GetImage();
                        Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                        Element.SetAlto(form.GetImage().Height);
                        Element.SetAncho(form.GetImage().Width);
                    }
                }
                else
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void escala_Click(object sender, EventArgs e) // Actualiza la pictureBox después de haber pasado por un filtro.
        {
            try
            {
                if (Element.GetLoad())
                {
                    paneldecarga.Show();
                    Bitmap bmp = (Bitmap)pictureBox.Image.Clone();
                    pictureBox.Image = (Image)Element.EscalaDeGrises(bmp);
                    Element.SetSaved(false);
                    Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                    paneldecarga.Hide();
                }
                else MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void intensidades_Click(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    intensidad f = new intensidad();
                    f.ShowDialog();
                    auxiliar = f.lehadadoaaplicar();
                    if (auxiliar == true)
                    {
                        paneldecarga.Show();
                        Bitmap bmp = (Bitmap)pictureBox.Image.Clone();
                        pictureBox.Image = (Image)Element.intenso(bmp, f.GetRojo(), f.GetVerde(), f.GetAzul());
                        paneldecarga.Hide();
                        Element.SetSaved(false);
                        Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                        auxiliar = false;
                    }
                }
                else
                { MessageBox.Show("Primero tienes que carga una imagen al programa."); }
            }
            catch
            { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        } // Cambiar intensidad de los colores RGB.

        private void volteohor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bitmap = (Bitmap)pictureBox.Image.Clone();
                    Element.RotateHorizontal(bitmap);
                    pictureBox.Image = (Image)bitmap;
                    Element.SetSaved(false);
                    Element.AddBitmap(bitmap);
                    Element.SetAlto(bitmap.Height);
                    Element.SetAncho(bitmap.Width);
                }
                else
                {
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void volteover_Click(object sender, EventArgs e)
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bitmap = (Bitmap)pictureBox.Image.Clone();
                    Element.RotateVertical(bitmap);
                    pictureBox.Image = (Image)bitmap;
                    Element.SetSaved(false);
                    Element.AddBitmap(bitmap);
                    Element.SetAlto(bitmap.Height);
                    Element.SetAncho(bitmap.Width);
                }
                else
                {
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void giroizq_Click(object sender, EventArgs e) // Voltea 90º a la izquierda.
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bitmap = (Bitmap)pictureBox.Image.Clone();
                    Element.RotateIzquierda(bitmap);
                    pictureBox.Image = (Image)bitmap;
                    Element.SetSaved(false);
                    Element.AddBitmap(bitmap);
                    Element.SetAlto(bitmap.Height);
                    Element.SetAncho(bitmap.Width);
                }
                else
                {
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void giroder_Click(object sender, EventArgs e) // Voltea 90º a la derecha.
        {
            try
            {
                if (Element.GetLoad())
                {
                    Bitmap bitmap = (Bitmap)pictureBox.Image.Clone();
                    Element.RotateDerecha(bitmap);
                    pictureBox.Image = (Image)bitmap;
                    Element.SetSaved(false);
                    Element.AddBitmap((Bitmap)pictureBox.Image.Clone());
                    Element.SetAlto(bitmap.Height);
                    Element.SetAncho(bitmap.Width);
                }
                else
                {
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void verdetalles_Click(object sender, EventArgs e) // Muestra los datos de la imagen en pantalla.
        {
            {
                if (Element.GetLoad())
                {
                    MostrarDatos f2 = new MostrarDatos();
                    f2.SetAncho2(Convert.ToString(Element.GetAncho()));
                    f2.SetAlto2(Convert.ToString(Element.GetAlto()));
                    f2.SetRuta2(Convert.ToString(Element.GetUbicacion()));
                    f2.SetNombre2(Convert.ToString(Element.GetNombreFicher()));
                    f2.ShowDialog();
                }
                else
                    MessageBox.Show("Primero tienes que carga una imagen al programa.");
            }
        }

        private void presentacion_Click(object sender, EventArgs e)
        {
            ModoPresentacion fmp = new ModoPresentacion();
            fmp.ShowDialog();

        }

        private void listadefotos_Click(object sender, EventArgs e)
        {
            BaseFotos form = new BaseFotos();
            form.SetData(Element.ShowTable());

            form.ShowDialog();
        }

        private void pantallacompleta_Click(object sender, EventArgs e) // Pantalla Completa.
        {
            try
            {
                pantallacompleta.Hide();
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
            }
            catch
            {
                MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo.");
            }
        }

        private void quitarpantallacompleta_Click(object sender, EventArgs e) // Quitar el pantalla completa.
        {
            try
            {
                pantallacompleta.Show();
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
            catch { MessageBox.Show("Algo no salió bien, por favor inténtelo de nuevo."); }
        }

        private void Interfaz_KeyDown(object sender, KeyEventArgs e) //Dándole a la tecla escape, se puede salir de la aplicación.
        {
            if (e.KeyCode == Keys.Escape)
            {
                pantallacompleta.Show();
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        // Procedimientos para hacer que aparezcan en los botones el nombre.

        private void marcos_MouseHover(object sender, EventArgs e)
        {
            marcosinfo.Show();
        }

        private void marcos_MouseLeave(object sender, EventArgs e)
        {
            marcosinfo.Hide();
        }

        private void recortar_MouseHover(object sender, EventArgs e)
        {
            recortarinfo.Show();
        }

        private void recortar_MouseLeave(object sender, EventArgs e)
        {
            recortarinfo.Hide();
        }

        private void escala_MouseHover(object sender, EventArgs e)
        {
            escalainfo.Show();
        }

        private void escala_MouseLeave(object sender, EventArgs e)
        {
            escalainfo.Hide();
        }

        private void intensidades_MouseHover(object sender, EventArgs e)
        {
            intensidadinfo.Show();
        }

        private void intensidades_MouseLeave(object sender, EventArgs e)
        {
            intensidadinfo.Hide();
        }

        private void volteohor_MouseHover(object sender, EventArgs e)
        {
            volteohorinfo.Show();
        }

        private void volteohor_MouseLeave(object sender, EventArgs e)
        {
            volteohorinfo.Hide();
        }

        private void volteover_MouseHover(object sender, EventArgs e)
        {
            volteoverinfo.Show();
        }

        private void volteover_MouseLeave(object sender, EventArgs e)
        {
            volteoverinfo.Hide();
        }

        private void giroizq_MouseHover(object sender, EventArgs e)
        {
            giroizqinfo.Show();
        }

        private void giroizq_MouseLeave(object sender, EventArgs e)
        {
            giroizqinfo.Hide();
        }

        private void giroder_MouseHover(object sender, EventArgs e)
        {
            giroderinfo.Show();
        }

        private void giroder_MouseLeave(object sender, EventArgs e)
        {
            giroderinfo.Hide();
        }

        private void pantallacompleta_MouseHover(object sender, EventArgs e)
        {
            pantallacompletainfo.Show();
        }

        private void pantallacompleta_MouseLeave(object sender, EventArgs e)
        {
            pantallacompletainfo.Hide();
        }

        private void quitarpantallacompleta_MouseHover(object sender, EventArgs e)
        {
            quitarpantallainfo.Show();
        }

        private void quitarpantallacompleta_MouseLeave(object sender, EventArgs e)
        {
            quitarpantallainfo.Hide();
        }

        private void deshacer_MouseHover(object sender, EventArgs e)
        {
            deshacerinfo.Show();
        }

        private void deshacer_MouseLeave(object sender, EventArgs e)
        {
            deshacerinfo.Hide();
        }

        private void rehacer_MouseHover(object sender, EventArgs e)
        {
            Rehacerinfo.Show();
        }

        private void rehacer_MouseLeave(object sender, EventArgs e)
        {
            Rehacerinfo.Hide();
        }

        private void aumentar_MouseHover(object sender, EventArgs e)
        {
            aumentarinfo.Show();
        }

        private void aumentar_MouseLeave(object sender, EventArgs e)
        {
            aumentarinfo.Hide();
        }

        private void alejar_MouseHover(object sender, EventArgs e)
        {
            alejarinfo.Show();
        }

        private void alejar_MouseLeave(object sender, EventArgs e)
        {
            alejarinfo.Hide();
        }

        private void verdetalles_MouseHover(object sender, EventArgs e)
        {
            verdetallesinfo.Show();
        }

        private void verdetalles_MouseLeave(object sender, EventArgs e)
        {
            verdetallesinfo.Hide();
        }

        private void presentacion_MouseHover(object sender, EventArgs e)
        {
            presentacioninfo.Show();
        }

        private void presentacion_MouseLeave(object sender, EventArgs e)
        {
            presentacioninfo.Hide();
        }

        private void listadefotos_MouseHover(object sender, EventArgs e)
        {
            listadefotosinfo.Show();
        }

        private void listadefotos_MouseLeave(object sender, EventArgs e)
        {
            listadefotosinfo.Hide();
        }
    }
}
