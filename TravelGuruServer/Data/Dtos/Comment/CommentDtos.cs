namespace TravelGuruServer.Data.Dtos.Comment;

public record CommentDto(int commentId, string commentText, float commentRating, DateTime commentDate, int? TRouterouteId);
public record CreateCommentDto(string commentText);
public record UpdateCommentDto(string commentText, float commentRating, DateTime commentDate, int? TRouterouteId);
public record DeleteCommentDto(int commentId, string commentText, float commentRating, DateTime commentDate, int? TRouterouteId);
