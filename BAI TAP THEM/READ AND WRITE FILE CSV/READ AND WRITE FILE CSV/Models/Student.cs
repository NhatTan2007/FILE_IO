using System;
using System.Collections.Generic;
using System.Text;

namespace READ_AND_WRITE_FILE_CSV.Models
{
    class Student
    {
        private int _id;
        private string _fullname;
        private string _dob;
        private GenderEnum _gender;
        private double _math;
        private double _physics;
        private double _chemistry;

        public int Id { get => _id; set => _id = value; }
        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Dob { get => _dob; set => _dob = value; }
        public GenderEnum Gender { get => _gender; set => _gender = value; }
        public double Math { get => _math; set => _math = value; }
        public double Physics { get => _physics; set => _physics = value; }
        public double Chemistry { get => _chemistry; set => _chemistry = value; }

        public Student()
        {

        }
    }
}
