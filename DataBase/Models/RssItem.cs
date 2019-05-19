using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class RssItem : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }  
        [Required]
        public string Link { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime PubTime { get; set; }
   
        public int RssChannelId { get; set; }
        [ForeignKey("RssChannelId")]
        public RssChannel RssChannel { get; set; }

        public ICollection<UserFavoriteItem> UserFavoriteItems { get; set; }
    }
}
