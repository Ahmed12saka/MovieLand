using MovieLand.Application.Configurations;
using MovieLand.Infrastructure.Database.Configuration;
using MovieLand.web.Middelwares;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MovieLand.Web
{

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public class Startup
        {

            public Startup(IWebHostEnvironment env)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("appsettings." + env.EnvironmentName + ".json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            }



            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllersWithViews();

                services.AddDatabase(
                    "Data Source=main.db",
                    typeof(Infrastructure.Database.Configuration.ApplicationConfiguration).Assembly);

                services.AddServices();
                services.AddMiddlewares();
                services.AddSwaggerGen();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseStaticFiles();

                app.UseRouting();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });

                app.UseAuthorization();
                app.UseCustomMiddleware();
                app.UseMigrations();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }

   
}
