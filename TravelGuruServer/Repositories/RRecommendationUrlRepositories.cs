using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRRecommendationUrlRepositories
    {
        Task CreateRecommendationAsync(RRecommendationUrl rRecommendationUrl);
        Task DeleteRecommendationAsync(RRecommendationUrl rRecommendationUrl);
        Task<RRecommendationUrl?> GetRecommendationAsync(int recommendationId);
        Task<List<RRecommendationUrl>> GetRecommendationsAsync(int routeId);
    }

    public class RRecommendationUrlRepositories : IRRecommendationUrlRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RRecommendationUrlRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<RRecommendationUrl?> GetRecommendationAsync(int recommendationId)
        {
            return await _travelDbContext.RrecommendationUrl.FirstOrDefaultAsync(o => o.rRecommendationUrlId == recommendationId);
        }
        public async Task<List<RRecommendationUrl>> GetRecommendationsAsync(int routeId)
        {
            return await _travelDbContext.RrecommendationUrl.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateRecommendationAsync(RRecommendationUrl rRecommendationUrl)
        {
            _travelDbContext.RrecommendationUrl.Add(rRecommendationUrl);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task DeleteRecommendationAsync(RRecommendationUrl rRecommendationUrl)
        {
            _travelDbContext.RrecommendationUrl.Remove(rRecommendationUrl);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
