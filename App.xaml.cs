using System;
using System.IO;
using System.Windows;

namespace EasyType
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ensure application directory exists for saving history
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "EasyType");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            // Set the working directory to ensure history file is saved in the right location
            Directory.SetCurrentDirectory(appDataPath);

            // Handle unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(
                $"An unhandled exception occurred: {ex?.Message}\n\nThe application will now close.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            // Log the error
            try
            {
                string logFile = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "EasyType",
                    "error.log");

                File.AppendAllText(logFile, $"{DateTime.Now}: {ex}\n\n");
            }
            catch
            {
                // If we can't log, just continue with shutdown
            }
        }
    }
}