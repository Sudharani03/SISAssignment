using SIS_Assignment.Exceptions;
using SIS_Assignment.Repository;
using SIS_Assignment.Model;
using SIS_Assignment.Service;
using SIS_Assignment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Service 
{
    internal class SISService : ISISService
    {
        ISISRepository sisrepository = new SISRepository();

        public void UpdateStudentInfo()
        {
            try
            {
                Console.WriteLine("Enter the Student ID whose information is to be updated: ");
                int studentId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new First Name: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter the new Last Name: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter the new Date of Birth in (yyyy-MM-dd) format: ");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter the new Phone Number: ");
                string phoneNumber = Console.ReadLine();


                sisrepository.UpdateStudentInfo(studentId ,firstName, lastName, dateOfBirth, email, phoneNumber);

                Console.WriteLine("Student Information Updated !!!");
            }catch(StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void DisplayStudentInfo()
        {
            var students = sisrepository.DisplayStudentInfo();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void FindStudentById()
        {
            try
            {
                Console.WriteLine("Enter the Student Id :: ");
                int studentID = int.Parse(Console.ReadLine());
                var students = sisrepository.FindStudentById(studentID);
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrolledCourses()
        {
            try
            {
                Console.WriteLine("Enter the Student Id :: ");
                int studentID = int.Parse(Console.ReadLine());

                var students = sisrepository.FindStudentById(studentID);

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        public void EnrollInCourse()
        {
            //check whether student exisrs then check whether that course exists
            Console.WriteLine("Enter student id");
            int stuId = int.Parse(Console.ReadLine());

            Console.WriteLine("Entire the desire course");
            string desiredCourse = Console.ReadLine();

            Enrollments enroll = new Enrollments()
            {
                StudentId = stuId,
                EnrollmentDate = DateTime.Now,
            };
            int enrollStatus = sisrepository.EnrollInCourse(enroll, desiredCourse);
            if (enrollStatus != 0)
            {
                Console.WriteLine($"Student {stuId} enrolled in {desiredCourse} ");
            }
            else
            {
                Console.WriteLine("couldnt enroll");
            }
        }


        public string ExitConsole()
        {
            Console.WriteLine("Do you really want to exit : Yes/No ");
            string res = Console.ReadLine();
            return res;
        }



    }
}
