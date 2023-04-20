using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;

namespace TravelGuruServer.Entities
{
    public class TRoutePrivate :IUserOwnedResource
    {
        [Key]
        public int routeId { get; set; }
        public string rName { get; set; }
        public string rOrigin { get; set; }
        public string rDestination { get; set; }

        public string? rCountry { get; set; }

        public string? rImagesUrl { get; set; }

        public string? rRecommendationUrl { get; set; }


        public List<MidWaypoint>? MidWaypoint { get; set; }
        public List<TrouteSectionDescription>? TrouteSectionDescription { get; set; }
        public List<TroutePointDescription>? TroutePointDescription { get; set; }

        // Kiekvienas taskas turi galeti tureti papildomas taskus/zymejimus


        [Required]
        public string UserId { get; set; }
        public TravelUser User { get; set; }
    }
}
