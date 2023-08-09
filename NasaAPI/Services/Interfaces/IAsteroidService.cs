using NasaAPI.Models;

namespace NasaAPI.Services.Interfaces
{
    public interface IAsteroidService
    {
        Task GetAsteroidDataAsync(string response, string startDate, string endDate);
    }
}
