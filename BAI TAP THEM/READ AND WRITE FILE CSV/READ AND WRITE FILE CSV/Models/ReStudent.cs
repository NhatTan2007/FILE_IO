using READ_AND_WRITE_FILE_CSV.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace READ_AND_WRITE_FILE_CSV.Models
{
    class ReStudent
    {
        private int _id;
        private string _lastname;
        private string _firstname;
        private string _dob;
        private GenderEnum _gender;
        private double _math;
        private double _physics;
        private double _chemistry;

        public int Id { get => _id; set => _id = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Dob { get => _dob; set => _dob = value; }
        public GenderEnum Gender { get => _gender; set => _gender = value; }
        public double Math { get => _math; set => _math = value; }
        public double Physics { get => _physics; set => _physics = value; }
        public double Chemistry { get => _chemistry; set => _chemistry = value; }

        public double AverageScore => (this.Math * 2 + this.Physics + this.Chemistry) / 4;
        public ReStudent()
        {

        }

        public ReStudent(Student inputStudent)
        {
            _id = inputStudent.Id;
            _dob = inputStudent.Dob;
            _math = inputStudent.Math;
            _physics = inputStudent.Physics;
            _chemistry = inputStudent.Chemistry;
        }

        public void SplitFullName(Student inputStudent)
        {
            StudentServices.SplitFullName(inputStudent.Fullname, out _firstname, out _lastname);
        }
    }
}
