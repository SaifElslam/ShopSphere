using System.Net;
using System.Text.Json;

namespace ShopSphere.Middlewere
{
    public class GlobalExceptionMiddlaware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddlaware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType =
                     "application/json";

                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    Message = ex.Message,
                    StatusCode = context.Response.StatusCode
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        } 
     
}
}
