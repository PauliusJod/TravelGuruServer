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

        // Kiekvienas taskas turi galeti tureti papildomas taskus/zymejimus

        //[Required]
        //public int TRouterouteId { get; set; }
        public int? TRoutePrivaterouteId { get; set; }
        public int? TRoutePublicrouteId { get; set; }

    }
}
