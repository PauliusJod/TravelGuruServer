using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;

namespace TravelGuruServer.Entities
{
    public class TRoute : IUserOwnedResource
    {
        [Key]
        public int routeId { get; set; }
        public string rOrigin { get; set; }
        public string rDestination { get; set; }

        public List<MidWaypoint>? MidWaypoint { get; set; }

        [Required]
        public string UserId { get; set; }
        public TravelUser User { get; set; }
    }
}
