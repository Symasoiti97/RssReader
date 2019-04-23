using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class RssItem
    {
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

        public ICollection<UserContent> UserContents { get; set; }
    }
}
