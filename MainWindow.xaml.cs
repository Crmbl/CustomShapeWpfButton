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

            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Right));
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Left));
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Top));
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Bottom));
            Grid.Children.Add(DrawUtil.CreateBaseArcButton(300D, PositionEnum.Center));
        }
    }
}
