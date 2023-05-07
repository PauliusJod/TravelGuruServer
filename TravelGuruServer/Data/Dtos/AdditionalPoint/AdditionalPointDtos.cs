namespace TravelGuruServer.Data.Dtos.AdditionalPoint;

public record AdditionalPointMarkerDto(int additionalPointId, int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string additionalPointInformation, string? additionalPointPlaceName, string? additionalPointPlaceId, double? additionalPointPlaceRating, string? additionalPointPlaceType, string? additionalPointPlaceRefToMaps, int TroutePointDescriptionpointId);
public record AdditionalPointMarkerTextDto(int additionalPointId, string additionalPointInformation);
public record CreateAdditionalPointDto(int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation, string? additionalPointPlaceName, string? additionalPointPlaceId, double? additionalPointPlaceRating, string? additionalPointPlaceType, string? additionalPointPlaceRefToMaps); //, int routeId
public record UpdateAdditionalPointDto(int additionalPointRouteId, int additionalPointIdInList, float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation, string? additionalPointPlaceName, string? additionalPointPlaceId, double? additionalPointPlaceRating, string? additionalPointPlaceType, string? additionalPointPlaceRefToMaps, int additionalPointUsedById);
public record UpdateAdditionalPointDescriptionDto( string? additionalPointInformation);

public record UpdateAdditionalPointAddPlaceDto(float additionalPointCoordX, float additionalPointCoordY, string? additionalPointPlaceName, string? additionalPointPlaceId, double? additionalPointPlaceRating, string? additionalPointPlaceType, string? additionalPointPlaceRefToMaps);
