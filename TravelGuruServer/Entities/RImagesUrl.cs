using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class RImagesUrl
    {
        [Key]
        public int rImagesUrlId { get; set; }
        public string rImagesUrlLink { get; set; }

        //[Required]
        public int? TRoutePrivaterouteId { get; set; }
        public int? TRoutePublicrouteId { get; set; }
    }
}
