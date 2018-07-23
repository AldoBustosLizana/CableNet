using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias
{
    public class Cliente
    {
        private string _rut;
        private string _nombre;
        private string _aPaterno;
        private string _aMaterno;
        private string _telefono;
        private string _correo;
        private int _tipoCliente;

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
    }
}
