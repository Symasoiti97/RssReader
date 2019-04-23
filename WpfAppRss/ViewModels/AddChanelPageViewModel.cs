using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppRss.ViewModels
{
    class AddChanelPageViewModel : BaseViewModel
    {
        private string _rssLink;
        private string _catalog;

        public AddChanelPageViewModel()
        {

        }

        public string RssLinkText
        {
            get
            {
                return _rssLink;
            }
            set
            {
                _rssLink = value;
                OnPropertyChanged("RssLinkText");
            }
        }

        public string CatalogText
        {
            get
            {
                return _catalog;
            }
            set
            {
                _catalog = value;
                OnPropertyChanged("CatalogText");
            }
        }
    }
}
