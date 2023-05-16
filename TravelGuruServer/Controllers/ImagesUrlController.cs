using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.rImagesUrl;
using TravelGuruServer.Data.Dtos.rRecommendationUrl;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class ImagesUrlController : ControllerBase
    {
        private readonly IRouteRespositories _routesRepository;
        private readonly IRImagesUrlRepositories _rImagesUrlRepositories;

        public ImagesUrlController(IRouteRespositories routesRepository,IRImagesUrlRepositories rImagesUrlRepositories)
        {
            _routesRepository = routesRepository;
            _rImagesUrlRepositories = rImagesUrlRepositories;
        }


        [HttpGet]
        [Route("troutes/{trouteId}/imageurl")]
        public async Task<IEnumerable<ImagesUrlDto>> GetImagesUrls(int trouteId)
        {
            var imagesUrls = await _rImagesUrlRepositories.GetImagesAsync(trouteId);

            return imagesUrls.Select(o => new ImagesUrlDto(o.rImagesUrlId, o.rImagesUrlLink, o.TRouterouteId));
        }

        [HttpPost]
        [Route("troutes/{trouteId}/newimageurl")]
        public async Task<ActionResult<ImagesUrlDto>> Create(int trouteId, CreateImagesUrlDto createImagesUrlDto)
        {

            var route = await _routesRepository.GetRouteAsync(trouteId);
            if (route.UserId != User.FindFirstValue(JwtRegisteredClaimNames.Sub))
            {
                return NotFound("Only creator can add images for route");
            }
            if(createImagesUrlDto.rImagesUrlLink.Length < 5 ) { return BadRequest("Link is to short"); }

            var image = new RImagesUrl
            {
                rImagesUrlLink = createImagesUrlDto.rImagesUrlLink,
            };
            image.TRouterouteId = trouteId;
            await _rImagesUrlRepositories.CreateImageAsync(image);
            // 201
            return Created($"api/troutes/{trouteId}/newimageurl{image.TRouterouteId}", new ImagesUrlDto(image.rImagesUrlId, image.rImagesUrlLink, image.TRouterouteId));
        }
    }
}
