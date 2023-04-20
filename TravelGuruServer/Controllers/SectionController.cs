using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.Section;
using TravelGuruServer.Data.Dtos.TRoute.Private;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{

    //[ApiController]
    ////[Route("api/troutes/{trouteId}/routesections")]
    //[Route("api")]
    //public class SectionController : ControllerBase
    //{

    //    //private readonly IRouteRespositories _routesRepository;
    //    private readonly IRouteSectionRepositories _routeSectionRepositories;
    //    private readonly IAdditionalPointRepositories _additionalPointRepositories;

    //    public SectionController(IRouteSectionRepositories routeSectionRepositories, IAdditionalPointRepositories additionalPointRepositories)
    //    {
    //        _routeSectionRepositories = routeSectionRepositories;
    //        _additionalPointRepositories = additionalPointRepositories;
    //    }
    //    // PRIVATE
    //    [HttpGet]
    //    [Route("troutesprivate/{trouteId}/sections/{sectionId}")]
    //    public async Task<ActionResult<SectionDto>> GetSection(int trouteId, int sectionId)
    //    {
    //        var section = await _routeSectionRepositories.GetTrouteSectionAsync(trouteId, sectionId);

    //        // 404
    //        if (section == null)
    //            return NotFound();

    //        return new SectionPrivateDto(section.sectionId, section.sectionOnRouteId, section.routeSectionDescription,section.AddinionalSectionPoints, section.TRoutePrivaterouteId);
    //    }

    //    [HttpGet]
    //    [Route("troutesprivate/{trouteId}/sections")]
    //    public async Task<IEnumerable<SectionDto>> GetSections(int trouteId)
    //    {
    //        var sections = await _routeSectionRepositories.GetTrouteSectionsAsync(trouteId);

    //        return sections.Select(o => new SectionDto(o.sectionId, o.sectionOnRouteId, o.routeSectionDescription,o.AddinionalSectionPoints, o.TRouterouteId));
    //    }

    //    [HttpPost]
    //    [Route("troutesprivate/{trouteId}/sections")]
    //    public async Task<ActionResult<SectionDto>> Create(int trouteId, CreateSectionDto createSectionDto)
    //    {
    //        var section = new TrouteSectionDescription
    //        {
    //            sectionOnRouteId = createSectionDto.sectionOnRouteId,
    //            routeSectionDescription = createSectionDto.routeSectionDescription,
    //        };
    //        if (createSectionDto.AddinionalSectionPoints != null)
    //        {
    //            foreach (var item in createSectionDto.AddinionalSectionPoints)
    //            {
    //                item.additionalPointUsedById = section.sectionId;
    //                await _additionalPointRepositories.CreateSectionMarkAsync(item);
    //            }
    //        }
    //        section.TRouterouteId = trouteId;
    //        await _routeSectionRepositories.CreateAsync(section);
    //        // 201
    //        return Created($"api/troutes/{trouteId}/routesections{section.sectionId}", new CreateSectionDto(section.sectionOnRouteId, section.routeSectionDescription,section.AddinionalSectionPoints));
    //    }
    //    // PUBLIC
    //    [HttpGet]
    //    [Route("{sectionId}")]
    //    public async Task<ActionResult<SectionDto>> GetSection(int trouteId, int sectionId)
    //    {
    //        var section = await _routeSectionRepositories.GetTrouteSectionAsync(trouteId, sectionId);

    //        // 404
    //        if (section == null)
    //            return NotFound();

    //        return new SectionDto(section.sectionId, section.sectionOnRouteId, section.routeSectionDescription, section.AddinionalSectionPoints, section.TRouterouteId);
    //    }

    //    [HttpGet]
    //    public async Task<IEnumerable<SectionDto>> GetSections(int trouteId)
    //    {
    //        var sections = await _routeSectionRepositories.GetTrouteSectionsAsync(trouteId);

    //        return sections.Select(o => new SectionDto(o.sectionId, o.sectionOnRouteId, o.routeSectionDescription, o.AddinionalSectionPoints, o.TRouterouteId));
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<SectionDto>> Create(int trouteId, CreateSectionDto createSectionDto)
    //    {
    //        var section = new TrouteSectionDescription
    //        {
    //            sectionOnRouteId = createSectionDto.sectionOnRouteId,
    //            routeSectionDescription = createSectionDto.routeSectionDescription,
    //        };
    //        if (createSectionDto.AddinionalSectionPoints != null)
    //        {
    //            foreach (var item in createSectionDto.AddinionalSectionPoints)
    //            {
    //                item.additionalPointUsedById = section.sectionId;
    //                await _additionalPointRepositories.CreateSectionMarkAsync(item);
    //            }
    //        }
    //        section.TRouterouteId = trouteId;
    //        await _routeSectionRepositories.CreateAsync(section);
    //        // 201
    //        return Created($"api/troutes/{trouteId}/routesections{section.sectionId}", new CreateSectionDto(section.sectionOnRouteId, section.routeSectionDescription, section.AddinionalSectionPoints));
    //    }
    //}
}
