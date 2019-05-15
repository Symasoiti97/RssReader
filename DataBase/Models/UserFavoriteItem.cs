using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class UserFavoriteItem : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RssItemId { get; set; }
        [ForeignKey("RssItemId")]
        public RssItem RssItem { get; set; }
    }
}
