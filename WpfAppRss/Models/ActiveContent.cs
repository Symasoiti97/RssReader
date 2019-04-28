using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class ActiveContent
    {
        private static ActiveContent _activeContent;

        public User User { get; set; }
        public ObservableCollection<RssItemTitle> RssItemTitles { get; set; }
        public RssItem RssItem { get; set; }
        public RssChanelTitle RssChanelTitle { get; set; }
        public RssItemTitle RssItemTitle { get; set; }
        public string Catalog { get; set; }

        private ActiveContent()
        {
            RssItem = new RssItem();
            User = new User();
            RssChanelTitle = new RssChanelTitle();
            RssItemTitle = new RssItemTitle();
            RssItemTitles = new ObservableCollection<RssItemTitle>();
        }

        public static ActiveContent GetInstance()
        {
            if (_activeContent == null)
            {
                _activeContent = new ActiveContent();
            }

            return _activeContent;
        }
    }
}