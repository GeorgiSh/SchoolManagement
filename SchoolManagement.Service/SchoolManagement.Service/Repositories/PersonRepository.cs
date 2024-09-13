using LiteDB;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Service.Repositories
{
    public class PersonRepository
    {
        private readonly string _databasePath;

        public PersonRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var personsCollection = db.GetCollection<Person>("Persons");
                return personsCollection.FindAll().ToList();
            }
        }

        public void AddPerson(Person person)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var personsCollection = db.GetCollection<Person>("Persons");
                personsCollection.Insert(person);
            }
        }

        public void UpdatePerson(Person person)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var personsCollection = db.GetCollection<Person>("Persons");
                personsCollection.Update(person);
            }
        }

        public void DeletePerson(int personId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var personsCollection = db.GetCollection<Person>("Persons");
                personsCollection.Delete(personId);
            }
        }

        public Person GetPersonById(int personId)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var personsCollection = db.GetCollection<Person>("Persons");
                return personsCollection.FindById(personId);
            }
        }
    }
}
