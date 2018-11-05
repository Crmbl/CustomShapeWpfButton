using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CustomShapeWpfButton
{
    /// <summary>
    /// Interaction logic for TopArcButton.xaml
    /// </summary>
    public partial class TopArcButton : Button, INotifyPropertyChanged
    {
        public new readonly static DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(string), typeof(TopArcButton), new PropertyMetadata());

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public new string Background
        {
            get { return (string)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); NotifyPropertyChanged("Background"); }
        }

        public TopArcButton()
        {
            InitializeComponent();
        }
    }
}
