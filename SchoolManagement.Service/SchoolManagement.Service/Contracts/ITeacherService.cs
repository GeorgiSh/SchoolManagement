using SchoolManagement.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolManagement.Service.Contracts
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        IEnumerable<Teacher> GetAllTeachers();

        [OperationContract]
        void AddTeacher(Teacher teacher);

        [OperationContract]
        void UpdateTeacher(Teacher teacher);

        [OperationContract]
        void DeleteTeacher(int teacherId);
    }
}
