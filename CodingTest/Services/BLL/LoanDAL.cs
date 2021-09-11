using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Services.BLL
{
    public class LoanDAL
    {
        public static decimal CalculateAmountWithInterest(int period, decimal loanAmount, decimal interest)
        {
            var interestAmount = (interest / 100) * loanAmount;
            var totalAmount = loanAmount + interestAmount;

            return totalAmount / period;
        }
    }
}
