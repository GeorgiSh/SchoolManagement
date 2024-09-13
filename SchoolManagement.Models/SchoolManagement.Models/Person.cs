using LiteDB;
using System;

namespace SchoolManagement.Models
{
    public class Person
    {
        [BsonId]
        public int PersonId { get; set; } // Unique identifier for LiteDB

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
