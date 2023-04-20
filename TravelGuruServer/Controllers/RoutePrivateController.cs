using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.TRoute.Private;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;


namespace TravelGuruServer.Controllers
{

    [ApiController]
    [Route("api/troutesprivate")]
    public class RoutePrivateController : ControllerBase
    {

        private readonly IRoutePrivateRespositories _routesPrivateRepository;
        //---
        private readonly IMidWaypointRepositories _midWaypointsRepository;
        private readonly IRouteSectionRepositories _routeSectionRepositories;
        private readonly IRoutePointRepositories _routePointRepositories;

        //private readonly IAuthorizationService _authorizationService;

        public RoutePrivateController(IRoutePrivateRespositories routesPrivateRepository, IMidWaypointRepositories midWaypointsRepository, IRouteSectionRepositories routeSectionRepositories, IRoutePointRepositories routePointRepositories)
        {
            _routesPrivateRepository = routesPrivateRepository;
            _midWaypointsRepository = midWaypointsRepository;
            _routeSectionRepositories = routeSectionRepositories;
            _routePointRepositories = routePointRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTRoutesPrivateDto>> GetPrivateTRoutes()
        {
            var routes = await _routesPrivateRepository.GetPrivateRoutesAsync();

            return routes.Select(o => new GetTRoutesPrivateDto(o.routeId, o.rName, o.rOrigin, o.rDestination));
        }
        [HttpGet]
        [Route("usercreated/{userId}")]
        public async Task<IEnumerable<GetTRoutesPrivateDto>> GetUserCreatedPrivateTRoutes(string userId)
        {
            //string UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            Console.WriteLine(userId);
            var routes = await _routesPrivateRepository.GetUserCreatedPrivateRoutesAsync(userId);

            return routes.Select(o => new GetTRoutesPrivateDto(o.routeId, o.rName, o.rOrigin, o.rDestination));
        }
        [HttpGet]
        [Route("{routeId}")]
        public async Task<ActionResult<TRoutePrivateDto>> GetPrivateTRoute(int routeId)
        {
            var route = await _routesPrivateRepository.GetPrivateRouteAsync(routeId);

            // 404
            if (route == null)
                return NotFound();

            return new TRoutePrivateDto(route.routeId,route.rName, route.rOrigin, route.rDestination, route.UserId); //, route.rMidWaypoints
        }
        [HttpPost]
        public async Task<ActionResult<TRoutePrivateDto>> CreatePrivate(CreateTRoutePrivateDto createTRoutePrivateDto)
        {
            var privateRoute = new TRoutePrivate
            {
                rName= createTRoutePrivateDto.rName,
                rOrigin = createTRoutePrivateDto.rOrigin,
                rDestination = createTRoutePrivateDto.rDestination,
                rCountry = createTRoutePrivateDto.rCountry,
                rImagesUrl = createTRoutePrivateDto.rImagesUrl,
                rRecommendationUrl = createTRoutePrivateDto.rRecommendationUrl,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            await _routesPrivateRepository.CreatePrivateAsync(privateRoute);
            if (createTRoutePrivateDto.midWaypoints != null)
            {
                foreach (var item in createTRoutePrivateDto.midWaypoints)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _midWaypointsRepository.CreateAsync(item);
                }
            }
            if (createTRoutePrivateDto.sectionDescriptions != null)
            {
                foreach (var item in createTRoutePrivateDto.sectionDescriptions)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _routeSectionRepositories.CreatePrivateAsync(item);
                }
            }
            if(createTRoutePrivateDto.pointDescriptions != null)
            {
                foreach (var item in createTRoutePrivateDto.pointDescriptions)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _routePointRepositories.CreatePrivateAsync(item);
                }
            }

            // 201
            return Created($"api/troutes/{privateRoute.routeId}", new GetTRoutePrivateDto(privateRoute.rName, privateRoute.rOrigin, privateRoute.rDestination)); //, route.rMidWaypoints,
        }

    }
}
