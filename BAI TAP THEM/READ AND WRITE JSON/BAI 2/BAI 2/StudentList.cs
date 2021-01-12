using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_2
{
    class School<T> where T: class
    {
        public List<T> StudentsOfSchool { get; set; }
    }
}
