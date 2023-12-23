using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Imagen
{
    class BaseDatos
    {
        //La tabla se llama fotosrecientes con Ruta varchar, UltimaVez varchar.
        //-------------------------------------------------------------------------//
        SQLiteConnection connector;

        public void IniciarBase()
        {
            //Recogemos la ubicación de la base de datos.
            string Source = "Data Source=..\\..\\..\\..\\SalamanderProject\\Menú\\bin\\Debug\\database\\dataphoto.db";

            //Ahora aplicamos la conexión.
            connector = new SQLiteConnection(Source);
            connector.Open();
        }

        public void CerrarBase()
        {
            connector.Close();
        }

        public DataTable GetTabla()
        {
            SQLiteDataAdapter adap;
            DataTable data = new DataTable();
            string command = "SELECT * FROM fotosrecientes ORDER BY UltimaVez DESC LIMIT 12";

            adap = new SQLiteDataAdapter(command, connector);
            adap.Fill(data);

            return data;
        }

        public void UpdateData(string ubicacion, int fecha)
        {
            string Command = "UPDATE fotosrecientes SET UltimaVez =" + fecha + " WHERE Ruta='" + ubicacion + "'";
            SQLiteCommand comexe = new SQLiteCommand(Command, connector);

            comexe.ExecuteNonQuery();

        }

        public void InsertData(string ubicacion, int fecha)
        {
            string command = "INSERT INTO fotosrecientes VALUES ('" + ubicacion + "', " + fecha + ")";
            SQLiteCommand comexe = new SQLiteCommand(command, connector);

            comexe.ExecuteNonQuery();
        }

        public bool IsOnTable(string ubicacion)
        {
            bool Encontrado = false;
            DataTable data = new DataTable();
            SQLiteDataAdapter adap;
            string command = "SELECT Ruta FROM fotosrecientes";

            adap = new SQLiteDataAdapter(command, connector);
            adap.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++ )
            {
                if (data.Rows[i][0].ToString() == ubicacion)
                    Encontrado = true;
            }

            return Encontrado;
        }

        public void RemovePhantom()
        {
            string commandSelect = "SELECT * FROM fotosrecientes";
            string commandDelete;
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(commandSelect, connector);
            SQLiteCommand comexe;

            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (!File.Exists(data.Rows[i][0].ToString()))
                {
                    commandDelete = "DELETE FROM fotosrecientes WHERE Ruta = '"+ data.Rows[i][0].ToString() + "'";
                    comexe = new SQLiteCommand(commandDelete, connector);
                    comexe.ExecuteNonQuery();
                }
            }
        }

        public DataTable Filter(string filtro)
        {
            DataTable data = new DataTable();
            SQLiteDataAdapter adp;
            string command = "SELECT * FROM fotosrecientes WHERE Ruta LIKE '%" + filtro +"%'";

            adp = new SQLiteDataAdapter(command, connector);
            adp.Fill(data);

            return data;
        }
    }
}
