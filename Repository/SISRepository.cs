using SIS_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SIS_Assignment.Exceptions;
using SIS_Assignment.Utility;
using SIS_Assignment.Repository;
using SIS_Assignment.Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Repository
{
    internal class SISRepository : ISISRepository
    {

        public string connectionString;
        SqlCommand cmd = null;

        public SISRepository()
        {
            connectionString = DbConnectionUtility.GetConnectionString();
            cmd = new SqlCommand();
        }
        public int UpdateStudentInfo(int studentId ,string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Students SET FirstName=@firstName, LastName=@lastName, DOB=@dateOfBirth, Email=@email, PhoneNumber=@phoneNumber WHERE StudentID=@studentID";

                
                cmd.Parameters.AddWithValue("@studentID", studentId);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int updateStatus = cmd.ExecuteNonQuery();

                if (updateStatus > 0)
                {
                    Console.WriteLine($"{updateStatus} Student Information Updated Successfully!");
                }
                else
                {
                    throw new StudentNotFoundException("Student with the entered id is not found , please check and re enter the student id whose student info is to be updated");
                }

                return updateStatus;
            }
        }

        //Displays all students info
        public List<Students> DisplayStudentInfo()
        {
            List<Students> students = new List<Students>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Students";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Students student = new Students();
                    student.StudentId = (int)reader["StudentId"];
                    student.FirstName = (string)reader["FirstName"];
                    student.LastName = (string)reader["LastName"];
                    student.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    student.Email = (string)reader["Email"];
                    student.PhoneNumber = (string)reader["PhoneNumber"];

                    students.Add(student);
                }
                return students;
            }
        }

        //Displays Particular student info
        public List<Students> FindStudentById(int studentId)
        {
            List<Students> students = new List<Students>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Students WHERE StudentId = @S_Id";
                cmd.Parameters.AddWithValue("@S_Id", studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Students student = new Students();
                    student.StudentId = (int)reader["studentId"];
                    student.FirstName = (string)reader["firstName"];
                    student.LastName = (string)reader["lastName"];
                    student.DateOfBirth = (DateTime)reader["dateOfBirth"];
                    student.Email= (string)reader["email"];
                    student.PhoneNumber = (string)reader["phoneNumber"];
                    
                    students.Add(student);
                }
                cmd.Parameters.Clear();
                if (students.Count() > 0)
                {
                    return students;
                }
                else
                {
                    throw new StudentNotFoundException("Sorry, Student u r trying to find is not Found , Invalid Id Entered...Exit and Please Enter Valid Id !!\n");

                }
            }
        }

        //GetEnrolledCourses() method 

        public List<Courses> GetEnrolledCourses(int studentId)
        {
            List<Courses> enrolledCourses = new List<Courses>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT c.CourseName AS CourseEnrolled FROM Courses c " +
                                  "INNER JOIN Enrollments e ON c.CourseId = e.CourseId " +
                                  "WHERE e.StudentId = @StudentId";
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Courses course = new Courses();
                    
                    course.CourseName = (string)reader["CourseName"];
                    

                    enrolledCourses.Add(course);
                }
                cmd.Parameters.Clear();

                if (enrolledCourses.Count > 0)
                {
                    return enrolledCourses;
                }
                else
                {
                    throw new CourseNotFoundException("Student is not enrolled in any courses.");
                }
            }
        }

        //create student info 

        public int CreateStudent(int studentID, string fname, string lname, DateTime dob, string email, string phone)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Students values(@sid, @fname, @lname, @dob, @email, @phone)";
                cmd.Parameters.AddWithValue("@sid", studentID);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int createStudentStatus = cmd.ExecuteNonQuery();

                return createStudentStatus;
            }
        }

        //Implementation for Student class methods
        public int EnrollInCourse(int courseID, int studentID, DateTime enrollmentDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                List<int> courseIDList = new List<int>();
                cmd.CommandText = "select course_id from Enrollments where student_id=@stid";
                cmd.Parameters.AddWithValue("@stid", studentID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courseIDList.Add((int)reader["course_id"]);
                }
                sqlConnection.Close();

                bool isEnrolled = false;
                foreach (int c in courseIDList)
                {
                    if (c == courseID)
                        isEnrolled = true;
                }

                if (isEnrolled)
                {
                    cmd.CommandText = "insert into Enrollments(student_id, course_id, enrollment_date) values(@sid, @cid, @edate)";
                    cmd.Parameters.AddWithValue("@sid", studentID);
                    cmd.Parameters.AddWithValue("@cid", courseID);
                    cmd.Parameters.AddWithValue("@edate", enrollmentDate);

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    int enrollStatus = cmd.ExecuteNonQuery();

                    return enrollStatus;
                }
                else
                    throw new DuplicateEnrollmentException();
            }
        }

        //Get payment history

        public List<Payments> GetPaymentHistory(int studentID)
        {
            List<Payments> paymentHistory = new List<Payments>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Payments where student_id=@sid";
                cmd.Parameters.AddWithValue("@sid", studentID);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payments p = new Payments();
                    p.PaymentId = (int)reader["payment_id"];
                    p.StudentId = (int)reader["student_id"];
                    p.Amount = Convert.ToDouble(reader["amount"]);
                    p.PaymentDate = (DateTime)reader["payment_date"];
                    paymentHistory.Add(p);
                }
            }

            return paymentHistory;
        }





    }
}
