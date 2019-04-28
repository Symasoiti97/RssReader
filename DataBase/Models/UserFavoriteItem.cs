using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class UserFavoriteItem
    {
        public int Id { get; set; }

        public int RssItemId { get; set; }
        [ForeignKey("RssItemId")]
        public RssItem RssItem { get; set; }
    }
}
