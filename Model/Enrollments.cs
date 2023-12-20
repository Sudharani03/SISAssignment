using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Model
{
    internal class Enrollments
    {
        public int EnrollmentId { get; set; } // Primary Key
        public int StudentId { get; set; } // Foreign Key
        public int CourseId { get; set; } // Foreign Key
        public DateTime EnrollmentDate { get; set; }

        // Default Constructor
        public Enrollments()
        {
        }

        // Parameterized Constructor
        public Enrollments(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            EnrollmentId = enrollmentId;
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = enrollmentDate;
        }

        public override string ToString()
        {
            return $"Enrollment ID : {EnrollmentId}\t StudentId : {StudentId}\t CourseId : {CourseId}\t EnrollmentDate : {EnrollmentDate}";
        }
    }
}
