using System;
using System.Windows;
using System.Windows.Media;

namespace Resources
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

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            var brush = FindResource("defaultBackgroundColor") as SolidColorBrush;
            //var brush = Resources["defaultBackgroundColor"] as SolidColorBrush;

            if (brush != null)
                brush.Color = Colors.Honeydew;
        }

        private void ChangeInstanceButton_Click(object sender, RoutedEventArgs e)
        {
            Resources["defaultBackgroundColor"] = new SolidColorBrush(Colors.MediumPurple);
        }

        private void ChangeTypeButton_Click(object sender, RoutedEventArgs e)
        {
            var brush = new RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.White, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Black, 1));

            Resources["defaultBackgroundColor"] = brush;
        }
    }
}
