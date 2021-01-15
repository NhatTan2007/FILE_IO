using System;
using System.IO;
using CsvHelper; 
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using READ_AND_WRITE_FILE_CSV.Models;
using READ_AND_WRITE_FILE_CSV.Services;
using AutoMapper;

namespace READ_AND_WRITE_FILE_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudents = new List<Student>();
            List<ReStudent> listReStudents = new List<ReStudent>();

            listStudents = FileCSVServices.ReadFileCsvToList<Student>(Path.Combine(FilePath.strRootPath, FilePath.strFileInputName));
            StudentServices.MapperDataStudent(listStudents, listReStudents);
            FileCSVServices.WriteFileCsv<ReStudent>(listReStudents, Path.Combine(FilePath.strRootPath, FilePath.strFileOutputName));
        }
    }
}
