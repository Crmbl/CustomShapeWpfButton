using CustomShapeWpfButton.Enums;
using System.Collections.Generic;
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

            var values = new Dictionary<Position, string>();
            values.Add(Position.Right, "Right");
            values.Add(Position.Left, "Left");
            values.Add(Position.Top, "Top");
            values.Add(Position.Bottom, "Bottom");
            values.Add(Position.Center, "Split");
            ArcButton arcButton = new ArcButton(300, values);

            Grid.Children.Add(arcButton);

            arcButton.ToggleVisibility(Position.Left);
            arcButton.UpdateButtonProperty(Position.Right, "Background", "#FFCE00");
        }
    }
}
