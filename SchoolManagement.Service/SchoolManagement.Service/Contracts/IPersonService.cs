using SchoolManagement.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolManagement.Service.Contracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        IEnumerable<Person> GetAllPersons();

        [OperationContract]
        void AddPerson(Person person);

        [OperationContract]
        void UpdatePerson(Person person);

        [OperationContract]
        void DeletePerson(int personId);

        [OperationContract]
        Person GetPersonById(int personId);
    }
}
