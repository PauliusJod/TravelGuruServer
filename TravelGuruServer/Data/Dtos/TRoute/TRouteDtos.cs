using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute;


public record TRouteDto(int routeId, string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string UserId);


public record CreateTRouteDto(string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions);
public record UpdateTRouteDto(string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TroutePointDescription>? pointDescriptions, List<List<AdditionalPoints>?>? additionalMarkers, string UserId);
public record UpdateTRoutePublishDto(bool rIsPublished); 


public record GetTRouteDto(string rName, string rOrigin, string rDestination);
public record GetFullTRouteDto(string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions);

public record GetTRoutesDto(int routeId, string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl);

