using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        [HttpDelete]
        [Route("troutes/{trouteId}/point/{pointId}/removeadditional/{pointInListId}")]
        public async Task<ActionResult> Remove(int trouteId, int pointId, int pointInListId)
        {
            var additionalPoint = await _additionalPointRepositories.GetAdditionalPointMarkAsync(trouteId, pointId, pointInListId);

            // 404
            if (additionalPoint == null)
                return NotFound();
            await _additionalPointRepositories.DeleteAsync(additionalPoint);

            // 204
            return NoContent();
        }


        [HttpPost]
        [Route("troutes/{trouteId}/point/{pointId}/additionalpoints")]
        public async Task<ActionResult<AdditionalPoints>> Create(int trouteId, int pointId, CreateAdditionalPointDto createAdditionalPointDto)
        {
            var addPoint = new AdditionalPoints
            {
                additionalPointIdInList = createAdditionalPointDto.additionalPointIdInList,
                additionalPointCoordX = createAdditionalPointDto.additionalPointCoordX,
                additionalPointCoordY = createAdditionalPointDto.additionalPointCoordY,
                additionalPointInformation = createAdditionalPointDto.additionalPointInformation,
                additionalPointPlaceName = createAdditionalPointDto.additionalPointPlaceName,
                additionalPointPlaceId = createAdditionalPointDto.additionalPointPlaceId,
                additionalPointPlaceRating = createAdditionalPointDto.additionalPointPlaceRating,
                additionalPointPlaceType = createAdditionalPointDto.additionalPointPlaceType,
                additionalPointPlaceRefToMaps = createAdditionalPointDto.additionalPointPlaceRefToMaps,
            };
            addPoint.additionalPointRouteId = trouteId;
            addPoint.TroutePointDescriptionpointId = pointId;
            await _additionalPointRepositories.CreatePointAdditionalMarkAsync(addPoint);

            // 201
            return Created($"api/troutes/{trouteId}/point/{pointId}/additionalpoints", new CreateAdditionalPointDto( addPoint.additionalPointRouteId, addPoint.additionalPointIdInList, addPoint.additionalPointCoordX, addPoint.additionalPointCoordY, addPoint.additionalPointInformation, addPoint.additionalPointPlaceName, addPoint.additionalPointPlaceId, addPoint.additionalPointPlaceRating, addPoint.additionalPointPlaceType, addPoint.additionalPointPlaceRefToMaps));
        }

        [HttpPut]
        [Route("troutes/{routeId}/point/{pointId}/additionalpoints/{addInListId}")]
        public async Task<ActionResult<TRouteDto>> UpdateDescription(int routeId, int pointId, int addInListId, UpdateAdditionalPointDescriptionDto updateAdditionalPointDescriptionDto)
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
        public async Task<ActionResult<TRouteDto>> UpdatePlace(int routeId, int pointId, int addInListId, UpdateAdditionalPointAddPlaceDto updateAdditionalPointAddPlaceDto)
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
