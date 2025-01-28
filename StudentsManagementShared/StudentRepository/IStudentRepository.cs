using StudentsManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Shared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddstudentAsync(Student student);
        Task<Student> UpdatestudentAsync(Student student);
        Task<Student> DeletestudentAsync(int studentId);

        Task<List<Student>> GetAllStudentsAsync();

        Task<Student> GetStudentByIdAsync(int studentId);
    }
}
