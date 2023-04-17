using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.TRoute;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;
using TravelGuruServer.Data.Dtos.MidWaypoints;

namespace TravelGuruServer.Controllers
{

    [ApiController]
    [Route("api/troutes/{trouteId}/midwaypoints")]
    public class MidWaypointController : ControllerBase
    {
        private readonly IRouteRespositories _routesRepository;
        private readonly IMidWaypointRepositories _midWaypointsRepository;

        public MidWaypointController(IRouteRespositories routesRepository, IMidWaypointRepositories midWaypointRepositories)
        {
            _routesRepository = routesRepository;
            _midWaypointsRepository = midWaypointRepositories;
        }

        [HttpGet]
        [Route("{midWaypointId}")]
        public async Task<ActionResult<MidWaypointDto>> GetMidWaypoint(int trouteId, int midWaypointId)
        {
            var midWaypoint = await _midWaypointsRepository.GetMidWaypointAsync(trouteId, midWaypointId);

            // 404
            if (midWaypoint == null)
                return NotFound();

            return new MidWaypointDto(midWaypoint.midWaypointId, midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover, midWaypoint.TRouterouteId);
        }
        
        [HttpGet]
        public async Task<IEnumerable<MidWaypointDto>> GetMidWaypoints(int trouteId)
        {
            var midWaypoints = await _midWaypointsRepository.GetMidWaypointsAsync(trouteId);

            return midWaypoints.Select(o => new MidWaypointDto(o.midWaypointId, o.midWaypointLocation, o.midWaypointStopover, o.TRouterouteId));
        }

        [HttpPost]
        public async Task<ActionResult<MidWaypointDto>> Create(int trouteId, CreateMidWaypointDto createMidWaypointDto)
        {
            var midWaypoint = new MidWaypoint
            {
                midWaypointLocation = createMidWaypointDto.midWaypointLocation,
                midWaypointStopover = createMidWaypointDto.midWaypointStopover,
            };
            midWaypoint.TRouterouteId = trouteId;
            await _midWaypointsRepository.CreateAsync(midWaypoint);
            // 201
            return Created($"api/troutes/{trouteId}/midwaypoints{midWaypoint.midWaypointId}", new CreateMidWaypointDto(midWaypoint.midWaypointLocation, midWaypoint.midWaypointStopover));
        }
    }
}
