using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BD_FARMACIA
{
    class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conectionn = new SqlConnection("Data Source=DESKTOP-3II9BC5; Initial Catalog=PROYECTO_FARMACIA;Integrated Security=true");
            conectionn.Open();
            return conectionn;
        }
    }
}
