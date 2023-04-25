using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRRecommendationUrlRepositories
    {
        Task CreateRecommendationAsync(RRecommendationUrl rRecommendationUrl);
        Task<List<RRecommendationUrl>> GetRecommendationAsync();
        Task<RRecommendationUrl?> GetRecommendationAsync(int recommendationId);
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
        public async Task<List<RRecommendationUrl>> GetRecommendationAsync()
        {
            return await _travelDbContext.RrecommendationUrl.ToListAsync();
        }

        public async Task CreateRecommendationAsync(RRecommendationUrl rRecommendationUrl)
        {
            _travelDbContext.RrecommendationUrl.Add(rRecommendationUrl);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
