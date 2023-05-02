using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRouteRespositories
    {
        Task CreateAsync(TRoute route);
        Task<List<TRoute>> GetPublicRoutesAsync();
        Task<TRoute?> GetRouteAsync(int routeid);
        Task<List<TRoute>> GetRoutesAsync();
        Task<List<TRoute>> GetUserCreatedRoutesAsync(string userId);
        Task UpdateAsync(TRoute route);
    }

    public class RouteRespositories : IRouteRespositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RouteRespositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TRoute?> GetRouteAsync(int routeid)
        {
            return await _travelDbContext.TRoutes.FirstOrDefaultAsync(o => o.routeId == routeid);
        }

        public async Task<List<TRoute>> GetPublicRoutesAsync()
        {
            return await _travelDbContext.TRoutes.Where(o => o.rIsPublished == true).ToListAsync();
        }

        public async Task<List<TRoute>> GetRoutesAsync()
        {
            return await _travelDbContext.TRoutes.ToListAsync();
        }
        public async Task<List<TRoute>> GetUserCreatedRoutesAsync(string userId)
        {
            return await _travelDbContext.TRoutes.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task CreateAsync(TRoute route)
        {
            _travelDbContext.TRoutes.Add(route);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(TRoute route)
        {
            _travelDbContext.TRoutes.Update(route);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
