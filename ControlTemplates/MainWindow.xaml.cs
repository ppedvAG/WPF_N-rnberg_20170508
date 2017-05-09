using System.Windows;

namespace ControlTemplates
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo!", "Die Nachricht:", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void NewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
