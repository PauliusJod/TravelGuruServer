using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class RRecommendationUrl
    {
        [Key]
        public int rRecommendationUrlId { get; set; }
        public string rRecommendationUrlLink { get; set; }
        public int? TRouterouteId { get; set; }
    }
}
