using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelGuruServer.Data.Dtos.Comment;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRespositories _commentRepositories;

        public CommentController(ICommentRespositories commentRepositories)
        {
            _commentRepositories = commentRepositories;
        }

        [HttpGet]
        [Route("routecomments/{trouteId}")]
        public async Task<IEnumerable<CommentDto>> GetComments(int trouteId)
        {
            var comments = await _commentRepositories.GetCommentsAsync(trouteId);

            return comments.Select(o => new CommentDto(o.commentId, o.commentText, o.commentRating, o.commentDate, o.TRouterouteId));
        }

        [HttpPost]
        [Route("routecomments/{trouteId}/newcomment")]
        public async Task<ActionResult<Comment>> Create(int trouteId, CreateCommentDto createCommentDto)
        {
            
            var comment = new Comment
            {
                commentText = createCommentDto.commentText,
                commentRating = (float)0.00,
                commentDate = DateTime.Today,
                TRouterouteId = trouteId,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub),
            };
            await _commentRepositories.CreateAsync(comment);
            // 201
            return Created($"api/troutes/{trouteId}/midwaypoints{comment.commentId}", new CreateCommentDto(comment.commentText));
        }
    }
}
