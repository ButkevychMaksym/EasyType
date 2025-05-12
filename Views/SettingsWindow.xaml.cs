using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using EasyType.Models;

namespace EasyType.Views
{
    public partial class SettingsWindow : Window, INotifyPropertyChanged
    {
        private int _testDuration;
        private string _selectedLanguage;
        private string _selectedTextMode;
        private readonly AppState _appState;
        private readonly TextProvider _textProvider;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int TestDuration
        {
            get => _testDuration;
            set
            {
                _testDuration = value;
                OnPropertyChanged();
            }
        }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTextMode
        {
            get => _selectedTextMode;
            set
            {
                _selectedTextMode = value;
                OnPropertyChanged();
            }
        }
        // ЗМІНЕНО: Оновлено назви режимів тексту для узгодженості
        public System.Collections.Generic.List<string> AvailableLanguages { get; }
        public System.Collections.Generic.List<string> TextModes { get; } = new() { "Окремі слова", "Цілі абзаци" };

        public SettingsWindow(AppState appState, TextProvider textProvider)
        {
            InitializeComponent();
            _appState = appState;
            _textProvider = textProvider;
            DataContext = this;

            TestDuration = _appState.TestDurationSeconds;
            SelectedLanguage = _appState.SelectedLanguage;
            SelectedTextMode = _appState.SelectedTextMode;

            AvailableLanguages = _textProvider.GetAvailableLanguages();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _appState.TestDurationSeconds = TestDuration;
            _appState.SelectedLanguage = SelectedLanguage;
            _appState.SelectedTextMode = SelectedTextMode;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}