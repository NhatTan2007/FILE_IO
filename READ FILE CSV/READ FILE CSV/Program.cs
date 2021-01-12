using System;
using System.IO;
using CsvHelper;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace READ_FILE_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"netcoreapp3.1.csv";
            using (StreamReader streamReadFile = new StreamReader(csvPath, new UTF8Encoding()))
            {
                CsvReader readCsv = new CsvReader(streamReadFile);
                {
                    List<string> records = readCsv.GetRecord<string>();
                }
            }
        }
    }
}
