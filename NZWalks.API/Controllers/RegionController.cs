using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Domain_Model;
using NZWalks.API.Migrations;
using NZWalks.API.Model;
using NZWalks.API.Model.Dto_Model;
using NZWalks.API.Repositories;
using System.Threading.Tasks;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public IActionResult GetById(Guid id)
        {
            var regionDomain = _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(regionDomain));

        }

        // Get Region
        // GET: /api/regions?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = true, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            var regionDomain = await _regionRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
            
            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<RegionDto>>(regionDomain));

        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            /// Map or convert Dto to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            /// Use Domain Model to create Region
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            /// Map Domain model back to DTO
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.RegionId }, regionDto);
        }

        // Update Region
        // PUT: hhtps://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequest)
        {
            /// Map Dto to Domain Model
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequest);

            /// Check if Region Exists
            regionDomainModel = await _regionRepository.UpdateAsync(id,regionDomainModel);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }


        // Delete Region
        // DELETE : https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}