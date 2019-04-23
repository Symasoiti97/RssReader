using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class UserContent
    {
        public int Id { get; set; }
        [Required]
        public bool Favorite { get; set;}

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RssChanelId { get; set; }
        [ForeignKey("RssChanelId")]
        public RssChanel RssChanel { get; set; }

        public int RssItemId { get; set; }
        [ForeignKey("RssItemId")]
        public RssItem RssItem { get; set; }
    }
}
