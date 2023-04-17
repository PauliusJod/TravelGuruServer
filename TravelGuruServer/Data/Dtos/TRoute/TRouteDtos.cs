using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.TRoute;


public record TRouteDto(int routeId, string rOrigin, string rDestination, string UserId); // string rMidWaypoints,
public record CreateTRouteDto(string rOrigin, string rDestination, List<MidWaypoint> midWaypoints, List<TrouteDescription> descriptions); //, string rMidWaypoints,   , string UserId
public record UpdateTRouteDto(string rOrigin, string rDestination, string UserId); // string rMidWaypoints,
public record GetTRouteDto(string rOrigin, string rDestination); // string rMidWaypoints,
public record GetTRoutesDto(int routeId, string rOrigin, string rDestination); // string rMidWaypoints,
