using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class TrouteSectionDescription
    {
        [Key]
        public int sectionId { get; set; }
        public int sectionOnRouteId { get; set; }
        public string routeSectionDescription { get; set; }


        [Required]
        public int TRouterouteId { get; set; }
    }
}
