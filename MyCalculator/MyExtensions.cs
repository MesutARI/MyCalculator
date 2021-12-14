using System;
using System.Globalization;

namespace MyCalculator
{
    public static class MyExtensions
    {
        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static double ToDouble(this object value, double defaultValue)
        {
            double result;
            value = value.ToString().Replace(",", ".");
            //Try parsing in the current culture
            if (!double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&

                //Then try in US english
                !double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&

                //Then in neutral language
                !double.TryParse(value.ToString(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }

            return result;
        }
    }
}
