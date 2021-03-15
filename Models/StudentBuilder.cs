using System;

namespace OgrenciKayitSistemi.Models
{
    public class StudentBuilder : IStudentBuilder
    {
        private readonly Student student;

        public StudentBuilder(Person person)
        {
            student = new Student
            {
                Name = person.Name,
                Surname = person.Surname,
                DateOfReg = person.DateOfReg
            };
        }

        public Student Result()
        {
            return this.student;
        }

        public void BuildClass()
        {
            student.Class = DateTime.Now.Year - student.DateOfReg.Year;
            student.Class = (student.Class < 0) ? 0 : student.Class;
        }

        public void BuildMail()
        {
            student.Email = $"{student.Name.ToLower()}.{student.Surname.ToLower()}@ogrenci.ibu.edu.tr";
        }

        public void BuildNumber(int count)
        {
            string scount = (count + 1).ToString();
            student.Number = $"{student.DateOfReg.Year.ToString().Substring(2, 2)}BM{scount.PadLeft(7, '0')}";
        }


    }
}
