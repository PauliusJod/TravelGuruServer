using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using TravelGuruServer.Data.Dtos.Point;
using TravelGuruServer.Data.Dtos.TRoute;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class PointController : ControllerBase
    {

        private readonly IRoutePointRepositories _routePointRepositories;
        private readonly IAdditionalPointRepositories _additionalPointRepositories;

        public PointController(IRoutePointRepositories routePointRepositories, IAdditionalPointRepositories additionalPointRepositories)
        {
            _routePointRepositories = routePointRepositories;
            _additionalPointRepositories = additionalPointRepositories;
        }

        [HttpGet]
        [Route("troutes/{trouteId}/routepoints/{pointId}")]
        public async Task<ActionResult<PointDto>> GetPointDescription(int trouteId, int pointId)
        {
            var point = await _routePointRepositories.GetTroutePointAsync(trouteId, pointId);

            // 404
            if (point == null)
                return NotFound();

            return new PointDto(point.pointId, point.pointOnRouteId, point.routePointDescription, point.AddinionalPointMarks, point.TRouterouteId);
        }

        [HttpGet]
        [Route("troutes/{trouteId}/routepoints")]
        public async Task<IEnumerable<PointDto>> GetPointsDescriptions(int trouteId)
        {
            var points = await _routePointRepositories.GetTroutePointsAsync(trouteId);

            return points.Select(o => new PointDto(o.pointId, o.pointOnRouteId, o.routePointDescription, o.AddinionalPointMarks, o.TRouterouteId));
        }

        [HttpGet]
        [Route("troutes/{trouteId}/routepointsadditional")]
        public async Task<IEnumerable<PointDto>> GetPointsDescriptionsWithAdditionalMarkers(int trouteId)
        {
            var points = await _routePointRepositories.GetTroutePointsAsync(trouteId);
            for (int i = 0; i < points.Count; i++)
            {
                var additional = await _additionalPointRepositories.GetAdditionalPointMarksChoosenPointAsync(points[i].pointId);
                if(additional != null)
                {
                    points[i].AddinionalPointMarks = additional;

                }

            }
            

            return points.Select(o => new PointDto(o.pointId, o.pointOnRouteId, o.routePointDescription, o.AddinionalPointMarks, o.TRouterouteId));
        }



        [HttpPost]
        [Route("troutes/{trouteId}/routepoints")]
        public async Task<ActionResult<PointDto>> Create(int trouteId, CreatePointDto createPointDto)
        {
            var point = new TroutePointDescription
            {
                pointOnRouteId = createPointDto.pointOnRouteId,
                routePointDescription = createPointDto.routePointDescription,
            };
            if (createPointDto.AddinionalPointMarks != null)
            {
                foreach (var item in createPointDto.AddinionalPointMarks)
                {
                    item.TroutePointDescriptionpointId = point.pointId;
                    await _additionalPointRepositories.CreatePointAdditionalMarkAsync(item);
                }
            }
            point.TRouterouteId = trouteId;
            await _routePointRepositories.CreateAsync(point);
            // 201
            return Created($"api/troutes/{trouteId}/routepoints{point.pointId}", new CreatePointDto(point.pointOnRouteId, point.routePointDescription, point.AddinionalPointMarks, point.TRouterouteId));
        }
        [HttpPut]
        [Route("troutes/{routeId}/routepoints/{pointId}")]
        public async Task<ActionResult<TRouteDto>> Update(int routeId, int pointId, UpdatePointDescriptionDto updatePointDescriptionDto)
        {
            var point = await _routePointRepositories.GetTroutePointAsync(routeId, pointId);

            if (point == null)
                return NotFound($"ERROR with routeId: {routeId}");

            if (updatePointDescriptionDto.routePointDescription != null)
            {
                point.routePointDescription = updatePointDescriptionDto.routePointDescription;
            }

            await _routePointRepositories.UpdateAsync(point);

            return Ok(new PointDto(point.pointId, point.pointOnRouteId, point.routePointDescription, point.AddinionalPointMarks, point.TRouterouteId));
        }
    }
}
