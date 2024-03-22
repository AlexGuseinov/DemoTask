using Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetail : BaseProblemDetail
    {
        public BusinessProblemDetail(Exception exception)
        {
            Title = "Business Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            TraceId = GenerateTraceId();
        }
    }
}
