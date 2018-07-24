using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Using para Conectar a SQLServer
using System.Data.SqlClient;

namespace Librerias
{
    public class MantenedorServicio
    {
        //Método para Agregar un Nuevo Servicio
        public void AgregarServicio(Servicio nServicio)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand comando = new SqlCommand(
                    string.Format("INSERT INTO SERVICIO VALUES ('{0}','{1}','{2}','{3}')",
                    nServicio.IdServicio, nServicio.TipoServicio, nServicio.Descripcion, nServicio.Valor), conn);
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }


    }
}
