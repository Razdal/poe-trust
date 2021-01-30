using Trust.Api.Persistence;
using Trust.Auth.Extensions;
using Trust.Auth.Helpers;
using Trust.Auth.Interfaces;
using Trust.Util.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Trust.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string CORS_ALL = "All";

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(CORS_ALL, build => build.AllowAnyHeader()
                                                                                  .AllowAnyOrigin()
                                                                                  .AllowAnyMethod()));

            services.AddDbContext<DataContext>();
            services.Configure<AuthSettings>(Configuration.GetSection("AuthSettings"));
            services.AddScoped<IAuthContext>(provider => provider.GetService<DataContext>());
            services.AddControllers()
                    .AddAuthControllers();
            services.AddAuth();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boilerplate API"));
            app.UseRouting();
            app.UseCors(CORS_ALL);
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuth();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
