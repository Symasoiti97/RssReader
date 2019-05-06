using DataBase;
using Parsers.ParserRss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.Models;

namespace WpfAppRss.Helper
{
    static class UpdaterRss
    {
        private static OperationDataBase _operationDataBase;

        static UpdaterRss()
        {
            _operationDataBase = OperationDataBase.GetInstance();
        }

        public static ObservableCollection<Catalog> UpdateTreeViewChannels(string login)
        {
            ObservableCollection<Catalog> catalogs = new ObservableCollection<Catalog>();

            Catalog catalogf = new Catalog
            {
                CatalogName = "Favorite"
            };

            catalogs.Add(catalogf);

            List<string> catalogsTitle = _operationDataBase.FindRssChannelCategory(login).Distinct().ToList();

            for (int i = 0; i < catalogsTitle.Count; i++)
            {
                Catalog catalog = new Catalog();
                catalog.CatalogName = catalogsTitle[i];

                ObservableCollection<RssChannel> rssChannels = new ObservableCollection<RssChannel>();

                List<string> listChannelsTitles = _operationDataBase.GetRssChanelTitels(login, catalogsTitle[i]).ToList();

                for (int j = 0; j < listChannelsTitles.Count; j++)
                {
                    rssChannels.Add(new RssChannel { Title = listChannelsTitles[j] });
                }

                catalog.RssChannels = rssChannels;

                catalogs.Add(catalog);
            }

            return catalogs;
        }

        public static ObservableCollection<Catalog> AddChannelDataBase(string url, string catalog, string login)
        {
            var rssChannel = RssLoader.ParserRss(url);
            rssChannel.Link = url;

            if (catalog == "" || catalog == null) catalog = "Different";

            _operationDataBase.AddUserContent(login, rssChannel, catalog);

            return UpdaterRss.UpdateTreeViewChannels(login);
        }

        public static void UpdateRssChannelsDateBase(User user)
        {
            List<string> listUrl = _operationDataBase.GetCurrentListUrlChannels(user.Login);

            foreach (var url in listUrl)
            {
                var rssChannel = RssLoader.ParserRss(url);
                rssChannel.Link = url;

                _operationDataBase.UpdateUserContent(user.Login, rssChannel);
            }
        }
    }
}
