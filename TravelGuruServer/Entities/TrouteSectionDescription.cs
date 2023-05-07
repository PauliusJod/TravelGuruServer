using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class TrouteSectionDescription
    {
        [Key]
        public int sectionId { get; set; }
        public int sectionOnRouteId { get; set; }
        public string routeSectionDescription { get; set; }


        public List<AdditionalPoints>? AddinionalSectionPoints { get; set; }

        public int? TRouterouteId { get; set; }
    }
}
