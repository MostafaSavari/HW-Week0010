using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week10.Enums
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public Result(bool isSuccess = false, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
