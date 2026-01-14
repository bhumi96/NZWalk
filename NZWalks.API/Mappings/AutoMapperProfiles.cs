using AutoMapper;
using NZWalks.API.Domain_Model;
using NZWalks.API.Model;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
        }
    }
}
