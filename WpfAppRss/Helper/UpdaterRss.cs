using DataBase;
using Parsers.ParserRss;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppRss.Models;
using DataBase.Models;

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

            List<string> catalogsTitle = _operationDataBase.GetCatologsRssChannels(login).Distinct().ToList();

            for (int i = 0; i < catalogsTitle.Count; i++)
            {
                Catalog catalog = new Catalog();
                catalog.CatalogName = catalogsTitle[i];

                ObservableCollection<RssChannel> rssChannels = new ObservableCollection<RssChannel>();

                ICollection<RssChannel> selectRssChannels = _operationDataBase.GetRssChannels(login, catalogsTitle[i]);

                foreach(var rc in selectRssChannels)
                {
                    rssChannels.Add(rc);
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

        public static void RemoveUserContentAndUpdate(string login, string title)
        {
            _operationDataBase.RemoveUserContent(login, title);
            UpdateTreeViewChannels(login);
        }
    }
}
