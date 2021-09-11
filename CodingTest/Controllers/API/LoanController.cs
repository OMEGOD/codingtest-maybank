using CodingTest.Data;
using CodingTest.Services.BLL;
using CodingTest.Services.Repository.LoanRepository;
using CodingTest.ViewModels.Loan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoanRepository _loanRepository;

        public LoanController(ApplicationDbContext dbContext, ILoanRepository loanRepository)
        {
            _context = dbContext;
            _loanRepository = loanRepository;
        }

        [HttpGet]
        [Route("GetList")]
        public ActionResult GetActiveList()
        {
            try
            {
                var result = _loanRepository.GetActiveList(_context);

                return Ok(new Global.ApiResponse
                {
                    Status = true,
                    Message = Global.SuccessMessage,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(CreateLoanRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newLoan = _loanRepository.Create(_context, request, null);

                    _context.SaveChanges();

                    return Ok(new Global.ApiResponse
                    {
                        Status = true,
                        Message = Global.SuccessMessage,
                        Data = newLoan
                    });
                }

                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = Global.ErrorMessage,
                    Data = ModelState.Values.SelectMany(m => m.Errors).Select(x => x.ErrorMessage).First()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(EditLoanRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var targetLoan = _context.Loans.Find(request.Id);

                    if (targetLoan != null)
                    {
                        var editedLoan = _loanRepository.Edit(targetLoan, request, null);

                        _context.SaveChanges();

                        return Ok(new Global.ApiResponse
                        {
                            Status = true,
                            Message = Global.SuccessMessage,
                            Data = editedLoan
                        });
                    }

                    return BadRequest(new Global.ApiResponse
                    {
                        Status = false,
                        Message = Global.DataIsNotValid,
                        Data = null
                    });
                }

                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = Global.ErrorMessage,
                    Data = ModelState.Values.SelectMany(m => m.Errors).Select(x => x.ErrorMessage).First()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(string loanId)
        {
            try
            {
                var targetLoan = _context.Loans.Find(loanId);

                if (targetLoan != null)
                {
                    _context.Loans.Remove(targetLoan);
                    _context.SaveChanges();

                    return Ok(new Global.ApiResponse
                    {
                        Status = true,
                        Message = Global.SuccessMessage,
                        Data = null
                    });
                }

                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = Global.DataIsNotValid,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search(SearchLoanRequest request)
        {
            var result = _loanRepository.Search(_context, request);

            return Ok(new Global.ApiResponse
            {
                Status = true,
                Message = Global.SuccessMessage,
                Data = result
            });
        }

        [HttpGet]
        [Route("Details")]
        public ActionResult Details(string loanId, bool isEmployee)
        {
            try
            {
                var targetLoan = _context.Loans.Find(loanId);

                if (targetLoan != null)
                {
                    var result = _loanRepository.Details(_context, targetLoan, isEmployee);

                    return Ok(new Global.ApiResponse
                    {
                        Status = true,
                        Message = Global.SuccessMessage,
                        Data = result
                    });
                }

                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = Global.DataIsNotValid,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Global.ApiResponse
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
