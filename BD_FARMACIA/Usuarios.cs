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
    public partial class Usuarios : Form
    {
        public Usuarios()
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
            textBox7.Clear();
            comboBox2.Text = "";           
        }
        public static void sololetras(TextBox e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Usuario.mostrarCargo(comboBox1);
            Usuario.mostrarCargo(comboBox2);
            groupBox2.Enabled = false;
            try
            {
                DataTable tabla = Usuariosclass.ListadoUS();
                dataGridView1.DataSource = tabla;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    DataTable tabla = Usuariosclass.BuscarUS(textBox1.Text,comboBox1.Text);
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];
                        textBox2.Text = fila[0].ToString();
                        textBox3.Text = fila[1].ToString();
                        textBox4.Text = fila[2].ToString();
                        textBox5.Text = fila[3].ToString();
                        textBox6.Text = fila[4].ToString();
                        dateTimePicker1.Text = fila[5].ToString();
                        comboBox2.Text = fila[6].ToString();
                        textBox7.Text = fila[7].ToString();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuariosclass us = new Usuariosclass();
            us.cod_us = textBox2.Text;
            us.nombre = textBox3.Text;
            us.paterno = textBox4.Text;
            us.materno = textBox5.Text;
            us.carnet = textBox6.Text;
            us.fechanac = dateTimePicker1.Value;
            us.cargo = comboBox2.Text;
            us.ocupacion = textBox7.Text;
            try
            {
                if (insoradd == true)
                {
                    if (Usuariosclass.AGRUS(us) > 0)
                    {
                        MessageBox.Show("REGISTRO EXITOSO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable tabla = Usuariosclass.ListadoUS();
                        dataGridView1.DataSource = tabla;
                        dataGridView1.Refresh();
                    }
                }
                else
                {
                    if (Usuariosclass.UPDUS(us) > 0)
                    {
                        MessageBox.Show("REGISTRO EXITOSO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable tabla = Usuariosclass.ListadoUS();
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

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable table = Usuariosclass.CONTADOR();
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
                groupBox3.Enabled = false;
                DataTable tabla = Usuariosclass.BuscarUS(textBox1.Text,comboBox1.Text);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    textBox2.Text = fila[0].ToString();
                    textBox3.Text = fila[1].ToString();
                    textBox4.Text = fila[2].ToString();
                    textBox5.Text = fila[3].ToString();
                    textBox6.Text = fila[4].ToString();
                    dateTimePicker1.Text = fila[5].ToString();
                    comboBox2.Text = fila[6].ToString();
                    textBox7.Text = fila[7].ToString();
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
                try
                {
                        Usuariosclass.DLTESTPA(textBox2.Text);                    
                        MessageBox.Show("ELIMINADO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable tabla = Usuariosclass.ListadoUS();
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

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
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
                MessageBox.Show("SOLO PERMITE LETRAS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("SOLO PERMITE LETRAS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("SOLO PERMITE LETRAS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("SOLO PERMITE LETRAS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
