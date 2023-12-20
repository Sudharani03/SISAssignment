using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Model
{
    internal class Students
    {
        public int StudentId { get; set; } //Primary Key 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Default constructor
        public Students()
        {
        }

        // Parameterized Constructor
        public Students(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Student ID : {StudentId}\t Name : {FirstName+" "+ LastName}\t DateOfBirth : {DateOfBirth}\t Email : {Email}\t PhoneNumber : {PhoneNumber}";
        }

    }
}
