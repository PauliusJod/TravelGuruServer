using TravelGuruServer.Entities;
namespace TravelGuruServer.Data.Dtos.rRecommendationUrl;


public record RecommendationPublicDto(int rRecommendationUrlId, string rRecommendationUrlLink, int? TRoutePublicrouteId);
public record RecommendationPrivateDto(int rRecommendationUrlId, string rRecommendationUrlLink, int? TRoutePrivaterouteId);
public record CreatePublicRecommendationDto(string rRecommendationUrlLink, int? TRoutePublicrouteId);
public record CreatePrivateRecommendationDto(string rRecommendationUrlLink, int? TRoutePrivaterouteId);
