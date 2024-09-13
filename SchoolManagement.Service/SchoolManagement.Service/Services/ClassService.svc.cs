using SchoolManagement.Models;
using SchoolManagement.Service.Contracts;
using SchoolManagement.Service.Repositories;
using System.Collections.Generic;

namespace SchoolManagement.Service.Services
{
    public class ClassService : IClassService
    {
        private readonly ClassRepository _classRepository;

        public ClassService()
        {
            _classRepository = new ClassRepository();
        }

        public void AddClass(Class @class)
        {
            _classRepository.AddClass(@class);
        }

        public void DeleteClass(int classId)
        {
            _classRepository.DeleteClass(classId);
        }

        public List<Class> GetAllClasses()
        {
            return _classRepository.GetAllClasses();
        }

        public Class GetClass(int classId)
        {
            return _classRepository.GetClass(classId);
        }

        public void UpdateClass(Class @class)
        {
            _classRepository.UpdateClass(@class);
        }
    }
}