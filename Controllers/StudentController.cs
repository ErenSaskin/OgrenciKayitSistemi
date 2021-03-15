using Microsoft.AspNetCore.Mvc;
using OgrenciKayitSistemi.Models;
using OgrenciKayitSistemi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Repository<Student> _repository;
        private readonly Repository<NewStudentSystem> _repositoryNewStudentSystem;

        public StudentController(Repository<Student> repository, Repository<NewStudentSystem> repositoryNewStudentSystem)
        {
            _repository = repository;
            _repositoryNewStudentSystem = repositoryNewStudentSystem;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get() =>
            await _repository.Get();

        [HttpGet("[action]/{id:length(24)}")]
        public async Task<ActionResult<Student>> Getbyid([FromRoute] string id)
        {
            var ogrenci = await _repository.Get(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return ogrenci;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Student>> Create(Person person)
        {
            try
            {
                var students = await _repository.Get();
                students ??= new List<Student>();
                IStudentBuilder builder = new StudentBuilder(person);
                builder.BuildMail();
                builder.BuildClass();
                builder.BuildNumber(students.Count);
                var student = await _repository.Create(builder.Result());

                NewStudentSystemController newStudentSystemController = new NewStudentSystemController(_repositoryNewStudentSystem);
                _ = newStudentSystemController.Create(student);

                return student;
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPut("[action]/{id:length(24)}")]
        public async Task<Student> Update(string id, Person person)
        {
            try
            {
                var students = await _repository.Get(id);
                var numara = students.Number;

                if (students != null)
                {
                    IStudentBuilder builder = new StudentBuilder(person);
                    builder.BuildMail();
                    builder.BuildClass();
                    builder.BuildNumber((int.Parse(numara.Substring(4, 7)) - 1));


                    _ = await _repository.Update(id, builder.Result());
                    NewStudentSystemController newStudentSystemController = new NewStudentSystemController(_repositoryNewStudentSystem);
                    _ = newStudentSystemController.Update(id, builder.Result());


                }

                return students;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpDelete("[action]/{id:length(24)}")]
        public async Task<ActionResult<Student>> Delete(string id)
        {
            var ogrenci = await _repository.Get(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            _repository.Remove(ogrenci.Id);
            NewStudentSystemController newStudentSystemController = new NewStudentSystemController(_repositoryNewStudentSystem);
            _ = newStudentSystemController.Delete(id);

            return ogrenci;
        }
    }
}
