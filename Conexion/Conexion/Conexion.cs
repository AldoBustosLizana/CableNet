using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Librerias
{
    public class Conexion
    {
        //Nos conectamos a la base de datos SqlServer
        public static SqlConnection Conectar()
        {
            SqlConnection conecta = new SqlConnection("Data Source =.; Initial Catalog = CableNet; Integrated Security = True");
            conecta.Open();
            return conecta;
        }
    }
}
