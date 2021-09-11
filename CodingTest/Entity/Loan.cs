using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Entity
{
    public class Loan : BaseEntity
    {
        public int MonthPeriod { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal SpecialInterestRate { get; set; }
        public int OverduePeriod { get; set; }
        public int OverdueRate { get; set; }
    }
}
