using CreditsafeCountryApi.Coordinators;
using CreditsafeCountryApi.DataAccess;
using CreditsafeCountryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditsafeCountryApi.Controllers
{
    [ApiController]
    [Route("City")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly ISearchCoordinator _searchCoordinator;
        public CityController(ICityRepository cityRepository, ISearchCoordinator searchCoordinator)
        {
            _cityRepository = cityRepository;
            _searchCoordinator = searchCoordinator;
        }

        [HttpPost]
        [Route("AddCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCity([FromBody] CityDto city)
        {
            if (city == null)
            {
                return BadRequest("Missing a valid body");
            }
            if (city.TouristRating <= 0 || city.TouristRating > 5)
            {
                return BadRequest("Enter a rating between 1 and 5");
            }

            try
            {
                await _cityRepository.CreateCity(city);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("SearchCities")]
        public async Task<IActionResult> SearchCities(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("enter a valid name");
            }

            try
            {
                var cities = await _searchCoordinator.SearchCities(name);
                return Ok(cities);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetLocalCity/{cityId}")]
        public async Task<IActionResult> GetCity(int cityId)
        {
            try
            {
                var city = await _cityRepository.GetCity(cityId);

                if(city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{cityId}")]
        public async Task<IActionResult> UpdateCity(int cityId, UpdateCityDto city)
        {
            try
            {
                var storedCity = await _cityRepository.GetCity(cityId);
                if(storedCity == null)
                {
                    return NotFound();
                }

                await _cityRepository.UpdateCity(cityId, city);

                return NoContent();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{cityId}")]
        public async Task <IActionResult> DeleteCity(int cityId)
        {
            try
            {
                var storedCity = await _cityRepository.GetCity(cityId);
                if (storedCity == null)
                {
                    return NotFound();
                }

                await _cityRepository.DeleteCity(cityId);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
