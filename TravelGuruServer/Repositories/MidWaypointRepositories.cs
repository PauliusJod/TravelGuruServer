﻿using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IMidWaypointRepositories
    {
        Task CreateAsync(MidWaypoint midWaypoint);
        Task<MidWaypoint?> GetMidWaypointAsync(int routeId, int midWaypointId);
        Task<List<MidWaypoint>> GetMidWaypointsAsync(int routeId);
    }

    public class MidWaypointRepositories : IMidWaypointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public MidWaypointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<MidWaypoint?> GetMidWaypointAsync(int routeId, int midWaypointId)
        {
            return await _travelDbContext.MidWaypoints.FirstOrDefaultAsync(o => o.midWaypointId == midWaypointId && o.TRouterouteId == routeId);
        }
        public async Task<List<MidWaypoint>> GetMidWaypointsAsync(int routeId)
        {
            return await _travelDbContext.MidWaypoints.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(MidWaypoint midWaypoint)
        {
            _travelDbContext.MidWaypoints.Add(midWaypoint);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
