using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRouteRespositories
    {
        Task CreateAsync(TRoute route);
        Task<TRoute?> GetRouteAsync(int routeid);
        Task<List<TRoute>> GetRoutesAsync();
    }

    public class RouteRespositories : IRouteRespositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RouteRespositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TRoute?> GetRouteAsync(int routeid)
        {
            return await _travelDbContext.TRoutes.FirstOrDefaultAsync(o => o.routeId == routeid);
        }
        public async Task<List<TRoute>> GetRoutesAsync()
        {
            return await _travelDbContext.TRoutes.ToListAsync();
        }

        public async Task CreateAsync(TRoute route)
        {
            _travelDbContext.TRoutes.Add(route);
            await _travelDbContext.SaveChangesAsync();

        }
        //public async Task UpdateAsync(TRoute city)
        //{
        //    _travelDbContext.Cities.Update(city);
        //    await _travelDbContext.SaveChangesAsync();

        //}
        //public async Task DeleteAsync(TRoute city)
        //{
        //    _travelDbContext.Cities.Remove(city);
        //    await _travelDbContext.SaveChangesAsync();

        //}

    }
}
