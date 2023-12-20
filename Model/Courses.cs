using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Model
{
    internal class Courses
    {
        public int CourseId { get; set; } // Primary Key
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; } // Foreign Key

        // Default Constructor
        public Courses()
        {
        }

        // Parameterized Constructor
        public Courses(int courseId, string courseName, int credits, int teacherId)
        {
            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;
            TeacherId = teacherId;
        }

        public override string ToString()
        {
            return $"Course ID : {CourseId}\t CourseName : {CourseName}\t Credits : {Credits}\t TeacherId : {TeacherId}"; 
        }
    }
}
