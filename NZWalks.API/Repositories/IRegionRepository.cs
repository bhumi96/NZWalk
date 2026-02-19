using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Domain_Model;
using System.Globalization;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(string? filterOn, string? filterQuery,string? sortBy, bool isAscending = true, int pageNumber = 1, int pageSize = 50);
        Task<Region> GetByIdAsync(Guid Id);
        Task<Region> CreateAsync(Region region);
    }
}
