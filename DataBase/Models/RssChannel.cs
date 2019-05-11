using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class RssChannel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Link { get; set; }

        public ICollection<RssItem> RssItems { get; set; }

        public ICollection<UserContent> UserContents { get; set; }
    }
}
