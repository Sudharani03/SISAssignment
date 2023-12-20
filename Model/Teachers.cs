using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Model
{
    internal class Teachers
    {
        public int TeacherId { get; set; } //Primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Default Constructor
        public Teachers()
        {
        }

        // Parameterized Constructor
        public Teachers(int teacherId, string firstName, string lastName, string email)
        {
            TeacherId = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return $"Teacher ID : {TeacherId}\t Name : {FirstName + " " + LastName}\t  Email : {Email}";
        }
    }
}
