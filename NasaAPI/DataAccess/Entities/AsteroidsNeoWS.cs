namespace NasaAPI.DataAccess.Entities
{
    public class AsteroidNeoWS
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AsteroidId { get; set; }
        public string KilometersToEarth { get; set; }
        public bool isPotentiallyHazardous { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
