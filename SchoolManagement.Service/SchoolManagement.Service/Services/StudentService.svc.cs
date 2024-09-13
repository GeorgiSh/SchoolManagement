using SchoolManagement.Models;
using SchoolManagement.Service.Contracts;
using SchoolManagement.Service.Repositories;
using System.Collections.Generic;

namespace SchoolManagement.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository(DatabaseHelper.GetDatabasePath());
        }

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _studentRepository.DeleteStudent(studentId);
        }
    }
}
