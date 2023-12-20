using SIS_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Assignment.Exceptions;
using SIS_Assignment.Repository;
using SIS_Assignment.Service;
using SIS_Assignment.Utility;

namespace SIS_Assignment.Repository
{
    internal interface ISISRepository
    {
        public int UpdateStudentInfo(int studentId,string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);

        public List<Students> DisplayStudentInfo();

        public List<Students> FindStudentById(int studentId);

        List<Courses> GetEnrolledCourses(int studentId);
        int CreateStudent(int studentID, string fname, string lname, DateTime dob, string email, string phone);
        int EnrollInCourse(int courseID, int studentID, DateTime enrollmentDate);
        List<Payments> GetPaymentHistory(int studentID);



    }
}
