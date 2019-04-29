using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class Content : BaseViewModel
    {
        private static Content _content;

        static Content()
        {
            _content = new Content();      
        }

        private Content()
        {
            User = new User();
            User.RssChannel = new RssChannel();
            User.RssItem = new RssItem();
            User.RssChannels = new ObservableCollection<RssChannel>();
            User.RssChannel = new RssChannel();
            User.Catalogs = new ObservableCollection<Catalog>();
            User.RssChannel.RssItems = new ObservableCollection<RssItem>();
            User.RssItem.PubTime = new DateTime();

            User.Login = "user1";
            User.Password = "pass1";
        }

        public static Content GetInstance()
        {
            return _content;
        }

        public User User { get; set; }

        public string RssItems_SelectValue { get; set; }
    }
}
