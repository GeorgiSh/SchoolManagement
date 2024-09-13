using System;

namespace SchoolManagement.Models
{
    public class Teacher : Person
    {
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string SubjectSpecialization { get; set; }
    }
}
