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
        public string Category { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int RssChanelId { get; set; }
        [ForeignKey("RssChanelId")]
        public RssChannel RssChannel { get; set; }
    }
}
