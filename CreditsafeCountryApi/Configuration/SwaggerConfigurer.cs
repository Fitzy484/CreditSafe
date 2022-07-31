using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CreditsafeCountryApi.Configuration
{
    public static class SwaggerConfigurer
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfiguration>();

            services.AddSwaggerGen();

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder application, IHostEnvironment environment)
        {
            application.UseSwagger();

            if (!environment.IsProduction())
            {
                application.UseSwaggerUI();
            }

            return application;
        }
    }
}
