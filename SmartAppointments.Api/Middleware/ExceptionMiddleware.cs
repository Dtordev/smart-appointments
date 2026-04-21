using Microsoft.Data.SqlClient;
using SmartAppointments.Application.DTOs.Common;
using System.Text.Json;

namespace SmartAppointments.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException ex)
            {
                await HandleExceptionAsync(context, 1001, "DB Error", ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, 401, "Unauthorized", ex.Message);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, 400, "Bad Request", ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, 500, "Internal Server Error", ex.Message);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, int statusCode, string message, string error)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ApiResponse<object>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
                Error = error
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
