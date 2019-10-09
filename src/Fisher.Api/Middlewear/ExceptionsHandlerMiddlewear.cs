using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Fisher.Api.Middlewear
{
    public class ExceptionsHandlerMiddleware
    {
        private RequestDelegate _next;

        public ExceptionsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(e,context);
            }
        }

        private  Task HandleException(Exception exception,HttpContext context)
        {
            int statusCode;
            var type = exception.GetType();
            switch (exception)
            {
                case Exception e when e.GetType()==typeof(UnauthorizedAccessException):
                    statusCode =(int) HttpStatusCode.Unauthorized;
                    break;
                default:
                   statusCode= (int)HttpStatusCode.BadRequest;
                    break;  
            }

            var payload = JsonConvert.SerializeObject(new {code = statusCode, message = exception.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(payload);


        }
    }
}