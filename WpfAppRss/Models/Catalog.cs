using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class Catalog : BaseViewModel
    {
        public ObservableCollection<RssChannel> RssChannels { get; set; }

        public string CatalogName { get; set; }
    }

}
