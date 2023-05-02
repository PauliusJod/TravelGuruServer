using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute;


public record TRouteDto(int routeId, string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string UserId); // string rMidWaypoints,


public record CreateTRouteDto(string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions); //, string rMidWaypoints,   , string UserId
public record UpdateTRouteDto(string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TroutePointDescription>? pointDescriptions, List<List<AdditionalPoints>?>? additionalMarkers, string UserId); // string rMidWaypoints,


public record GetTRouteDto(string rName, string rOrigin, string rDestination); // string rMidWaypoints,
public record GetFullTRouteDto(string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions); // string rMidWaypoints,
//public record GetTRoutesPrivateDto(int routeId, string rName, string rOrigin, string rDestination); // string rMidWaypoints,
public record GetTRoutesDto(int routeId, string rName, string rOrigin, string rDestination, double rTripCost, float rRating, bool rIsPublished, string? rCountry, List<RImagesUrl>? rImagesUrl, List<RRecommendationUrl>? rRecommendationUrl); // string rMidWaypoints,


//public double rTripCost { get; set; } //TODO
//public float rRating { get; set; } //TODO
//public bool rIsPublished { get; set; } //TODO