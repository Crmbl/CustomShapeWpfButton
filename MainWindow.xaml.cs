using System.Windows;

namespace CustomShapeWpfButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.TopButton.Click += TopButton_Click;
            Grid.Children.Add(DrawUtil.CreateRightButtonPath(300));
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
