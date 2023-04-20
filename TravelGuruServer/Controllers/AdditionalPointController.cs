using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.AdditionalPoint;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{

    //[ApiController]
    //[Route("api/troutes/{trouteId}/routesections")]
    //public class AdditionalPointController : ControllerBase
    //{

    //    private readonly IRouteSectionRepositories _routeSectionRepositories;
    //    private readonly IAdditionalPointRepositories _additionalPointRepositories;

    //    public AdditionalPointController(IRouteSectionRepositories routeSectionRepositories, IAdditionalPointRepositories additionalPointRepositories)
    //    {
    //        _routeSectionRepositories = routeSectionRepositories;
    //        _additionalPointRepositories = additionalPointRepositories;
    //    }

    //    [HttpGet]
    //    [Route("{sectionId}")]
    //    public async Task<ActionResult<AdditionalPointDto>> GetSection(int sectionId)
    //    {
    //        if(sectionId != null)
    //        {
    //            var section = await _routeSectionRepositories.GetTrouteSectionAsync(trouteId, sectionId);
    //        }
    //        if(pointId != null)
    //        {

    //        }
            

    //        // 404
    //        if (section == null && pointId == null)
    //            return NotFound("Section or point");

    //        return new AdditionalPointDto(section.sectionId, section.sectionOnRouteId, section.routeSectionDescription, section.TRouterouteId);
    //    }

    //    //[HttpGet]
    //    //public async Task<IEnumerable<AdditionalPointDto>> GetSections(int trouteId)
    //    //{
    //    //    var sections = await _routeSectionRepositories.GetTrouteSectionsAsync(trouteId);

    //    //    return sections.Select(o => new AdditionalPointDto(o.sectionId, o.sectionOnRouteId, o.routeSectionDescription, o.TRouterouteId));
    //    //}

    //    [HttpPost]
    //    public async Task<ActionResult<AdditionalPointDto>> Create(int usedById, CreateAdditionalPointDto createAdditionalPointDto)
    //    {
    //        var addPoint = new AdditionalPoints
    //        { 
    //            additionalPointCoordX = createAdditionalPointDto.additionalPointCoordX,
    //            additionalPointCoordY = createAdditionalPointDto.additionalPointCoordY,
    //            additionalPointInformation = createAdditionalPointDto.additionalPointInformation,
    //        };
    //        addPoint.additionalPointUsedById = usedById;
    //        await _routeSectionRepositories.CreateAsync(addPoint);
    //        // 201
    //        return Created($"api/troutes/{trouteId}/routesections{addPoint.sectionId}", new CreateAdditionalPointDto(addPoint.sectionOnRouteId, addPoint.routeSectionDescription));
    //    }
    //}
}
