using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Librerias
{
    public class cargaTipoCliente
    {
        private int _tipoCliente;
        private string _descripcion;

        public int TipoCliente
        {
            get
            {
                return _tipoCliente;
            }

            set
            {
                _tipoCliente = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public static List<cargaTipoCliente> cargaTiposClientes()
        {
            List<cargaTipoCliente> cargaTiposClientes = new List<cargaTipoCliente>();
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select * from TIPO_CLIENTE"), conn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    cargaTipoCliente carga = new cargaTipoCliente();
                    carga.TipoCliente = reader.GetInt32(0);
                    carga.Descripcion = reader.GetString(1);
                    cargaTiposClientes.Add(carga);
                }
                conn.Close();
                return cargaTiposClientes;
            }
        }
    }
}
