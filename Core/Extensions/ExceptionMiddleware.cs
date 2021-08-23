using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)//bütün kodları try-catch içine alır
        {
            try
            {
                await _next(httpContext);//hata almazsa devam
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);//hata alırsa handle eder
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))//validation hatası ise 
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;//hataları errorsa attar
                httpContext.Response.StatusCode = 400;//badrequest

                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode = 400,
                    message = message,
                    ValidationErrors = errors
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails //responsu ErrorDetails formatında gönder
            {
                StatusCode = httpContext.Response.StatusCode,
                message = message
            }.ToString());
        }
    }
}
