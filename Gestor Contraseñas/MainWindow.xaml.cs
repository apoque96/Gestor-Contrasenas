using Gestor_Contraseñas.Models;
using Gestor_Contraseñas.Views.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gestor_Contraseñas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Instance of the main menu
        public static MainMenu mainMenu;
        public static Settings settings;

        //Timer for opening/closing the settings menu
        DispatcherTimer timer;
        DispatcherTimer idleTimer;
        bool hidden = true;
        bool block = false;

        public MainWindow()
        {
            InitializeComponent();
            mainMenu = MainMenuControl;
            // Used for the opening/closing settings menu animation
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            settings = new Settings();
            settings.ReadSettings();
            // Checks inactivity every second
            idleTimer = new DispatcherTimer();
            idleTimer.Interval = new TimeSpan(0, 0, 1);
            idleTimer.Tick += Idle_Tick;
            idleTimer.Start();
        }

        private void Idle_Tick(object? sender, EventArgs e)
        {
            var idleTime = IdleTimeDetector.GetIdleTimeInfo();

            //Idle
            if (idleTime.IdleTime.TotalSeconds >= settings.inactivityTimeSeconds)
            {
                MainGridColumn.Width = new GridLength(0, GridUnitType.Star);
                BlockGridColumn.Width = new GridLength(1, GridUnitType.Star);
                block = true;
            }
            //Not idle
            else if (block)
            {
                MainGridColumn.Width = new GridLength(1, GridUnitType.Star);
                BlockGridColumn.Width = new GridLength(0, GridUnitType.Star);
                block = false;
            }
        }

        // Opens/Closes the settings menu
        private void Timer_Tick(object? sender, EventArgs e)
        {
            int difference = 15;

            if (hidden)
            {
                SettingsColumn.Width = new GridLength(SettingsColumn.Width.Value + difference, GridUnitType.Pixel);

                if(SettingsColumn.Width.Value >= 150)
                {
                    timer.Stop();
                    SettingsColumn.Width = new GridLength(150, GridUnitType.Pixel);
                    hidden = false;
                }
            }
            else
            {
                SettingsColumn.Width = new GridLength(SettingsColumn.Width.Value - difference, GridUnitType.Pixel);

                if (SettingsColumn.Width.Value <= 0)
                {
                    timer.Stop();
                    SettingsColumn.Width = new GridLength(0, GridUnitType.Pixel);
                    hidden = true;
                }
            }
        }

        private void HeaderControl_ButtonClicked(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void SettingsMenuControl_ExitButtonClicked(object sender, EventArgs e)
        {
            HeaderControl.ShowSettingsButton();
            timer.Start();
        }

        private void SettingsMenuControl_SaveButtonClicked(object sender, EventArgs e)
        {
            HeaderControl.ShowSettingsButton();
            timer.Start();
        }
    }
}