using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Imagen
{
    public class ImagenProperties
    {
        /* ATRIBUTOS */

        /* ATRIBUTOS GENERALES */
        string extension, nfichero, ubicacion, direccion, ubicacion_como; // Ruta, Extension y nombre del fichero.
        bool load = false, saved = false; // Saber si la imagen está cargada.
        int Ancho, Alto; // Alto y ancho de la foto. (Unificado para PPM, PNG y JPG).

        /* ATRIBUTOS PPM */
        string NumeroMagico; //El número mágico de las imagenes PPM, siempre P3.
        int ValMaxCol;
        PixelProperties[,] Pixel; //La matriz de pixeles exclusiva para PPM.

        /* ATRIBUTOS DE DESHACER Y REHACER */
        List<Bitmap> modifications = new List<Bitmap>(); //Lista de Bitmaps que ayuda a la Reconstrucción.
        int numMod = 0, index = 0; //numMod --> Número de veces modificado| index --> Posición en la que estamos de la lista.

        /* DATABASE */
        BaseDatos gestor = new BaseDatos();

        /*-----------------------------------------------------------------------------------------------------------*/

        /* FUNCIONES Y MÉTODOS */

        /* FUNCIONES Y MÉTODOS RELACIONADAS CON EL BITMAP [UNIFICADAS]*/
        public Bitmap EscalaDeGrises(Bitmap bmp)
        {
            Color ColorPixel;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    ColorPixel = bmp.GetPixel(x, y);
                    int sumCol = (ColorPixel.R + ColorPixel.B + ColorPixel.G) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(ColorPixel.A, sumCol, sumCol, sumCol));
                }
            }
            return bmp;
        }//Escala de grises. La media de los colores a cada pixel.


        // Crea el nuevo Documento en Blanco donde poder dibujar.
        public Bitmap NuevoDocEnBlanco(int x, int y)
        {
            Color colorBlanc = Color.White;
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }

        public void SalvarComo(PictureBox pictureBox1)
        {
            try
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image.Clone();
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PNG |*.png|JPG |*.jpg|PPM |*.ppm";
                saveFile.Title = "Guardar Como";
                saveFile.ShowDialog();
                FileStream fiche = (FileStream)saveFile.OpenFile();
                switch (saveFile.FilterIndex)
                {
                    case 1:
                        bmp.Save(fiche, System.Drawing.Imaging.ImageFormat.Png);
                        fiche.Dispose();
                        break;
                    case 2:
                        bmp.Save(fiche, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fiche.Dispose();
                        break;
                    case 3:
                        fiche.Dispose();
                        this.SobreescribirPPM(bmp, saveFile.FileName);
                        break;
                }
                this.ubicacion = saveFile.FileName;
                saveFile.Dispose();
            }
            catch
            {
            }
        } //Filtro para guardar el fichero como.

        public bool CompareBitmaps(Bitmap bmp)
        {
            try
            {
                Bitmap bmpToCompare = this.modifications[0]; //Lo compara con la foto original
                bool comparator = false; //False si son iguales. True si hay cambios.

                //Filtro para saber si bmpToCompare es igual a bmp:
                //Primero el tamaño:
                if (bmpToCompare.Size.Equals(bmp.Size))
                {
                    //Los FORs nos ayudan a movernos por la matriz de pixel:
                    for (int y = 0; (y < this.Alto)&&(!comparator); y++)
                    {
                        for (int x = 0; (x < this.Ancho)&&(!comparator); x++)
                        {
                            //Finalmente comparamos cada pixel:
                            if ((bmpToCompare.GetPixel(x, y) != bmp.GetPixel(x, y)))
                                comparator = true;
                        }
                    }
                }
                else
                {
                    comparator = true; //Si la medida no es la misma directamente ya lo vuelve falso.
                }
                return comparator;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        } //Compara dos bitmaps, el bitmap de la picturebox actual y el anterior a el.

        public void AddBitmap(Bitmap bmp)
        {
            if (this.index == this.numMod) //si coincide que el indice está en el top de la lista
            {
                //Añadimos el bitmap actual a la lista de modificaciones
                this.modifications.Add(bmp);

                //Ahora señalamos el Número de modificaciones y la posición de index en la lista
                this.numMod  = this.modifications.Count;
                this.index++;
            }
            else //De otra forma, es decir, el indice está por debajo (El indice nunca va a poder ser mayor que el número de modificaciones):
            {
                //Insertamos una posición arriba el bitmap actualizado.
                this.modifications.Insert((this.index+1), bmp);

                //Subimos en 1 index y actualizamos el número de modificaciones
                this.numMod = this.modifications.Count;
                this.index++;
            }

        } //Añade un Bitmap a la lista.

        public Bitmap Deshacer()
        {
            if (this.index > 0) //mientras estemos por encima de la posición 0
            {
                //Señalamos la versión anterior en la que nos encontramos
                if (this.index == this.numMod)
                    this.index -= 2;
                else
                    this.index--;

                //Actualizamos las propiedades de la imagen
                this.Alto = this.modifications[this.index].Height;
                this.Ancho = this.modifications[this.index].Width;

                //Ahora devolvemos la versión anterior
                return this.modifications[this.index];

            }
            else //una vez estemos en la posición 0
            {

                //Actualizamos las propiedades de la imagen
                this.Alto = this.modifications[this.index].Height;
                this.Ancho = this.modifications[this.index].Width;

                //Como ahora estamos en la posición 0, facilmente devolvemos:
                return this.modifications[this.index];

            }

        } //Deshacer un cambio.

        public Bitmap Rehacer()
        {
            if (this.index < (this.numMod - 1)) //Mientras estemos por debajo del top
            {
                //sumamos 1 al index
                this.index++;

                //Actualizamos las propiedades de la imagen
                this.Alto = this.modifications[this.index].Height;
                this.Ancho = this.modifications[this.index].Width;

                //ahora devolvemos la modificación superior
                return this.modifications[this.index];
            }
            else //Mientras estemos justo en el top
            {
                //Actualizamos las propiedades de la imagen
                this.Alto = this.modifications[this.index].Height;
                this.Ancho = this.modifications[this.index].Width;

                //Devolvemos la modificación top
                return this.modifications[this.index];

            }

        } //Rehace un cambio.

        public void Reset()
        {
            //Reset de propiedades:
            this.index = 0;
            this.numMod = 0;

            //Reset List Modification:
            this.modifications.Clear();

        } //Resetea todas las propiedades de las listas.

        public void Zoom(double zoomfactor, PictureBox pictureBox1)
        {
            Rectangle ScreenSize = new Rectangle();
            ScreenSize.Width = pictureBox1.Width;
            ScreenSize.Height = pictureBox1.Height;
            Image img = pictureBox1.Image;
            Bitmap bitMapImg = new Bitmap(img);


            if (bitMapImg.Width < ScreenSize.Width && bitMapImg.Height < ScreenSize.Height)
            {
                Size newSize = new Size((int)(bitMapImg.Width * zoomfactor), (int)(bitMapImg.Height * zoomfactor));
                Bitmap bmp = new Bitmap(bitMapImg, newSize);
                pictureBox1.Image = (Image)bmp;
            }
        } //Zoom en proceso.

        public Bitmap RotateHorizontal(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            return bitmap;
        } //para rotar horizontal.

        public Bitmap RotateIzquierda(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
            return bitmap;
        } //Rota a la Izquierda.

        public Bitmap RotateDerecha(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);
            return bitmap;
        } //Rota a la Derecha.

        public Bitmap RotateVertical(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            return bitmap;
        } //Rota verticalmente.

        public Bitmap intenso(Bitmap bmp, int factorRojo, int factorVerde, int factorAzul)
        {
            Color ColorPixel;
            int SumaRoja;
            int SumaVerde;
            int SumaAzul;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    ColorPixel = bmp.GetPixel(x, y);
                    SumaRoja = ColorPixel.R + factorRojo;
                    SumaVerde = ColorPixel.G + factorVerde;
                    SumaAzul = ColorPixel.B + factorAzul;
                    if (ColorPixel.R + factorRojo > 255)
                    {
                        SumaRoja = 255;
                    }
                    else if (ColorPixel.R + factorRojo < 0)
                    {
                        SumaRoja = 0;
                    }
                    if (ColorPixel.G + factorVerde > 255)
                    {
                        SumaVerde = 255;
                    }
                    else if (ColorPixel.G + factorVerde < 0)
                    {
                        SumaVerde = 0;
                    }
                    if (ColorPixel.B + factorAzul > 255)
                    {
                        SumaAzul = 255;
                    }
                    else if (ColorPixel.B + factorAzul < 0)
                    {
                        SumaAzul = 0;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(ColorPixel.A, SumaRoja, SumaVerde, SumaAzul));
                }
            }
            return bmp;
        } //filtro para cambiar la intensidad de los colores.


        /* FUNCIONES DE USO GENERAL */
        //Funciones para cargar.
        public void SetLoadTrue()
        { this.load = true; } //Establecemos si se ha cargado una foto.

        public bool GetLoad()
        { return this.load; } //Para saber si hay una foto cargada.

        public void SetAncho(int x)
        { this.Ancho = x; } //Establecemos cuanto vale el Ancho de la imagen.

        public int GetAncho()
        { return this.Ancho; } //Para saber el valor del Ancho de la imagen.

        public void SetAlto(int y)
        { this.Alto = y; } //Establecemos el Alto de la imagen.

        public int GetAlto()
        { return this.Alto; } //Para saber el valor del Alto de la imagen.

        public void SetExtension(string ex)
        {this.extension = ex;} //Establecemos que tipo de fichero es.

        public string GetExtension()
        { return this.extension; } //Para saber que tipo de fichero es.

        public void SetNombreFichero(string nf)
        { this.nfichero = nf; } //Establecemos el nombre del archivo.

        public string GetNombreFicher()
        { return this.nfichero; } //Para saber que nombre tiene.

        public void SetUbicacion(string file)
        {
            this.ubicacion = file;
            this.SetExtension(Path.GetExtension(file));
            this.SetNombreFichero(Path.GetFileName(file));
        } //Conjunto para establecer la ubicación, nombre y la extensión.

        public string GetUbicacion()
        { return ubicacion; } //Devuelve la ubicación completa, nombre y extensión.

        public void SetDireccion(string dir)
        { this.direccion = dir; } //Establece la dirección del archivo.

        public string GetDireccion()
        { return this.direccion; }//Devuelve la dirección del archivo ORIGINAL.

        public void SetSaved(bool x)
        { this.saved = x; } //Establece si se ha guardado o no.

        public bool GetSaved()
        { return this.saved; } //Devuelve si se ha guardado o no.

        public void FiltroDeCarga(PictureBox pictureBox1)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                string ruta;
                openFile.Filter = "Todos los archivos|*.*|PNG |*.png|JPG |*.jpg|PPM |*.ppm";
                openFile.Title = "Abrir archivo";
                openFile.ShowDialog();
                ruta = openFile.FileName;
                this.SetUbicacion(ruta);
                Bitmap bmp;
                if ((this.GetExtension() == ".png") || (this.GetExtension() == ".jpg") || (this.GetExtension() == ".PNG"))
                {
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    pictureBox1.Image = this.LoadBitmapUnlocked(ruta);
                    bmp = this.LoadBitmapUnlocked(ruta);
                    this.SetLoadTrue();
                    this.SetAlto(bmp.Height);
                    this.SetAncho(bmp.Width);
                }
                else if (this.GetExtension() == ".ppm")
                {
                    this.CargarImagenPPM(ruta);
                    bmp = this.CreateBitmapPPM();
                    pictureBox1.Image = (Image)bmp;
                    this.SetLoadTrue();
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                openFile.Dispose();
            }
            catch
            {
            }
        } //Dependiendo de la extensión abre de una manera o no.

        /* FUNCIONES Y MÉTODOS EXCLUSIVOS DE PPM */
        //Funciones para cargar.
        public Bitmap CreateBitmapPPM()
        {
            try
            {
                Bitmap bmp = new Bitmap(this.Ancho, this.Alto);
                for (int m = 0; m < this.Alto; m++)
                    for (int n = 0; n < this.Ancho; n++)
                    {
                        Color colorPixel = Color.FromArgb(Pixel[m, n].GetRedPixel(), Pixel[m, n].GetGreenPixel(), Pixel[m, n].GetBluePixel());
                        bmp.SetPixel(n, m, colorPixel);
                    }
                return bmp;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("¡Vaya! Parece que este archivo está corrupto o vacío.");
                return null;
            }
        } //Aunque esté relacionado con Formularios, esta función es de uso de PPM.
        
        public void SetNumeroMagico(string NM)
        { this.NumeroMagico = NM; } //Establecer el valor del Número Mágico.

        public string GetNumeroMagico()
        { return this.NumeroMagico; } //Para saber el valor del Número Mágico.

        public void SetMaxVALcol(int x)
        { this.ValMaxCol = x; } //Establecer el valor máximo de cada pixel.

        public int GetMAXcol()
        { return this.ValMaxCol; } //Para saber el valor máximo de cada pixel.

        public void CargarImagenPPM(string ubicacion)
        {
            StreamReader lectura = new StreamReader(ubicacion);
            string linea;
            linea = lectura.ReadLine();
            for (int i = 0; linea != null; i++)
            {
                if (i < 3)
                {
                    LeerCabecera(i, linea);
                }
                else if (i >= 3)
                {
                    Pixel = new PixelProperties[GetAlto(), GetAncho()];
                    for (int m = 0; m < this.Alto; m++)
                        for (int n = 0; n < this.Ancho; n++)
                            Pixel[m, n] = new PixelProperties();
                    for (int m = 0; m < this.Alto; m++)
                    {
                        for (int n = 0; n < this.Ancho; n++)
                        {
                            Pixel[m, n].CargarPixel(n * 3, linea, this.Ancho);
                        }
                        linea = lectura.ReadLine();
                    }
                }
                linea = lectura.ReadLine();
            }
            lectura.Close();
            this.SetLoadTrue();
        } //Cargar una imagen PPM en específico.

        public void LeerCabecera(int indice, string line)
        {
            string[] Dimensiones = new string[2];
            if (indice == 0)
                SetNumeroMagico(line);
            if (indice == 1)
            {
                Dimensiones = line.Split(' ');
                SetAncho(Convert.ToInt32(Dimensiones[0]));
                SetAlto(Convert.ToInt32(Dimensiones[1]));
            }
            if (indice == 2)
            {
                SetMaxVALcol(Convert.ToInt32(line));
            }

        } //Leemos y asigamos los valores de la cabecera.

        public void SobreescribirPPM(Bitmap bmp, string ubicacion)
        {
            StreamWriter Writer = new StreamWriter(ubicacion);
            Color col;
            for (int linia = 0; linia < this.Alto + 3; linia++)
            {
                if (linia < 3)
                {
                    if (linia == 0)
                        Writer.WriteLine("P3");
                    if (linia == 1)
                        Writer.WriteLine(this.Ancho + " " + this.Alto);
                    if (linia == 2)
                        Writer.WriteLine("255");
                }
                else
                {
                    for (int e = 0; e < this.Ancho; e++)
                    {
                        col = bmp.GetPixel(e, linia - 3);
                        Writer.Write(col.R + " " + col.G + " " + col.B + " ");
                    }
                    Writer.WriteLine();
                }
            }
            Writer.Close();
        }//Escribe en la ruta ppm proporcionada, todos los datos en formato ppm.

        /* FUNCIONES PARA SALVAR O SALVAR COMO .PNG O .JPG*/
        public void Salvar(Bitmap img)
        {
                File.Delete(this.ubicacion);
                img.Save(this.ubicacion);
        } //(?)

        public Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        public void ActualizarDatabase()
        {
            gestor.IniciarBase();
            gestor.RemovePhantom();
            if (gestor.IsOnTable(this.ubicacion))
            {
                gestor.UpdateData(this.ubicacion, Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")));
            }
            else
            {
                gestor.InsertData(this.ubicacion, Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")));
            }
            gestor.CerrarBase();
        }

        public DataTable ShowTable()
        {
            DataTable data = new DataTable();

            gestor.IniciarBase();
            gestor.RemovePhantom();
            data = gestor.GetTabla();
            gestor.CerrarBase();

            return data;
        }

        public DataTable GestorFiltro(string filtro)
        {
            DataTable data = new DataTable();

            gestor.IniciarBase();
            data = gestor.Filter(filtro);
            gestor.CerrarBase();

            return data;
        }
    }
}
