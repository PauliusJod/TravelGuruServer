using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRRecommendationUrlRepositories
    {
        Task CreateRecommendationPrivateAsync(RRecommendationUrl rRecommendationUrl);
        Task DeleteRecommendationPrivateAsync(RRecommendationUrl rRecommendationUrl);
        Task<RRecommendationUrl?> GetRecommendationPrivateAsync(int recommendationId);
        Task<List<RRecommendationUrl>> GetRecommendationsPrivateAsync(int routeId);
    }

    public class RRecommendationUrlRepositories : IRRecommendationUrlRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RRecommendationUrlRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<RRecommendationUrl?> GetRecommendationPrivateAsync(int recommendationId)
        {
            return await _travelDbContext.RrecommendationUrl.FirstOrDefaultAsync(o => o.rRecommendationUrlId == recommendationId);
        }
        public async Task<List<RRecommendationUrl>> GetRecommendationsPrivateAsync(int routeId)
        {
            return await _travelDbContext.RrecommendationUrl.Where(o => o.TRoutePrivaterouteId == routeId).ToListAsync();
        }

        public async Task CreateRecommendationPrivateAsync(RRecommendationUrl rRecommendationUrl)
        {
            _travelDbContext.RrecommendationUrl.Add(rRecommendationUrl);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task DeleteRecommendationPrivateAsync(RRecommendationUrl rRecommendationUrl)
        {
            _travelDbContext.RrecommendationUrl.Remove(rRecommendationUrl);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
