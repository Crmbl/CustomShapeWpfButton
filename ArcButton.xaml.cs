using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomShapeWpfButton
{
    /// <summary>
    /// Interaction logic for ArcButton.xaml
    /// </summary>
    public partial class ArcButton : UserControl, INotifyPropertyChanged
    {
        #region DependencyProperties

        #region Visibility

        public readonly static DependencyProperty ShowTopProperty = DependencyProperty.Register("ShowTopButton", typeof(bool), typeof(ArcButton), new PropertyMetadata(true));
        public readonly static DependencyProperty ShowRightProperty = DependencyProperty.Register("ShowRightButton", typeof(bool), typeof(ArcButton), new PropertyMetadata(true));
        public readonly static DependencyProperty ShowLeftProperty = DependencyProperty.Register("ShowLeftButton", typeof(bool), typeof(ArcButton), new PropertyMetadata(true));
        public readonly static DependencyProperty ShowBottomProperty = DependencyProperty.Register("ShowBottomButton", typeof(bool), typeof(ArcButton), new PropertyMetadata(true));
        public readonly static DependencyProperty ShowCenterProperty = DependencyProperty.Register("ShowCenterButton", typeof(bool), typeof(ArcButton), new PropertyMetadata(true));

        #endregion //Visibility

        #region Background

        public readonly static DependencyProperty BackgroundTopProperty = DependencyProperty.Register("BackgroundTopButton", typeof(string), typeof(ArcButton), new PropertyMetadata("Yellow"));
        public readonly static DependencyProperty BackgroundRightProperty = DependencyProperty.Register("BackgroundRightButton", typeof(string), typeof(ArcButton), new PropertyMetadata("#59F50606"));
        public readonly static DependencyProperty BackgroundLeftProperty = DependencyProperty.Register("BackgroundLeftButton", typeof(string), typeof(ArcButton), new PropertyMetadata("#3FF506CA"));
        public readonly static DependencyProperty BackgroundBottomProperty = DependencyProperty.Register("BackgroundBottomButton", typeof(string), typeof(ArcButton), new PropertyMetadata("#3F065EF5"));
        public readonly static DependencyProperty BackgroundCenterProperty = DependencyProperty.Register("BackgroundCenterButton", typeof(string), typeof(ArcButton), new PropertyMetadata("#3FFF0000"));

        #endregion //Background

        #endregion //DependencyProperties

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion //NotifyPropertyChanged

        #region Properties

        #region Visibility

        public bool ShowTopButton
        {
            get { return (bool)GetValue(ShowTopProperty); }
            set { SetValue(ShowTopProperty, value); NotifyPropertyChanged("ShowTopButton"); }
        }

        public bool ShowRightButton
        {
            get { return (bool)GetValue(ShowRightProperty); }
            set { SetValue(ShowRightProperty, value); NotifyPropertyChanged("ShowRightButton"); }
        }

        public bool ShowLeftButton
        {
            get { return (bool)GetValue(ShowLeftProperty); }
            set { SetValue(ShowLeftProperty, value); NotifyPropertyChanged("ShowLeftButton"); }
        }

        public bool ShowBottomButton
        {
            get { return (bool)GetValue(ShowBottomProperty); }
            set { SetValue(ShowBottomProperty, value); NotifyPropertyChanged("ShowBottomButton"); }
        }

        public bool ShowCenterButton
        {
            get { return (bool)GetValue(ShowCenterProperty); }
            set { SetValue(ShowCenterProperty, value); NotifyPropertyChanged("ShowCenterButton"); }
        }

        #endregion //Visibility

        #region Background

        public string BackgroundTopButton
        {
            get { return (string)GetValue(BackgroundTopProperty); }
            set { SetValue(BackgroundTopProperty, value); NotifyPropertyChanged("BackgroundTopButton"); }
        }

        public string BackgroundRightButton
        {
            get { return (string)GetValue(BackgroundRightProperty); }
            set { SetValue(BackgroundRightProperty, value); NotifyPropertyChanged("BackgroundRightButton"); }
        }

        public string BackgroundLeftButton
        {
            get { return (string)GetValue(BackgroundLeftProperty); }
            set { SetValue(BackgroundLeftProperty, value); NotifyPropertyChanged("BackgroundLeftButton"); }
        }

        public string BackgroundBottomButton
        {
            get { return (string)GetValue(BackgroundBottomProperty); }
            set { SetValue(BackgroundBottomProperty, value); NotifyPropertyChanged("BackgroundBottomButton"); }
        }

        public string BackgroundCenterButton
        {
            get { return (string)GetValue(BackgroundCenterProperty); }
            set { SetValue(BackgroundCenterProperty, value); NotifyPropertyChanged("BackgroundCenterButton"); }
        }

        #endregion //Background

        #endregion //Properties

        #region Constructors

        public ArcButton() : base()
        {
            DataContext = this;
            InitializeComponent();
        }

        #endregion //Constructors
    }
}
