using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace CustomShapeWpfButton.Utils
{
    /// <summary>
    /// Draw related methods.
    /// </summary>
    public static class DrawUtil
    {
        /// <summary>
        /// Creates the right button's path.
        /// </summary>
        /// <param name="size">Size of the global ArcButton.</param>
        public static Path CreateRightButtonPath(double size)
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
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = new SolidColorBrush(Colors.Black),
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

        
    }
}
