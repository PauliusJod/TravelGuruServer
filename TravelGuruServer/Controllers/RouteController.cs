using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using TravelGuruServer.Auth.Model;
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
        //---
        private readonly IMidWaypointRepositories _midWaypointsRepository;
        private readonly IRouteSectionRepositories _routeSectionRepositories;
        private readonly IRoutePointRepositories _routePointRepositories;
        private readonly IRImagesUrlRepositories _rImagesUrlRepositories;
        private readonly IRRecommendationUrlRepositories _rRecommendationUrlRepositories;
        private readonly IAdditionalPointRepositories _additionalPointRepositories;

        private readonly UserManager<TravelUser> _userManager;
        //private readonly IAuthorizationService _authorizationService;

        public RouteController(UserManager<TravelUser> userManager,IRouteRespositories routesRepository, IMidWaypointRepositories midWaypointsRepository, IRouteSectionRepositories routeSectionRepositories, IRoutePointRepositories routePointRepositories, IRImagesUrlRepositories rImagesUrlRepositories, IRRecommendationUrlRepositories rRecommendationUrlRepositories, IAdditionalPointRepositories additionalPointRepositories)
        {
            _userManager = userManager;
            _routesRepository = routesRepository;
            _midWaypointsRepository = midWaypointsRepository;
            _routeSectionRepositories = routeSectionRepositories;
            _routePointRepositories = routePointRepositories;
            _rImagesUrlRepositories= rImagesUrlRepositories;
            _rRecommendationUrlRepositories = rRecommendationUrlRepositories;
            _additionalPointRepositories = additionalPointRepositories;
        }


        [HttpGet]
        [Route("public")]
        public async Task<IEnumerable<GetTRoutesDto>> GetPublicTRoutes()
        {
            //IEnumerable
            var routes = await _routesRepository.GetPublicRoutesAsync();

            //// 404
            //if (routes == null)
            //    return NotFound();

            foreach (var item in routes)
            {
                var images = await _rImagesUrlRepositories.GetImagesAsync(item.routeId);
                item.rImagesUrl = images;
            }

            return routes.Select(o => new GetTRoutesDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rTripCost, o.rRating, o.rIsPublished, o.rCountry, o.rImagesUrl, o.rRecommendationUrl));
        }

        //[HttpGet]
        //public async Task<IEnumerable<GetTRoutesDto>> GetPrivateTRoutes()
        //{
        //    var routes = await _routesRepository.GetRoutesAsync();

        //    return routes.Select(o => new GetTRoutesDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rTripCost, o.rRating, o.rIsPublished, o.rCountry, o.rImagesUrl, o.rRecommendationUrl));
        //}
        [HttpGet]
        [Route("usercreated/{userId}")]
        public async Task<IEnumerable<GetTRoutesDto>> GetUserCreatedPrivateTRoutes(string userId)
        {
            //string UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            Console.WriteLine(userId);
            var routes = await _routesRepository.GetUserCreatedRoutesAsync(userId);

            return routes.Select(o => new GetTRoutesDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rTripCost, o.rRating, o.rIsPublished, o.rCountry, o.rImagesUrl, o.rRecommendationUrl));
        }

        //[HttpGet]
        //[Route("usercreated/{userId}")]
        //public async Task<IActionResult> GetUserCreatedPrivateTRoutes(string userId)
        //{

        //    if(userId != User.FindFirstValue(JwtRegisteredClaimNames.Sub))
        //    {
        //        return Unauthorized();
        //    }
        //    var userValid = await _userManager.FindByIdAsync(userId);
        //    if (userValid == null)
        //    {
        //        return NotFound("User was not found");
        //    }
        //    var routes = await _routesRepository.GetUserCreatedRoutesAsync(userId);
        //    if (routes.Count == 0) return NotFound($"User have zero routes created");

        //    return Ok(routes.Select(o => new GetTRoutesDto(o.routeId, o.rName, o.rOrigin, o.rDestination, o.rTripCost, o.rRating, o.rIsPublished, o.rCountry, o.rImagesUrl, o.rRecommendationUrl)));
        //}
        [HttpGet]
        [Route("{routeId}")]
        public async Task<ActionResult<TRouteDto>> GetPrivateTRoute(int routeId)
        {
            var route = await _routesRepository.GetRouteAsync(routeId);

            // 404
            if (route == null)
                return NotFound();

            return new TRouteDto(route.routeId,route.rName, route.rOrigin, route.rDestination, route.rTripCost, route.rRating, route.rIsPublished, route.UserId); //, route.rMidWaypoints
        }
        [HttpPost]
        public async Task<ActionResult<TRouteDto>> CreatePrivate(CreateTRouteDto createTRouteDto)
        {
            var route = new TRoute
            {
                rName= createTRouteDto.rName,
                rOrigin = createTRouteDto.rOrigin,
                rDestination = createTRouteDto.rDestination,
                rTripCost = createTRouteDto.rTripCost,
                rRating = createTRouteDto.rRating,
                rIsPublished = createTRouteDto.rIsPublished,
                rCountry = createTRouteDto.rCountry,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };
            await _routesRepository.CreateAsync(route);

            if (createTRouteDto.rImagesUrl != null)
            {
                foreach (var item in createTRouteDto.rImagesUrl)
                {
                    item.TRouterouteId = route.routeId;
                    await _rImagesUrlRepositories.CreateImageAsync(item);
                }
            }

            if (createTRouteDto.rRecommendationUrl != null)
            {
                foreach (var item in createTRouteDto.rRecommendationUrl)
                {
                    item.TRouterouteId = route.routeId;
                    await _rRecommendationUrlRepositories.CreateRecommendationAsync(item);
                }
            }
            if (createTRouteDto.midWaypoints != null)
            {
                foreach (var item in createTRouteDto.midWaypoints)
                {
                    item.TRouterouteId = route.routeId;
                    await _midWaypointsRepository.CreateAsync(item);
                }
            }
            //if (createTRouteDto.sectionDescriptions != null)
            //{
            //    foreach (var item in createTRouteDto.sectionDescriptions)
            //    {
            //        item.TRouterouteId = route.routeId;
            //        await _routeSectionRepositories.CreateAsync(item);
            //    }
            //}
            if (createTRouteDto.pointDescriptions != null)
            {
                foreach (var item in createTRouteDto.pointDescriptions)
                {
                    item.TRouterouteId = route.routeId;
                    await _routePointRepositories.CreateAsync(item);
                }
            }

            // 201
            return Created($"api/troutes/{route.routeId}", new GetFullTRouteDto(route.rName, route.rOrigin, route.rDestination, route.rTripCost, route.rRating, route.rIsPublished, route.rCountry, route.rImagesUrl, route.rRecommendationUrl, route.MidWaypoint, route.TrouteSectionDescription, route.TroutePointDescription)); //, route.rMidWaypoints,
        }

        [HttpPut]
        [Route("{routeId}")] // UPDATE'int tik tą kurį išsitraukei iš DUOMENŲ BAZĖS!!!
        public async Task<ActionResult<TRouteDto>> Update(int routeId, UpdateTRouteDto updateTRouteDto)
        {
            var route = await _routesRepository.GetRouteAsync(routeId);

            if (route == null)
                return NotFound($"ERROR with routeId: {routeId}");

            if (updateTRouteDto.additionalMarkers != null && updateTRouteDto.additionalMarkers.Count > 0)
            {
                for (int i = 0; i < updateTRouteDto.additionalMarkers.Count; i++)
                {
                    if(updateTRouteDto.additionalMarkers[i].Count > 0)
                    {
                        foreach (var item in updateTRouteDto.additionalMarkers[i])
                        {
                            //item.additionalPointRouteId = route.routeId;
                            var additionalPoint = await _additionalPointRepositories.GetAdditionalPointMarkAsync(item.additionalPointRouteId, item.TroutePointDescriptionpointId, item.additionalPointIdInList);

                            if (additionalPoint == null)
                            {
                                /*item.TroutePointDescriptionpointId = updateTRoutePrivateDto.pointDescriptions[i].pointId;*/
                                await _additionalPointRepositories.CreatePointAdditionalMarkAsync(item);
                            }
                            else if (additionalPoint == item && additionalPoint != null)
                            {

                                additionalPoint.additionalPointInformation = item.additionalPointInformation;
                                Console.WriteLine(additionalPoint);
                            }
                            else if (additionalPoint != null && additionalPoint.additionalPointRouteId == item.additionalPointRouteId && additionalPoint.TroutePointDescriptionpointId == item.TroutePointDescriptionpointId && additionalPoint.additionalPointIdInList == item.additionalPointIdInList)
                            {
                                additionalPoint.additionalPointCoordX = item.additionalPointCoordX;
                                additionalPoint.additionalPointCoordY = item.additionalPointCoordY;

                                if (item.additionalPointInformation != null && item.additionalPointInformation != "") { additionalPoint.additionalPointInformation = item.additionalPointInformation; }

                                await _additionalPointRepositories.UpdateAdditionalPointMarkAsync(additionalPoint);
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                    }
                }
            }

            route.rTripCost = updateTRouteDto.rTripCost;
            route.rRating = updateTRouteDto.rRating;
            route.rIsPublished = updateTRouteDto.rIsPublished;
            route.rCountry = updateTRouteDto.rCountry;
            await _routesRepository.UpdateAsync(route);

            return Ok(new TRouteDto(route.routeId, route.rName, route.rOrigin, route.rDestination, route.rTripCost, route.rRating, route.rIsPublished, route.UserId));
        }
        [HttpPut]
        [Route("{routeId}/publish")] 
        public async Task<ActionResult<TRouteDto>> UpdatePublish(int routeId, UpdateTRoutePublishDto updateTRoutePublishDto)
        {
            var route = await _routesRepository.GetRouteAsync(routeId);

            if (route == null)
                return NotFound($"ERROR with routeId: {routeId}");

            route.rIsPublished = updateTRoutePublishDto.rIsPublished;

            await _routesRepository.UpdateAsync(route);

            return Ok(new TRouteDto(route.routeId, route.rName, route.rOrigin, route.rDestination, route.rTripCost, route.rRating, route.rIsPublished, route.UserId));
        }

    }
}
