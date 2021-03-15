using System;

namespace OgrenciKayitSistemi.Models
{
    interface INewStudentSystem
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfReg { get; set; }
        public string Class { get; set; }   //Yeni sistemde sınıf değeri string tutuluyor.
        public string Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    //Yeni sistemde ek olarak parola isteniyor.
    }
}
