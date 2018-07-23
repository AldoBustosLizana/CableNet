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
using System.Windows.Navigation;
using System.Windows.Shapes;

//Using necesarios para los MahApps
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

//Using necesario para las Clases
using Librerias;

namespace Aplicacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Usuario usuarioBuscado { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        //Método para validar el usuario
        public async void ingresoUsuario()
        {
            if (MantenedorUsuario.buscarv2(txtRut.Text, txtClave.Password) == true)
            {
                barraCarga.Visibility = Visibility;
                usuarioBuscado = MantenedorUsuario.ObtenerUsuario(txtRut.Text);
                string nombreEjecutivo = usuarioBuscado.Nombre + " " + usuarioBuscado.APaterno + " " + usuarioBuscado.AMaterno;
                MenuPrincipal ventanaPrincipal = new MenuPrincipal();
                await this.ShowMessageAsync("Bienvenido", "Sr/a. " + nombreEjecutivo);

                ventanaPrincipal.Owner = this;
                ventanaPrincipal.lblEjecutivo.Content = nombreEjecutivo;
                ventanaPrincipal.lblTipoUsuario.Content = Mantenedor.tipoUsuario(usuarioBuscado.TipoUsuario);
                ventanaPrincipal.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Ingreso Fallido", "Los datos ingresados son incorrectos, vuelva a intentarlo");
            }
        }


        private async void confirmaSalida()
        {
            var result = await this.ShowMessageAsync("Salir", "Está seguro que desea salir de la aplicación?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                this.Close();
            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            ingresoUsuario();
        }

        private void btnSalir_MouseDown(object sender, MouseButtonEventArgs e)
        {
            confirmaSalida();
        }
    }
}
