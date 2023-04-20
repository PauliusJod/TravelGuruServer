using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute.Public;


public record TRoutePublicDto(int routeId, string rName, string rOrigin, string rDestination, string UserId); // string rMidWaypoints,


public record CreateTRoutePublicDto(string rName, string rOrigin, string rDestination, double rCost, float rRating, string rType, string? rCountry, string? rImagesUrl, string? rRecommendationUrl, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions); //, string rMidWaypoints,   , string UserId
public record UpdateTRoutePublicDto(string rOrigin, string rDestination, double rCost, float rRating, string rType, string? rCountry, string? rImagesUrl, string? rRecommendationUrl, string UserId); // string rMidWaypoints,


public record GetTRoutePublicDto(string rName, string rOrigin, string rDestination); // string rMidWaypoints,
public record GetTRoutesPublicDto(int routeId, string rName, string rOrigin, string rDestination); // string rMidWaypoints,
