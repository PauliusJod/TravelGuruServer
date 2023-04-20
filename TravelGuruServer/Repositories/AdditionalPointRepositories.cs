using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IAdditionalPointRepositories
    {
        Task CreatePointMarkAsync(AdditionalPoints additionalPoint);
        Task CreateSectionMarkAsync(AdditionalPoints additionalPoint);
        Task<AdditionalPoints?> GetAdditionalPointMarkAsync(int pointId);
        Task<List<AdditionalPoints>> GetAdditionalPointMarksAsync();
        Task<AdditionalPoints?> GetAdditionalSectionMarkAsync(int sectionId);
        Task<List<AdditionalPoints>> GetAdditionalSectionMarksAsync();
    }

    public class AdditionalPointRepositories : IAdditionalPointRepositories
    {
        private readonly TravelDBContext _travelDbContext;

        public AdditionalPointRepositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<AdditionalPoints?> GetAdditionalPointMarkAsync(int pointId)
        {
            return await _travelDbContext.AdditionalPointPoints.FirstOrDefaultAsync(o => o.TroutePointDescriptionpointId == pointId);
        }
        public async Task<List<AdditionalPoints>> GetAdditionalPointMarksAsync()
        {
            return await _travelDbContext.AdditionalPointPoints.ToListAsync();
        }

        public async Task CreatePointMarkAsync(AdditionalPoints additionalPoint)
        {
            _travelDbContext.AdditionalPointPoints.Add(additionalPoint);
            await _travelDbContext.SaveChangesAsync();

        }

        public async Task<AdditionalPoints?> GetAdditionalSectionMarkAsync(int sectionId)
        {
            return await _travelDbContext.AdditionalSectionPoints.FirstOrDefaultAsync(o => o.TrouteSectionDescriptionsectionId == sectionId);
        }
        public async Task<List<AdditionalPoints>> GetAdditionalSectionMarksAsync()
        {
            return await _travelDbContext.AdditionalSectionPoints.ToListAsync();
        }

        public async Task CreateSectionMarkAsync(AdditionalPoints additionalPoint)
        {
            _travelDbContext.AdditionalSectionPoints.Add(additionalPoint);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
