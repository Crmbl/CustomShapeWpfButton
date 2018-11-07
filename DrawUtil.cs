using System;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace CustomShapeWpfButton
{
    public static class DrawUtil
    {
        public const double RAD45 = 0.785D;

        public static Path CreateRightButton(double size)
        {
            var innerSize = size - Round(size / 3);

            var xST = CalculateX(innerSize);
            var yST = CalculateY(innerSize);

            var x1 = CalculateX(size);
            var y1 = CalculateY(size);

            var x2 = x1;
            var y2 = -y1;

            var x3 = xST;
            var y3 = -yST;

            var x4 = xST;
            var y4 = yST;

            var path = new Path();
            path.HorizontalAlignment = HorizontalAlignment.Center;
            path.VerticalAlignment = VerticalAlignment.Center;
            path.Fill = new SolidColorBrush(Colors.Black);
            var pathGeometry = new PathGeometry();
            var pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(0, yST + y1);
            var lineSegment1 = new LineSegment();
            lineSegment1.Point = new Point(x1 - xST, y1 + y1);
            var arcSegment1 = new ArcSegment();
            arcSegment1.Point = new Point(x2 - xST, y2 + y1);
            arcSegment1.Size = new Size(Round(size / 2), Round(size / 2));
            arcSegment1.IsLargeArc = false;
            arcSegment1.SweepDirection = SweepDirection.Counterclockwise;
            var lineSegment2 = new LineSegment();
            lineSegment2.Point = new Point(x3 - xST, y3 + y1);
            var arcSegment2 = new ArcSegment();
            arcSegment2.Point = new Point(x4 - xST, y4 + y1);
            arcSegment2.Size = new Size(Round(innerSize / 2), Round(innerSize / 2));
            arcSegment2.IsLargeArc = false;
            arcSegment2.SweepDirection = SweepDirection.Clockwise;

            pathFigure.IsClosed = true;
            pathFigure.Segments.Add(lineSegment1);
            pathFigure.Segments.Add(arcSegment1);
            pathFigure.Segments.Add(lineSegment2);
            pathFigure.Segments.Add(arcSegment2);

            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;

            return path;
        }

        private static double Round(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        private static double CalculateX(double value)
        {
            return Round(value / 2 * Math.Cos(RAD45));
        }

        private static double CalculateY(double value)
        {
            return Round(value / 2 * Math.Sin(RAD45));
        }
    }
}
