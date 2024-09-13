using SchoolManagement.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolManagement.Service.Contracts
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        IEnumerable<Student> GetAllStudents();

        [OperationContract]
        void AddStudent(Student student);

        [OperationContract]
        void UpdateStudent(Student student);

        [OperationContract]
        void DeleteStudent(int studentId);
    }
}
