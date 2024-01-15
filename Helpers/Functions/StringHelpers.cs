using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Helpers.Functions
{
    public static class StringHelpers
    {
        public static string FormatNumberWithSpaces(decimal number)
        {
            return number.ToString("N0", CultureInfo.GetCultureInfo("fr-FR"));
        }
    }
}
