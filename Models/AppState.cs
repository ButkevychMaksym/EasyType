using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyType.Models
{
    public class AppState : INotifyPropertyChanged
    {
        private int _testDurationSeconds = 60;
        private string _selectedLanguage = "Українська";
        private string _selectedTextMode = "Окремі слова";
        private string _currentText = string.Empty;
        private bool _isActive = false;
        private int _correctChars = 0;
        private int _incorrectChars = 0;
        private DateTime _startTime;
        private int _remainingTime; 

        public event PropertyChangedEventHandler? PropertyChanged;

        public int TestDurationSeconds
        {
            get => _testDurationSeconds;
            set
            {
                if (_testDurationSeconds != value)
                {
                    _testDurationSeconds = value;
                    OnPropertyChanged();
                    RemainingTime = value; 
                }
            }
        }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedTextMode
        {
            get => _selectedTextMode;
            set
            {
                if (_selectedTextMode != value)
                {
                    _selectedTextMode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrentText
        {
            get => _currentText;
            set
            {
                if (_currentText != value)
                {
                    _currentText = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CorrectChars
        {
            get => _correctChars;
            set
            {
                if (_correctChars != value)
                {
                    _correctChars = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(WPM));
                    OnPropertyChanged(nameof(Accuracy));
                }
            }
        }

        public int IncorrectChars
        {
            get => _incorrectChars;
            set
            {
                if (_incorrectChars != value)
                {
                    _incorrectChars = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(WPM));
                    OnPropertyChanged(nameof(Accuracy));
                }
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RemainingTime
        {
            get => _remainingTime;
            set
            {
                if (_remainingTime != value)
                {
                    _remainingTime = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(WPM));
                    OnPropertyChanged(nameof(Accuracy));
                }
            }
        }

        public double WPM
        {
            get
            {
                if (!IsActive && TestDurationSeconds == RemainingTime && CorrectChars == 0) return 0; 

                double elapsedSeconds = TestDurationSeconds - RemainingTime;
                if (elapsedSeconds <= 0) return 0;


                return (CorrectChars / 5.0) / (elapsedSeconds / 60.0);
            }
        }

        public double Accuracy
        {
            get
            {
                int totalChars = CorrectChars + IncorrectChars;
                if (totalChars == 0) return 0;
                return (double)CorrectChars / totalChars * 100;
            }
        }

        public void Reset()
        {
            IsActive = false;
            CorrectChars = 0;
            IncorrectChars = 0;
            RemainingTime = TestDurationSeconds;
            CurrentText = string.Empty;

        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}