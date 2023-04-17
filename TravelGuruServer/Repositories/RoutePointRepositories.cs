using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRoutePointRepositories
    {
        Task CreateAsync(TroutePointDescription routeDescription);
        Task<TroutePointDescription?> GetTroutePointAsync(int routeId, int pointid);
        Task<List<TroutePointDescription>> GetTroutePointsAsync(int routeId);
    }

    public class RoutePointRepositories : IRoutePointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RoutePointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TroutePointDescription?> GetTroutePointAsync(int routeId, int pointid) //int routeid, 
        {
            return await _travelDbContext.TroutePointDescriptions.FirstOrDefaultAsync(o => o.pointId == pointid && o.TRouterouteId == routeId); // bad
        }
        public async Task<List<TroutePointDescription>> GetTroutePointsAsync(int routeId)
        {
            return await _travelDbContext.TroutePointDescriptions.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(TroutePointDescription routeDescription)
        {
            _travelDbContext.TroutePointDescriptions.Add(routeDescription);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
