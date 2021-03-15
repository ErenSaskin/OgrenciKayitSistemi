using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OgrenciKayitSistemi.Models
{
    public class Student : Entity, IOldStudentSystem
    {

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Surname")]
        public string Surname { get; set; }

        [BsonElement("DateOfReg")]
        public DateTime DateOfReg { get; set; }

        [BsonElement("Class")]
        public int Class { get; set; }

        [BsonElement("Number")]
        public string Number { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

    }
}
