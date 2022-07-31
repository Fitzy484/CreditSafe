using CreditsafeCountryApi.Models;

namespace CreditsafeCountryApi.DataAccess
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> SearchCities();

        public Task<City> GetCity(int id);

        public Task CreateCity(CityDto city);

        public Task UpdateCity(int id, UpdateCityDto city);

        public Task DeleteCity(int id);
    }
}
