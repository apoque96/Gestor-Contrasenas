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
        private MainMenu mainMenu;

        public Header()
        {
            InitializeComponent();
        }

        //Initialize method for changing the menu
        public void Initialize(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            if(mainMenu != null)
                mainMenu.SwitchToAccountForm();
        }

        private void ExportFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (mainMenu != null)
                mainMenu.SwitchToHome();
        }
    }
}
