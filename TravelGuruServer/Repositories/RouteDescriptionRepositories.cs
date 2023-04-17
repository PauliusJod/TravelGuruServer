using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRouteDescriptionRepositories
    {
        Task CreateAsync(TrouteDescription routeDescription);
        Task<TrouteDescription?> GetTrouteDescriptionAsync(int routeId, int descriptionId);
        Task<List<TrouteDescription>> GetTrouteDescriptionsAsync(int routeId);
    }

    public class RouteDescriptionRepositories : IRouteDescriptionRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RouteDescriptionRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TrouteDescription?> GetTrouteDescriptionAsync(int routeId, int descriptionId) //int routeid, 
        {
            return await _travelDbContext.TrouteDescriptions.FirstOrDefaultAsync(o => o.routeDescId == descriptionId && o.TRouterouteId == routeId); // bad
        }
        public async Task<List<TrouteDescription>> GetTrouteDescriptionsAsync(int routeId)
        {
            return await _travelDbContext.TrouteDescriptions.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(TrouteDescription routeDescription)
        {
            _travelDbContext.TrouteDescriptions.Add(routeDescription);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
