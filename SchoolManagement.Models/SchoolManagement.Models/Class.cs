using LiteDB;

namespace SchoolManagement.Models
{
    public class Class
    {
        [BsonId]
        public int ClassId { get; set; } // Unique identifier for LiteDB

        public string ClassName { get; set; }
        public string ClassDescription { get; set; }

        public int? TeacherId { get; set; } // Foreign key reference to Teacher
    }
}
