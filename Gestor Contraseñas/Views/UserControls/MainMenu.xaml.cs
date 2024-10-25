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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void SwitchToAccountForm()
        {
            MenuContent.Children.Clear();
            MenuContent.Children.Add(new AccountForm());
        }

        public void SwitchToHome()
        {
            MenuContent.Children.Clear();
            MenuContent.Children.Add(new Home());
        }

        public void SwitchToAccountCard()
        {
            MenuContent.Children.Clear();
            MenuContent.Children.Add(new AccountCard());
        }
    }
}
