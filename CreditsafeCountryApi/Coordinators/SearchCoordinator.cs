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
            var result = localCities.Where(a => countries.Any(b => b.Name.ToLower().Contains(a.Name.ToLower())));

            if (result.Any())
            {
                foreach (var item in result)
                { 
                    foreach(var country in countries)
                    {
                        searchResults.Add(new CityResult()
                        {
                            Name = item.Name,
                            State = item.State,
                            Country = item.Country,
                            TouristRating = item.TouristRating,
                            DateEstablished = item.DateEstablished,
                            EstimatedPopulation = item.EstimatedPopulation,
                            TwoDigitCode = country.Alpha2Code,
                            ThreeDigitCode = country.Alpha3Code,
                            CurrencyCode = country.Currencies.FirstOrDefault().Name,
                            Weather = await _weatherService.GetWeather(name)
                        }); 
                    }
                }
            }
            return searchResults;
        }
    }
}
