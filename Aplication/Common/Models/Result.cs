using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result<T>
    {
        public Result(bool success, T data, string message = null, string[] errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }
    }

    public class Result
    {
        public Result(bool success, string message = null, string[] errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }      
    }
}
