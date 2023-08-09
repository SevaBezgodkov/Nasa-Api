using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasaAPI.Models;
using NasaAPI.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NasaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IAsteroidService _asteroidService;

        public AsteroidsController(HttpClient httpClient, IConfiguration config, IAsteroidService asteroidService)
        {
            _httpClient = httpClient;
            _config = config;
            _asteroidService = asteroidService;
        }

        [HttpGet]
        [Route("asteroids")]
        public async Task<IActionResult> GetAsteroidsNearEarthAsync(string startDate = "2019-05-23", string endDate = "2019-05-25")
        {
            var apiKey = _config.GetValue(typeof(string), "ApiKey");

            try
            {
                var request = await _httpClient.GetAsync($"https://api.nasa.gov/neo/rest/v1/feed?start_date={startDate}&end_date={endDate}&api_key={apiKey}");

                var response = await request.Content.ReadAsStringAsync();

                await _asteroidService.GetAsteroidDataAsync(response, startDate, endDate);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("asteroidById")]
        public async Task<IActionResult> GetAsteroidNearEarthByIdAsync(int id = 2154347)
        {
            var apiKey = _config.GetValue(typeof(string), "ApiKey");

            try
            {
                var request = await _httpClient.GetAsync($"https://api.nasa.gov/neo/rest/v1/neo/{id}?api_key={apiKey}");

                if (id == 0) return BadRequest("Enter the asteroid's id");
                if (request == null) return NotFound("Asteroid not found"); 

                var responseAsString = request.Content.ReadAsStringAsync();

                //await _asteroidService.GetAsteroidById(responseAsString);
                //response.
                return Ok(responseAsString);
            }
            catch (JsonException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
