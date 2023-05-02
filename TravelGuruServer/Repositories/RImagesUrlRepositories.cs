using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRImagesUrlRepositories
    {
        Task CreateImageAsync(RImagesUrl rImagesUrl);
        Task<RImagesUrl?> GetImageAsync(int rImagesId);
        Task<List<RImagesUrl>> GetImagesAsync(int routeId);
    }

    public class RImagesUrlRepositories : IRImagesUrlRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RImagesUrlRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<RImagesUrl?> GetImageAsync(int rImagesId)
        {
            return await _travelDbContext.RimagesUrl.FirstOrDefaultAsync(o => o.rImagesUrlId == rImagesId);
        }
        public async Task<List<RImagesUrl>> GetImagesAsync(int routeId)
        {
            return await _travelDbContext.RimagesUrl.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateImageAsync(RImagesUrl rImagesUrl)
        {
            _travelDbContext.RimagesUrl.Add(rImagesUrl);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
