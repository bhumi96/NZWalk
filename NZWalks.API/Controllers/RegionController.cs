using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Domain_Model;
using NZWalks.API.Migrations;
using NZWalks.API.Model;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        public RegionController(IMapper mapper, IRegionRepository regionRepository)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
        }

        [HttpGet("{id:guid}")]
        //[Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var region = _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or convert Dto to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            // Map Domain model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.RegionId }, regionDto);
        }
    }
}
