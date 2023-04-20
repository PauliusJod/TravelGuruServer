using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IMidWaypointRepositories
    {
        Task CreateAsync(MidWaypoint midWaypoint);
        Task CreatePublicAsync(MidWaypoint midWaypoint);
        Task<MidWaypoint?> GetMidWaypointAsync(int routeId, int midWaypointId);
        Task<MidWaypoint?> GetMidWaypointPublicAsync(int routeId, int midWaypointId);
        Task<List<MidWaypoint>> GetMidWaypointsAsync(int routeId);
        Task<List<MidWaypoint>> GetMidWaypointsPublicAsync(int routeId);
    }

    public class MidWaypointRepositories : IMidWaypointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public MidWaypointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<MidWaypoint?> GetMidWaypointAsync(int routeId, int midWaypointId) //int routeid, 
        {
            return await _travelDbContext.MidWaypoints.FirstOrDefaultAsync(o => o.midWaypointId == midWaypointId && o.TRoutePrivaterouteId == routeId); // bad
        }
        public async Task<List<MidWaypoint>> GetMidWaypointsAsync(int routeId)
        {
            return await _travelDbContext.MidWaypoints.Where(o => o.TRoutePrivaterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(MidWaypoint midWaypoint)
        {
            _travelDbContext.MidWaypoints.Add(midWaypoint);
            await _travelDbContext.SaveChangesAsync();

        }

        public async Task<MidWaypoint?> GetMidWaypointPublicAsync(int routeId, int midWaypointId) //int routeid, 
        {
            return await _travelDbContext.MidWaypoints.FirstOrDefaultAsync(o => o.midWaypointId == midWaypointId && o.TRoutePublicrouteId == routeId); // bad
        }
        public async Task<List<MidWaypoint>> GetMidWaypointsPublicAsync(int routeId)
        {
            return await _travelDbContext.MidWaypoints.Where(o => o.TRoutePublicrouteId == routeId).ToListAsync();
        }

        public async Task CreatePublicAsync(MidWaypoint midWaypoint)
        {
            _travelDbContext.MidWaypoints.Add(midWaypoint);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
