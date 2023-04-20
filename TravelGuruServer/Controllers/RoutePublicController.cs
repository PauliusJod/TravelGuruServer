using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.TRoute.Private;
using TravelGuruServer.Data.Dtos.TRoute.Public;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;


namespace TravelGuruServer.Controllers
{


    [ApiController]
    [Route("api/troutespublic")]
    public class RoutePublicController : ControllerBase
    {

        private readonly IRoutePublicRespositories _routesPublicRepository;
        private readonly IMidWaypointRepositories _midWaypointsRepository;
        private readonly IRouteSectionRepositories _routeSectionRepositories;
        private readonly IRoutePointRepositories _routePointRepositories;

        //private readonly IAuthorizationService _authorizationService;

        public RoutePublicController(IRoutePublicRespositories routesPublicRepository, IMidWaypointRepositories midWaypointsRepository, IRouteSectionRepositories routeSectionRepositories, IRoutePointRepositories routePointRepositories)
        {
            _routesPublicRepository = routesPublicRepository;
            _midWaypointsRepository = midWaypointsRepository;
            _routeSectionRepositories = routeSectionRepositories;
            _routePointRepositories = routePointRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTRoutesPublicDto>> GetTRoutes()
        {
            var routes = await _routesPublicRepository.GetPublicRoutesAsync();

            return routes.Select(o => new GetTRoutesPublicDto(o.routeId, o.rName, o.rOrigin, o.rDestination));
        }
        [HttpGet]
        [Route("usercreated/{userId}")]
        public async Task<IEnumerable<GetTRoutesPublicDto>> GetUserCreatedTRoutes(string userId)
        {
            //string UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            Console.WriteLine(userId);
            var routes = await _routesPublicRepository.GetUserCreatedPublicRoutesAsync(userId);

            return routes.Select(o => new GetTRoutesPublicDto(o.routeId, o.rName, o.rOrigin, o.rDestination));
        }
        [HttpGet]
        [Route("{routeId}")]
        public async Task<ActionResult<TRoutePublicDto>> GetTRoute(int routeId)
        {
            var route = await _routesPublicRepository.GetPublicRouteAsync(routeId);

            // 404
            if (route == null)
                return NotFound();

            return new TRoutePublicDto(route.routeId,route.rName, route.rOrigin, route.rDestination, route.UserId); //, route.rMidWaypoints
        }
        [HttpPost]
        public async Task<ActionResult<TRoutePublicDto>> Create(CreateTRoutePublicDto createTRoutePublicDto)
        {
            var route = new TRoutePublic
            {
                rName= createTRoutePublicDto.rName,
                rOrigin = createTRoutePublicDto.rOrigin,
                rDestination = createTRoutePublicDto.rDestination,



                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            await _routesPublicRepository.CreatePublicAsync(route);
            if (createTRoutePublicDto.midWaypoints != null)
            {
                foreach (var item in createTRoutePublicDto.midWaypoints)
                {
                    item.TRoutePublicrouteId = route.routeId;
                    await _midWaypointsRepository.CreatePublicAsync(item);
                }
            }
            if (createTRoutePublicDto.sectionDescriptions != null)
            {
                foreach (var item in createTRoutePublicDto.sectionDescriptions)
                {
                    item.TRoutePublicrouteId = route.routeId;
                    await _routeSectionRepositories.CreatePublicAsync(item);
                }
            }
            if(createTRoutePublicDto.pointDescriptions != null)
            {
                foreach (var item in createTRoutePublicDto.pointDescriptions)
                {
                    item.TRoutePublicrouteId = route.routeId;
                    await _routePointRepositories.CreatePublicAsync(item);
                }
            }

            // 201
            return Created($"api/troutes/{route.routeId}", new GetTRoutePublicDto(route.rName, route.rOrigin, route.rDestination)); //, route.rMidWaypoints,
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
