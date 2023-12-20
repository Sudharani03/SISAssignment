using SIS_Assignment.Service;
using SIS_Assignment.Model;
using SIS_Assignment.Repository;


ISISRepository iCarLeaseRepository = new SISRepository();


ISISService sisservice = new SISService();

while (true)
{
    Console.WriteLine("-------------------STUDENTS------------------\n");
    Console.WriteLine("1. DisplayStudentInfo");
    Console.WriteLine("2. FindStudentbyId");
    Console.WriteLine("3. UpdateStudentInfo");
    Console.WriteLine("4.EnrollInCourse");
    Console.WriteLine("5.CreateStudent");
    Console.WriteLine("6.GetPaymentHistory");
    Console.WriteLine("7.GetEnrolledCourses");

    Console.WriteLine("-----------------------------------------------\n");
    Console.WriteLine("16.Exit");
    Console.WriteLine("\nEnter Your Choice:: \n");
    int choice = int.Parse(Console.ReadLine());


    switch (choice)
    {
        case 1:
            sisservice.DisplayStudentInfo();
            break;
        case 2:
            sisservice.FindStudentById();
            break;
        case 3:
            sisservice.UpdateStudentInfo();
            break;
        case 4:
            sisservice.EnrollInCourse();
            break;
        case 5:
            sisservice.CreateStudent();
            break;
        case 6:
            sisservice.GetPaymentHistory();
            break;
        case 7:
            sisservice.GetEnrolledCourses();
            break;

        case 16:
            string Result = sisservice.ExitConsole();
            if (Result.ToLower() == "yes")
            {
                Console.WriteLine("Exited successfully");
                Environment.Exit(0);
                break;
            }
            else
            {
                continue;
            }


    }
}
