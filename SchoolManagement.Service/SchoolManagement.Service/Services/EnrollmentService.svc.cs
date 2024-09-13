using SchoolManagement.Models;
using SchoolManagement.Service.Contracts;
using SchoolManagement.Service.Repositories;
using System.Collections.Generic;

namespace SchoolManagement.Service.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly EnrollmentRepository _enrollmentRepository;

        public EnrollmentService()
        {
            _enrollmentRepository = new EnrollmentRepository(DatabaseHelper.GetDatabasePath());
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _enrollmentRepository.GetAllEnrollments();
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.AddEnrollment(enrollment);
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.UpdateEnrollment(enrollment);
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            _enrollmentRepository.DeleteEnrollment(enrollmentId);
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            return _enrollmentRepository.GetEnrollmentById(enrollmentId);
        }
    }
}
