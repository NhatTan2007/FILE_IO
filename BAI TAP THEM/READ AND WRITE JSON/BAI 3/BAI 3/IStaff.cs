using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_3
{
    interface IStaff
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public double SalaryInMonth { get; set; }
        public double SalaryPerDay { get; set; }
        public int DaysWorkInMonth { get; set; }
        public int MyProperty { get; set; }
    }
}
