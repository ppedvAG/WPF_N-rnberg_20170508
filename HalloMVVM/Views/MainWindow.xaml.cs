using System.Windows;

namespace HalloMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeTextButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewModels.MainWindowViewModel).WelcomeText = "Hallo aus dem Code Behind";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
