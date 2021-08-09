using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)//kendi middleware(hatayakalama)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
