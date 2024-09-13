namespace SchoolManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }      // Foreign Key to Student
        public int ClassId { get; set; }        // Foreign Key to Class
        public string Grade { get; set; }       // Grade for this enrollment

        // Navigation properties (optional, depending on use)
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}