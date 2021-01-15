using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace BD_FARMACIA
{
    class Usuario
    {
        internal object paterno;
        internal object codigo;
        internal object tipo;
        public class Login
        {
            public string paterno { get; set; }
            public string codigo { get; set; }
            public string cargo { get; set; }
            public Login() { }
            public Login(string vpa, string vco, string vcar)
            {
                this.paterno = vpa;
                this.codigo = vco;
                this.cargo = vcar;
            }
        }
        public static void mostrarCargo(ComboBox cb)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("MOSTRAR_CARGO", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    cb.Items.Add(data["CARGO"].ToString());
                }
                cb.SelectedIndex = 0;
                con.Close();
            }
        }
        public static int AutentificarUs(string vpa, string vco)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT CARGO FROM USUARIOS WHERE PATERNO='{0}' AND COD_US='{1}'"
            , vpa, vco), con);
                SqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    retorno = 1;
                }
                con.Close();
            }
            return retorno;
        }

        //comprueba que exista el usuario
        public static DataTable validarUs(string vap, string vpass)
        {
            Usuario var = new Usuario();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("VAL", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ap", SqlDbType.VarChar, 15);
                command.Parameters.Add("@pass", SqlDbType.VarChar, 15);
                command.Parameters["@ap"].Value = vap;
                command.Parameters["@pass"].Value = vpass;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "user");
                con.Close();
                DataTable tabla = datos.Tables["user"];
                return tabla;
            }
        }

    }
}
