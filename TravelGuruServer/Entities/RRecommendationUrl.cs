using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class RRecommendationUrl
    {
        [Key]
        public int rRecommendationUrlId { get; set; }
        public string rRecommendationUrlLink { get; set; }

        //[Required]
        public int? TRoutePrivaterouteId { get; set; }
        public int? TRoutePublicrouteId { get; set; }
    }
}
