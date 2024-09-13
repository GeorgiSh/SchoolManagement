using LiteDB;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Service.Repositories
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddStudent(Student student)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Insert into the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                var studentAsPerson = new Person
                {
                    PersonId = student.PersonId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber
                };
                personCollection.Insert(studentAsPerson);

                // Insert into the Student collection
                var studentCollection = db.GetCollection<Student>("Students");
                studentCollection.Insert(student);
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                return db.GetCollection<Student>("Students").FindAll().ToList();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Update in the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                var studentAsPerson = personCollection.FindById(student.PersonId);
                if (studentAsPerson != null)
                {
                    studentAsPerson.FirstName = student.FirstName;
                    studentAsPerson.LastName = student.LastName;
                    studentAsPerson.DateOfBirth = student.DateOfBirth;
                    studentAsPerson.Email = student.Email;
                    studentAsPerson.PhoneNumber = student.PhoneNumber;
                    personCollection.Update(studentAsPerson);
                }

                // Update in the Student collection
                var studentCollection = db.GetCollection<Student>("Students");
                studentCollection.Update(student);
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Delete from the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                personCollection.Delete(studentId);

                // Delete from the Student collection
                var studentCollection = db.GetCollection<Student>("Students");
                studentCollection.Delete(studentId);
            }
        }
    }
}
