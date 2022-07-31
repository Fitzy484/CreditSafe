using CreditsafeCountryApi.Models;
using Dapper;
using System.Data;

namespace CreditsafeCountryApi.DataAccess
{
    public class CityRepository : ICityRepository
    {
        private readonly DapperContext _context;

        public CityRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> SearchCities()
        {
            var query = "SELECT * FROM Cities";

            using (var connection = _context.CreateConnection())
            {
                var cities = await connection.QueryAsync<City>(query);
                return cities.ToList();
            }
        }

        public async Task<City> GetCity(int Id)
        {
            var query = "SELECT * FROM Cities WHERE CityId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var city = await connection.QuerySingleOrDefaultAsync<City>(query, new { Id });

                return city;
            }
        }

        public async Task CreateCity(CityDto city)
        {
           // var cityId = Guid.NewGuid();
            var query = "INSERT INTO Cities (Name, State, Country, TouristRating, DateEstablished, EstimatedPopulation)" +
                " VALUES (@Name, @State, @Country, @TouristRating, @DateEstablished, @EstimatedPopulation)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", city.Name, DbType.String);
            parameters.Add("State", city.State, DbType.String);
            parameters.Add("Country", city.Country, DbType.String);
            parameters.Add("TouristRating", city.TouristRating, DbType.Int32);
            parameters.Add("DateEstablished", city.DateEstablished, DbType.Int32);
            parameters.Add("EstimatedPopulation", city.EstimatedPopulation, DbType.Int32);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateCity(int id, UpdateCityDto city)
        {
            var query = "UPDATE Cities SET TouristRating = @TouristRating, DateEstablished = @DateEstablished, EstimatedPopulation = @EstimatedPopulation WHERE CityId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("TouristRating", city.TouristRating, DbType.Int32);
            parameters.Add("DateEstablished", city.DateEstablished, DbType.Int32);
            parameters.Add("EstimatedPopulation", city.EstimatedPopulation, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCity(int id)
        {
            var query = "DELETE FROM Cities WHERE CityId = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
