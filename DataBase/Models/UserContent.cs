using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class UserContent
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RssChannelId { get; set; }
        [ForeignKey("RssChannelId")]
        public RssChannel RssChannel { get; set; }
    }
}
