using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using URLShortener.Common.Exceptions;
using URLShortener.Web.Dtos;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace URLShortener.Web.MiddleWares
{
    public static class CustomErrorHandlerHelper
    {
        public static void UseCustomErrors(this IApplicationBuilder app)
        {
            app.Use(WriteResponse);
        }

        private static async Task WriteResponse(HttpContext httpContext, Func<Task> next)
        {
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;

            if (ex == null)
                return;

            if (!(ex is IBusinessException exception)) return;

            var model = new ResultDto<ErrorDto>
            {
                Succeeded = false,
                Result = null,
                Error = new ErrorDto
                {
                    Code = exception.GetCode(),
                    Message = exception.ReturnMessage(),
                    Details = exception.GetData()
                }
            };

            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            httpContext.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(httpContext.Response.Body))
            {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }

        }
    }
}
