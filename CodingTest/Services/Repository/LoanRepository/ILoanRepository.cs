using AutoMapper;
using CodingTest.Data;
using CodingTest.Entity;
using CodingTest.Services.BLL;
using CodingTest.ViewModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Services.Repository.LoanRepository
{
    public interface ILoanRepository
    {
        List<LoanViewModel> GetActiveList(ApplicationDbContext dbContext);
        Loan Create(ApplicationDbContext dbContext, CreateLoanRequest request, string userId);
        Loan Edit(Loan targetLoan, EditLoanRequest request, string userId);
        List<LoanSearchResponse> Search(ApplicationDbContext dbContext, SearchLoanRequest request);
        LoanDetailsResponse Details(ApplicationDbContext dbContext, Loan targetLoan, bool isEmployee);
    }

    public class LoanRepository : ILoanRepository
    {
        private readonly IMapper _mapper;

        public LoanRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<LoanViewModel> GetActiveList(ApplicationDbContext dbContext)
        {
            var result = dbContext.Loans.Where(x => x.IsActive).ToList();
            var response = _mapper.Map<List<LoanViewModel>>(result);

            return response;
        }

        public Loan Create(ApplicationDbContext dbContext, CreateLoanRequest request, string userId)
        {
            var model = _mapper.Map<Loan>(request);

            model.InitiliazeData(userId);
            dbContext.Loans.Add(model);

            return model;
        }

        public Loan Edit(Loan targetLoan, EditLoanRequest request, string userId)
        {
            var editedLoan = _mapper.Map(request, targetLoan);

            return editedLoan;
        }

        public List<LoanSearchResponse> Search(ApplicationDbContext dbContext, SearchLoanRequest request)
        {
            var targetLoans = dbContext.Loans
                .Where(x
                => x.IsActive
                && (x.Amount.ToString().Contains(request.Amount) && x.MonthPeriod.ToString().Contains(request.Period)))
                .ToList();

            var response = _mapper.Map<List<LoanSearchResponse>>(targetLoans);

            return response;
        }

        public LoanDetailsResponse Details(ApplicationDbContext dbContext, Loan targetLoan, bool isEmployee)
        {
            var interestRate = isEmployee ? targetLoan.SpecialInterestRate : targetLoan.InterestRate;
            var monthlyPayment = LoanDAL.CalculateAmountWithInterest(targetLoan.MonthPeriod, targetLoan.Amount, interestRate);
            var firstOverduePayment = LoanDAL.CalculateAmountWithInterest(targetLoan.MonthPeriod, monthlyPayment * targetLoan.MonthPeriod, targetLoan.OverdueRate);
            var secondOverduePayment = LoanDAL.CalculateAmountWithInterest(targetLoan.MonthPeriod, firstOverduePayment * targetLoan.MonthPeriod, targetLoan.OverdueRate);
            var thirdOverduePayment = LoanDAL.CalculateAmountWithInterest(targetLoan.MonthPeriod, secondOverduePayment * targetLoan.MonthPeriod, targetLoan.OverdueRate);

            var response = new LoanDetailsResponse
            {
                LoanAmount = targetLoan.Amount.ToString("N0"),
                InterestRate = interestRate.ToString("N") + "%",
                OverdueRate = targetLoan.OverdueRate.ToString("N") + "%",
                Period = targetLoan.MonthPeriod.ToString() + " Bulan",
                MonthlyPayment = monthlyPayment.ToString("N0"),
                OverduePayment = firstOverduePayment.ToString("N0") 
                                + ", " + secondOverduePayment.ToString("N0")
                                + ", " + thirdOverduePayment.ToString("N0")
            };

            return response;
        }
    }
}
