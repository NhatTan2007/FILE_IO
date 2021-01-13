using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Services
{
    static class ConvertServices
    {
        public static bool ToIntByTryParse(string inputString, out int number)
        {
            return int.TryParse(inputString.Trim(), out number);
        }

        public static bool ToDoubleByTryParse(string inputString, out double number)
        {
            return double.TryParse(inputString.Trim(), out number);
        }
    }
}
