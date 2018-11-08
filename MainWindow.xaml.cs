using CustomShapeWpfButton.Enums;
using CustomShapeWpfButton.Utils;
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
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Right));
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Left));
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
