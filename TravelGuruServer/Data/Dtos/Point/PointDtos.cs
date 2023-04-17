using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Data.Dtos.Point;


public record PointDto(int pointId, int pointOnRouteId, string routePointDescription, int routeId);
public record CreatePointDto(int pointOnRouteId, string routePointDescription); //, int routeId
public record UpdatePointDto(int pointOnRouteId, string routePointDescription, int routeId);
