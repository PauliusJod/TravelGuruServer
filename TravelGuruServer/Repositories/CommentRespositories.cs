using Microsoft.EntityFrameworkCore;
using TravelGuruServer.Data;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Repositories
{
    public interface ICommentRespositories
    {
        Task CreateAsync(Comment comment);
        Task<Comment?> GetCommentAsync(int routeId, int commentId);
        Task<List<Comment>> GetCommentsAsync(int routeId);
        Task UpdateAsync(Comment comment);
    }

    public class CommentRespositories : ICommentRespositories
    {
        private readonly TravelDBContext _travelDbContext;

        public CommentRespositories(TravelDBContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task<Comment?> GetCommentAsync(int routeId, int commentId)
        {
            return await _travelDbContext.Comments.FirstOrDefaultAsync(o => o.TRouterouteId == routeId && o.commentId == commentId);
        }
        public async Task<List<Comment>> GetCommentsAsync(int routeId)
        {
            return await _travelDbContext.Comments.Where(o => o.TRouterouteId == routeId).ToListAsync();
        }

        public async Task CreateAsync(Comment comment)
        {
            _travelDbContext.Comments.Add(comment);
            await _travelDbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(Comment comment)
        {
            _travelDbContext.Comments.Update(comment);
            await _travelDbContext.SaveChangesAsync();

        }
    }
}
