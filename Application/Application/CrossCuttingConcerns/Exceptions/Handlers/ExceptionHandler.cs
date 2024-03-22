using Application.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        protected HttpResponse response;
        public Task HandleException(Exception exception, HttpContext context)
        {
            response = context.Response;
            if (exception is BusinessException businessException) return HandleException(businessException);
            if (exception is UnauthorizeException unauthorizeException) return HandleException(unauthorizeException);
            if (exception is ValidationException validationException) return HandleException(validationException);
            return HandleException(exception);
        }

        protected abstract Task HandleException(BusinessException exception);
        protected abstract Task HandleException(UnauthorizeException exception);
        protected abstract Task HandleException(ValidationException exception);
        protected abstract Task HandleException(Exception exception);
    }
}
