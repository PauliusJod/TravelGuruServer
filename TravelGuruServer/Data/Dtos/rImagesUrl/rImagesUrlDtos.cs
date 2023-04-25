using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.rImagesUrl;



public record ImagesUrlPublicDto(int rImagesUrlId, string rImagesUrlLink, int? TRoutePublicrouteId);
public record ImagesUrlPrivateDto(int rImagesUrlId, string rImagesUrlLink, int? TRoutePrivaterouteId);
public record CreatePublicImagesUrlDto(string rImagesUrlLink, int? TRoutePublicrouteId);
public record CreatePrivateImagesUrlDto(string rImagesUrlLink, int? TRoutePrivaterouteId);
