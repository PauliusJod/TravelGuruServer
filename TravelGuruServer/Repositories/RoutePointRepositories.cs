using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRoutePointRepositories
    {
        Task CreateAsync(TroutePointDescription routePointDescription);
        Task<TroutePointDescription?> GetTroutePointAsync(int routeId, int pointid);
        Task<List<TroutePointDescription>> GetTroutePointsAsync(int routeId);
        Task UpdateAsync(TroutePointDescription routePointDescription);
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

        public async Task CreateAsync(TroutePointDescription routePointDescription)
        {
            _travelDbContext.TroutePointDescriptions.Add(routePointDescription);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(TroutePointDescription routePointDescription)
        {
            _travelDbContext.TroutePointDescriptions.Update(routePointDescription);
            await _travelDbContext.SaveChangesAsync();

        }
    }
}
