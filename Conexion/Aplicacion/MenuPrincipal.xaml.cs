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

//Using necesarios para los MahApps
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

//Using necesario para las Clases
using Librerias;

//Using necesario para el evento empezar Reloj
using System.Windows.Threading;

namespace Aplicacion
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : MetroWindow
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            EmpezarReloj();
        }


        public void EmpezarReloj()
        {
            DispatcherTimer reloj = new DispatcherTimer();
            reloj.Interval = TimeSpan.FromSeconds(1);
            reloj.Tick += tickevent;
            reloj.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtReloj.Text = DateTime.Now.ToString();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Inicio":
                    MessageBox.Show("Inicio");
                    break;
                case "Cliente":
                    usc = new Clientes();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                    /*
                case "Clientes":
                    usc = new MenuCliente();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "Pagos":
                    usc = new MenuDepositos();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "Destinos":
                    usc = new MenuDestinos();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;*/
                default:
                    break;
            }
        }

        private void btnAbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            abrirMenu();
        }

        public void abrirMenu()
        {
            btnCerrarMenu.Visibility = Visibility.Visible;
            btnAbrirMenu.Visibility = Visibility.Collapsed;
            txtReloj.Visibility = Visibility.Visible;
        }


        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCerrarMenu.Visibility = Visibility.Collapsed;
            btnAbrirMenu.Visibility = Visibility.Visible;
            txtReloj.Visibility = Visibility.Collapsed;
        }

        private void btnSalir_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
