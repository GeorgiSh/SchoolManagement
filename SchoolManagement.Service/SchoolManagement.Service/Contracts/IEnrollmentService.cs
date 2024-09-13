using SchoolManagement.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolManagement.Service.Contracts
{
    [ServiceContract]
    public interface IEnrollmentService
    {
        [OperationContract]
        IEnumerable<Enrollment> GetAllEnrollments();

        [OperationContract]
        void AddEnrollment(Enrollment enrollment);

        [OperationContract]
        void UpdateEnrollment(Enrollment enrollment);

        [OperationContract]
        void DeleteEnrollment(int enrollmentId);

        [OperationContract]
        Enrollment GetEnrollmentById(int enrollmentId);
    }
}
