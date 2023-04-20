using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface IRoutePublicRespositories
    {
        Task CreatePublicAsync(TRoutePublic route);
        Task<TRoutePublic?> GetPublicRouteAsync(int routeid);
        Task<List<TRoutePublic>> GetPublicRoutesAsync();
        Task<List<TRoutePublic>> GetUserCreatedPublicRoutesAsync(string userId);
    }

    public class RoutePublicRespositories : IRoutePublicRespositories
    {
        private readonly TravelDBContext _travelDbContext;

        public RoutePublicRespositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<TRoutePublic?> GetPublicRouteAsync(int routeid)
        {
            return await _travelDbContext.TRoutesPublic.FirstOrDefaultAsync(o => o.routeId == routeid);
        }
        public async Task<List<TRoutePublic>> GetPublicRoutesAsync()
        {
            return await _travelDbContext.TRoutesPublic.ToListAsync();
        }
        public async Task<List<TRoutePublic>> GetUserCreatedPublicRoutesAsync(string userId)
        {
            return await _travelDbContext.TRoutesPublic.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task CreatePublicAsync(TRoutePublic route)
        {
            _travelDbContext.TRoutesPublic.Add(route);
            await _travelDbContext.SaveChangesAsync();

        }


    }
}
