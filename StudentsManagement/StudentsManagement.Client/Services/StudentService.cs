using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<Student> AddstudentAsync(Student student)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/student/Add-Student", student);
            var respose = await newstudent.Content.ReadFromJsonAsync<Student>();
            return respose;
        }

        public async Task<Student> DeletestudentAsync(int studentId)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/student/Delete-Student", studentId);
            var respose = await newstudent.Content.ReadFromJsonAsync<Student>();
            return respose;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var allstudents = await _httpClient.GetAsync("api/student/All-students");
            var respose = await allstudents.Content.ReadFromJsonAsync<List<Student>>();
            return respose;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudents = await _httpClient.GetAsync("api/student/Single-Student");
            var respose = await singlestudents.Content.ReadFromJsonAsync<Student>();
            return respose;
        }

        public async Task<Student> UpdatestudentAsync(Student student)
        {
            var updatestudent = await _httpClient.PostAsJsonAsync("api/student/update-Student", student);
            var respose = await updatestudent.Content.ReadFromJsonAsync<Student>();
            return respose;
        }
    }
}
