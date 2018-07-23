using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Libreria para BD
using System.Data.SqlClient;

namespace Librerias
{
    public class MantenedorUsuario
    {
        //Método para Verificar si el Ejecutivo existe
        public static bool buscarv2(string rut, string clave)
        {
            bool existe = false;
            SqlConnection conn = Conexion.Conectar();
            SqlCommand comando = new SqlCommand(string.Format(
                         "Select * From USUARIO Where RUT = '{0}' and CLAVE ='{1}'", rut, clave), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                existe = true;
            }
            conn.Close();
            return existe;
        }

        //Obtenemos Datos del empleado
        public static Usuario ObtenerUsuario(string eRut)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                Usuario obtenerUsuario = new Usuario();
                SqlCommand comando = new SqlCommand(
                    string.Format("SELECT * FROM USUARIO WHERE RUT = '{0}'", eRut), conn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    obtenerUsuario.Rut = reader.GetString(0);
                    obtenerUsuario.Nombre = reader.GetString(1);
                    obtenerUsuario.APaterno = reader.GetString(2);
                    obtenerUsuario.AMaterno = reader.GetString(3);
                    obtenerUsuario.Telefono = reader.GetString(4);
                    obtenerUsuario.Correo = reader.GetString(5);
                    obtenerUsuario.Clave = reader.GetString(6);
                    obtenerUsuario.TipoUsuario = reader.GetInt32(7);
                    obtenerUsuario.IdOficina = reader.GetInt32(8);
                }
                conn.Close();
                return obtenerUsuario;
            }
        }

    }
}
