using NasaAPI.DataAccess.Entities;

namespace NasaAPI.Repositories.Interfaces
{
    public interface IAsteroidRepository
    {
        Task SaveAsteroidDataAsync(AsteroidNeoWS model);
    }
}
