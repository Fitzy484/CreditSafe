using CreditsafeCountryApi.Models;
using RESTCountries.Models;

namespace CreditsafeCountryApi.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountries(string name);
    }
}
