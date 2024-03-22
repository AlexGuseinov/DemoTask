using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Application.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons
{
    public class BaseProblemDetail : ProblemDetails
    {
        public string TraceId { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        protected string GenerateTraceId()
            => $"{DateTime.Now:dd-MM-yyyy:HH:mm:ss}-{Guid.NewGuid().ToString()}";
    }
}
