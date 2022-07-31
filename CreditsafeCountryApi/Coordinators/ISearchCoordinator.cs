using CreditsafeCountryApi.Models;
using System.Collections.Generic;

namespace CreditsafeCountryApi.Coordinators
{
    public interface ISearchCoordinator
    {
        Task<IEnumerable<CityResult>> SearchCities(string name);
    }
}
