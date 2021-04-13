using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Succsess { get; }

        public string Message { get; }

        public Result(bool success)
        {
            Succsess = success;
        }

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

    }
}
