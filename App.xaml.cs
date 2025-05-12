using System;
using System.IO;
using System.Windows;

namespace EasyType
{
    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "EasyType");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            
            Directory.SetCurrentDirectory(appDataPath);

            
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
                
            }
        }
    }
}