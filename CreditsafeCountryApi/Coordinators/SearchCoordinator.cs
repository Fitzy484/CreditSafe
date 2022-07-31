using CreditsafeCountryApi.DataAccess;
using CreditsafeCountryApi.Models;
using CreditsafeCountryApi.Services;
using System.Linq;

namespace CreditsafeCountryApi.Coordinators
{
    public class SearchCoordinator : ISearchCoordinator
    {
        private readonly IWeatherService _weatherService;
        private readonly ICountryService _countryService;
        private readonly ICityRepository _cityRepository;

        public SearchCoordinator(IWeatherService weatherService, ICountryService countryService, ICityRepository cityRepository)
        {
            _weatherService = weatherService;
            _countryService = countryService;
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityResult>> SearchCities(string name)
        {
            var localCities = await _cityRepository.SearchCities();

            var countries = await _countryService.GetCountries(name);

            List<CityResult> searchResults = new List<CityResult>();

            //filter results that are in both local cities and countries list
            var result = localCities.Where(a => countries.Any(b => b.Name.Contains(a.Name)));

            if (result.Count() != 0)
            {
                foreach (var item in countries)
                {
                    searchResults.Add(new CityResult()
                    {
                        Name = item.Name,
                       // State = 
                        Weather = await _weatherService.GetWeather(name, item.Alpha2Code.ToString())
                    });;
                }
            }
            return searchResults;
        }
    }
}
