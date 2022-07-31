using CreditsafeCountryApi.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using RESTCountries.Services;

namespace CreditsafeCountryApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public IHostEnvironment HostEvironment { get; private set; }

        public Startup(IConfiguration configuration, IHostEnvironment hostEvironment)
        {
            Configuration = configuration;
            HostEvironment = hostEvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(op => op.SuppressModelStateInvalidFilter = true);

            services.AddHealthChecks();

            services.AddRazorPages();

            services.AddControllersWithViews();

            services.ConfigureSwagger();

            services.AddCountrySearchBindings();

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();

                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync("An error occurred");
                    });
                });
            }

            app
               .UseHttpsRedirection()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
                   endpoints.MapHealthChecks("/HealthCheck");
               })
               .UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("../swagger/v1/swagger.json", "Robs City Api V1");
                   c.EnableTryItOutByDefault();
               });
        }
    }
}
