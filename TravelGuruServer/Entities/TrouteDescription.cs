using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class TrouteDescription
    {
        [Key]
        public int routeDescId { get; set; }
        public int routeDescStopId { get; set; }
        public string? routeDescription { get; set; }


        [Required]
        public int TRouterouteId { get; set; }
    }
}
