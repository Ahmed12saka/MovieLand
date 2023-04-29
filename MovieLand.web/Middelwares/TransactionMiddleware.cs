using MovieLand.Infrastructure.Database.Configuration;
using Newtonsoft.Json;
using System.Net.Mime;
namespace MovieLand.web.Middelwares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly DatabaseContext _db;

        public TransactionMiddleware(
            DatabaseContext db)
        {
            _db = db;
        }
        public async Task InvokeAsync(
            HttpContext context,
            RequestDelegate next)
        {
            try
            {
                await next(context);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var response = new
                {
                    IsException = true,
                    Error = $"Database error occured. {ex.Message}",
                    Date = DateTime.Now
                };

                var responseText = JsonConvert.SerializeObject(response);
                context.Response.ContentLength = responseText.Length;

                await context.Response.WriteAsync(responseText);
            }
        }
    } 
}
