using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IAdditionalPointRepositories
    {
        Task CreatePointAdditionalMarkAsync(AdditionalPoints additionalPoint);
        Task DeleteAsync(AdditionalPoints additionalPoint);
        Task<AdditionalPoints?> GetAdditionalPointForTextUpdateAsync(int routeId, int? pointId, int pointInListId);
        Task<AdditionalPoints?> GetAdditionalPointMarkAsync(int routeId, int? pointId, int pointInListId);
        Task<List<AdditionalPoints>> GetAdditionalPointMarksAsync();
        Task<List<AdditionalPoints>> GetAdditionalPointMarksChoosenPointAsync(int pointId);
        Task<List<AdditionalPoints>> GetAdditionalPointMarksChoosenRouteAsync(int routeId);
        Task UpdateAdditionalPointMarkAsync(AdditionalPoints additionalPoint);
    }

    public class AdditionalPointRepositories : IAdditionalPointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public AdditionalPointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<AdditionalPoints?> GetAdditionalPointMarkAsync(int routeId, int? pointId, int pointInListId)
        {
            return await _travelDbContext.AdditionalPointPoints.FirstOrDefaultAsync(o => o.additionalPointRouteId == routeId && o.TroutePointDescriptionpointId == pointId && o.additionalPointIdInList == pointInListId);
        }
        public async Task<AdditionalPoints?> GetAdditionalPointForTextUpdateAsync(int routeId, int? pointId, int pointInListId)
        {
            return await _travelDbContext.AdditionalPointPoints.FirstOrDefaultAsync(o => o.additionalPointRouteId == routeId && o.TroutePointDescriptionpointId == pointId && o.additionalPointIdInList == pointInListId);
        }
        public async Task<List<AdditionalPoints>> GetAdditionalPointMarksAsync()
        {
            return await _travelDbContext.AdditionalPointPoints.ToListAsync();
        }
        public async Task<List<AdditionalPoints>> GetAdditionalPointMarksChoosenRouteAsync(int routeId)
        {
            return await _travelDbContext.AdditionalPointPoints.Where(o => o.additionalPointRouteId == routeId).ToListAsync();
        }

        public async Task<List<AdditionalPoints>> GetAdditionalPointMarksChoosenPointAsync(int pointId)
        {
            return await _travelDbContext.AdditionalPointPoints.Where(o => o.TroutePointDescriptionpointId == pointId).ToListAsync();
        }
        public async Task CreatePointAdditionalMarkAsync(AdditionalPoints additionalPoint)
        {
            _travelDbContext.AdditionalPointPoints.Add(additionalPoint);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task UpdateAdditionalPointMarkAsync(AdditionalPoints additionalPoint)
        {
            _travelDbContext.AdditionalPointPoints.Update(additionalPoint);
            await _travelDbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(AdditionalPoints additionalPoint)
        {
            _travelDbContext.AdditionalPointPoints.Remove(additionalPoint);
            await _travelDbContext.SaveChangesAsync();
        }


    }
}
