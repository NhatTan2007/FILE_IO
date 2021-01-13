using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace BAI_3_UPDATE.Services
{
    static class FileJsonServices
    {
        public static string ReadFileJson(string fullPath)
        {
            string data = string.Empty;
            using (StreamReader sr = new StreamReader(fullPath, new UTF8Encoding()))
            {
                data = sr.ReadToEnd();
            }
            return data;
        }

        public static void WriteFileJson(object inputObject, string fullPath, bool append = false)
        {
            string dataToWrite = JsonConvert.SerializeObject(inputObject, Formatting.Indented);
            using (StreamWriter sr = new StreamWriter(fullPath, append, new UTF8Encoding()))
            {
                sr.WriteLine(dataToWrite);
            }
        }
    }
}
