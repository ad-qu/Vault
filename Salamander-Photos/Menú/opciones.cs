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
    public partial class opciones : Form
    {
        bool aplicarcambios = false;

        public opciones()
        {
            InitializeComponent();
        }

        public bool lehadadoaaplicar()
        {
            return aplicarcambios;
        }

        public void visibledesre(Panel a)
        {
            if (a.Visible)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        public void visibleaumre(Panel a)
        {
            if (a.Visible)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        public int aumre()
        {
            if (checkBox1.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int desre()
        {
            if (checkBox2.Checked == true)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aplicarcambios = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aplicarcambios = false;
        }
    }
}
