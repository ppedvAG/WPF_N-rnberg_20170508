using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DependencyProperties
{
    public class TextLabel : FrameworkElement
    {


        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(TextLabel), new PropertyMetadata(Brushes.LightGray));


        public static readonly DependencyProperty FontSizeProperty;
        public static readonly DependencyProperty TextProperty;
        public static readonly DependencyProperty ForegroundProperty;
        
        static TextLabel()
        {
            var metadata = new FrameworkPropertyMetadata(
                defaultValue: 11.0,
                flags: FrameworkPropertyMetadataOptions.AffectsMeasure);

            FontSizeProperty = DependencyProperty.Register(
                name: nameof(FontSize),
                propertyType: typeof(double),
                ownerType: typeof(TextLabel),
                typeMetadata: metadata,
                validateValueCallback: v => (double)v > 0);

            TextProperty = DependencyProperty.Register(
                name: nameof(Text),
                propertyType: typeof(string),
                ownerType: typeof(TextLabel),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: string.Empty,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure | 
                           FrameworkPropertyMetadataOptions.AffectsRender));

            ForegroundProperty = DependencyProperty.Register(
                name: nameof(Foreground),
                propertyType: typeof(Brush),
                ownerType: typeof(TextLabel),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: Brushes.Black,
                    flags: FrameworkPropertyMetadataOptions.AffectsRender));
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Background, null, new Rect(RenderSize));
            drawingContext.DrawText(GetFormattedText(), new Point(2.5, 2.5));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var text = GetFormattedText();
            return new Size(text.Width + 5, text.Height + 5);
        }

        private FormattedText GetFormattedText()
        {
            return new FormattedText(
                Text,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                FontSize,
                Foreground);
        }
    }
}
