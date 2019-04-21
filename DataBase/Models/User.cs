using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<RssChanel> RssChanels { get; set; }
        public List<RssItem> RssItemsFavorite { get; set; }
    }
}
