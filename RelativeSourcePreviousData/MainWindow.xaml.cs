using System.Collections.Generic;
using System.Windows;

namespace RelativeSourcePreviousData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataItemsControl.ItemsSource = GetData();
        }

        private IEnumerable<Item> GetData()
        {
            return new List<Item>
            {
                new Item { Value = 50 },
                new Item { Value = 80 },
                new Item { Value = 57 },
                new Item { Value = 53 },
                new Item { Value = 48 },
                new Item { Value = 100 },
                new Item { Value = 147 },
                new Item { Value = 53 },
                new Item { Value = 95 },
                new Item { Value = 0 },
                new Item { Value = 75 },
                new Item { Value = 16 },
                new Item { Value = 72 },
                new Item { Value = 88 }
            };
        }
    }
}
