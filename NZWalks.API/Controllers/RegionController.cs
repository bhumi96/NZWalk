using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Migrations;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksEntities _nZWalksEntities;
        public RegionController(NZWalksEntities nZWalksEntities)
        {
            _nZWalksEntities = nZWalksEntities;
        }

        [HttpGet("{id:guid}")]
        //[Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var region = _nZWalksEntities.Region.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);

        }
    }
}
