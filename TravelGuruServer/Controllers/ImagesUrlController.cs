using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.rImagesUrl;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class ImagesUrlController : ControllerBase
    {
        private readonly IRImagesUrlRepositories _rImagesUrlRepositories;

        public ImagesUrlController(IRImagesUrlRepositories rImagesUrlRepositories)
        {
            _rImagesUrlRepositories = rImagesUrlRepositories;
        }

        //[HttpGet]
        //[Route("troutesprivate/{trouteId}/midwaypoints/{midWaypointId}")]
        //public async Task<ActionResult<MidWaypointPrivateDto>> GetMidWaypoint(int trouteId, int midWaypointId)
        //{
        //    var midWaypoint = await _rImagesUrlRepositories.GetMidWaypointAsync(trouteId, midWaypointId);

        //    // 404
        //    if (midWaypoint == null)
        //        return NotFound();

        //    return new MidWaypointPrivateDto(midWaypoint.midWaypointId, midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover, midWaypoint.TRoutePrivaterouteId);
        //}

        [HttpGet]
        [Route("troutesprivate/{trouteId}/imageurl")]
        public async Task<IEnumerable<ImagesUrlPrivateDto>> GetImagesUrls(int trouteId)
        {
            var imagesUrls = await _rImagesUrlRepositories.GetImagesAsync(trouteId);

            return imagesUrls.Select(o => new ImagesUrlPrivateDto(o.rImagesUrlId, o.rImagesUrlLink, o.TRoutePrivaterouteId));
        }

        //[HttpPost]
        //[Route("troutesprivate/{trouteId}/midwaypoints")]
        //public async Task<ActionResult<MidWaypointPrivateDto>> Create(int trouteId, CreateMidWaypointPrivateDto createMidWaypointPrivateDto)
        //{
        //    var midWaypoint = new MidWaypoint
        //    {
        //        midWaypointLocation = createMidWaypointPrivateDto.midWaypointLocation,
        //        midWaypointStopover = createMidWaypointPrivateDto.midWaypointStopover,
        //    };
        //    midWaypoint.TRoutePrivaterouteId = trouteId;
        //    await _rImagesUrlRepositories.CreateAsync(midWaypoint);
        //    // 201
        //    return Created($"api/troutes/{trouteId}/midwaypoints{midWaypoint.midWaypointId}", new CreateMidWaypointPrivateDto(midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover));
        //}
    }
}
