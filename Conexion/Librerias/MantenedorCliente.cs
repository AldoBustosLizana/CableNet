using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Librerias
{
    public class MantenedorCliente
    {
        //Método para verificar si el rut ya existe
        public static bool buscarRut(string rut)
        {
            bool existe = false;
            SqlConnection conn = Conexion.Conectar();
            SqlCommand comando = new SqlCommand(string.Format(
                "SELECT * FROM CLIENTE WHERE RUT = '{0}'", rut), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                existe = true;
            }
            conn.Close();
            return existe;
        }

        //Método para obtener los datos del Cliente
        public static Cliente obtenerCliente(string rutCliente)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                Cliente dCliente = new Cliente();
                SqlCommand comando = new SqlCommand(
                    string.Format("SELECT * FROM CLIENTE WHERE RUT ='{0}'", rutCliente), conn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    dCliente.Rut = reader.GetString(0);
                    dCliente.Nombre = reader.GetString(1);
                    dCliente.APaterno = reader.GetString(2);
                    dCliente.AMaterno = reader.GetString(3);
                    dCliente.Telefono = reader.GetString(4);
                    dCliente.Correo = reader.GetString(5);
                    dCliente.TipoCliente = reader.GetInt32(6);
                }
                conn.Close();
                return dCliente;
            }
        }

        //Método para Guardar Cliente
        public void AgregarCliente(Cliente gCliente)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand comando = new SqlCommand(
                    string.Format("INSERT INTO CLIENTE VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}')",
                    gCliente.Rut, gCliente.Nombre, gCliente.APaterno, gCliente.AMaterno, gCliente.Telefono, gCliente.Correo, gCliente.TipoCliente), conn);
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }


    }
}