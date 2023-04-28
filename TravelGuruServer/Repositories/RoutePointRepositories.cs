using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRoutePointRepositories
    {
        Task CreatePrivateAsync(TroutePointDescription routePointDescription);
        Task CreatePublicAsync(TroutePointDescription routePointDescription);
        Task<TroutePointDescription?> GetTroutePointPrivateAsync(int routeId, int pointid);
        Task<TroutePointDescription?> GetTroutePointPublicAsync(int routeId, int pointid);
        Task<List<TroutePointDescription>> GetTroutePointsPrivateAsync(int routeId);
        Task<List<TroutePointDescription>> GetTroutePointsPublicAsync(int routeId);
    }

    public class RoutePointRepositories : IRoutePointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RoutePointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }
        //Private
        public async Task<TroutePointDescription?> GetTroutePointPrivateAsync(int routeId, int pointid) //int routeid, 
        {
            return await _travelDbContext.TroutePointDescriptions.FirstOrDefaultAsync(o => o.pointId == pointid && o.TRoutePrivaterouteId == routeId); // bad
        }
        public async Task<List<TroutePointDescription>> GetTroutePointsPrivateAsync(int routeId)
        {
            return await _travelDbContext.TroutePointDescriptions.Where(o => o.TRoutePrivaterouteId == routeId).ToListAsync();
        }

        public async Task CreatePrivateAsync(TroutePointDescription routePointDescription)
        {
            _travelDbContext.TroutePointDescriptions.Add(routePointDescription);
            await _travelDbContext.SaveChangesAsync();

        }




        //Public
        public async Task<TroutePointDescription?> GetTroutePointPublicAsync(int routeId, int pointid) //int routeid, 
        {
            return await _travelDbContext.TroutePointDescriptions.FirstOrDefaultAsync(o => o.pointId == pointid && o.TRoutePublicrouteId == routeId); // bad
        }
        public async Task<List<TroutePointDescription>> GetTroutePointsPublicAsync(int routeId)
        {
            return await _travelDbContext.TroutePointDescriptions.Where(o => o.TRoutePublicrouteId == routeId).ToListAsync();
        }

        public async Task CreatePublicAsync(TroutePointDescription routePointDescription)
        {
            _travelDbContext.TroutePointDescriptions.Add(routePointDescription);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
