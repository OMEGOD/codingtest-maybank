using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Services.BLL
{
    public class Global
    {
        public static readonly string SuccessMessage = "success";
        public static readonly string ErrorMessage = "error";
        public static readonly string DataIsNotValid = "Data/Id is not valid";

        public class ApiResponse
        {
            public bool Status { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }
    }
}
