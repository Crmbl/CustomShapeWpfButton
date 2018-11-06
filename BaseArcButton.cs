using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomShapeWpfButton
{
    public class BaseArcButton : Button, INotifyPropertyChanged
    {
        #region DependencyProperties

        public new readonly static DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(string), typeof(BaseArcButton), new PropertyMetadata("#dddddd"));
        public new readonly static DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(string), typeof(BaseArcButton), new PropertyMetadata("#a29bfe"));
        public new readonly static DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(string), typeof(BaseArcButton), new PropertyMetadata("#000000"));
        public new readonly static DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(string), typeof(BaseArcButton), new PropertyMetadata("Consolas"));
        public new readonly static DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(int), typeof(BaseArcButton), new PropertyMetadata(6));
        public new readonly static DependencyProperty MarginProperty = DependencyProperty.Register("Margin", typeof(string), typeof(BaseArcButton), new PropertyMetadata("0,0,0,7"));
        public readonly static DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(BaseArcButton), new PropertyMetadata(0.3));
        public readonly static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BaseArcButton), new PropertyMetadata(""));

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

        public new int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); NotifyPropertyChanged("FontSize"); }
        }

        public new string Margin
        {
            get { return (string)GetValue(MarginProperty); }
            set { SetValue(MarginProperty, value); NotifyPropertyChanged("Margin"); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); NotifyPropertyChanged("Text"); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); NotifyPropertyChanged("StrokeThickness"); }
        }

        #endregion //Properties

        #region Constructors

        public BaseArcButton()
        {}

        #endregion //Constructors : UserControl
    }
}
