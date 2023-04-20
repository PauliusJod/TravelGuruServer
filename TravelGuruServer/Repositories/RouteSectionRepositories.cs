using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRouteSectionRepositories
    {
        Task CreatePrivateAsync(TrouteSectionDescription routeSection);
        Task CreatePublicAsync(TrouteSectionDescription routeSection);
        Task<TrouteSectionDescription?> GetTrouteSectionPrivateAsync(int routeId, int sectionid);
        Task<TrouteSectionDescription?> GetTrouteSectionPublicAsync(int routeId, int sectionid);
        Task<List<TrouteSectionDescription>> GetTrouteSectionsPrivateAsync(int routeId);
        Task<List<TrouteSectionDescription>> GetTrouteSectionsPublicAsync(int routeId);
    }

    public class RouteSectionRepositories : IRouteSectionRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RouteSectionRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }
        //Private
        public async Task<TrouteSectionDescription?> GetTrouteSectionPrivateAsync(int routeId, int sectionid) //int routeid, 
        {
            return await _travelDbContext.TrouteSectionDescriptions.FirstOrDefaultAsync(o => o.sectionId == sectionid && o.TRoutePrivaterouteId == routeId); // bad
        }
        public async Task<List<TrouteSectionDescription>> GetTrouteSectionsPrivateAsync(int routeId)
        {
            return await _travelDbContext.TrouteSectionDescriptions.Where(o => o.TRoutePrivaterouteId == routeId).ToListAsync();
        }

        public async Task CreatePrivateAsync(TrouteSectionDescription routeSection)
        {
            _travelDbContext.TrouteSectionDescriptions.Add(routeSection);
            await _travelDbContext.SaveChangesAsync();

        }
        //Public
        public async Task<TrouteSectionDescription?> GetTrouteSectionPublicAsync(int routeId, int sectionid) //int routeid, 
        {
            return await _travelDbContext.TrouteSectionDescriptions.FirstOrDefaultAsync(o => o.sectionId == sectionid && o.TRoutePublicrouteId == routeId); // bad
        }
        public async Task<List<TrouteSectionDescription>> GetTrouteSectionsPublicAsync(int routeId)
        {
            return await _travelDbContext.TrouteSectionDescriptions.Where(o => o.TRoutePublicrouteId == routeId).ToListAsync();
        }

        public async Task CreatePublicAsync(TrouteSectionDescription routeSection)
        {
            _travelDbContext.TrouteSectionDescriptions.Add(routeSection);
            await _travelDbContext.SaveChangesAsync();

        }

    }
}
