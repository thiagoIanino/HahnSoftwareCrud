using HahnSoftwareCrud.Application.Models;
using HahnSoftwareCrud.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HahnSoftwareCrud.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode responseStatusCode;

            if (context.Exception is BadRequestException)
                responseStatusCode = HttpStatusCode.BadRequest;

            else if (context.Exception is NotFoundExeption)
                responseStatusCode = HttpStatusCode.NotFound;

            else
                responseStatusCode = HttpStatusCode.InternalServerError;

            context.Result = new ObjectResult(new ErrorModel(context.Exception.Message))
            {
                StatusCode = responseStatusCode.GetHashCode()
            };
        }
    }
}
