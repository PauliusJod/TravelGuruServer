using TravelGuruServer.Entities;
namespace TravelGuruServer.Data.Dtos.rRecommendationUrl;


public record RecommendationPrivateDto(int rRecommendationUrlId, string rRecommendationUrlLink, int? TRouterouteId);
public record CreatePrivateRecommendationDto(string rRecommendationUrlLink);
