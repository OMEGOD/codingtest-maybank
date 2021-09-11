using AutoMapper;
using CodingTest.Entity;
using CodingTest.ViewModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanViewModel, Loan>().ReverseMap();
            CreateMap<CreateLoanRequest, Loan>().ReverseMap();
            CreateMap<EditLoanRequest, Loan>().ReverseMap();
            CreateMap<LoanSearchResponse, Loan>().ReverseMap();
        }
    }
}
