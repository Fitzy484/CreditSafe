using CreditsafeCountryApi.Models;
using System.Collections.Generic;

namespace CreditsafeCountryApi.Coordinators
{
    public interface ISearchCoordinator
    {
        Task<IEnumerable<City>> SearchCities(string name);
    }
}
