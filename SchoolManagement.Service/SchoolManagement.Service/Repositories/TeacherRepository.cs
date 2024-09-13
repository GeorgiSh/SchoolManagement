using LiteDB;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Service.Repositories
{
    public class TeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddTeacher(Teacher teacher)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Insert into the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                var teacherAsPerson = new Person
                {
                    PersonId = teacher.PersonId,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    DateOfBirth = teacher.DateOfBirth,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber
                };
                personCollection.Insert(teacherAsPerson);

                // Insert into the Teacher collection
                var teacherCollection = db.GetCollection<Teacher>("Teachers");
                teacherCollection.Insert(teacher);
            }
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                return db.GetCollection<Teacher>("Teachers").FindAll().ToList();
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Update in the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                var teacherAsPerson = personCollection.FindById(teacher.PersonId);
                if (teacherAsPerson != null)
                {
                    teacherAsPerson.FirstName = teacher.FirstName;
                    teacherAsPerson.LastName = teacher.LastName;
                    teacherAsPerson.DateOfBirth = teacher.DateOfBirth;
                    teacherAsPerson.Email = teacher.Email;
                    teacherAsPerson.PhoneNumber = teacher.PhoneNumber;
                    personCollection.Update(teacherAsPerson);
                }

                // Update in the Teacher collection
                var teacherCollection = db.GetCollection<Teacher>("Teachers");
                teacherCollection.Update(teacher);
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                // Delete from the Person collection
                var personCollection = db.GetCollection<Person>("Persons");
                personCollection.Delete(teacherId);

                // Delete from the Teacher collection
                var teacherCollection = db.GetCollection<Teacher>("Teachers");
                teacherCollection.Delete(teacherId);
            }
        }
    }
}
