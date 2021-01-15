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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            DataTable table = Ventasclass.CONTADOR();
            DataRow fila = table.Rows[0];
            textBox4.Text = (fila[0].ToString());
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            
        }

        float total = 0;
        int con = 0;
        int global = 0;

        private void Ventas_Load(object sender, EventArgs e)
        {
            textBox6.Text = total.ToString();
            groupBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            Productosclass.LISTIPOS(comboBox1);

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

        private void button3_Click(object sender, EventArgs e)
        {
            string cod, cant,sal=textBox4.Text;
           
            try {  
                DataTable tabla = Ventasclass.VAL(textBox1.Text);
                if (tabla.Rows.Count > 0)
                {
                    if (Ventasclass.AGRORDPA(sal, textBox1.Text) > 0)
                    {
                        MessageBox.Show("VENTA EXITOSA");

                        for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                        {
                      
                            cod = dataGridView2[0, i].Value.ToString();
                            cant = dataGridView2[2, i].Value.ToString();
                            if (cod == "" || cant == "")
                            {

                            }
                            else
                            {                             
                                if (Ventasclass.adds(textBox4.Text, textBox1.Text, cod, cant) > 0) { }
                            }

                            ;
                            Factura fac = new Factura();
                            fac.textBox1.Text =textBox4.Text;
                            this.Hide();
                            fac.Show();
                        }

                    }
                }
                else
                    {
                        if (Ventasclass.AGRCLI(textBox1.Text, textBox2.Text) > 0)
                        {
                            MessageBox.Show("REGISTRO EXITOSO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataTable tabla = Productosclass.BuscarPR(textBox3.Text, comboBox1.Text);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    textBox3.Text = fila[1].ToString();
                    comboBox1.Text = fila[5].ToString();
                    dataGridView1.DataSource = tabla;
                    dataGridView1.Refresh();
                }
                else
                    MessageBox.Show("DATOS NO ENCONTRADOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (Ventasclass.stk(textBox5.Text, textBox3.Text) >-2)
                {
                    DataTable tabla = Productosclass.BuscarPR(textBox3.Text, comboBox1.Text);
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];
                        dataGridView2.Rows.Add();
                        dataGridView2[0, con].Value = fila[0].ToString();
                        dataGridView2[1, con].Value = fila[1].ToString();
                        dataGridView2[2, con].Value = textBox5.Text;
                        dataGridView2[3, con].Value = fila[3].ToString();
                        dataGridView2[4, con].Value = comboBox1.Text;
                        dataGridView2[5, con].Value = fila[6].ToString();
                        total += float.Parse(fila[3].ToString()) * float.Parse(textBox5.Text);
                        textBox6.Text = total.ToString();
                        con++;
                    }
                }
                else
                    MessageBox.Show("CANTIDAD DEL PRODUCTO COMPRADOS MAYOR AL STOCK ");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //VALIDACION LETRAS Y NUMEROS
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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
    }
}
