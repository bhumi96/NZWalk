using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Domain_Model;
using NZWalks.API.Migrations;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        //[HttpGet("{id:guid}")]
        //[Route("{id:guid}")]
        //public IActionResult GetById(Guid id)
        //{
        //    var region = _regionRepository.Region.Find(id);
        //    if (region == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(region);

        //}

        // Get Region
        // GET: /api/regions?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet()]
        public IActionResult Get([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            var region = _regionRepository.GetAllAsync(filterOn, filterQuery,sortBy,isAscending, pageNumber, pageSize);
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
