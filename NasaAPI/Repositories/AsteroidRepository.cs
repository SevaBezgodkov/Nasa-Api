using NasaAPI.DataAccess;
using NasaAPI.DataAccess.Entities;
using NasaAPI.Repositories.Interfaces;

namespace NasaAPI.Repositories
{
    public class AsteroidRepository : IAsteroidRepository
    {
        private readonly ApplicationContext _context;

        public AsteroidRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task SaveAsteroidDataAsync(AsteroidNeoWS model)
        {
            var asteroid = new AsteroidNeoWS()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                AsteroidId = model.AsteroidId,
                KilometersToEarth = model.KilometersToEarth,
                isPotentiallyHazardous = model.isPotentiallyHazardous,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            await _context.AddAsync(asteroid);
            await _context.SaveChangesAsync();
        }
    }
}
