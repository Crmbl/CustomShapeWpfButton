using CustomShapeWpfButton.Enums;
using CustomShapeWpfButton.Utils;
using System;
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
                DrawUtil.CreateBaseArcButton(size, Position.Left, textValues[Position.Left], proportion, strokeThickness),
                DrawUtil.CreateBaseArcButton(size, Position.Right, textValues[Position.Right], proportion, strokeThickness),
                DrawUtil.CreateBaseArcButton(size, Position.Top, textValues[Position.Top], proportion, strokeThickness),
                DrawUtil.CreateBaseArcButton(size, Position.Bottom, textValues[Position.Bottom], proportion, strokeThickness),
                DrawUtil.CreateBaseArcButton(size, Position.Center, textValues[Position.Center], proportion, strokeThickness)
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
                if (!string.IsNullOrWhiteSpace(borderBrushPressed))
                    button.BorderBrushPressed = borderBrushPressed;
                if (!string.IsNullOrWhiteSpace(backgroundPressed))
                    button.BackgroundPressed = backgroundPressed;
                if (fontSize != default(double))
                    button.FontSize = fontSize;

                Grid.Children.Add(button);
            }
        }

        #endregion //Constructors

        #region Methods

        /// <summary>
        /// Toggle visibility for the given position/button.
        /// </summary>
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

        /// <summary>
        /// Allows to update property for every buttons.
        /// </summary>
        public void UpdateButtonsProperty(string propertyName, object value)
        {
            var buttons = new BaseArcButton[]
            {
                this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == Position.Left),
                this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == Position.Right),
                this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == Position.Top),
                this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == Position.Bottom),
                this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == Position.Center)
            };

            foreach (var button in buttons)
                UpdateButtonProperty((Position)button.Tag, propertyName, value);
        }
        
        /// <summary>
        /// Allow to update property for a specific button.
        /// </summary>
        public void UpdateButtonProperty(Position position, string propertyName, object value)
        {
            var button = this.Grid.Children.Cast<BaseArcButton>().FirstOrDefault(x => (Position)x.Tag == position);

            if (propertyName.ToLower() == nameof(button.Background).ToLower())
                button.Background = value.ToString();
            if (propertyName.ToLower() == nameof(button.BorderBrush).ToLower())
                button.BorderBrush = value.ToString();
            if (propertyName.ToLower() == nameof(button.Foreground).ToLower())
                button.Foreground = value.ToString();
            if (propertyName.ToLower() == nameof(button.FontFamily).ToLower())
                button.FontFamily = value.ToString();
            if (propertyName.ToLower() == nameof(button.BorderBrushPressed).ToLower())
                button.BorderBrushPressed = value.ToString();
            if (propertyName.ToLower() == nameof(button.BackgroundPressed).ToLower())
                button.BackgroundPressed = value.ToString();
            if (propertyName.ToLower() == nameof(button.FontSize).ToLower())
                button.FontSize = (double)value;
            if (propertyName.ToLower() == nameof(button.StrokeThickness).ToLower())
                throw new Exception("The strokeThickness cannot be modified after the shape has been created.");
            if (propertyName.ToLower() == nameof(button.Proportion).ToLower())
                throw new Exception("The proportion cannot be modified after the shape has been created.");
        }

        #endregion //Methods
    }
}
