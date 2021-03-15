using System;

namespace OgrenciKayitSistemi.Models
{
    public interface IOldStudentSystem
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfReg { get; set; }
        public int Class { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

    }
}
