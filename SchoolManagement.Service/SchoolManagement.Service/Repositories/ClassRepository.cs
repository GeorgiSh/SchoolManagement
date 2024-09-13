// In SchoolManagement.Service project
using LiteDB;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Service.Repositories
{
    public class ClassRepository
    {
        private readonly string _collectionName = "classes";

        public void AddClass(Class @class)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                var collection = db.GetCollection<Class>(_collectionName);
                collection.Insert(@class);
            }
        }

        public Class GetClass(int classId)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                var collection = db.GetCollection<Class>(_collectionName);
                return collection.FindById(classId);
            }
        }

        public List<Class> GetAllClasses()
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                var collection = db.GetCollection<Class>(_collectionName);
                return collection.FindAll().ToList();
            }
        }

        public void UpdateClass(Class @class)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                var collection = db.GetCollection<Class>(_collectionName);
                collection.Update(@class);
            }
        }

        public void DeleteClass(int classId)
        {
            using (var db = DatabaseHelper.GetDatabase())
            {
                var collection = db.GetCollection<Class>(_collectionName);
                collection.Delete(classId);
            }
        }
    }
}
