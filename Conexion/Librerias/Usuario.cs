using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias
{
    public class Usuario
    {
        private string _rut;
        private string _nombre;
        private string _aPaterno;
        private string _aMaterno;
        private string _telefono;
        private string _correo;
        private string _clave;
        private int _tipoUsuario;
        private int _idOficina;

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string APaterno
        {
            get
            {
                return _aPaterno;
            }

            set
            {
                _aPaterno = value;
            }
        }

        public string AMaterno
        {
            get
            {
                return _aMaterno;
            }

            set
            {
                _aMaterno = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        public string Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                _clave = value;
            }
        }

        public int TipoUsuario
        {
            get
            {
                return _tipoUsuario;
            }

            set
            {
                _tipoUsuario = value;
            }
        }

        public int IdOficina
        {
            get
            {
                return _idOficina;
            }

            set
            {
                _idOficina = value;
            }
        }
    }
}
