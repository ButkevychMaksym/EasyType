using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using EasyType.Models; 
using EasyType.Views;

namespace EasyType.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly AppState _appState;
        private readonly TextProvider _textProvider;
        private readonly DispatcherTimer _timer = new();

        private string _userInput = string.Empty;
        private int _currentPosition;
        private bool _isLastCharCorrect;
        private string _displayText = "Натисніть 'Старт' щоб почати.";

        public event PropertyChangedEventHandler? PropertyChanged;

        public AppState AppState => _appState;
        public List<string> TextModes { get; } = new() { "Окремі слова", "Цілі абзаци" };

        public ICommand StartCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand OpenSettingsCommand { get; }

        public MainViewModel()
        {
            _appState = new AppState();
            _textProvider = new TextProvider();

            StartCommand = new RelayCommand(_ => StartTest(), _ => !_appState.IsActive);
            ResetCommand = new RelayCommand(_ => ResetTest(), _ => _appState.IsActive || _appState.RemainingTime < _appState.TestDurationSeconds);
            OpenSettingsCommand = new RelayCommand(_ => OpenSettings());

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            _appState.PropertyChanged += AppState_PropertyChanged;
        }

        public string UserInput
        {
            get => _userInput;
            set
            {
                if (_userInput != value)
                {
                    _userInput = value;
                    OnPropertyChanged();
                    ProcessUserInput();
                }
            }
        }

        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CurrentPosition => _currentPosition;
        public bool IsLastCharCorrect => _isLastCharCorrect;

        private void AppState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(AppState.WPM) || e.PropertyName == nameof(AppState.Accuracy) || e.PropertyName == nameof(AppState.RemainingTime))
            {
                OnPropertyChanged(nameof(AppState));
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _appState.RemainingTime--;

            if (_appState.RemainingTime <= 0)
            {
                EndTest();
            }
        }

        private void OpenSettings()
        {
            var settingsWindow = new SettingsWindow(_appState, _textProvider);
            if (settingsWindow.ShowDialog() == true)
            {

                (StartCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (ResetCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private void StartTest()
        {
            _appState.StartTime = DateTime.Now;
            _appState.IsActive = true;
            _currentPosition = 0;
            _appState.CorrectChars = 0;
            _appState.IncorrectChars = 0;
            _isLastCharCorrect = true;
            _appState.RemainingTime = _appState.TestDurationSeconds;

            _appState.CurrentText = _textProvider.GetRandomText(_appState.SelectedLanguage, _appState.SelectedTextMode);
            if (string.IsNullOrEmpty(_appState.CurrentText))
            {
                _appState.CurrentText = "Не вдалося завантажити текст."; 
            }

            UserInput = string.Empty;
            DisplayText = _appState.CurrentText;

            (StartCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (ResetCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (OpenSettingsCommand as RelayCommand)?.RaiseCanExecuteChanged();

            _timer.Start();

            OnPropertyChanged(nameof(DisplayText));
        }

        private void EndTest()
        {
            _timer.Stop();
            _appState.IsActive = false;

            var resultWindow = new ResultWindow(new TrainingResult(_appState)); 
            if (Application.Current.MainWindow != null)
            {
                resultWindow.Owner = Application.Current.MainWindow;
            }
            resultWindow.ShowDialog();

            (StartCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (ResetCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (OpenSettingsCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }

        private void ResetTest()
        {
            _timer.Stop();
            _appState.Reset();
            UserInput = string.Empty;
            _currentPosition = 0;
            _isLastCharCorrect = true;
            DisplayText = "Натисніть 'Старт' щоб почати.";

            (StartCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (ResetCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (OpenSettingsCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }

        private void ProcessUserInput()
        {
            if (!_appState.IsActive || string.IsNullOrEmpty(UserInput))
                return;

            string targetText = _appState.CurrentText;


            if (UserInput.Length < _currentPosition)
            {
                _currentPosition = UserInput.Length;
                OnPropertyChanged(nameof(DisplayText));
                return;
            }

            if (UserInput.Length > 0 && UserInput.Length <= targetText.Length)
            {
                int i = UserInput.Length - 1;

                if (i < targetText.Length)
                {
                    _isLastCharCorrect = UserInput[i] == targetText[i];


                    if (UserInput.Length > _currentPosition)
                    {
                        if (_isLastCharCorrect)
                            _appState.CorrectChars++;
                        else
                            _appState.IncorrectChars++;
                    }
                }

                _currentPosition = UserInput.Length;
                OnPropertyChanged(nameof(DisplayText));
            }
            else if (UserInput.Length > targetText.Length)
            {
                OnPropertyChanged(nameof(DisplayText));
            }


            if (UserInput.Length >= targetText.Length && _appState.IsActive)
            {
                EndTest();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
