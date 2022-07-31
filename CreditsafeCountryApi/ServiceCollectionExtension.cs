using CreditsafeCountryApi.Coordinators;
using CreditsafeCountryApi.DataAccess;
using CreditsafeCountryApi.Services;

namespace CreditsafeCountryApi
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCountrySearchBindings(this IServiceCollection services)
        {
            return services
                .AddSingleton<DapperContext>()
                .AddTransient<ICityRepository, CityRepository>()
                .AddTransient<IWeatherService, WeatherService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<ISearchCoordinator, SearchCoordinator>();
                

            //services registrations
        }
    }
}
