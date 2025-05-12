using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections.Generic;

namespace EasyType.Views
{
    public class TextRenderer
    {
        private readonly RichTextBox _textBox;
        private Paragraph _mainParagraph;
        private List<Run> _characterRuns;

        private readonly SolidColorBrush _correctColorBrush = new(Color.FromRgb(152, 195, 121));
        private readonly SolidColorBrush _incorrectColorBrush = new(Color.FromRgb(224, 108, 117));
        private readonly SolidColorBrush _pendingColorBrush = new(Color.FromRgb(171, 178, 191));
        private readonly SolidColorBrush _cursorColorBrush = new(Color.FromRgb(97, 175, 239));
        private readonly SolidColorBrush _incorrectBackgroundBrush = new(Color.FromRgb(60, 60, 70));

        public TextRenderer(RichTextBox textBox)
        {
            _textBox = textBox;
            _mainParagraph = new Paragraph();
            _characterRuns = new List<Run>();
            _textBox.Document.Blocks.Add(_mainParagraph);
        }

        public void RenderText(string text, string userInput)
        {

            if (_characterRuns.Count != text.Length)
            {

                RebuildRuns(text);
            }


            int previousCursorPosition = -1;


            if (userInput.Length > 0 && userInput.Length - 1 < _characterRuns.Count)
            {
                // Якщо курсор змінив позицію або текст оновився, перерендерити відповідні символи
            }


            for (int i = 0; i < text.Length; i++)
            {
                Run run = _characterRuns[i];


                run.Background = Brushes.Transparent;
                run.FontWeight = FontWeights.Normal;

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
            }
        }

        private void RebuildRuns(string text)
        {
            _mainParagraph.Inlines.Clear();
            _characterRuns.Clear();

            for (int i = 0; i < text.Length; i++)
            {
                Run run = new Run(text[i].ToString());
                _mainParagraph.Inlines.Add(run);
                _characterRuns.Add(run);
            }
        }
    }
}