using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute;


public record TRouteDto(int routeId, string rName, string rOrigin, string rDestination, string UserId); // string rMidWaypoints,
public record CreateTRouteDto(string rName, string rOrigin, string rDestination, List<MidWaypoint> midWaypoints, List<TrouteSectionDescription>? sectionDescriptions, List<TroutePointDescription>? pointDescriptions); //, string rMidWaypoints,   , string UserId
public record UpdateTRouteDto(string rOrigin, string rDestination, string UserId); // string rMidWaypoints,
public record GetTRouteDto(string rName, string rOrigin, string rDestination); // string rMidWaypoints,
public record GetTRoutesDto(int routeId, string rName, string rOrigin, string rDestination); // string rMidWaypoints,
