using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace NasaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsRoverController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public MarsRoverController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        [HttpGet]
        [Route("/photos")]
        public async Task<IActionResult> MarsRoverPhotos(int sol, string camera = "fhaz")
        {
            try
            {
                var apiKey = _config["ApiKey"];
                using var request = await _httpClient.GetAsync($"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol={sol}&camera={camera}&api_key={apiKey}");

                var response = await request.Content.ReadAsStringAsync();
                return Ok(response);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            } 
        }
    }
}
