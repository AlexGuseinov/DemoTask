using Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalProblemDetail : BaseProblemDetail
    {
        public InternalProblemDetail(Exception exception)
        {
            Title = "Internal Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.InternalServerError;
            TraceId = GenerateTraceId();
        }
    }
}
