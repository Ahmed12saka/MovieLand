using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieLand.Application.Services.Implementations;
using MovieLand.Application.Services.Interfaces;
using MovieLand.Application.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Configurations
{
    public static class ApplicationConfiguration
    {
            public static IServiceCollection AddServices(
                this IServiceCollection services)
            {
                services.AddAutoMapper(
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetEntryAssembly(),
                    Assembly.GetCallingAssembly());

                services.AddScoped<IMovieService, MovieService>();
                services.AddScoped<IShoppingCartService, ShoppingCartService>();
                services.AddScoped<ICategoryService, CategoryService>();

                return services;
            }
        
    }
}