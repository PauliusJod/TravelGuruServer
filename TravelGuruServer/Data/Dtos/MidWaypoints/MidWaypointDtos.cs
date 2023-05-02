namespace TravelGuruServer.Data.Dtos.MidWaypoints;


public record MidWaypointPrivateDto(int midWaypointId, string midWaypointLocation, bool midWaypointStopover, int? TRouterouteId);
public record CreateMidWaypointPrivateDto(string midWaypointLocation, bool midWaypointStopover); //, int routeId
public record UpdateMidWaypointPrivateDto(string midWaypointLocation, bool midWaypointStopover, int TRouterouteId);
