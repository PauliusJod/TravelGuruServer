using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.Point;


public record PointPublicDto(int pointId, int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRoutePublicrouteId);
public record PointPrivateDto(int pointId, int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRoutePrivaterouteId);
public record CreatePublicPointDto(int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRoutePublicrouteId); //, int routeId
public record CreatePrivatePointDto(int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int? TRoutePrivaterouteId); //, int routeId
public record UpdatePointDto(int pointOnRouteId, string routePointDescription, List<AdditionalPoints>? AddinionalPointMarks, int routeId);
