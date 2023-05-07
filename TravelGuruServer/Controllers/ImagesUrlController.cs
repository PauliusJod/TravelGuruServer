using Microsoft.AspNetCore.Mvc;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.rImagesUrl;
using TravelGuruServer.Data.Dtos.rRecommendationUrl;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class ImagesUrlController : ControllerBase
    {
        private readonly IRImagesUrlRepositories _rImagesUrlRepositories;

        public ImagesUrlController(IRImagesUrlRepositories rImagesUrlRepositories)
        {
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
