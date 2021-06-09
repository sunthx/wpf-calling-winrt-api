using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.ViewManagement;

namespace CallingWin10API.NET47
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UISettings _currentUiSettings;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;

            _currentUiSettings = new UISettings();
            //当主题色改变时，获取通知
            _currentUiSettings.ColorValuesChanged += UiSettingsOnColorValuesChanged;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ShowWinColor();
        }

        private void UiSettingsOnColorValuesChanged(UISettings sender, object args)
        {
            Dispatcher.Invoke(ShowWinColor);
        }

        private void ShowWinColor()
        {
            var color = _currentUiSettings.GetColorValue(UIColorType.Background).ToString();
            TbWinColor.Text = $"Windows Color: {color}";
            GdContainer.Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString(color));
        }
    }
}
