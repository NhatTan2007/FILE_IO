using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3_UPDATE.Services
{
    static class ValidDataServices
    {
        public static string FormatName(string nameInput)
        {
            nameInput = nameInput.Trim();
            //Remove space;
            while (nameInput.IndexOf("  ") != -1)
            {
                nameInput = nameInput.Replace("  ", " ");
            }
            //make Upercase first char each word.
            nameInput = nameInput.ToLower();
            string[] nameSplitArray = nameInput.Split(" ");
            for (int i = 0; i < nameSplitArray.Length; i++)
            {
                char[] stringSplitToChar = nameSplitArray[i].ToCharArray();
                stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
                nameSplitArray[i] = new string(stringSplitToChar);
            }
            nameInput = String.Join(" ", nameSplitArray);
            return nameInput;
        }
    }
}
