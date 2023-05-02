using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.rImagesUrl;



public record ImagesUrlDto(int rImagesUrlId, string rImagesUrlLink, int? TRouterouteId);
public record CreateImagesUrlDto(string rImagesUrlLink, int? TRouterouteId);
