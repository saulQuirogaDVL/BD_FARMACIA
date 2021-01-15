using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BD_FARMACIA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Enabled = false;

        }
        int cont;
        string tipoval = "";
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable tabla = Usuario.validarUs(textBox1.Text, textBox2.Text);

                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    tipoval = fila[0].ToString();

                }
                if (tipoval == "ADMINISTRADOR" || tipoval == "GERENTE" || tipoval == "PASANTE")
                {
                    MessageBox.Show("Ingresando.....");
                    Form2 form2 = new Form2();
                    form2.label2.Text = tipoval;
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Por favor intente de nuevo");
                    cont = cont + 1;
                }

                if (cont == 3)
                {
                    MessageBox.Show("Demaciados intentos sin exito");
                    //Application.Exit();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("LLENE LOS CAMPOS");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEA SALIR DE LA APLICACION?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("CANCELADO");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("ULTIMOS 3 INTENTOS");
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            if (Usuario.AutentificarUs(textBox1.Text, textBox2.Text) > 0)
            {
                MessageBox.Show("CORRECTO");
                MessageBox.Show("BIENVENITO " + "'" + textBox1.Text + "'");
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            { 
                textBox1.Clear();
                textBox2.Clear();
                cont = cont + 1;
            }


            if (cont == 5)
            {
                MessageBox.Show("DEMACIADOS INTENTOS SIN EXITO");
                Application.Exit();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextGotFocus(object sender, EventArgs e)
        {
            textBox1.Text = "dfsfsdfs";
            textBox1.ForeColor = Color.Black;
        }
        private void TextLostFocus(object sender, EventArgs e)
        {
            textBox1.Text = "jajcjshfbdf";
            textBox1.ForeColor = Color.Gray;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Paterno")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Paterno";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contraseña")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Contraseña";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se Permiten Letras!!!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
