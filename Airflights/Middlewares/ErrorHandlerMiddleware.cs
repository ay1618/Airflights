using Airflights.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Airflights.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;


        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._logger = loggerFactory?.CreateLogger<ErrorHandlerMiddleware>()
                ?? throw new NotImplementedException(nameof(ILogger<ErrorHandlerMiddleware>));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Somthing went wrong: {ex}");
                await this.HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // handle ex and write logs

            var response = new ApiResponse(AirflightsShared.Enums.ResultCode.Error);
            var result = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(result);
        }
    }
}
