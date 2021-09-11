using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Entity
{
    public class LoanPayment : BaseEntity
    {
        public string LoanId { get; set; }
        public virtual Loan Loan { get; set; }
        public decimal PaymentAmount { get; set; }
        public int Period { get; set; }
    }
}
