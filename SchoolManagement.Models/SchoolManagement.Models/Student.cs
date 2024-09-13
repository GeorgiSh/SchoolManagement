using System.Collections.Generic;
using System;

namespace SchoolManagement.Models
{
    public class Student : Person
    {
        public string Major { get; set; }          // Major of the student
        public DateTime EnrollmentDate { get; set; }  // Date when the student enrolled

        // List of enrollments for this student (optional)
        public List<Enrollment> Enrollments { get; set; }
    }
}
