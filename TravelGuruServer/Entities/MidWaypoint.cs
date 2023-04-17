using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;

namespace TravelGuruServer.Entities
{
    public class MidWaypoint
    {

        [Key]
        public int midWaypointId { get; set; }
        public string? midWaypointLocation { get; set; }
        public bool midWaypointStopover { get; set; }


        [Required]
        public int TRouterouteId { get; set; }

    }
}
