using System;
using System.Collections.Generic;
using System.Text;

namespace READ_JSON
{
    class Matrix
    {
        public List<List<int>> matrix { get; set; }
        public List<Student> students { get; set; }
    }

    class Student
    {
        public int studentId { get; set; }
        public string fullname { get; set; }
        public DateTime dob { get; set; }
        public List<Subject> scores { get; set; }
        public double averageScore => CalAverageScore();
        private double CalAverageScore()
        {
            double sum = 0.0;
            foreach (Subject item in scores)
            {
                sum += item.score;
            }
            return sum / scores.Count;
        }
    }

    class Subject
    {
        public string scoreName { get; set; }
        public double score { get; set; }
    }
}
