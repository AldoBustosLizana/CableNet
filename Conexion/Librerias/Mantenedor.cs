using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Librerias
{
    public class Mantenedor
    {
        public static string tipoUsuario (int idTipo)
        {
            string nombre = "";
            SqlConnection conn = Conexion.Conectar();
            SqlCommand comando = new SqlCommand(string.Format("SELECT DESCRIPCION FROM TIPO_USUARIO WHERE ID_TIPO = '{0}'", idTipo), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                nombre = reader.GetString(0);
            }
            conn.Close();
            return nombre;
        }

    }
}
