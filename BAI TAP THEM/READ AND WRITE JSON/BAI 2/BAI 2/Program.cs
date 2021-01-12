using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using AutoMapper;

namespace BAI_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup path file and file name and declear variables
            string strPathFile = @"D:\LEARNING\MODULE 2\14. FILE IO\EXERCISE\BAI TAP THEM\READ AND WRITE JSON\BAI 2\BAI 2\data";
            string strFileNameInput = "data.json";
            string strFileNameOutput = "outcome.json";
            string strDataRead = string.Empty;
            string strDataWrite = string.Empty;
            School<Student> listOfStudents = new School<Student>();
            School<ReStudent> reListOfStudents = new School<ReStudent>();
            //Auto mapping configuration between Student and ReStudent
            MapperConfiguration configAutoMapping = new MapperConfiguration(cfg => { cfg.CreateMap<Student, ReStudent>(); });
            IMapper iMapper = configAutoMapping.CreateMapper();
            
            //Read data from json
            using (StreamReader streamReadFile = new StreamReader(path: $@"{strPathFile}\{strFileNameInput}", encoding: new UTF8Encoding()))
            {
                strDataRead = streamReadFile.ReadToEnd();
            }
            //Mapping data to new list of Student after calculate Average Scores and ClassificateStudent
            listOfStudents = JsonConvert.DeserializeObject<School<Student>>(strDataRead);
            List<ReStudent> tempStudentsOfSchool = new List<ReStudent>();
            foreach (Student item in listOfStudents.StudentsOfSchool)
            {
                ReStudent tempStudent = new ReStudent();
                tempStudent = iMapper.Map<Student, ReStudent>(item);
                tempStudentsOfSchool.Add(tempStudent);
            }
            reListOfStudents.StudentsOfSchool = tempStudentsOfSchool;
            reListOfStudents.StudentsOfSchool.Sort();
            strDataWrite = JsonConvert.SerializeObject(reListOfStudents);
            using (StreamWriter streamWriteFile = new StreamWriter(path: @$"{strPathFile}\{strFileNameOutput}", append: false, encoding: new UTF8Encoding()))
            {
                streamWriteFile.Write(strDataWrite);
            }
        }
    }
}
