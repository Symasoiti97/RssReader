using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class User : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public RssChannel RssChannel { get; set; }
        public RssItem RssItem { get; set; }

        public ObservableCollection<Catalog> Catalogs { get; set; }
        public ObservableCollection<RssChannel> RssChannels { get; set; }
    }
}
