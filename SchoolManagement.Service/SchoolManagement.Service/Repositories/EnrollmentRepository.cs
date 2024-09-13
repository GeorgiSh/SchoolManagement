using LiteDB;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Service.Repositories
{
    public class EnrollmentRepository
    {
        private readonly string _databasePath;

        public EnrollmentRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var enrollmentCollection = db.GetCollection<Enrollment>("Enrollments");
                enrollmentCollection.Insert(enrollment);
            }
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                return db.GetCollection<Enrollment>("Enrollments").FindAll().ToList();
            }
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var enrollmentCollection = db.GetCollection<Enrollment>("Enrollments");
                enrollmentCollection.Update(enrollment);
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var enrollmentCollection = db.GetCollection<Enrollment>("Enrollments");
                enrollmentCollection.Delete(enrollmentId);
            }
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var enrollmentCollection = db.GetCollection<Enrollment>("Enrollments");
                return enrollmentCollection.FindById(enrollmentId);
            }
        }
    }
}
