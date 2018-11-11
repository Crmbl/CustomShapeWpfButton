using System;

namespace CustomShapeWpfButton.Utils
{
    /// <summary>
    /// Math related methods.
    /// </summary>
    public static class MathUtil
    {
        #region Constants

        /// <summary>
        /// 45 degrees in rad.
        /// </summary>
        private const double RAD45 = 0.785D;

        #endregion //Constants

        #region Methods

        /// <summary>
        /// Round the value to 2 digits awayFromZero.
        /// </summary>
        public static double Round(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculates X pos on the circle.
        /// </summary>
        /// <remarks>The formula is : x = r * cos(Angle)</remarks>
        public static double CalculateX(double value)
        {
            return Round(value / 2 * Math.Cos(RAD45));
        }

        /// <summary>
        /// Calculates Y pos on the circle.
        /// </summary>
        /// <remarks>The formula is : y = r * sin(Angle)</remarks>
        public static double CalculateY(double value)
        {
            return Round(value / 2 * Math.Sin(RAD45));
        }

        /// <summary>
        /// Checks if there is Stroke on button, and returns the offset to apply.
        /// </summary>
        public static double StrokeCornerChecker(BaseArcButton button)
        {
            return button.StrokeThickness == 0 ? 0 : Round(Math.Sqrt(2 * Math.Pow(button.StrokeThickness, 2)) / 2);
        }

        /// <summary>
        /// Checks if there is Stroke on center button, and returns the offset to apply.
        /// </summary>
        public static double StrokeCenterChecker(BaseArcButton button)
        {
            return button.StrokeThickness == 0 ? 0 : Round(button.StrokeThickness / 2);
        }
        #endregion //Methods
    }
}
