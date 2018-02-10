using System;
using System.Collections.Generic;
using System.Text;

namespace myMood.Helpers
{
    public static class FormatHelpers
    {
        public static string FormatSliderValue(double newValue, double stepValue)
        {
            var newStep = Math.Round(newValue / stepValue);
            var stringFormatted = (newStep * stepValue).ToString();

            return stringFormatted;
        }
    }
}
