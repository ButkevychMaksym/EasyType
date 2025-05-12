using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EasyType.Views
{
    public class TextRenderer(RichTextBox textBox)
    {
        private readonly RichTextBox _textBox = textBox;

        private readonly SolidColorBrush _correctColorBrush = new(Color.FromRgb(152, 195, 121)); // Green
        private readonly SolidColorBrush _incorrectColorBrush = new(Color.FromRgb(224, 108, 117)); // Red
        private readonly SolidColorBrush _pendingColorBrush = new(Color.FromRgb(171, 178, 191)); // Light gray
        private readonly SolidColorBrush _cursorColorBrush = new(Color.FromRgb(97, 175, 239));    // Blue
        private readonly SolidColorBrush _incorrectBackgroundBrush = new(Color.FromRgb(60, 60, 70));

        public void RenderText(string text, string userInput)
        {
            _textBox.Document.Blocks.Clear();
            Paragraph paragraph = new();

            for (int i = 0; i < text.Length; i++)
            {
                Run run = new(text[i].ToString());

                if (i < userInput.Length)
                {
                    if (text[i] == userInput[i])
                    {
                        run.Foreground = _correctColorBrush;
                    }
                    else
                    {
                        run.Foreground = _incorrectColorBrush;
                        run.Background = _incorrectBackgroundBrush;
                    }
                }
                else if (i == userInput.Length)
                {
                    run.Foreground = _cursorColorBrush;
                    run.FontWeight = FontWeights.Bold;
                }
                else
                {
                    run.Foreground = _pendingColorBrush;
                }
                paragraph.Inlines.Add(run);
            }

            _textBox.Document.Blocks.Add(paragraph);
        }
    }
}