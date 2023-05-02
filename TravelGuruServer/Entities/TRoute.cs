using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;
using TravelGuruServer.Entities;

namespace TravelGuruServer.Entities
{
    public class TRoute : IUserOwnedResource
    {
        [Key]
        public int routeId { get; set; }
        public string rName { get; set; }
        public string rOrigin { get; set; }
        public string rDestination { get; set; }
        public double rTripCost { get; set; } //TODO
        public float rRating { get; set; } //TODO
        public bool rIsPublished { get; set; } //TODO
        public string? rCountry { get; set; }

        public List<RImagesUrl>? rImagesUrl { get; set; }

        public List<RRecommendationUrl>? rRecommendationUrl { get; set; }


        public List<MidWaypoint>? MidWaypoint { get; set; }
        public List<TrouteSectionDescription>? TrouteSectionDescription { get; set; }
        public List<TroutePointDescription>? TroutePointDescription { get; set; }

        // Kiekvienas taskas turi galeti tureti papildomas taskus/zymejimus


        [Required]
        public string UserId { get; set; }
        public TravelUser User { get; set; }
    }
}



//public double rCost { get; set; } // extra
//public float rRating { get; set; }

//public string rType { get; set; }
