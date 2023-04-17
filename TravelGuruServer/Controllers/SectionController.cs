using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.Section;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{

    [ApiController]
    [Route("api/troutes/{trouteId}/routesections")]
    public class SectionController : ControllerBase
    {

        private readonly IRouteRespositories _routesRepository;
        private readonly IRouteSectionRepositories _routeSectionRepositories;

        public SectionController(IRouteRespositories routesRepository, IRouteSectionRepositories routeSectionRepositories)
        {
            _routesRepository = routesRepository;
            _routeSectionRepositories = routeSectionRepositories;
        }

        [HttpGet]
        [Route("{sectionId}")]
        public async Task<ActionResult<SectionDto>> GetSection(int trouteId, int sectionId)
        {
            var section = await _routeSectionRepositories.GetTrouteSectionAsync(trouteId, sectionId);

            // 404
            if (section == null)
                return NotFound();

            return new SectionDto(section.sectionId, section.sectionOnRouteId, section.routeSectionDescription, section.TRouterouteId);
        }

        [HttpGet]
        public async Task<IEnumerable<SectionDto>> GetSections(int trouteId)
        {
            var sections = await _routeSectionRepositories.GetTrouteSectionsAsync(trouteId);

            return sections.Select(o => new SectionDto(o.sectionId, o.sectionOnRouteId, o.routeSectionDescription, o.TRouterouteId));
        }

        [HttpPost]
        public async Task<ActionResult<SectionDto>> Create(int trouteId, CreateSectionDto createSectionDto)
        {
            var section = new TrouteSectionDescription
            {
                sectionOnRouteId = createSectionDto.sectionOnRouteId,
                routeSectionDescription = createSectionDto.routeSectionDescription,
            };
            section.TRouterouteId = trouteId;
            await _routeSectionRepositories.CreateAsync(section);
            // 201
            return Created($"api/troutes/{trouteId}/routesections{section.sectionId}", new CreateSectionDto(section.sectionOnRouteId, section.routeSectionDescription));
        }
    }
}
