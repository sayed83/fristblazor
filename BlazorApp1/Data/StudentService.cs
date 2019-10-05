using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class StudentService
    {
        private StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            var student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(string id,Student s)
        {
            var student = await _context.Students.FindAsync(id);

            if(student == null)           
                return null;
                       
                student.FirstName = s.FirstName;
                student.LastName = s.LastName;
                student.School = s.School;
            
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student>DeletetudentAsync(string id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
             return null;
             _context.Students.Remove(student);     await _context.SaveChangesAsync();
            return student;
        }

    }
}
