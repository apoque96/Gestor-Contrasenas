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
    /// Interaction logic for SettingsMenu.xaml
    /// </summary>
    public partial class SettingsMenu : UserControl
    {
        public event EventHandler ExitButtonClicked;
        public event EventHandler SaveButtonClicked;

        public SettingsMenu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            uint clipboardTime;
            uint inactivityTime;
            string masterKey = tbMasterKey.Text;
            // Creates custom messages to display when clipboard and inactivity time are invalid
            try
            {
                clipboardTime = uint.Parse(tbClipboardTime.Text);
            }
            catch
            {
                MessageBox.Show("Clipboard Time can't be negative");
                return;
            }

            try
            {
                inactivityTime = uint.Parse(tbInactivityTime.Text);
                if (inactivityTime < 10)
                    throw new ArgumentException();
            }
            catch
            {
                MessageBox.Show("Inactivity Time should be greater than 10");
                return;
            }

            try
            {
                Settings settings = new(clipboardTime, inactivityTime, masterKey);
                MainWindow.settings = settings;
                SaveButtonClicked?.Invoke(this, EventArgs.Empty);
                tbClipboardTime.Clear();
                tbInactivityTime.Clear();
                tbMasterKey.Clear();
            }
            catch(Exception ex) 
            {
                    MessageBox.Show(ex.Message);
            }
        }
    }
}
