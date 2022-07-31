using CreditsafeCountryApi.Models;
using Newtonsoft.Json;
using RESTCountries.Models;
using RESTCountries.Services;


namespace CreditsafeCountryApi.Services
{
    public class CountryService : ICountryService
    {

        public async Task<List<Country>> GetCountries(string name)
        {
            try
            {

                List<Country> countries = await RESTCountriesAPI.GetCountriesByNameContainsAsync(name);

                return countries;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error returned from countries api{ex.Message}");
            }
        }
    }
}
