using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OgrenciKayitSistemi.Models
{
    public class NewStudentSystem : Entity, INewStudentSystem
    {

        private readonly Student oldStudent;
        private string name;
        private string surname;
        private DateTime dateOfReg;
        private string @class;
        private string number;
        private string email;
        private string password;

        public NewStudentSystem(Student student)
        {
            this.oldStudent = student;
            SetOpr();
        }

        [BsonElement("Name")]
        public string Name { get => name; set => name = value; }

        [BsonElement("Surname")]
        public string Surname { get => surname; set => surname = value; }

        [BsonElement("DateOfReg")]
        public DateTime DateOfReg { get => dateOfReg; set => dateOfReg = value; }

        [BsonElement("Class")]
        public string Class { get => @class; set => @class = value; }

        [BsonElement("Number")]
        public string Number { get => number; set => number = value; }

        [BsonElement("Email")]
        public string Email { get => email; set => email = value; }

        [BsonElement("Password")]
        public string Password { get => password; set => password = value; }


        void SetOpr()
        {
            Id = this.oldStudent.Id;
            name = this.oldStudent.Name;
            surname = this.oldStudent.Surname;
            dateOfReg = this.oldStudent.DateOfReg;
            @class = (this.oldStudent.Class).ToString();
            number = this.oldStudent.Number;
            email = this.oldStudent.Email;
            password = this.oldStudent.Name.Substring(0, 1) + this.oldStudent.Surname.Substring(0, 1) + this.oldStudent.Number.Substring(0, 3);
        }



    }
}