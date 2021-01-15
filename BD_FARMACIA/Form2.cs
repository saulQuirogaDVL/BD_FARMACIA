using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_FARMACIA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios us = new Usuarios();
            us.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (label2.Text == "GERENTE")
            {
                button1.Visible =false;
            }
            if (label2.Text=="PASANTE")
            {
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Productos pr = new Productos();
            pr.Show();
        }
        
    }
}
