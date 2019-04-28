using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class RssItemsTitle : BaseViewModel
    {
        private string _rssItemTitleName;

        public string RssItemTitleName
        {
            get
            {
                return _rssItemTitleName;
            }
            set
            {
                _rssItemTitleName = value;
                OnPropertyChanged("RssItemTitleName");
            }
        }
    }
}
