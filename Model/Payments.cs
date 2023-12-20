using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Assignment.Model
{
    internal class Payments
    {
        public int PaymentId { get; set; } // Primary Key
        public int StudentId { get; set; } // Foreign Key
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Default Constructor
        public Payments()
        {
        }

        // Parameterized Constructor
        public Payments(int paymentId, int studentId, int amount, DateTime paymentDate)
        {
            PaymentId = paymentId;
            StudentId = studentId;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public override string ToString()
        {
            return $"Payment ID : {PaymentId}\t StudentId : {StudentId}\t Amount : {Amount}\t PaymentDate : {PaymentDate}";
        }
    }
}
