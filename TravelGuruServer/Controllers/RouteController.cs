using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.TRoute;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;


namespace TravelGuruServer.Controllers
{


    [ApiController]
    [Route("api/troutes")]
    public class RouteController : ControllerBase
    {

        private readonly IRouteRespositories _routesRepository;
        private readonly IMidWaypointRepositories _midWaypointsRepository;
        private readonly IRouteSectionRepositories _routeSectionRepositories;
        private readonly IRoutePointRepositories _routePointRepositories;

        //private readonly IAuthorizationService _authorizationService;

        public RouteController(IRouteRespositories routesRepository, IMidWaypointRepositories midWaypointsRepository, IRouteSectionRepositories routeSectionRepositories, IRoutePointRepositories routePointRepositories)
        {
            _routesRepository = routesRepository;
            _midWaypointsRepository = midWaypointsRepository;
            _routeSectionRepositories = routeSectionRepositories;
            _routePointRepositories = routePointRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTRoutesDto>> GetTRoutes()
        {
            var routes = await _routesRepository.GetRoutesAsync();

            return routes.Select(o => new GetTRoutesDto(o.routeId, o.rName, o.rOrigin, o.rDestination));
        }

        [HttpGet]
        [Route("{routeId}")]
        public async Task<ActionResult<TRouteDto>> GetTRoute(int routeId)
        {
            var route = await _routesRepository.GetRouteAsync(routeId);

            // 404
            if (route == null)
                return NotFound();

            return new TRouteDto(route.routeId,route.rName, route.rOrigin, route.rDestination, route.UserId); //, route.rMidWaypoints
        }
        [HttpPost]
        public async Task<ActionResult<TRouteDto>> Create(CreateTRouteDto createTRouteDto)
        {
            var route = new TRoute
            {
                rName= createTRouteDto.rName,
                rOrigin = createTRouteDto.rOrigin,
                //rMidWaypoints = createTRouteDto.rMidWaypoints,
                rDestination = createTRouteDto.rDestination,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            await _routesRepository.CreateAsync(route);
            if (createTRouteDto.midWaypoints != null)
            {
                foreach (var item in createTRouteDto.midWaypoints)
                {
                    item.TRouterouteId = route.routeId;
                    await _midWaypointsRepository.CreateAsync(item);
                }
            }
            if (createTRouteDto.sectionDescriptions != null)
            {
                foreach (var item in createTRouteDto.sectionDescriptions)
                {
                    item.TRouterouteId = route.routeId;
                    await _routeSectionRepositories.CreateAsync(item);
                }
            }
            if(createTRouteDto.pointDescriptions != null)
            {
                foreach (var item in createTRouteDto.pointDescriptions)
                {
                    item.TRouterouteId = route.routeId;
                    await _routePointRepositories.CreateAsync(item);
                }
            }

            // 201
            return Created($"api/troutes/{route.routeId}", new GetTRouteDto(route.rName, route.rOrigin, route.rDestination)); //, route.rMidWaypoints,
        }
        //[HttpPut]
        //[Route("{routeId}")]
        //public async Task<ActionResult<RouteDtos>> Update(int cityId, UpdateCityDto updateCityDto)
        //{
        //    var city = await _citiesRepository.GetCityAsync(cityId);


        //    if (city == null)
        //        return NotFound($"ERROR user {cityId}");

        //    city.cityName = updateCityDto.CityName;
        //    await _citiesRepository.UpdateAsync(city);

        //    return Ok(new CityDto(city.cityId, city.cityName, city.UserId));
        //}
        //[HttpDelete]
        //[Route("{routeId}")]
        //public async Task<ActionResult> Remove(int cityId)
        //{
        //    var city = await _citiesRepository.GetCityAsync(cityId);

        //    // 404
        //    if (city == null)
        //        return NotFound();
        //    await _citiesRepository.DeleteAsync(city);

        //    // 204
        //    return NoContent();
        //}
    }
}
