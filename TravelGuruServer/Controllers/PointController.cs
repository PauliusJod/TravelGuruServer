using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using TravelGuruServer.Data.Dtos.Point;
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
        [Route("troutesprivate/{trouteId}/routepoints/{pointId}")]
        public async Task<ActionResult<PointPrivateDto>> GetPointDescription(int trouteId, int pointId)
        {
            var point = await _routePointRepositories.GetTroutePointPrivateAsync(trouteId, pointId);

            // 404
            if (point == null)
                return NotFound();

            return new PointPrivateDto(point.pointId, point.pointOnRouteId, point.routePointDescription, point.AddinionalPointMarks, point.TRoutePrivaterouteId);
        }

        [HttpGet]
        [Route("troutesprivate/{trouteId}/routepoints")]
        public async Task<IEnumerable<PointPrivateDto>> GetPointsDescriptions(int trouteId)
        {
            var points = await _routePointRepositories.GetTroutePointsPrivateAsync(trouteId);

            return points.Select(o => new PointPrivateDto(o.pointId, o.pointOnRouteId, o.routePointDescription, o.AddinionalPointMarks, o.TRoutePrivaterouteId));
        }



        [HttpPost]
        [Route("troutesprivate/{trouteId}/routepoints")]
        public async Task<ActionResult<PointPrivateDto>> Create(int trouteId, CreatePrivatePointDto createPrivatePointDto)
        {
            var point = new TroutePointDescription
            {
                pointOnRouteId = createPrivatePointDto.pointOnRouteId,
                routePointDescription = createPrivatePointDto.routePointDescription,
            };
            if (createPrivatePointDto.AddinionalPointMarks != null)
            {
                foreach (var item in createPrivatePointDto.AddinionalPointMarks)
                {
                    item.TroutePointDescriptionpointId = point.pointId;
                    await _additionalPointRepositories.CreatePointMarkAsync(item);
                }
            }
            point.TRoutePrivaterouteId = trouteId;
            await _routePointRepositories.CreatePrivateAsync(point);
            // 201
            return Created($"api/troutes/{trouteId}/routepoints{point.pointId}", new CreatePrivatePointDto(point.pointOnRouteId, point.routePointDescription, point.AddinionalPointMarks, point.TRoutePrivaterouteId));
        }

    }
}
