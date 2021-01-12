using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace READ_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPathJson = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\READ JSON\READ JSON\Data\matrixJS.json";
            string data;
            using (StreamReader readFileJson = new StreamReader(path: strPathJson, new UTF8Encoding()))
            {
                data = readFileJson.ReadToEnd();
            }

            Matrix result = JsonConvert.DeserializeObject<Matrix>(data);
            
        }
    }
}
