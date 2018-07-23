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

using Librerias;

namespace Aplicacion
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        public MantenedorCliente reg = new MantenedorCliente();

        public Cliente clienteBuscado { get; set; }

        public Clientes()
        {
            InitializeComponent();
            limpiar();
        }

        public void limpiar()
        {
            txtNombres.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbCargaTipoCliente();
            btnActualizar.Visibility = Visibility.Collapsed;
            btnEliminar.Visibility = Visibility.Collapsed;
        }


        public void cmbCargaTipoCliente()
        {
            cmbTipoCliente.ItemsSource = cargaTipoCliente.cargaTiposClientes();
            cmbTipoCliente.DisplayMemberPath = "Descripcion";
            cmbTipoCliente.SelectedValuePath = "TipoCliente";
            cmbTipoCliente.SelectedIndex = 0;
        }

        //Método para Guardar Clientes, creando un nuevo objeto para posteriormente realizar la consulta
        public void guardarCliente()
        {
            string rutCompleto = txtRut.Text + "-" + txtDv.Text;
            if (MantenedorCliente.buscarRut(rutCompleto) == true)
            {
                MessageBox.Show("El rut ingresado ya esta registrado");
            }
            else
            {
                try
                {
                    int tipoCliente;
                    Cliente nCliente = new Cliente();
                    nCliente.Rut = txtRut.Text;
                    nCliente.Nombre = txtNombres.Text;
                    nCliente.APaterno = txtApPaterno.Text;
                    nCliente.AMaterno = txtApMaterno.Text;
                    nCliente.Telefono = txtTelefono.Text;
                    nCliente.Correo = txtCorreo.Text;
                    bool n1 = Int32.TryParse(cmbTipoCliente.SelectedValue.ToString(), out tipoCliente);
                    nCliente.TipoCliente = tipoCliente;
                    reg.AgregarCliente(nCliente);
                    MessageBox.Show("Cliente " + nCliente.Rut + " " + " Registrado Correctamente");
                    limpiar();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        //Método para buscar y mostrar cliente
        public void MostrarCliente(string pRut)
        {
            //Verificamos si el cliente Existe en el sistema
            if (MantenedorCliente.buscarRut(pRut) == true)
            {
                //Llenamos los datos del cliente
                clienteBuscado = MantenedorCliente.obtenerCliente(pRut);

                txtNombres.Text = clienteBuscado.Nombre;
                txtApPaterno.Text = clienteBuscado.APaterno;
                txtApMaterno.Text = clienteBuscado.AMaterno;
                txtTelefono.Text = clienteBuscado.Telefono;
                txtCorreo.Text = clienteBuscado.Correo;
                cmbTipoCliente.SelectedValue = clienteBuscado.TipoCliente;

                //Habilitamos el boton editar y evitamos que se cambie el rut del textbox
                btnActualizar.Visibility = Visibility.Visible;
                btnEliminar.Visibility = Visibility.Visible;
                btnGuardar.Visibility = Visibility.Collapsed;
            }
            btnActualizar.Visibility = Visibility.Collapsed;
            btnEliminar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Visible;
        }

        private void txtDv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRut.Text == "" || txtDv.Text == "")
            {
                limpiar();
            }
            else
            {
                MostrarCliente(txtRut.Text + "-" + txtDv.Text);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            guardarCliente();
        }

        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtDv.Clear();
        }
    }
}
