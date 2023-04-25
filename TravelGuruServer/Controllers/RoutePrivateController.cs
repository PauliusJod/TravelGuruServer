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
        private readonly IRImagesUrlRepositories _rImagesUrlRepositories;
        private readonly IRRecommendationUrlRepositories _rRecommendationUrlRepositories;

        //private readonly IAuthorizationService _authorizationService;

        public RoutePrivateController(IRoutePrivateRespositories routesPrivateRepository, IMidWaypointRepositories midWaypointsRepository, IRouteSectionRepositories routeSectionRepositories, IRoutePointRepositories routePointRepositories, IRImagesUrlRepositories rImagesUrlRepositories, IRRecommendationUrlRepositories rRecommendationUrlRepositories)
        {
            _routesPrivateRepository = routesPrivateRepository;
            _midWaypointsRepository = midWaypointsRepository;
            _routeSectionRepositories = routeSectionRepositories;
            _routePointRepositories = routePointRepositories;
            _rImagesUrlRepositories= rImagesUrlRepositories;
            _rRecommendationUrlRepositories = rRecommendationUrlRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTRoutesPrivateDto>> GetPrivateTRoutes()
        {
            var routes = await _routesPrivateRepository.GetPrivateRoutesAsync();

            return routes.Select(o => new GetTRoutesPrivateDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rCountry, o.rImagesUrl, o.rRecommendationUrl));
        }
        [HttpGet]
        [Route("usercreated/{userId}")]
        public async Task<IEnumerable<GetTRoutesPrivateDto>> GetUserCreatedPrivateTRoutes(string userId)
        {
            //string UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            Console.WriteLine(userId);
            var routes = await _routesPrivateRepository.GetUserCreatedPrivateRoutesAsync(userId);

            return routes.Select(o => new GetTRoutesPrivateDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rCountry, o.rImagesUrl, o.rRecommendationUrl));
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
                //rImagesUrl = createTRoutePrivateDto.rImagesUrl,
                //rRecommendationUrl = createTRoutePrivateDto.rRecommendationUrl,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            await _routesPrivateRepository.CreatePrivateAsync(privateRoute);

            if (createTRoutePrivateDto.rImagesUrl != null)
            {
                foreach (var item in createTRoutePrivateDto.rImagesUrl)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _rImagesUrlRepositories.CreateImageAsync(item);
                }
            }

            if (createTRoutePrivateDto.rRecommendationUrl != null)
            {
                foreach (var item in createTRoutePrivateDto.rRecommendationUrl)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _rRecommendationUrlRepositories.CreateRecommendationAsync(item);
                }
            }
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
            if (createTRoutePrivateDto.pointDescriptions != null)
            {
                foreach (var item in createTRoutePrivateDto.pointDescriptions)
                {
                    item.TRoutePrivaterouteId = privateRoute.routeId;
                    await _routePointRepositories.CreatePrivateAsync(item);
                }
            }

            // 201
            return Created($"api/troutesprivate/{privateRoute.routeId}", new GetFullTRoutePrivateDto(privateRoute.rName, privateRoute.rOrigin, privateRoute.rDestination, privateRoute.rCountry, privateRoute.rImagesUrl, privateRoute.rRecommendationUrl, privateRoute.MidWaypoint, privateRoute.TrouteSectionDescription, privateRoute.TroutePointDescription)); //, route.rMidWaypoints,
        }

    }
}
