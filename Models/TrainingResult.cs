using System;

namespace EasyType.Models
{
    public class TrainingResult
    {
        public DateTime Date { get; set; }
        public double WPM { get; set; }
        public double Accuracy { get; set; }
        public string LanguageUsed { get; set; }
        public string TextModeUsed { get; set; }
        public int TestDurationSeconds { get; set; }
        public int CorrectChars { get; set; }
        public int IncorrectChars { get; set; }

        // Default constructor for deserialization
        public TrainingResult() { }

        public TrainingResult(AppState appState)
        {
            Date = DateTime.Now;
            WPM = appState.WPM;
            Accuracy = appState.Accuracy;
            LanguageUsed = appState.SelectedLanguage;
            TextModeUsed = appState.SelectedTextMode;
            TestDurationSeconds = appState.TestDurationSeconds;
            CorrectChars = appState.CorrectChars;
            IncorrectChars = appState.IncorrectChars;
        }
    }
}