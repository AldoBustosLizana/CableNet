using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias
{
    public class Servicio
    {
        private string _idServicio;
        private int _tipoServicio;
        private string _descripcion;
        private int _valor;

        public string IdServicio
        {
            get
            {
                return _idServicio;
            }

            set
            {
                _idServicio = value;
            }
        }

        public int TipoServicio
        {
            get
            {
                return _tipoServicio;
            }

            set
            {
                _tipoServicio = value;
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

        public int Valor
        {
            get
            {
                return _valor;
            }

            set
            {
                _valor = value;
            }
        }
    }
}
