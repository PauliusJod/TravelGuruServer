namespace TravelGuruServer.Data.Dtos.AdditionalPoint;

public record AdditionalPointDto(int additionalPointId, float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation, int additionalPointUsedById);
public record CreateAdditionalPointDto(float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation); //, int routeId
public record UpdateAdditionalPointDto(float additionalPointCoordX, float additionalPointCoordY, string? additionalPointInformation, int additionalPointUsedById);
