using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(default, true) { }
        public ErrorDataResult(T data) : base(data, true) { }
        public ErrorDataResult(T data, string message) : base(data, true, message) { }
        public ErrorDataResult(string message) : base(default, true, message) { }
    }
}
