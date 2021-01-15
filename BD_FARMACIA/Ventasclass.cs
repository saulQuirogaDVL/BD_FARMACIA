using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BD_FARMACIA
{
    class Ventasclass
    {

        public Ventasclass(){}
        
        //busca a al cliente y verifica si existe
        public static DataTable VAL(string car)
        {            
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("VALCLI", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@car", SqlDbType.VarChar, 15);
                command.Parameters["@car"].Value = car;
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "cli");
                con.Close();
                DataTable tabla = datos.Tables["cli"];
                return tabla;
            }
        }

        //agrega un cliente
        public static int AGRCLI(string car, string ap)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("AGRCLI", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@car", SqlDbType.VarChar, 15);
                command.Parameters.Add("@ap", SqlDbType.VarChar, 15);
                command.Parameters["@car"].Value = car;
                command.Parameters["@ap"].Value = ap;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //valida el stock
        public static int stk(string cant, string nom)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("VALSTK", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@cant", SqlDbType.Int);
                command.Parameters.Add("@nom", SqlDbType.VarChar, 15);
                command.Parameters["@cant"].Value = cant;
                command.Parameters["@nom"].Value = nom;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        public static DataTable CONTADOR()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("CONT", con);
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


        public static int AGRORDPA(string nit, string carnet)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("AGRFAC", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nit", SqlDbType.VarChar, 15);
                command.Parameters.Add("@carnet", SqlDbType.VarChar, 15);
                command.Parameters["@nit"].Value = nit;
                command.Parameters["@carnet"].Value = carnet;
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        //agregar ventas
        public static int adds(string nit, string car, string cod, string cant)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand("ADDS", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@NIT", SqlDbType.VarChar, 15);
                command.Parameters.Add("@car", SqlDbType.Int);
                command.Parameters.Add("@cod", SqlDbType.VarChar,15);
                command.Parameters.Add("@cant", SqlDbType.VarChar, 15);

                command.Parameters["@NIT"].Value = nit;
                command.Parameters["@car"].Value = car;
                command.Parameters["@cod"].Value = cod;
                command.Parameters["@cant"].Value = int.Parse(cant);
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

       

    }
}
