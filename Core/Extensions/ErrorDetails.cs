using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);//json formatına çevirir
        }


    }

    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
