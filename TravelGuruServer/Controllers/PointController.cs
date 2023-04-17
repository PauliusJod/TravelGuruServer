using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.Point;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{        
    [ApiController]
    [Route("api/troutes/{trouteId}/routepoints")]
    public class PointController : ControllerBase
    {

            private readonly IRouteRespositories _routesRepository;
            private readonly IRoutePointRepositories _routePointRepositories;

            public PointController(IRouteRespositories routesRepository, IRoutePointRepositories routePointRepositories)
            {
                _routesRepository = routesRepository;
                _routePointRepositories = routePointRepositories;
            }

            [HttpGet]
            [Route("{pointId}")]
            public async Task<ActionResult<PointDto>> GetMidWaypoint(int trouteId, int pointId)
            {
                var point = await _routePointRepositories.GetTroutePointAsync(trouteId, pointId);

                // 404
                if (point == null)
                    return NotFound();

                return new PointDto(point.pointId, point.pointOnRouteId, point.routePointDescription, point.TRouterouteId);
            }

            [HttpGet]
            public async Task<IEnumerable<PointDto>> GetMidWaypoints(int trouteId)
            {
                var midWaypoints = await _routePointRepositories.GetTroutePointsAsync(trouteId);

                return midWaypoints.Select(o => new PointDto(o.pointId, o.pointOnRouteId, o.routePointDescription, o.TRouterouteId));
            }

            [HttpPost]
            public async Task<ActionResult<PointDto>> Create(int trouteId, CreatePointDto createPointDto)
            {
                var point = new TroutePointDescription
                {
                    pointOnRouteId = createPointDto.pointOnRouteId,
                    routePointDescription = createPointDto.routePointDescription,
                };
                point.TRouterouteId = trouteId;
                await _routePointRepositories.CreateAsync(point);
                // 201
                return Created($"api/troutes/{trouteId}/routepoints{point.pointId}", new CreatePointDto(point.pointOnRouteId, point.routePointDescription));
            }
    }
}
