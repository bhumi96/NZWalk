using Microsoft.AspNetCore.Mvc;
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

        public async Task<Region> CreateAsync(Region region)
        {
            await _nZWalksEntities.Region.AddAsync(region);
            await _nZWalksEntities.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync(string? filterOn, string? filterQuery,string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 50)
        {
            var region =  _nZWalksEntities.Region.AsQueryable();
            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                region =  region.Where(s => s.Name.Contains(filterQuery));
            }

            //Sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    region = isAscending == true ? region.OrderBy(x => x.Name) : region.OrderByDescending(x => x.Name);
                }
            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;

           return await region.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return await _nZWalksEntities.Region.FirstOrDefaultAsync(x => x.RegionId == Id);
        }
    }
}
