using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class TroutePointDescription
    {

        [Key]
        public int pointId { get; set; }
        public int pointOnRouteId { get; set; }
        public string routePointDescription { get; set; }


        [Required]
        public int TRouterouteId { get; set; }
    }
}
