using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MovieLand.web.Middelwares
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddMiddlewares(
            this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            services.AddScoped<TransactionMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseCustomMiddleware(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            return app;
        }
    }


}

