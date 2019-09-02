using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Tracker.Entity.Entities;

namespace Tracker.Api.Layers
{
    public class CheckContentType
    {
        private readonly RequestDelegate _next;

        public CheckContentType(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var contentType = context.Request.ContentType;

            if (contentType != "application/json")
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse<string>
                {
                    Data = null, Error = true, Message = "Invalid Content Type", StatusCode = 400
                }));
                return;
            }

            await _next(context);

        }
    }
}