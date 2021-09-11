using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.ViewModels.Loan
{
    public class CreateLoanRequest
    {
        [Required]
        public int MonthPeriod { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Amount is not valid.")]
        public decimal Amount { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public decimal InterestRate { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public decimal SpecialInterestRate { get; set; }
        [Required]
        public int OverduePeriod { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public int OverdueRate { get; set; }
    }

    public class EditLoanRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int MonthPeriod { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Amount is not valid.")]
        public decimal Amount { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public decimal InterestRate { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public decimal SpecialInterestRate { get; set; }
        [Required]
        public int OverduePeriod { get; set; }
        [Required]
        [Range(0.0, 100, ErrorMessage = "Interest value is not valid.")]
        public int OverdueRate { get; set; }
    }

    public class SearchLoanRequest
    {
        public string Amount { get; set; }
        public string Period { get; set; }
    }
}
