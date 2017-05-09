using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Item> _items = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = _items;
        }

        private void executePreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            _items.Add(new Item { EventName = "PreviewMouseDown", ControlName = control.Name });

            if (control.Name == "RedRectangle")
                e.Handled = true;
        }

        private void executeMouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            _items.Add(new Item { EventName = "MouseDown", ControlName = control.Name });
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _items.Clear();
        }
    }
}
