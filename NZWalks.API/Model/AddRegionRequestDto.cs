using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(3)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
