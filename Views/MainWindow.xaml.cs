using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using EasyType.ViewModels;

namespace EasyType.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly TextRenderer _textRenderer;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainViewModel)DataContext;
            _textRenderer = new TextRenderer(DisplayText);
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateDisplayText();
            InputText.Focus(); // Встановлюємо фокус на поле введення при запуску
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.DisplayText) ||
                e.PropertyName == nameof(_viewModel.UserInput))
            {
                UpdateDisplayText();
            }
        }

        private void UpdateDisplayText()
        {
            _textRenderer.RenderText(
                _viewModel.DisplayText,
                _viewModel.UserInput);

            if (_viewModel.AppState.IsActive && !InputText.IsFocused)
            {
                InputText.Focus();
            }
        }
    }
}