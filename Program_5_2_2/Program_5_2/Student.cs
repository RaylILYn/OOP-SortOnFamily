using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_5_2
{
    class Student: Chelovek
    {
        private Marr grade; //массив оценок

        public Student(string fam, string status, int god, Marr grade) : 
            base(fam, status, god)
        {
            this.grade = grade;
        }
        public Marr GetGrade()
        {
            return grade;
        }


        //сведения для студента это средняя оценка
        public override string Svedenija()
        {
            return $"средний бал {grade.GetSum()/grade.GetLength()}";
        }
    }
}
