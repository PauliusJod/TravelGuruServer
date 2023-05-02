using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.Point;

public record PointDto(int pointId, int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRouterouteId);
public record CreatePointDto(int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRouterouteId); //, int routeId
public record UpdatePointDescriptionDto(int pointId, string routePointDescription, int routeId);
