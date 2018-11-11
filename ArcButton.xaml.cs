using CustomShapeWpfButton.Enums;
using CustomShapeWpfButton.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CustomShapeWpfButton
{
    /// <summary>
    /// Interaction logic for ArcButton.xaml
    /// </summary>
    public partial class ArcButton : UserControl
    {
        #region Constructors

        /// <summary>
        /// Init the Arcbutton with every parameters.
        /// </summary>
        /// <param name="size">The total size of the button height/width.</param>
        /// <param name="textValues">The values for the different buttons.</param>
        public ArcButton(double size, Dictionary<Position, string> textValues, string background = null, 
            string borderBrush = null, string foreground = null, string fontFamily = null, 
            double fontSize = default(double), double strokeThickness = default(double), string borderBrushPressed = null, 
            string backgroundPressed = null, double proportion = default(double))
        {
            InitializeComponent();

            Grid.Height = size;
            Grid.Width = size;

            var arcButtons = new List<BaseArcButton>
            {
                DrawUtil.CreateBaseArcButton(size, Position.Left, textValues[Position.Left]),
                DrawUtil.CreateBaseArcButton(size, Position.Right, textValues[Position.Right]),
                DrawUtil.CreateBaseArcButton(size, Position.Top, textValues[Position.Top]),
                DrawUtil.CreateBaseArcButton(size, Position.Bottom, textValues[Position.Bottom]),
                DrawUtil.CreateBaseArcButton(size, Position.Center, textValues[Position.Center])
            };

            foreach (var button in arcButtons)
            {
                if (!string.IsNullOrWhiteSpace(background))
                    button.Background = background;
                if (!string.IsNullOrWhiteSpace(borderBrush))
                    button.BorderBrush = borderBrush;
                if (!string.IsNullOrWhiteSpace(foreground))
                    button.Foreground = foreground;
                if (!string.IsNullOrWhiteSpace(fontFamily))
                    button.FontFamily = fontFamily;
                if (fontSize != default(double))
                    button.FontSize = fontSize;
                if (strokeThickness != default(double))
                    button.StrokeThickness = strokeThickness;
                if (!string.IsNullOrWhiteSpace(borderBrushPressed))
                    button.BorderBrushPressed = borderBrushPressed;
                if (!string.IsNullOrWhiteSpace(backgroundPressed))
                    button.BackgroundPressed = backgroundPressed;
                if (proportion != default(double))
                    button.Proportion = proportion;

                Grid.Children.Add(button);
            }
        }

        #endregion //Constructors

        #region Methods

        public void ToggleVisibility(Position position)
        {
            BaseArcButton button = new BaseArcButton();
            switch (position)
            {
                case Position.Left:
                    button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => x.Name == "Left");
                    button.Visibility = !button.Visibility;
                    break;

                case Position.Right:
                    button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => x.Name == "Right");
                    button.Visibility = !button.Visibility;
                    break;

                case Position.Top:
                    button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => x.Name == "Top");
                    button.Visibility = !button.Visibility;
                    break;

                case Position.Bottom:
                    button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => x.Name == "Bottom");
                    button.Visibility = !button.Visibility;
                    break;

                case Position.Center:
                    button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => x.Name == "Center");
                    button.Visibility = !button.Visibility;
                    break;
            }
        }

        public void UpdateButtonsProperty()
        {

        }
        
        public void UpdateButtonProperty(Position position, string propertyName, object value)
        {
            var button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == position);

            if (propertyName == nameof(button.Background))
                button.Background = value.ToString();
        }

        #endregion //Methods
    }
}
