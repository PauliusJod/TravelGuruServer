using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRoutePrivateRespositories
    {
        Task CreatePrivateAsync(TRoutePrivate routePrivate);
        Task<TRoutePrivate?> GetPrivateRouteAsync(int routeid);
        Task<List<TRoutePrivate>> GetPrivateRoutesAsync();
        Task<List<TRoutePrivate>> GetUserCreatedPrivateRoutesAsync(string userId);
    }

    public class RoutePrivateRespositories : IRoutePrivateRespositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RoutePrivateRespositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TRoutePrivate?> GetPrivateRouteAsync(int routeid)
        {
            return await _travelDbContext.TRoutesPrivate.FirstOrDefaultAsync(o => o.routeId == routeid);
        }
        public async Task<List<TRoutePrivate>> GetPrivateRoutesAsync()
        {
            return await _travelDbContext.TRoutesPrivate.ToListAsync();
        }
        public async Task<List<TRoutePrivate>> GetUserCreatedPrivateRoutesAsync(string userId)
        {
            return await _travelDbContext.TRoutesPrivate.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task CreatePrivateAsync(TRoutePrivate routePrivate)
        {
            _travelDbContext.TRoutesPrivate.Add(routePrivate);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
