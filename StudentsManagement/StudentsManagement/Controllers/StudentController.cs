using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository) 
        {
            this._studentRepository = studentRepository;

        }

        [HttpGet("All-Students")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            return Ok(students);
        }

        [HttpGet("Single-Student/{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            return Ok(student);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<Student>> AddstudentAsync(Student student)
        {
            var newstudent = await _studentRepository.AddstudentAsync(student);

            return Ok(newstudent);
        }

        [HttpGet("Delete-Student/{id}")]
        public async Task<ActionResult<Student>> DeletestudentAsync(int id)
        {
            var deletestudent = await _studentRepository.DeletestudentAsync(id);

            return Ok(deletestudent);
        }

        [HttpPost("Update-Student")]
        public async Task<ActionResult<Student>> UpdatestudentAsync(Student student)
        {
            var updatestudent = await _studentRepository.UpdatestudentAsync(student);

            return Ok(updatestudent);
        }
    }
}
