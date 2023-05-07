using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.AdditionalPoint;
using TravelGuruServer.Data.Dtos.Point;
using TravelGuruServer.Data.Dtos.rRecommendationUrl;
using TravelGuruServer.Data.Dtos.TRoute;
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

            return additionalPoints.Select(o => new AdditionalPointMarkerDto(o.additionalPointId, o.additionalPointRouteId, o.additionalPointIdInList, o.additionalPointCoordX, o.additionalPointCoordY, o.additionalPointInformation, o.additionalPointPlaceName, o.additionalPointPlaceId, o.additionalPointPlaceRating,o.additionalPointPlaceType, o.additionalPointPlaceRefToMaps , (int)o.TroutePointDescriptionpointId));
        }
        [HttpPut]
        [Route("troutes/{routeId}/point/{pointId}/additionalpoints/{addInListId}")]
        public async Task<ActionResult<TRouteDto>> Update(int routeId, int pointId, int addInListId, UpdateAdditionalPointDescriptionDto updateAdditionalPointDescriptionDto)
        {
            var addPoint = await _additionalPointRepositories.GetAdditionalPointForTextUpdateAsync(routeId, pointId, addInListId);

            if (addPoint == null)
                return NotFound($"ERROR with routeId: {routeId}");

            if (updateAdditionalPointDescriptionDto.additionalPointInformation != null)
            {
                addPoint.additionalPointInformation = updateAdditionalPointDescriptionDto.additionalPointInformation;
            }

            await _additionalPointRepositories.UpdateAdditionalPointMarkAsync(addPoint);

            return Ok(new AdditionalPointMarkerTextDto(addPoint.additionalPointId, additionalPointInformation: addPoint.additionalPointInformation));
        }
        [HttpPut]
        [Route("troutes/{routeId}/point/{pointId}/additionalpointdata/{addInListId}")]
        public async Task<ActionResult<TRouteDto>> Update(int routeId, int pointId, int addInListId, UpdateAdditionalPointAddPlaceDto updateAdditionalPointAddPlaceDto)
        {
            var addPoint = await _additionalPointRepositories.GetAdditionalPointForTextUpdateAsync(routeId, pointId, addInListId);

            if (addPoint == null)
                return NotFound($"ERROR with routeId: {routeId}");

            if (updateAdditionalPointAddPlaceDto.additionalPointPlaceName != null)
            {

                addPoint.additionalPointCoordX = updateAdditionalPointAddPlaceDto.additionalPointCoordX;
                addPoint.additionalPointCoordY = updateAdditionalPointAddPlaceDto.additionalPointCoordY;
                addPoint.additionalPointPlaceName = updateAdditionalPointAddPlaceDto.additionalPointPlaceName;
                addPoint.additionalPointPlaceId = updateAdditionalPointAddPlaceDto.additionalPointPlaceId;
                addPoint.additionalPointPlaceRating = updateAdditionalPointAddPlaceDto.additionalPointPlaceRating;
                addPoint.additionalPointPlaceType = updateAdditionalPointAddPlaceDto.additionalPointPlaceType;
                addPoint.additionalPointPlaceRefToMaps = updateAdditionalPointAddPlaceDto.additionalPointPlaceRefToMaps;
            }

            await _additionalPointRepositories.UpdateAdditionalPointMarkAsync(addPoint);

            return Ok(new AdditionalPointMarkerTextDto(addPoint.additionalPointId, additionalPointInformation: addPoint.additionalPointInformation));

        }
    }
}
