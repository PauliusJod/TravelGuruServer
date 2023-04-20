using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute.Private;


public record TRoutePrivateDto(int routeId, string rName, string rOrigin, string rDestination, string UserId); // string rMidWaypoints,


public record CreateTRoutePrivateDto(string rName, string rOrigin, string rDestination, string? rCountry, string? rImagesUrl, string? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions); //, string rMidWaypoints,   , string UserId
public record UpdateTRoutePrivateDto(string rOrigin, string rDestination, string? rCountry, string? rImagesUrl, string? rRecommendationUrl, string UserId); // string rMidWaypoints,


public record GetTRoutePrivateDto(string rName, string rOrigin, string rDestination); // string rMidWaypoints,
public record GetTRoutesPrivateDto(int routeId, string rName, string rOrigin, string rDestination); // string rMidWaypoints,
