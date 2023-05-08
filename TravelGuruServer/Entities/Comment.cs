using System.ComponentModel.DataAnnotations;
using TravelGuruServer.Auth.Model;

namespace TravelGuruServer.Entities
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public string commentText { get; set; }
        public float commentRating { get; set; }
        public DateTime commentDate { get; set; }
        public int? TRouterouteId { get; set; }

        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public TravelUser User { get; set; }
    }
}
