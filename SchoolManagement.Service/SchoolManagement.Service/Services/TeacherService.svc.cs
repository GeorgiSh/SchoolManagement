using SchoolManagement.Models;
using SchoolManagement.Service.Contracts;
using SchoolManagement.Service.Repositories;
using System.Collections.Generic;

namespace SchoolManagement.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository(DatabaseHelper.GetDatabasePath());
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.AddTeacher(teacher);
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAllTeachers();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.UpdateTeacher(teacher);
        }

        public void DeleteTeacher(int teacherId)
        {
            _teacherRepository.DeleteTeacher(teacherId);
        }
    }
}
