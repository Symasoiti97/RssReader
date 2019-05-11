using System.Collections.ObjectModel;
using WpfAppRss.ViewModels;
using DataBase.Models;

namespace WpfAppRss.Models
{
    class Catalog : BaseViewModel
    {
        public ObservableCollection<RssChannel> RssChannels { get; set; }

        public string CatalogName { get; set; }
    }

}
