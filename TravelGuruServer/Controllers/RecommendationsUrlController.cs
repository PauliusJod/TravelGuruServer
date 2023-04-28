using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TravelGuruServer.Data.Dtos.MidWaypoints;
using TravelGuruServer.Data.Dtos.rImagesUrl;
using TravelGuruServer.Data.Dtos.rRecommendationUrl;
using TravelGuruServer.Entities;
using TravelGuruServer.Repositories;

namespace TravelGuruServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class RecommendationsUrlController : ControllerBase
    {
        private readonly IRRecommendationUrlRepositories _rRecommendationUrlRepositories;

        public RecommendationsUrlController(IRRecommendationUrlRepositories rRecommendationUrlRepositories)
        {
            _rRecommendationUrlRepositories = rRecommendationUrlRepositories;
        }

        [HttpGet]
        [Route("troutesprivate/{trouteId}/recommendationurl")]
        public async Task<IEnumerable<RecommendationPrivateDto>> GetRecommendationsUrls(int trouteId)
        {
            var recommendationsUrls = await _rRecommendationUrlRepositories.GetRecommendationsPrivateAsync(trouteId);

            return recommendationsUrls.Select(o => new RecommendationPrivateDto(o.rRecommendationUrlId, o.rRecommendationUrlLink, o.TRoutePrivaterouteId));
        }

        [HttpDelete]
        [Route("troutesprivate/{trouteId}/recommendationurl/{recomendationId}")]
        public async Task<ActionResult> Remove(int routeId,int recomendationId)
        {
            var recommendation = await _rRecommendationUrlRepositories.GetRecommendationPrivateAsync(recomendationId);

            // 404
            if (recommendation == null)
                return NotFound();
            await _rRecommendationUrlRepositories.DeleteRecommendationPrivateAsync(recommendation);

            // 204
            return NoContent();
        }



        //CreateRecommendationPrivateAsync
        [HttpPost]
        [Route("troutesprivate/{trouteId}/recommendationurl")]
        public async Task<ActionResult<RecommendationPrivateDto>> Create(int trouteId, CreatePrivateRecommendationDto createPrivateRecommendationDto)
        {
            var recommentation = new RRecommendationUrl
            {
                rRecommendationUrlLink = createPrivateRecommendationDto.rRecommendationUrlLink,
            };
            recommentation.TRoutePrivaterouteId = trouteId;
            await _rRecommendationUrlRepositories.CreateRecommendationPrivateAsync(recommentation);
            // 201
            return Created($"api/troutesprivate/{trouteId}/recommendationurl{recommentation.TRoutePrivaterouteId}", new RecommendationPrivateDto(recommentation.rRecommendationUrlId, recommentation.rRecommendationUrlLink, recommentation.TRoutePrivaterouteId));
        }
    }
}
