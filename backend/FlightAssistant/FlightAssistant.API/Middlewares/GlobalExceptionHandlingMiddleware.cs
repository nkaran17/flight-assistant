using FlightAssistant.Core.Enums;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FlightAssistant.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly Type[] BAD_REQUEST_EXCEPTIONS = { };
        private readonly Type[] NOT_FOUND_EXCEPTIONS = { };

        private readonly ILogService _logService;


        public GlobalExceptionHandlingMiddleware(ILogService logService)
        {
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await _logService.LogAsync(new Log
                {
                    Level = LogLevelEnum.Error,
                    Message = e.Message
                });

                int status;
                string type;
                string title;
                string detail;

                if (BAD_REQUEST_EXCEPTIONS.Contains(e.GetType()))
                {
                    status = (int)HttpStatusCode.BadRequest;
                    type = "Bad Request";
                    title = "Bad Request Error";
                    detail = e.Message;
                }
                else if (NOT_FOUND_EXCEPTIONS.Contains(e.GetType()))
                {
                    status = (int)HttpStatusCode.NotFound;
                    type = "Not Found";
                    title = "Not Found Error";
                    detail = e.Message;
                }
                else
                {
                    status = (int)HttpStatusCode.InternalServerError;
                    type = "Server Error";
                    title = "Server Error";
                    detail = "An internal server error has occured.";
                }

                context.Response.StatusCode = status;

                ProblemDetails problem = new()
                {
                    Status = status,
                    Type = type,
                    Title = title,
                    Detail = detail
                };

                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
