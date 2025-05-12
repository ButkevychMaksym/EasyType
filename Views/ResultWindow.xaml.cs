using System.Windows;
using EasyType.Models;

namespace EasyType.Views
{
    public partial class ResultWindow : Window
    {
        public ResultWindow(TrainingResult result)
        {
            InitializeComponent();


            WpmTextBlock.Text = result.WPM.ToString("F0");
            AccuracyTextBlock.Text = result.Accuracy.ToString("F0");
            LanguageTextBlock.Text = result.LanguageUsed;
            TextModeTextBlock.Text = result.TextModeUsed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
            Close();
        }
    }
}