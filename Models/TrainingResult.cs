using System;
using EasyType.Models;

namespace EasyType.Models
{
    public class TrainingResult(AppState appState)
    {
        public DateTime DateTime { get; } = DateTime.Now;
        public double WPM { get; } = appState.WPM;
        public double Accuracy { get; } = appState.Accuracy;
        public string LanguageUsed { get; } = appState.SelectedLanguage;
        public int TestDurationSeconds { get; } = appState.TestDurationSeconds;
        public string TextModeUsed { get; } = appState.SelectedTextMode; // Додано режим тексту
    }
}