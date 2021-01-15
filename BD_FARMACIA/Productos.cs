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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        Boolean insoradd = true;

        private void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.Text = "";
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            Productosclass.LISTIPOS(comboBox1);

            Productosclass.LISTIPOS(comboBox2);

            groupBox2.Enabled = false;
            try
            {
                DataTable tabla = Productosclass.ListadoPR();
                dataGridView1.DataSource = tabla;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Productosclass pr = new Productosclass();
            pr.cod_prod = textBox2.Text;
            pr.nombre = textBox3.Text;
            pr.stock = int.Parse(textBox4.Text);
            pr.precio = float.Parse(textBox5.Text);
            pr.descripcion = textBox6.Text;
            pr.tipo = comboBox2.Text;
            try
            {
                if (insoradd == true)
                {
                    if (Productosclass.AGRPR(pr,textBox7.Text) > 0)
                    {
                        MessageBox.Show("REGISTRO EXITOSO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable tabla =Productosclass.ListadoPR();
                        dataGridView1.DataSource = tabla;
                        dataGridView1.Refresh();
                    }
                }
                else
                {
                    if (Productosclass.UPDPR(pr,textBox7.Text) > 0)
                    {
                        MessageBox.Show("REGISTRO EXITOSO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable tabla = Productosclass.ListadoPR();
                        dataGridView1.DataSource = tabla;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    DataTable tabla = Productosclass.BuscarPR(textBox1.Text, comboBox1.Text);
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];
                        textBox2.Text = fila[0].ToString();
                        textBox3.Text = fila[1].ToString();
                        textBox4.Text = fila[2].ToString();
                        textBox5.Text = fila[3].ToString();
                        textBox6.Text = fila[4].ToString();
                        comboBox2.Text = fila[5].ToString();
                        dataGridView1.DataSource = tabla;
                        dataGridView1.Refresh();
                    }
                    else
                        MessageBox.Show("DATOS NO ENCONTRADOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            label9.Visible = true;
            DataTable table = Productosclass.CONTADOR();
            DataRow fila = table.Rows[0];
            insoradd = true;
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            textBox2.Enabled = true;
            textBox5.Enabled = true;
            limpiar();
            textBox2.Text = (fila[0].ToString());
            textBox2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                insoradd = false;
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;;
                DataTable tabla = Productosclass.BuscarPR(textBox1.Text, comboBox1.Text);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    textBox2.Text = fila[0].ToString();
                    textBox3.Text = fila[1].ToString();
                    textBox4.Text = fila[2].ToString();
                    textBox5.Text = fila[3].ToString();
                    textBox6.Text = fila[4].ToString();
                    comboBox2.Text = fila[5].ToString();
                    dataGridView1.DataSource = tabla;
                    dataGridView1.Refresh();
                }
            }
            else
                MessageBox.Show("SIN DATOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                insoradd = false;
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                textBox7.Visible = false;
                label9.Visible = false;
                DataTable tabla = Productosclass.BuscarPR(textBox1.Text, comboBox1.Text);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    textBox2.Text = fila[0].ToString();
                    textBox3.Text = fila[1].ToString();
                    textBox4.Text = fila[2].ToString();
                    textBox5.Text = fila[3].ToString();
                    textBox6.Text = fila[4].ToString();
                    comboBox2.Text = fila[5].ToString();
                    dataGridView1.DataSource = tabla;
                    dataGridView1.Refresh();
                }
            }
            else
                MessageBox.Show("SIN DATOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                try
                {
                    Productosclass.DLTPR(textBox2.Text);
                    MessageBox.Show("ELIMINADO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable tabla = Productosclass.ListadoPR();
                    dataGridView1.DataSource = tabla;
                    dataGridView1.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("SIN DATOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        //VALIDACION NUMEROS Y LETRAS
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
