using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Data.Dtos.Section;

public record SectionDto(int sectionId, int sectionOnRouteId, string routeSectionDescription, int routeId);
public record CreateSectionDto(int sectionOnRouteId, string routeSectionDescription); //, int routeId
public record UpdateSectionDto(int sectionOnRouteId, string routeSectionDescription, int routeId);


