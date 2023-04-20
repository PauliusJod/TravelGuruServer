using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Data.Dtos.Section;

public record SectionDto(int sectionId, int sectionOnRouteId, string routeSectionDescription, List<AdditionalPoints>? AddinionalSectionPoints, int routeId);
public record CreateSectionDto(int sectionOnRouteId, string routeSectionDescription, List<AdditionalPoints>? AddinionalSectionPoints); //, int routeId
public record UpdateSectionDto(int sectionOnRouteId, string routeSectionDescription, List<AdditionalPoints>? AddinionalSectionPoints, int routeId);
public record GetSectionDto(int sectionOnRouteId, string routeSectionDescription, int routeId);


