using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BAI_3_UPDATE.Models
{
    static class FilePath
    {
        private readonly static string _strDataFilePath = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3 UPDATE\BAI 3 UPDATE\Data";
        private readonly static string _strDataFileName = "data.json";
        public static string StrDataFileFullPath => @$"{_strDataFilePath}\{_strDataFileName}";
        private readonly static string _strPaymentFilePath = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3 UPDATE\BAI 3 UPDATE\Data\Payments";
        private static string _strPaymentFileName = string.Empty;
        private readonly static string _strPaymentFolderName = $"BILLS_{DateTime.UtcNow.ToString("dd.MM.yyyy")}";
        public static string StrPaymentFolderPath => Path.Combine(_strPaymentFilePath, _strPaymentFolderName);
        public static string StrPaymentFileName {set => _strPaymentFileName = value; }
        public static string StrPaymentFileFullPath => Path.Combine(StrPaymentFolderPath, _strPaymentFileName);
        private readonly static string _strOrderHistoryFilePath = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 3 UPDATE\BAI 3 UPDATE\Data\Orders";
        private readonly static string _strOrderHistoryFileName = $"Order_{DateTime.UtcNow.ToString("dd.MM.yyyy")}.json";
        public static string StrOrderHistoryFileFullPath => @$"{_strOrderHistoryFilePath}\{_strOrderHistoryFileName}";

        
    }
}
