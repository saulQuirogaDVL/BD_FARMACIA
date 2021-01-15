using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BD_FARMACIA
{
    class Productosclass
    {
        public string cod_prod { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public float precio { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }

        public Productosclass()
        {

        }

        public Productosclass(string vcp, string vnp, int vsp,float vpp, string vdp,  string vtp)
        {
            this.cod_prod = vcp;
            this.nombre = vnp;
            this.stock = vsp;
            this.precio = vpp;
            this.descripcion = vdp;
            this.tipo = vtp;
        }

        //muestra la lista de los Productos
        public static DataTable ListadoPR()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("LISTPR", con);
                command.CommandType = CommandType.StoredProcedure;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "pr");
                con.Close();
                DataTable tabla = datos.Tables["pr"];
                return tabla;
            }
        }

        //busca a los productos por su nombre, id o tipo
        public static DataTable BuscarPR(string codnom, string tipo)
        {
            Productosclass var = new Productosclass();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("BUSQPR", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@codnom", SqlDbType.VarChar, 15);
                command.Parameters["@codnom"].Value = codnom;
                command.Parameters.Add("@tipo", SqlDbType.VarChar, 15);
                command.Parameters["@tipo"].Value = tipo;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "PR");
                con.Close();
                DataTable tabla = datos.Tables["PR"];
                return tabla;
            }
        }

        //agrega un producto
        public static int AGRPR(Productosclass u,string nomprov)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("AGRPR", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cod", SqlDbType.VarChar, 15);
                command.Parameters.Add("@nom", SqlDbType.VarChar, 15);
                command.Parameters.Add("@stock", SqlDbType.Int);
                command.Parameters.Add("@pre", SqlDbType.Decimal);
                command.Parameters.Add("@des", SqlDbType.VarChar, 15);
                command.Parameters.Add("@tipo", SqlDbType.VarChar,15);
                command.Parameters.Add("@comp", SqlDbType.VarChar, 15);
                command.Parameters["@cod"].Value = u.cod_prod;
                command.Parameters["@nom"].Value = u.nombre;
                command.Parameters["@stock"].Value = u.stock;
                command.Parameters["@pre"].Value = u.precio;
                command.Parameters["@des"].Value = u.descripcion;
                command.Parameters["@tipo"].Value = u.tipo;
                command.Parameters["@comp"].Value = nomprov;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //actualizar un Producto
        public static int UPDPR(Productosclass u, string nomprov)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("UPDPR", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cod", SqlDbType.VarChar, 15);
                command.Parameters.Add("@nom", SqlDbType.VarChar, 15);
                command.Parameters.Add("@stock", SqlDbType.Int);
                command.Parameters.Add("@pre", SqlDbType.Decimal);
                command.Parameters.Add("@des", SqlDbType.VarChar, 15);
                command.Parameters.Add("@tipo", SqlDbType.VarChar, 15);
                command.Parameters.Add("@comp", SqlDbType.VarChar, 15);
                command.Parameters["@cod"].Value = u.cod_prod;
                command.Parameters["@nom"].Value = u.nombre;
                command.Parameters["@stock"].Value = u.stock;
                command.Parameters["@pre"].Value = u.precio;
                command.Parameters["@des"].Value = u.descripcion;
                command.Parameters["@tipo"].Value = u.tipo;
                command.Parameters["@comp"].Value = nomprov;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //elimina un productos
        public static int DLTPR(string cod)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("DLTPR", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cod", SqlDbType.VarChar, 15);
                command.Parameters["@cod"].Value = cod;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //contador
        public static DataTable CONTADOR()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("CONTPR", con);
                command.CommandType = CommandType.StoredProcedure;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "PR");
                con.Close();
                DataTable tabla = datos.Tables["PR"];
                return tabla;
            }
        }

        //combox productos
        public static void LISTIPOS(ComboBox cb)
        {
            using(SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("TIPOS", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    cb.Items.Add(data["TIPO"].ToString());
                }
                cb.SelectedIndex = 0;
                con.Close();
            }
        }
    }
}
