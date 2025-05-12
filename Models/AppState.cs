using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EasyType.Models
{
    public class AppState : INotifyPropertyChanged
    {
        private int _testDurationSeconds;
        private int _remainingTime;
        private bool _isActive;
        private string _currentText = string.Empty;
        private int _correctChars;
        private int _incorrectChars;
        private DateTime _startTime;
        private string _selectedLanguage = "English";
        private string _selectedTextMode = "Випадкові слова"; // Додана властивість

        public event PropertyChangedEventHandler? PropertyChanged;

        public AppState()
        {
            TestDurationSeconds = 60;
            RemainingTime = TestDurationSeconds;
            IsActive = false;
        }

        public int TestDurationSeconds
        {
            get => _testDurationSeconds;
            set
            {
                if (_testDurationSeconds != value)
                {
                    _testDurationSeconds = value;
                    RemainingTime = value;
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
                    OnPropertyChanged(nameof(Accuracy));
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

        public string SelectedTextMode // Додана властивість
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

        public double WPM
        {
            get
            {
                int totalSeconds = TestDurationSeconds - RemainingTime;
                if (totalSeconds == 0) return 0;
                double minutes = totalSeconds / 60.0;
                return CorrectChars / 5.0 / minutes;
            }
        }

        public double Accuracy
        {
            get
            {
                int totalChars = CorrectChars + IncorrectChars;
                if (totalChars == 0) return 100.0;
                return (double)CorrectChars / totalChars * 100.0;
            }
        }

        public void Reset()
        {
            IsActive = false;
            CorrectChars = 0;
            IncorrectChars = 0;
            RemainingTime = TestDurationSeconds;
        }

        public void ToggleTestDuration()
        {
            TestDurationSeconds = TestDurationSeconds switch
            {
                30 => 60,
                60 => 120,
                _ => 30
            };
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}