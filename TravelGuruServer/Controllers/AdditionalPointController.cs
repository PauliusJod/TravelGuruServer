using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.AdditionalPoint;
using TravelGuruServer.Data.Dtos.rRecommendationUrl;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{

    [ApiController]
    [Route("api")]
    public class AdditionalPointController : ControllerBase
    {

        private readonly IRouteSectionRepositories _routeSectionRepositories;
        private readonly IAdditionalPointRepositories _additionalPointRepositories;

        public AdditionalPointController(IRouteSectionRepositories routeSectionRepositories, IAdditionalPointRepositories additionalPointRepositories)
        {
            _routeSectionRepositories = routeSectionRepositories;
            _additionalPointRepositories = additionalPointRepositories;
        }

        [HttpGet]
        [Route("troutes/{trouteId}/additionalpoints")]
        public async Task<IEnumerable<AdditionalPointMarkerDto>> GetAdditionalPointsOnRoute(int trouteId)
        {
            var additionalPoints = await _additionalPointRepositories.GetAdditionalPointMarksChoosenRouteAsync(trouteId);

            return additionalPoints.Select(o => new AdditionalPointMarkerDto(o.additionalPointId, o.additionalPointRouteId, o.additionalPointIdInList, o.additionalPointCoordX, o.additionalPointCoordY, o.additionalPointInformation , (int)o.TroutePointDescriptionpointId));
        }
    }
}
