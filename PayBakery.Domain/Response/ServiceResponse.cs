using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayBakery.Domain.Response
{
    public class ServiceResponse
    {
        public bool Successful => !Errors.Any();
        public string Message { get; set; }
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Result { get; set; }
    }

    public class ValidationError
    {
        public ValidationError(string code, string error)
        {
            Code = code;
            Error = error;
        }
        public string Error { get; set; }
        public string Code { get; set; }

    }
}
