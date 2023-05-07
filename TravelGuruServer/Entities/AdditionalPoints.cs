using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class AdditionalPoints
    {

        [Key]
        public int additionalPointId { get; set; }
        public int additionalPointRouteId { get; set; }
        public int additionalPointIdInList { get; set; }
        public float additionalPointCoordX { get; set; }
        public float additionalPointCoordY { get; set; }
        public string? additionalPointInformation { get; set; }
        public string? additionalPointPlaceName { get; set; }
        public string? additionalPointPlaceId { get; set; }
        public double? additionalPointPlaceRating { get; set; }
        public string? additionalPointPlaceType { get; set; }
        public string? additionalPointPlaceRefToMaps { get; set; }


        public int? TroutePointDescriptionpointId { get; set; }
        public int? TrouteSectionDescriptionsectionId { get; set; }

    }
}
