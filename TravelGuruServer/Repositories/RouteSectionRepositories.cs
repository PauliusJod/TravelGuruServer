using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRouteSectionRepositories
    {
        Task CreateAsync(TrouteSectionDescription routeSection);
        Task<TrouteSectionDescription?> GetTrouteSectionAsync(int routeId, int sectionid);
        Task<List<TrouteSectionDescription>> GetTrouteSectionsAsync(int routeId);
    }

    public class RouteSectionRepositories : IRouteSectionRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RouteSectionRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }
        public async Task<TrouteSectionDescription?> GetTrouteSectionAsync(int routeId, int sectionid) //int routeid, 
        {
            return await _travelDbContext.TrouteSectionDescriptions.FirstOrDefaultAsync(o => o.sectionId == sectionid && o.TRouterouteId == routeId); // bad
        }
        public async Task<List<TrouteSectionDescription>> GetTrouteSectionsAsync(int routeId)
        {
            return await _travelDbContext.TrouteSectionDescriptions.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(TrouteSectionDescription routeSection)
        {
            _travelDbContext.TrouteSectionDescriptions.Add(routeSection);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
