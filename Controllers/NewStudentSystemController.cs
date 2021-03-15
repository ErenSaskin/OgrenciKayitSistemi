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
    public class NewStudentSystemController : Controller
    {

        private readonly Repository<NewStudentSystem> _repository;

        public NewStudentSystemController(Repository<NewStudentSystem> repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<List<NewStudentSystem>>> Get() =>
            await _repository.Get();



        [HttpGet("[action]/{id:length(24)}")]
        public async Task<ActionResult<NewStudentSystem>> Getbyid([FromRoute] string id)
        {
            var ogrenci = await _repository.Get(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return ogrenci;
        }



        [HttpPost("[action]")]
        public async Task<ActionResult<NewStudentSystem>> Create(Student student)
        {
            try
            {
                INewStudentSystem newStudent = new NewStudentSystem(student);
                var _newStudent = await _repository.Create((NewStudentSystem)newStudent);
                return _newStudent;
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPut("[action]/{id:length(24)}")]
        public async Task<NewStudentSystem> Update(string id, Student student)
        {
            try
            {
                var students = await _repository.Get(id);


                if (students != null)
                {


                    INewStudentSystem newStudent = new NewStudentSystem(student);

                    _ = await _repository.Update(id, (NewStudentSystem)newStudent);



                }

                return students;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpDelete("[action]/{id:length(24)}")]
        public async Task<ActionResult<NewStudentSystem>> Delete(string id)
        {
            var ogrenci = await _repository.Get(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            _repository.Remove(ogrenci.Id);

            return ogrenci;
        }
    }



}

