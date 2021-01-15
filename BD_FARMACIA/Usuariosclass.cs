using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BD_FARMACIA
{
    class Usuariosclass
    {
        public string cod_us { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string carnet { get; set; }
        public DateTime fechanac { get; set; }
        public string cargo { get; set; }
        public string ocupacion { get; set; }

        public Usuariosclass()
        {

        }

        public Usuariosclass(string vcu, string vnu, string vpu, string vmu, string vcaru,DateTime fecha, string vcargu, string vou)
        {
            this.cod_us = vcu;
            this.nombre = vnu;
            this.paterno = vpu;
            this.materno = vmu;
            this.carnet = vcaru;
            this.fechanac = fecha;
            this.cargo = vcargu;
            this.ocupacion = vou;
        }

        //muestra la lista de los Usuarios
        public static DataTable ListadoUS()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("LIST_US", con);
                command.CommandType = CommandType.StoredProcedure;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "US");
                con.Close();
                DataTable tabla = datos.Tables["US"];
                return tabla;
            }
        }

        //busca a los usuarios por su paterno, id o cargo
        public static DataTable BuscarUS(string codnom, string cargo)
        {
            Usuariosclass var = new Usuariosclass();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("BUSQ_US", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@codnom", SqlDbType.VarChar, 15);
                command.Parameters["@codnom"].Value = codnom;
                command.Parameters.Add("@cargo", SqlDbType.VarChar, 15);
                command.Parameters["@cargo"].Value = cargo;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "US");
                con.Close();
                DataTable tabla = datos.Tables["US"];
                return tabla;
            }
        }

        //agrega un usuario
        public static int AGRUS(Usuariosclass u)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("AGRUS", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cod", SqlDbType.VarChar, 15);
                command.Parameters.Add("@nom", SqlDbType.VarChar, 15);
                command.Parameters.Add("@pat", SqlDbType.VarChar, 15);
                command.Parameters.Add("@mat", SqlDbType.VarChar,15);
                command.Parameters.Add("@ci", SqlDbType.VarChar, 15);
                command.Parameters.Add("@fecha", SqlDbType.Date);
                command.Parameters.Add("@cargo", SqlDbType.VarChar, 15);
                command.Parameters.Add("@oc", SqlDbType.VarChar, 15);
                command.Parameters["@cod"].Value = u.cod_us;
                command.Parameters["@nom"].Value = u.nombre;
                command.Parameters["@pat"].Value = u.paterno;
                command.Parameters["@mat"].Value = u.materno;
                command.Parameters["@ci"].Value = u.carnet;
                command.Parameters["@fecha"].Value = u.fechanac;
                command.Parameters["@cargo"].Value = u.cargo;
                command.Parameters["@oc"].Value = u.ocupacion;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //actualizar un Usuario
        public static int UPDUS(Usuariosclass u)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("UPDUS", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cod", SqlDbType.VarChar, 15);
                command.Parameters.Add("@nom", SqlDbType.VarChar, 15);
                command.Parameters.Add("@pat", SqlDbType.VarChar, 15);
                command.Parameters.Add("@mat", SqlDbType.VarChar, 15);
                command.Parameters.Add("@ci", SqlDbType.VarChar, 15);
                command.Parameters.Add("@fecha", SqlDbType.Date);
                command.Parameters.Add("@cargo", SqlDbType.VarChar, 15);
                command.Parameters.Add("@oc", SqlDbType.VarChar, 15);
                command.Parameters["@cod"].Value = u.cod_us;
                command.Parameters["@nom"].Value = u.nombre;
                command.Parameters["@pat"].Value = u.paterno;
                command.Parameters["@mat"].Value = u.materno;
                command.Parameters["@ci"].Value = u.carnet;
                command.Parameters["@fecha"].Value = u.fechanac;
                command.Parameters["@cargo"].Value = u.cargo;
                command.Parameters["@oc"].Value = u.ocupacion;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //elimina un estudiante
        public static int DLTESTPA(string cod)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("DLTUS", con);
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
                SqlCommand command = new SqlCommand("CONTUS", con);
                command.CommandType = CommandType.StoredProcedure;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "US");
                con.Close();
                DataTable tabla = datos.Tables["US"];
                return tabla;
            }
        }
    }
}
