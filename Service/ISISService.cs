using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Assignment.Exceptions;
using SIS_Assignment.Repository;
using SIS_Assignment.Model;
using SIS_Assignment.Service;
using SIS_Assignment.Utility;

namespace SIS_Assignment.Service
{
    internal interface ISISService
    {
        void UpdateStudentInfo();
        void DisplayStudentInfo();
        void FindStudentById();
        void CreateStudent();
        void EnrollInCourse();
        void GetPaymentHistory();
        
        string ExitConsole();
    }
}
