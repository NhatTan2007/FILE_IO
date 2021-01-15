using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using READ_AND_WRITE_FILE_CSV.Models;
using AutoMapper;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace READ_AND_WRITE_FILE_CSV.Services
{
    class FileCSVServices
    {
        public static List<T> ReadFileCsvToList<T>(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture))
                {
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }

        public static void WriteFileCsv<T>(IEnumerable<T> inputData, string filePath, bool append = false)
        {
            using (StreamWriter streamReader = new StreamWriter(filePath, append, Encoding.UTF8))
            {
                using (CsvWriter csvWriter = new CsvWriter(streamReader, CultureInfo.CurrentCulture))
                {
                    csvWriter.WriteRecords(inputData);
                }
            }
        }
    }
}
