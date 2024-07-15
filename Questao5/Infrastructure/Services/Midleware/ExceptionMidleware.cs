using Questao5.Domain.Errors;
using System.Net;
using System.Text.Json;

namespace Questao5.Infrastructure.Services.Midleware
{
    public class ExceptionMidleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMidleware> _logger;

        public ExceptionMidleware(RequestDelegate next, ILogger<ExceptionMidleware> logger)
        {
            _next=next;
            _logger=logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new ApiException(context.Response.StatusCode.ToString(), ex.Message);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);  
                await context.Response.WriteAsync(json);    
            }
        }
    }
}
