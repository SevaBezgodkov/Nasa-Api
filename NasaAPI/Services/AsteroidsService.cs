using NasaAPI.Models;
using NasaAPI.Repositories.Interfaces;
using NasaAPI.Services.Interfaces;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using NasaAPI.DataAccess.Entities;
using System;

namespace NasaAPI.Services
{
    public class AsteroidsService : IAsteroidService
    {
        private readonly IAsteroidRepository _repo;

        public AsteroidsService(IAsteroidRepository repo)
        {
            _repo = repo;
        }

        public async Task GetAsteroidDataAsync(string response, string startDate, string endDate)
        {
            var jsonObject = JObject.Parse(response);
            var jDate = jsonObject.Property("near_earth_objects");

            var asteroidsCount = (int?)jsonObject["element_count"];

            var startDateConvert = DateTime.Parse(startDate);
            var endDateConvert = DateTime.Parse(endDate);

            var data = JsonConvert.DeserializeObject<Root>(response);
            if (jDate != null && jDate.Value is JObject dateObject)
            {
                foreach (var dateProperty in dateObject.Properties())
                {
                    
                    string propertyName = dateProperty.Name;
                    var value = dateProperty.Value;
                    var countOfAsteroids = value.Count();

                    for (int i = 0; i < countOfAsteroids; i++)
                    {

                        var kilometersToEarth = data.near_earth_objects[propertyName][i].close_approach_data[0].miss_distance.kilometers;
                        var asteroidId = data.near_earth_objects[propertyName][i].id;
                        var name = data.near_earth_objects[propertyName][i].name;
                        var isPotentiallyHazardous = data.near_earth_objects[propertyName][i].is_potentially_hazardous_asteroid;

                        var asteroidModel = new AsteroidNeoWS()
                        {
                            Name = name,
                            AsteroidId = asteroidId,
                            KilometersToEarth = kilometersToEarth,
                            isPotentiallyHazardous = isPotentiallyHazardous,
                            StartDate = startDateConvert,
                            EndDate = endDateConvert,
                        };
                        await _repo.SaveAsteroidDataAsync(asteroidModel);
                    }
                }
            }

            //(2021 AG6)
            //459458 (2012 XR134)
            //(2022 AV3) 19
            //for (int i = 0; i < asteroidsCount; i++)
            //{

            //}
            //352102 (2007 AG12)
            //var nearEarthObjects = jsonObject?["near_earth_objects"];
            //var asteroidName = nearEarthObjects?["name"];
            //var asteroidId = nearEarthObjects?["id"];
            //var jsonArray = new JsonArray(jsonObject);

            ////get kilometers to Earth
            //var approachData = jsonObject["close_approach_data"];
            //var missDistance = approachData?[0]?["miss_distance"];
            //var kilometersToEarth = missDistance["kilometers"];

            //// isPotentiallyHazardousAsteroid
            //var isPotentiallyHazardous = jsonObject["is_potentially_hazardous_asteroid"];

            ////close_approach_date_
            //var closeApproachDate = jsonObject["close_approach_date_full"];
        }
    }//close_approach_data[miss_distance:kilometers]
}
