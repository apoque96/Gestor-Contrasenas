using Gestor_Contraseñas.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AccountForm.xaml
    /// </summary>
    public partial class AccountForm : UserControl
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string site_name = tbSiteName.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Password;
            string url = tbUrl.Text;
            string extra1 = tbExtra1.Text;
            string extra2 = tbExtra2.Text;
            string extra3 = tbExtra3.Text;
            string extra4 = tbExtra4.Text;
            string extra5 = tbExtra5.Text;
            ExtraFields extra_fields = new ExtraFields(extra1, extra2, extra3, extra4, extra5);
            string notes = tbNotes.Text;
            List<string> tags = tbTags.Text.Split(" ").ToList();
            string creation_date = dpCreationDate.SelectedDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string update_date = dpUpdateDate.SelectedDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);

            MainWindow.mainMenu.AddNewAccount(new Account(site_name, username, password, url, extra_fields, notes, tags, creation_date, update_date, "a"));

            MainWindow.mainMenu.SwitchToHome();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainMenu.SwitchToHome();
        }
    }
}
