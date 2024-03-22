using Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;
using Application.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetail : BaseProblemDetail
    {
        Dictionary<string, List<string>> Errors;

        public ValidationProblemDetail(Exception exception)
        {
            Title = "Validation Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.Unauthorized;
            TraceId = GenerateTraceId();
            Errors = (exception as ValidationException).Errors;
        }
    }
}
