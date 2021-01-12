using System;
using System.Collections.Generic;
using System.Text;

namespace BAI_2
{
    class ReStudent : Student, IComparable<ReStudent>
    {
        private double _diemTrungBinh => AverageScores();
        private string _xepLoai => ClassificateStudent();

        public double DiemTrungBinh => _diemTrungBinh;
        public string XepLoai => _xepLoai;

        private double AverageScores()
        {
            double sum = 0.0;
            foreach (Subject item in MonHoc)
            {
                if (item.TenMonHoc == "Toan") sum += (item.DiemThi * 2);
                else sum += item.DiemThi;
            }
            return sum / 4;
        }

        private string ClassificateStudent()
        {
            if (_diemTrungBinh >= 9) return "Xuat sac";
            else if (_diemTrungBinh >= 8) return "Gioi";
            else if (_diemTrungBinh >= 7) return "Kha";
            else if (_diemTrungBinh >= 6.5) return "TB Kha";
            else if (_diemTrungBinh >= 5) return "Trung binh";
            else if (_diemTrungBinh >= 3.5) return "Yeu";
            return "Kem";
        }

        public int CompareTo(ReStudent student)
        {
            if (_diemTrungBinh < student.DiemTrungBinh) return 1;
            else if (_diemTrungBinh == student.DiemTrungBinh) return 0;
            else return -1;
        }

    }
}
