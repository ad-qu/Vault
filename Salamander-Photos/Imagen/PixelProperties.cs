using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imagen
{
    class PixelProperties
    {
        /* ATRIBUTOS DE LOS PIXELES */
        int red, green, blue;

        /* FUNCIONES DE CARGA */
        public void CargarPixel(int i, string linea, int ancho)
        {
            string[] valcol = new string[ancho * 3];
            valcol = linea.Split(' ');
            this.red = Convert.ToInt32(valcol[i]);
            this.green = Convert.ToInt32(valcol[i + 1]);
            this.blue = Convert.ToInt32(valcol[i + 2]);
        }
        public int GetRedPixel()
        { return this.red; }
        public void SetRedPixel(int val)
        { this.red = val; }
        public int GetGreenPixel()
        { return this.green; }
        public void SetGreenPixel(int val)
        { this.green = val; }
        public int GetBluePixel()
        { return this.blue; }
        public void SetBluePixel(int val)
        { this.blue = val; }
        /* _____________________________________________________________________*/

        /* OBTENER DATOS DE LOS PIXELES */
        public string PixelShow()
        {
            return Convert.ToString(GetRedPixel()) + " " + Convert.ToString(GetGreenPixel()) + " " + Convert.ToString(GetBluePixel()) + " ";
        } // con formato: ValorRojo ValorVerde ValorAzul [espacios incluidos].

        /* Función modificar atributos */

        public void ModificarColores(string[] Pixel)
        {
            this.red = Convert.ToInt32(Pixel[0]);
            this.green = Convert.ToInt32(Pixel[1]);
            this.blue = Convert.ToInt32(Pixel[2]);
        }
    }
}
