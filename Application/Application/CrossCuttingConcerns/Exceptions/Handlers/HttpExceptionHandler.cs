using Application.CrossCuttingConcerns.Exceptions.Types;
using Core.CrossCuttingConcers.Exceptions.HttpProblemDetails;
using Core.Exceptions.ExceptionProblemDetails;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        protected override Task HandleException(BusinessException exception)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response.WriteAsync(new BusinessProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(UnauthorizeException exception)
        {
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return response.WriteAsync(new UnauthorizeProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(ValidationException exception)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response.WriteAsync(new ValidationProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(Exception exception)
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return response.WriteAsync(new InternalProblemDetail(exception).ToJson());
        }

    }
}
