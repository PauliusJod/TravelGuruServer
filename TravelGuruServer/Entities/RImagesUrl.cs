﻿using System.ComponentModel.DataAnnotations;

namespace TravelGuruServer.Entities
{
    public class RImagesUrl
    {
        [Key]
        public int rImagesUrlId { get; set; }
        public string rImagesUrlLink { get; set; }
        public int? TRouterouteId { get; set; }
    }
}
