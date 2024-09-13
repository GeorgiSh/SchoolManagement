using SchoolManagement.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolManagement.Service.Contracts
{
    [ServiceContract]
    public interface IClassService
    {
        [OperationContract]
        void AddClass(Class @class);

        [OperationContract]
        Class GetClass(int classId);

        [OperationContract]
        List<Class> GetAllClasses();

        [OperationContract]
        void UpdateClass(Class @class);

        [OperationContract]
        void DeleteClass(int classId);
    }
}
