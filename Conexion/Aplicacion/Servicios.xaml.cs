using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//Using Libreria de clases
using Librerias;

namespace Aplicacion
{
    /// <summary>
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : UserControl
    {
        public MantenedorServicio reg = new MantenedorServicio();

        public Servicios()
        {
            InitializeComponent();
            limpiar();
        }

        //Método para cargar Combobox TipoServicio
        public void cargarCmbTipoServicio()
        {
            cmbTipoServicio.ItemsSource = cargaTipoServicio.cargaTiposServicios();
            cmbTipoServicio.DisplayMemberPath = "Descripcion";
            cmbTipoServicio.SelectedValuePath = "TipoServicio";
            cmbTipoServicio.SelectedIndex = 0;
        }

        //Método para limpiar el formulario
        public void limpiar()
        {
            txtCodigoServicio.Clear();
            txtCodigoServicio.IsReadOnly = true;
            txtDescripcion.Clear();
            txtValor.Clear();
            cargarCmbTipoServicio();
            btnActualizar.Visibility = Visibility.Collapsed;
            btnEliminar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Visible;
        }

        //Método para comprobar campos vacíos
        public bool comprobarVacios()
        {
            bool vacios = false;
            if (txtCodigoServicio.Text == "" || txtDescripcion.Text == "" || txtValor.Text == "")
            {
                vacios = true;
            }
            return vacios;
        }

        //Método para Guardar Clientes, creando un nuevo objeto para posteriormente realizar la consulta
        public void guardarServicio()
        {
            try
            {
                int tipoServicio, valor;
                Servicio objServicio = new Servicio();
                objServicio.IdServicio = txtCodigoServicio.Text;

                bool n1 = Int32.TryParse(cmbTipoServicio.SelectedValue.ToString(), out tipoServicio);
                objServicio.TipoServicio = tipoServicio;
                objServicio.Descripcion = txtDescripcion.Text;

                bool n2 = Int32.TryParse(txtValor.Text, out valor);
                objServicio.Valor = valor;
                reg.AgregarServicio(objServicio);
                MessageBox.Show("Servicio " + objServicio.Descripcion + " Registrado Correctamente con costo: $" + objServicio.Valor);
                limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarVacios() == true)
            {
                MessageBox.Show("Se deben llenar todos los campos para guardar el Servicio");
            }
            else
            {
                guardarServicio();
            }
        }
    }
}