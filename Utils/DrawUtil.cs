using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using CustomShapeWpfButton.Enums;
using System.Windows.Controls;
using System.Windows.Data;
using System;
using CustomShapeWpfButton.Converters;

namespace CustomShapeWpfButton.Utils
{
    /// <summary>
    /// Draw related methods.
    /// </summary>
    public static class DrawUtil
    {
        // TODO merge left/right && top/bottom
        private static Point[] Points = null;

        private static Path RightPath = null;

        public static BaseArcButton CreateBaseArcButton(double size, PositionEnum position)
        {
            var arcButton = new BaseArcButton();
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
                    generatedPath = CreateLeftButtonPath(size);
                    break;

                case PositionEnum.Top:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top);
                    generatedPath = CreateTopButtonPath(size);
                    break;

                case PositionEnum.Right:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
                    generatedPath = CreateRightButtonPath(size);
                    RightPath = generatedPath;
                    break;

                case PositionEnum.Bottom:
                    grid.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    grid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Bottom);
                    generatedPath = CreateBottomButtonPath(size);
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
            arcButton.Template = template;

            template.Seal();

            return arcButton;
        }

        /// <summary>
        /// Creates the right button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateRightButtonPath(double size)
        {
            //TODO: GETRENDERBOUNDS on PATH 
            var innerSize = size - MathUtil.Round(size / 3);

            var points = new Point[]
            {
                new Point(MathUtil.CalculateX(innerSize), MathUtil.CalculateY(innerSize)),
                new Point(MathUtil.CalculateX(size), MathUtil.CalculateY(size)),
                new Point(MathUtil.CalculateX(size), -MathUtil.CalculateY(size)),
                new Point(MathUtil.CalculateX(innerSize), -MathUtil.CalculateY(innerSize)),
                new Point(MathUtil.CalculateX(innerSize), MathUtil.CalculateY(innerSize))
            };
            Points = points;

            var path = new Path
            {
                Name = "Path",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var pathFigure = new PathFigure
            {
                StartPoint = new Point(points[0].X - points[0].X, points[0].Y + points[1].Y),
                IsClosed = true,
                IsFilled = true,
                Segments = new PathSegmentCollection
                {
                    new LineSegment { Point = new Point(points[1].X - points[0].X, points[1].Y + points[1].Y) },
                    new ArcSegment { Point = new Point(points[2].X - points[0].X, points[2].Y + points[1].Y),
                        Size = new Size(MathUtil.Round(size/2), MathUtil.Round(size/2)), IsLargeArc = false, SweepDirection = SweepDirection.Counterclockwise },
                    new LineSegment { Point = new Point(points[3].X - points[0].X, points[3].Y + points[1].Y) },
                    new ArcSegment { Point = new Point(points[4].X - points[0].X, points[4].Y + points[1].Y),
                        Size = new Size(MathUtil.Round(innerSize/2), MathUtil.Round(innerSize/2)), IsLargeArc = false, SweepDirection = SweepDirection.Clockwise }
                }
            };

            path.Data = new PathGeometry(new [] {pathFigure});
            return path;
        }

        /// <summary>
        /// Creates the left button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateLeftButtonPath(double size)
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
            var t = MathUtil.Round(RightPath.Data.Bounds.Width) - Points[1].X;
            var pathFigure = new PathFigure
            {
                StartPoint = new Point(MathUtil.Round(RightPath.Data.Bounds.Width), points[0].Y + points[1].Y),
                IsClosed = true,
                IsFilled = true,
                Segments = new PathSegmentCollection
                {
                    new LineSegment { Point = new Point(MathUtil.Round(RightPath.Data.Bounds.Width) - Points[1].X, points[1].Y + points[1].Y) },
                    new ArcSegment { Point = new Point(MathUtil.Round(RightPath.Data.Bounds.Width) - Points[1].X, points[2].Y + points[1].Y),
                        Size = new Size(MathUtil.Round(size/2), MathUtil.Round(size/2)), IsLargeArc = false, SweepDirection = SweepDirection.Clockwise },
                    new LineSegment { Point = new Point(MathUtil.Round(RightPath.Data.Bounds.Width), points[3].Y + points[1].Y) },
                    new ArcSegment { Point = new Point(MathUtil.Round(RightPath.Data.Bounds.Width), points[4].Y + points[1].Y),
                        Size = new Size(MathUtil.Round(innerSize/2), MathUtil.Round(innerSize/2)), IsLargeArc = false, SweepDirection = SweepDirection.Counterclockwise }
                }
            };

            path.Data = new PathGeometry(new[] { pathFigure });
            return path;
        }

        /// <summary>
        /// Creates the top button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateTopButtonPath(double size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the bottom button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateBottomButtonPath(double size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the center button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateCenterButtonPath(double size)
        {
            throw new NotImplementedException();
        }
    }
}
