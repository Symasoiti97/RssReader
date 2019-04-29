using DataBase;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly Page _settingPage;
        private readonly Page _addChanelPage;
        private readonly Page _currentRssItemPage;

        public Content CurrentContent { get; set; }
        private OperationDataBase _operationDataBase;

        public MainWindowViewModel()
        {
            _operationDataBase = OperationDataBase.GetInstance();

            _currentRssItemPage = new Pages.RssItemPage();
            _addChanelPage = new Pages.AddChanelPage();

            CurrentContent = Content.GetInstance();

            UpdateChannels();
        }



        public ICommand<TreeView> TreeView_SelectedItem
        {
            get
            {
                return new DelegateCommand<TreeView>((item) =>
                {
                    ActionSelectTreeItem(item);
                });
            }
        }

        public ICommand AddChanel_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ContentPage = _addChanelPage;
                });
            }
        }

        public ICommand Setting_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {

                });
            }
        }

        public Page ContentPage { get; set; }

        private void ActionSelectTreeItem(TreeView item)
        {
            object i = item.SelectedValue;

            if (i is RssChannel)
            {
                RssChannel selectTitle = (RssChannel)i as RssChannel;
                CurrentContent.RssItems_SelectValue = selectTitle.Title;

                ICollection<string> collectionName = _operationDataBase.FindRssItemTitels(CurrentContent.RssItems_SelectValue);
                ObservableCollection<RssItem> rssItemTitles = new ObservableCollection<RssItem>();

                foreach (var ii in collectionName)
                {
                    rssItemTitles.Add(new RssItem { Title = ii });
                }

                CurrentContent.User.RssChannel.RssItems = rssItemTitles;

            }
            else if (i is Catalog)
            {
                Catalog selectCategory = (Catalog)i as Catalog;
                string it = selectCategory.CatalogName;
                //CurrentContent.User..Catalog = it;
                MessageBox.Show(it);
            }
        }

        private void UpdateChannels()
        {
            List<string> catalogs = _operationDataBase.FindRssChannelCategory(CurrentContent.User.Login).ToList();

            for (int i = 0; i < catalogs.Count; i++)
            {
                Catalog catalog = new Catalog();
                catalog.CatalogName = catalogs[i];

                ObservableCollection<RssChannel> rssChannels = new ObservableCollection<RssChannel>();

                List<string> listChannelsTitles = _operationDataBase.FindRssChanelTitels(CurrentContent.User.Login, catalogs[i]).ToList();

                for (int j = 0; j < listChannelsTitles.Count; j++)
                {
                    rssChannels.Add(new RssChannel { Title = listChannelsTitles[j] });
                }

                catalog.RssChannels = rssChannels;

                CurrentContent.User.Catalogs.Add(catalog);
            }
        }
    }
}