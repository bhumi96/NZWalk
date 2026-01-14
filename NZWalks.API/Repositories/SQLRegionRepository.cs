using Microsoft.EntityFrameworkCore;
using NZWalks.API.Domain_Model;
using NZWalks.API.Migrations;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksEntities _nZWalksEntities;

        public SQLRegionRepository(NZWalksEntities nZWalksEntities)
        {
            _nZWalksEntities = nZWalksEntities;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _nZWalksEntities.Region.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _nZWalksEntities.Region.FirstOrDefaultAsync(s => s.RegionId == id);
        }

        public async Task<Region?> CreateAsync(Region region)
        {
            await _nZWalksEntities.Region.AddAsync(region);
            await _nZWalksEntities.SaveChangesAsync();
            return region;
        }

    
    }
}
