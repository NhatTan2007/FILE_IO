using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_2
{
    class Student
    {
        public int MaHS { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string Lop { get; set; }
        public List<Subject> MonHoc { get; set; }
    }
}
