using System;
using System.Threading.Tasks;
using Cw4.Dal;
using Cw4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _studentDbService;

        public StudentsController(IStudentDbService studentDbService)
        {
            _studentDbService = studentDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GeStudents(string orderBy)
        {
            try
            {
                return Ok(await _studentDbService.GetStudents());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //student.IndexNumber = $"{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Ąktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }

    }
}
