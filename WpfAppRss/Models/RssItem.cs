using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class RssItem : BaseViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }  
        public string Link { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime PubTime { get; set; }
    }
}
