namespace NZWalks.API.Domain_Model
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
