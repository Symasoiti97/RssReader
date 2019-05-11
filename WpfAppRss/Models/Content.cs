using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfAppRss.ViewModels;
using DataBase.Models;

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
            RssChannel = new RssChannel();
            RssItem = new RssItem();
            RssChannels = new ObservableCollection<RssChannel>();
            RssChannel = new RssChannel();
            Catalogs = new ObservableCollection<Catalog>();
            RssItems = new ObservableCollection<RssItem>();
            RssItem.PubTime = new DateTime();

            User.Login = "user1";
            User.Password = "pass1";
        }

        public static Content GetInstance()
        {
            return _content;
        }

        public DataBase.Models.User User { get; set; }

        public Page ContentPage { get; set; }

        public RssItem RssItems_SelectValue;


        public RssChannel RssChannel { get; set; }
        public RssItem RssItem { get; set; }

        public ObservableCollection<Catalog> Catalogs { get; set; }
        public ObservableCollection<RssChannel> RssChannels { get; set; }
        public ObservableCollection<RssItem> RssItems { get; set; }
    }
}
