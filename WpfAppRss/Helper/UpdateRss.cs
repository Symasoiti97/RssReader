using DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.Models;

namespace WpfAppRss.Helper
{
    static class UpdateRss
    {
        private static OperationDataBase _operationDataBase;

        static UpdateRss()
        {
            _operationDataBase = OperationDataBase.GetInstance();
        }

        public static ObservableCollection<Catalog> UpdateChannels(string login)
        {
            ObservableCollection<Catalog> catalogs = new ObservableCollection<Catalog>();

            List<string> catalogsTitle = _operationDataBase.FindRssChannelCategory(login).Distinct().ToList();

            for (int i = 0; i < catalogsTitle.Count; i++)
            {
                Catalog catalog = new Catalog();
                catalog.CatalogName = catalogsTitle[i];

                ObservableCollection<RssChannel> rssChannels = new ObservableCollection<RssChannel>();

                List<string> listChannelsTitles = _operationDataBase.FindRssChanelTitels(login, catalogsTitle[i]).ToList();

                for (int j = 0; j < listChannelsTitles.Count; j++)
                {
                    rssChannels.Add(new RssChannel { Title = listChannelsTitles[j] });
                }

                catalog.RssChannels = rssChannels;

                catalogs.Add(catalog);
            }

            return catalogs;
        }
    }
}
