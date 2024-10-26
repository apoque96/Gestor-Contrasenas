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

namespace Gestor_Contraseñas.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public event EventHandler ButtonClicked;

        public Header()
        {
            InitializeComponent();
        }

        public void ShowSettingsButton()
        {
            Settings.Visibility = Visibility.Visible;
        }

        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainMenu.SwitchToAccountForm();
        }

        private void ExportFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainMenu.SwitchToHome();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Visibility = Visibility.Collapsed;
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
