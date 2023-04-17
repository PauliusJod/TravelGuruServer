namespace TravelGuruServer.Data.Dtos.MidWaypoints;


public record MidWaypointDto(int midWaypointId, string midWaypointLocation, bool midWaypointStopover, int routeId);
public record CreateMidWaypointDto(string midWaypointLocation, bool midWaypointStopover); //, int routeId
public record UpdateMidWaypointDto(string midWaypointLocation, bool midWaypointStopover, int routeId);