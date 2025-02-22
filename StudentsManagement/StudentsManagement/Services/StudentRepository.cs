﻿using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task<Student> AddstudentAsync(Student student)
        {
            if (student == null) return null;

            var newstudent =_context.Students.Add(student).Entity;
            await _context.SaveChangesAsync();

            return newstudent;
        }   

        public async Task<Student> DeletestudentAsync(int studentId)
        {
            var student = await _context.Students.Where(x=>x.Id == studentId).FirstOrDefaultAsync();
            if(student == null) return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public Task<List<Student>> GetAllStudentsAsync()
        {
            var students = _context.Students.ToListAsync();

            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudent = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (singlestudent == null) return null;

            return singlestudent;
        }

        public async Task<Student> UpdatestudentAsync(Student student)
        {
            if (student == null) return null;


            var newstudent = _context.Students.Update(student).Entity;
            await _context.SaveChangesAsync();

            return newstudent;
        }
    }
}
