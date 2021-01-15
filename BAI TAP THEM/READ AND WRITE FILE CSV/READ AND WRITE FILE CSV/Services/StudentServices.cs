using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using READ_AND_WRITE_FILE_CSV.Models;

namespace READ_AND_WRITE_FILE_CSV.Services
{
    public class StudentServices
    {
        public static void SplitFullName(string fullName, out string firstName, out string lastName)
        {
            string[] partsOfFulLname = fullName.Split(" ");
            firstName = partsOfFulLname[partsOfFulLname.Length - 1];
            Array.Resize(ref partsOfFulLname, partsOfFulLname.Length - 1);
            lastName = String.Join(" ",partsOfFulLname);
        }

        public static void MapperDataStudent(object objectSource, object objectDes)
        {
            List<Student> sourceList = (List<Student>)objectSource;
            List<ReStudent> desList = (List<ReStudent>)objectDes;
            if (sourceList.Count > 0)
            {
                for (int i = 0; i < sourceList.Count; i++)
                {
                    desList.Add(new ReStudent());
                    desList[i] = MapperServices.MapperData<Student, ReStudent>(sourceList[i]);
                    desList[i].SplitFullName(sourceList[i]);
                }
                return ;
            } 
        }
    }
}
