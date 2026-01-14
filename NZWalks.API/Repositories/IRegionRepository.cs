using NZWalks.API.Domain_Model;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAllAsync();
        public Task<Region?> GetByIdAsync(Guid id);

       public Task<Region?> CreateAsync(Region region);
    }
}
