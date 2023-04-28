namespace TravelGuruServer.Data.Dtos.AdditionalPoint;

public record AdditionalPointMarkerDto(int additionalPointId,int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string additionalPointInformation, int TroutePointDescriptionpointId);
public record CreateAdditionalPointDto(int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation); //, int routeId
public record UpdateAdditionalPointDto(int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation, int additionalPointUsedById);
