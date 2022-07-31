using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CreditsafeCountryApi.Configuration
{
    public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Creditsafe City & Country",
                Version = "v1",
                License = new OpenApiLicense
                {
                    Name = $"Robert Fitzpatrick {DateTime.Now.Year}."
                }
            });
        }
    }
}
