using SchoolManagement.Models;
using SchoolManagement.Service.Contracts;
using SchoolManagement.Service.Repositories;
using System.Collections.Generic;

namespace SchoolManagement.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository(DatabaseHelper.GetDatabasePath());
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAllPersons();
        }

        public void AddPerson(Person person)
        {
            _personRepository.AddPerson(person);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
        }

        public void DeletePerson(int personId)
        {
            _personRepository.DeletePerson(personId);
        }

        public Person GetPersonById(int personId)
        {
            return _personRepository.GetPersonById(personId);
        }
    }
}
