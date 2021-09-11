using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.ViewModels.Loan
{
    public class LoanViewModel
    {
        public string Id { get; set; }
        public int MonthPeriod { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal SpecialInterestRate { get; set; }
        public int OverduePeriod { get; set; }
        public int OverdueRate { get; set; }
    }

    public class LoanSearchResponse
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public int MonthPeriod { get; set; }
    }

    public class LoanDetailsResponse
    {
        public string LoanAmount { get; set; }
        public string Period { get; set; }
        public string MonthlyPayment { get; set; }
        public string InterestRate { get; set; }
        public string OverdueRate { get; set; }
        public string OverduePayment { get; set; }
    }
}
