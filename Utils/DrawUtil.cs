using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using CustomShapeWpfButton.Enums;
using System.Windows.Controls;
using System.Windows.Data;
using CustomShapeWpfButton.Converters;

namespace CustomShapeWpfButton.Utils
{
    /// <summary>
    /// Draw related methods.
    /// </summary>
    public static class DrawUtil
    {
        #region Static Properties

        /// <summary>
        /// Give access of properties inside the whole class.
        /// </summary>
        private static BaseArcButton ArcButton;

        #endregion //Static Properties

        public static BaseArcButton CreateBaseArcButton(double size, PositionEnum position)
        {
            ArcButton = new BaseArcButton();
            var template = new ControlTemplate(typeof(Button));

            #region Triggers

            var mouseOverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverTrigger.Setters.Add(new Setter
            {
                TargetName = "Path",
                Property = Shape.StrokeProperty,
                Value = new Binding
                {
                    Path = new PropertyPath("BorderOver"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
                }
            });
            mouseOverTrigger.Setters.Add(new Setter
            {
                TargetName = "Path",
                Property = Shape.FillProperty,
                Value = new Binding
                {
                    Path = new PropertyPath("BackgroundOver"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
                }
            });

            var pressedTrigger = new Trigger
            {
                Property = Button.IsPressedProperty,
                Value = true
            };
            pressedTrigger.Setters.Add(new Setter
            {
                TargetName = "Path",
                Property = Shape.StrokeProperty,
                Value = new Binding
                {
                    Path = new PropertyPath("BorderBrushPressed"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
                }
            });
            pressedTrigger.Setters.Add(new Setter
            {
                TargetName = "Path",
                Property = Shape.FillProperty,
                Value = new Binding
                {
                    Path = new PropertyPath("BackgroundPressed"),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
                }
            });

            template.Triggers.Add(mouseOverTrigger);
            template.Triggers.Add(pressedTrigger);

            #endregion //Triggers

            #region Bindings

            var grid = new FrameworkElementFactory(typeof(Grid));
            grid.SetValue(FrameworkElement.HeightProperty, double.NaN);
            grid.SetValue(FrameworkElement.WidthProperty, double.NaN);
            grid.SetValue(UIElement.VisibilityProperty, new Binding
            {
                Path = new PropertyPath("Visibility"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1),
                Converter = new BoolToVisibilityConverter()
            });

            var path = new FrameworkElementFactory(typeof(Path), "Path");
            path.SetValue(Shape.StrokeThicknessProperty, new Binding
            {
                Path = new PropertyPath("StrokeThickness"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            path.SetValue(Shape.FillProperty, new Binding
            {
                Path = new PropertyPath("Background"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            path.SetValue(Shape.StrokeProperty, new Binding
            {
                Path = new PropertyPath("BorderBrush"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });

            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            textBlock.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBlock.SetValue(FrameworkElement.MarginProperty, new Binding
            {
                Path = new PropertyPath("TextMargin"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            textBlock.SetValue(TextBlock.FontFamilyProperty, new Binding
            {
                Path = new PropertyPath("FontFamily"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            textBlock.SetValue(TextBlock.ForegroundProperty, new Binding
            {
                Path = new PropertyPath("Foreground"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            textBlock.SetValue(TextBlock.FontSizeProperty, new Binding
            {
                Path = new PropertyPath("FontSize"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });
            textBlock.SetValue(TextBlock.TextProperty, new Binding
            {
                Path = new PropertyPath("Text"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1)
            });

            #endregion //Bindings

            #region Position

            Path generatedPath = null;
            switch(position)
            {
                case PositionEnum.Left:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
                    generatedPath = CreateSideButtonPath(size);
                    path.SetValue(FrameworkElement.LayoutTransformProperty, new RotateTransform(180));
                    break;

                case PositionEnum.Top:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top);
                    generatedPath = CreateSideButtonPath(size);
                    path.SetValue(FrameworkElement.LayoutTransformProperty, new RotateTransform(270));
                    break;

                case PositionEnum.Right:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
                    generatedPath = CreateSideButtonPath(size);
                    break;

                case PositionEnum.Bottom:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Bottom);
                    generatedPath = CreateSideButtonPath(size);
                    path.SetValue(FrameworkElement.LayoutTransformProperty, new RotateTransform(90));
                    break;

                case PositionEnum.Center:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
                    generatedPath = CreateCenterButtonPath(size);
                    break;
            }

            path.SetValue(Path.DataProperty, generatedPath.Data);

            #endregion //Position

            grid.AppendChild(path);
            grid.AppendChild(textBlock);

            template.VisualTree = grid;
            ArcButton.Template = template;

            template.Seal();

            return ArcButton;
        }

        /// <summary>
        /// Creates the horizontal button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateSideButtonPath(double size)
        {
            var innerSize = size - MathUtil.Round(size / 3);

            var points = new Point[]
            {
                new Point(MathUtil.CalculateX(innerSize), MathUtil.CalculateY(innerSize)),
                new Point(MathUtil.CalculateX(size), MathUtil.CalculateY(size)),
                new Point(MathUtil.CalculateX(size), -MathUtil.CalculateY(size)),
                new Point(MathUtil.CalculateX(innerSize), -MathUtil.CalculateY(innerSize)),
                new Point(MathUtil.CalculateX(innerSize), MathUtil.CalculateY(innerSize))
            };

            var path = new Path
            {
                Name = "Path",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            //var points2 = new Point[]
            //{
            //    new Point(points[0].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[0].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
            //    new Point(points[1].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[1].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
            //    new Point(points[2].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[2].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
            //    new Point(points[3].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[3].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
            //    new Point(points[4].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[4].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton))
            //};

            var pathFigure = new PathFigure
            {
                StartPoint = new Point(points[0].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[0].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
                IsClosed = true,
                IsFilled = true,
                Segments = new PathSegmentCollection
                {
                    new LineSegment { Point = new Point(points[1].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[1].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)) },
                    new ArcSegment { Point = new Point(points[2].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[2].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
                        Size = new Size(MathUtil.Round(size/2), MathUtil.Round(size/2)), IsLargeArc = false, SweepDirection = SweepDirection.Counterclockwise },
                    new LineSegment { Point = new Point(points[3].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[3].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)) },
                    new ArcSegment { Point = new Point(points[4].X - points[0].X + MathUtil.StrokeChecker(ArcButton), points[4].Y + points[1].Y + MathUtil.StrokeChecker(ArcButton)),
                        Size = new Size(MathUtil.Round(innerSize/2), MathUtil.Round(innerSize/2)), IsLargeArc = false, SweepDirection = SweepDirection.Clockwise }
                }
            };

            path.Data = new PathGeometry(new [] {pathFigure});
            return path;
        }

        /// <summary>
        /// Creates the center button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateCenterButtonPath(double size)
        {
            var innerSize = size - MathUtil.Round(size / 3);
            var radiusSize = MathUtil.Round(innerSize / 2);

            var path = new Path
            {
                Name = "Path",
                Height = innerSize,
                Width = innerSize,
                Stretch = Stretch.Uniform,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            path.Data = new EllipseGeometry(new Point(radiusSize, radiusSize), radiusSize, radiusSize);
            //path.Data = new EllipseGeometry(new Point(radiusSize + MathUtil.StrokeChecker(ArcButton), radiusSize + MathUtil.StrokeChecker(ArcButton)), radiusSize, radiusSize);

            return path;
        }
    }
}
