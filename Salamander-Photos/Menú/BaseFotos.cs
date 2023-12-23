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
    public partial class BaseFotos : Form
    {
        int i = 1; string a, b, c; int dia, mes, año;

        ImagenProperties Gestor = new ImagenProperties();

        DataTable data = new DataTable();

        public BaseFotos()
        {
            InitializeComponent();
        }

        public void SetData(DataTable table)
        {
            data = table;
        }

        private void BaseFotos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Ruta de la imagen";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].HeaderText = "Última vez que guardaste la foto";
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.Refresh();

            label13.Text = "1 / 2";
            label14.Show();

            if (i < dataGridView1.RowCount)
            {
                label14.Hide();
                pictureBox1.ImageLocation = Convert.ToString(dataGridView1[0, 0].Value);
                a = Convert.ToString(dataGridView1[0, 0].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label1.Text = a;
                b = Convert.ToString(dataGridView1[1, 0].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label2.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox1.Hide();
                label1.Hide();
                label2.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox2.ImageLocation = Convert.ToString(dataGridView1[0, 1].Value);
                a = Convert.ToString(dataGridView1[0, 1].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label3.Text = a;
                b = Convert.ToString(dataGridView1[1, 1].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label4.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox2.Hide();
                label3.Hide();
                label4.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox3.ImageLocation = Convert.ToString(dataGridView1[0, 2].Value);
                a = Convert.ToString(dataGridView1[0, 2].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label5.Text = a;
                b = Convert.ToString(dataGridView1[1, 2].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label6.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox3.Hide();
                label5.Hide();
                label6.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox4.ImageLocation = Convert.ToString(dataGridView1[0, 3].Value);
                a = Convert.ToString(dataGridView1[0, 3].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label7.Text = a;
                b = Convert.ToString(dataGridView1[1, 3].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label8.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox4.Hide();
                label7.Hide();
                label8.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox5.ImageLocation = Convert.ToString(dataGridView1[0, 4].Value);
                a = Convert.ToString(dataGridView1[0, 4].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label9.Text = a;
                b = Convert.ToString(dataGridView1[1, 4].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label10.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox5.Hide();
                label9.Hide();
                label10.Hide();
            }

            if (i < dataGridView1.RowCount)
            {

                pictureBox6.ImageLocation = Convert.ToString(dataGridView1[0, 5].Value);
                a = Convert.ToString(dataGridView1[0, 5].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label11.Text = a;
                b = Convert.ToString(dataGridView1[1, 5].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label12.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox6.Hide();
                label11.Hide();
                label12.Hide();
            } 
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            i = 7;  label13.Text = "2 / 2";

            if (i < dataGridView1.RowCount)
            {
                pictureBox1.ImageLocation = Convert.ToString(dataGridView1[0, 6].Value);
                a = Convert.ToString(dataGridView1[0, 6].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label1.Text = a;
                b = Convert.ToString(dataGridView1[1, 6].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label2.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox1.Hide();
                label1.Hide();
                label2.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox2.ImageLocation = Convert.ToString(dataGridView1[0, 7].Value);
                a = Convert.ToString(dataGridView1[0, 7].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label3.Text = a;
                b = Convert.ToString(dataGridView1[1, 7].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label4.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox2.Hide();
                label3.Hide();
                label4.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox3.ImageLocation = Convert.ToString(dataGridView1[0, 8].Value);
                a = Convert.ToString(dataGridView1[0, 8].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label5.Text = a;
                b = Convert.ToString(dataGridView1[1, 8].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label6.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox3.Hide();
                label5.Hide();
                label6.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox4.ImageLocation = Convert.ToString(dataGridView1[0, 9].Value);
                a = Convert.ToString(dataGridView1[0, 9].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label7.Text = a;
                b = Convert.ToString(dataGridView1[1, 9].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label8.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox4.Hide();
                label7.Hide();
                label8.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox5.ImageLocation = Convert.ToString(dataGridView1[0, 10].Value);
                a = Convert.ToString(dataGridView1[0, 10].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label9.Text = a;
                b = Convert.ToString(dataGridView1[1, 10].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label10.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox5.Hide();
                label9.Hide();
                label10.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                pictureBox6.ImageLocation = Convert.ToString(dataGridView1[0, 11].Value);
                a = Convert.ToString(dataGridView1[0, 11].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label11.Text = a;
                b = Convert.ToString(dataGridView1[1, 11].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label12.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox6.Hide();
                label11.Hide();
                label12.Hide();
            }
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            i = 1; label13.Text = "1 / 2";

            if (i < dataGridView1.RowCount)
            {
                label1.Show();
                label2.Show();
                pictureBox1.Show();
                pictureBox1.ImageLocation = Convert.ToString(dataGridView1[0, 0].Value);
                a = Convert.ToString(dataGridView1[0, 0].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label1.Text = a;
                b = Convert.ToString(dataGridView1[1, 0].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label2.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox1.Hide();
                label1.Hide();
                label2.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                label3.Show();
                label4.Show();
                pictureBox2.Show();
                pictureBox2.ImageLocation = Convert.ToString(dataGridView1[0, 1].Value);
                a = Convert.ToString(dataGridView1[0, 1].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label3.Text = a;
                b = Convert.ToString(dataGridView1[1, 1].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label4.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox2.Hide();
                label3.Hide();
                label4.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                label5.Show();
                label6.Show();
                pictureBox3.Show();
                pictureBox3.ImageLocation = Convert.ToString(dataGridView1[0, 2].Value);
                a = Convert.ToString(dataGridView1[0, 2].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label5.Text = a;
                b = Convert.ToString(dataGridView1[1, 2].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label6.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox3.Hide();
                label5.Hide();
                label6.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                label7.Show();
                label8.Show();
                pictureBox4.Show();
                pictureBox4.ImageLocation = Convert.ToString(dataGridView1[0, 3].Value);
                a = Convert.ToString(dataGridView1[0, 3].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label7.Text = a;
                b = Convert.ToString(dataGridView1[1, 3].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label8.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox4.Hide();
                label7.Hide();
                label8.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                label9.Show();
                label10.Show();
                pictureBox5.Show();
                pictureBox5.ImageLocation = Convert.ToString(dataGridView1[0, 4].Value);
                a = Convert.ToString(dataGridView1[0, 4].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label9.Text = a;
                b = Convert.ToString(dataGridView1[1, 4].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label10.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox5.Hide();
                label9.Hide();
                label10.Hide();
            }

            if (i < dataGridView1.RowCount)
            {
                label11.Show();
                label12.Show();
                pictureBox6.Show();
                pictureBox6.ImageLocation = Convert.ToString(dataGridView1[0, 5].Value);
                a = Convert.ToString(dataGridView1[0, 5].Value); if (a.Length > 44) { a = a.Remove(44) + "... "; }
                label11.Text = a;
                b = Convert.ToString(dataGridView1[1, 5].Value);
                año = Convert.ToInt32(b.Remove(4));
                c = b.Remove(0, 4); mes = Convert.ToInt32(c.Remove(2));
                dia = Convert.ToInt32(b.Remove(0, 6));
                label12.Text = ("Última vez que viste esta imagen: " + dia + " / " + mes + " / " + año);
                i++;
            }
            else
            {
                pictureBox6.Hide();
                label11.Hide();
                label12.Hide();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel1.Hide(); label15.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel1.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CellInformation inform = new CellInformation();
                if (dataGridView1[0, e.RowIndex].Value.ToString() != null)
                {
                    inform.SetRuta(dataGridView1[0, e.RowIndex].Value.ToString());
                    inform.SetUltimaVez(Convert.ToInt32(dataGridView1[1, e.RowIndex].Value));
                    inform.ShowDialog();
                }
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filtre = textBox1.Text;
                if (filtre != null)
                {
                    dataGridView1.DataSource = Gestor.GestorFiltro(filtre);
                    dataGridView1.Refresh();
                }
            }
            catch
            { }
        }
    }
}
