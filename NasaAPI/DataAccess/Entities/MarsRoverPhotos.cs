namespace NasaAPI.DataAccess.Entities
{
    public class MarsRoverPhotos
    {
        public Guid Id { get; set; }
        public int Sol { get; set; }
        public string Camera { get; set; }
        public int Page { get; set; }
    }
}
