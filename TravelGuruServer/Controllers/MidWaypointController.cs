using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.TRoute;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;
using TravelGuruServer.Data.Dtos.MidWaypoints;

namespace TravelGuruServer.Controllers
{

    [ApiController]
    [Route("api")]
    public class MidWaypointController : ControllerBase
    {
        private readonly IMidWaypointRepositories _midWaypointsRepository;

        public MidWaypointController(IMidWaypointRepositories midWaypointRepositories)
        {
            _midWaypointsRepository = midWaypointRepositories;
        }

        [HttpGet]
        [Route("troutesprivate/{trouteId}/midwaypoints/{midWaypointId}")]
        public async Task<ActionResult<MidWaypointPrivateDto>> GetMidWaypoint(int trouteId, int midWaypointId)
        {
            var midWaypoint = await _midWaypointsRepository.GetMidWaypointAsync(trouteId, midWaypointId);

            // 404
            if (midWaypoint == null)
                return NotFound();

            return new MidWaypointPrivateDto(midWaypoint.midWaypointId, midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover, midWaypoint.TRoutePrivaterouteId);
        }

        [HttpGet]
        [Route("troutesprivate/{trouteId}/midwaypoints")]
        public async Task<IEnumerable<MidWaypointPrivateDto>> GetMidWaypoints(int trouteId)
        {
            var midWaypoints = await _midWaypointsRepository.GetMidWaypointsAsync(trouteId);

            return midWaypoints.Select(o => new MidWaypointPrivateDto(o.midWaypointId, o.midWaypointLocation, o.midWaypointStopover, o.TRoutePrivaterouteId));
        }

        [HttpPost]
        [Route("troutesprivate/{trouteId}/midwaypoints")]
        public async Task<ActionResult<MidWaypointPrivateDto>> Create(int trouteId, CreateMidWaypointPrivateDto createMidWaypointPrivateDto)
        {
            var midWaypoint = new MidWaypoint
            {
                midWaypointLocation = createMidWaypointPrivateDto.midWaypointLocation,
                midWaypointStopover = createMidWaypointPrivateDto.midWaypointStopover,
            };
            midWaypoint.TRoutePrivaterouteId = trouteId;
            await _midWaypointsRepository.CreateAsync(midWaypoint);
            // 201
            return Created($"api/troutes/{trouteId}/midwaypoints{midWaypoint.midWaypointId}", new CreateMidWaypointPrivateDto(midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover));
        }
    }
}
