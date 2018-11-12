using CustomShapeWpfButton.Enums;
using CustomShapeWpfButton.Utils;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomShapeWpfButton
{
    public class BaseArcButton : Button, INotifyPropertyChanged
    {
        #region Constants

        private const float ColorCoef = 0.8f;
        private const string DefaultBackground = "#dddddd";
        private const string DefaultBorderBrush = "#a29bfe";
        private const string DefaultForeground = "#000000";
        private const string DefaultFontFamily = "Consolas";
        private const double DefaultFontSize = 16D;
        private const double DefaultStrokeThickness = 1D;
        private const bool DefaultVisibility = true;
        private const string DefaultBorderBrushPressed = "#a29bfe";
        private const string DefaultBackgroundPressed = "#55efc4";
        private const string DefaultText = "N/A";
        private const double DefaultProportion = 2D;

        #endregion //Constants

        #region DependencyProperties

        public new readonly static DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultBackground));
        public new readonly static DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultBorderBrush));
        public new readonly static DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultForeground));
        public new readonly static DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultFontFamily));
        public new readonly static DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(BaseArcButton), new PropertyMetadata(DefaultFontSize));
        public new readonly static DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility", typeof(bool), typeof(BaseArcButton), new PropertyMetadata(DefaultVisibility));
        public readonly static DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(BaseArcButton), new PropertyMetadata(DefaultStrokeThickness));
        public readonly static DependencyProperty TextMarginProperty = DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(BaseArcButton), new PropertyMetadata(null));
        public readonly static DependencyProperty BorderBrushPressedProperty = DependencyProperty.Register("BorderBrushPressed", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultBorderBrushPressed));
        public readonly static DependencyProperty BackgroundPressedProperty = DependencyProperty.Register("BackgroundPressed", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultBackgroundPressed));
        public readonly static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BaseArcButton), new PropertyMetadata(DefaultText));
        public readonly static DependencyProperty ProportionProperty = DependencyProperty.Register("Proportion", typeof(double), typeof(BaseArcButton), new PropertyMetadata(DefaultProportion));

        #endregion //DependencyProperties

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion //NotifyPropertyChanged

        #region Properties

        public new string Background
        {
            get { return (string)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); NotifyPropertyChanged("Background"); }
        }

        public new string Foreground
        {
            get { return (string)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); NotifyPropertyChanged("Foreground"); }
        }

        public new string BorderBrush
        {
            get { return (string)GetValue(BorderBrushProperty); }
            set { SetValue(BackgroundProperty, value); NotifyPropertyChanged("BorderBrush"); }
        }

        public new string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); NotifyPropertyChanged("FontFamily"); }
        }

        public new double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); NotifyPropertyChanged("FontSize"); }
        }

        public new bool Visibility
        {
            get { return (bool)GetValue(VisibilityProperty); }
            set { SetValue(VisibilityProperty, value); NotifyPropertyChanged("Visibility"); }
        }

        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); NotifyPropertyChanged("TextMargin"); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); NotifyPropertyChanged("StrokeThickness"); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); NotifyPropertyChanged("Text"); }
        }

        public string BackgroundPressed
        {
            get { return (string)GetValue(BackgroundPressedProperty); }
            set { SetValue(BackgroundPressedProperty, value); NotifyPropertyChanged("BackgroundPressed"); }
        }

        public string BorderBrushPressed
        {
            get { return (string)GetValue(BorderBrushPressedProperty); }
            set { SetValue(BorderBrushPressedProperty, value); NotifyPropertyChanged("BorderBrushPressed"); }
        }

        public double Proportion
        {
            get { return (double)GetValue(ProportionProperty); }
            set { SetValue(ProportionProperty, value); NotifyPropertyChanged("Proportion"); }
        }

        public string BackgroundOver
        {
            get
            {
                var colorRgb = (Color)ColorConverter.ConvertFromString((string)GetValue(BackgroundProperty));
                var colorDarker = Color.FromRgb((byte)(colorRgb.R * ColorCoef), (byte)(colorRgb.G * ColorCoef), (byte)(colorRgb.B * ColorCoef));

                return colorDarker.ToString();
            }
        }

        public string BorderOver
        {
            get
            {
                var colorRgb = (Color)ColorConverter.ConvertFromString((string)GetValue(BorderBrushProperty));
                var colorDarker = Color.FromRgb((byte)(colorRgb.R * ColorCoef), (byte)(colorRgb.G * ColorCoef), (byte)(colorRgb.B * ColorCoef));

                return colorDarker.ToString();
            }
        }

        #endregion //Properties

        #region Constructors

        /// <summary>
        /// Defaut constructor.
        /// </summary>
        public BaseArcButton()
        {
        }

        /// <summary>
        /// Init the text value of the button.
        /// </summary>
        /// <param name="text"></param>
        public BaseArcButton(string text, Position position)
        {
            Text = text;
            Tag = position;

            this.Click += HandleClick;
        }

        #endregion //Constructors

        #region Methods

        /// <summary>
        /// Override render method to add margin to textblock.
        /// </summary>
        protected override void OnRender(DrawingContext dc)
        {
            DrawUtil.AdaptMarginTextblock(this);
        }

        /// <summary>
        /// Forward the click event to the right ArcButton.Event.
        /// </summary>
        protected void HandleClick(object sender, RoutedEventArgs e)
        {
            if (sender is BaseArcButton)
            {
                var button = (BaseArcButton)sender;
                var position = (Position)button.Tag;

                switch (position)
                {
                    case Position.Left:
                        RaiseEvent(new RoutedEventArgs(ArcButton.LeftClickEvent));
                        break;

                    case Position.Right:
                        RaiseEvent(new RoutedEventArgs(ArcButton.RightClickEvent));
                        break;

                    case Position.Top:
                        RaiseEvent(new RoutedEventArgs(ArcButton.TopClickEvent));
                        break;

                    case Position.Bottom:
                        RaiseEvent(new RoutedEventArgs(ArcButton.BottomClickEvent));
                        break;

                    case Position.Center:
                        RaiseEvent(new RoutedEventArgs(ArcButton.CenterClickEvent));
                        break;
                }
            }
        }

        #endregion //Methods
    }
}
