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
using WpfAppRss.Helper;
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

            CurrentContent = Content.GetInstance();

            CurrentContent.User.Catalogs = UpdateRss.UpdateTreeViewChannels(CurrentContent.User.Login);
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
                    CurrentContent.ContentPage = new Pages.AddChanelPage();
                });
            }
        }

        public ICommand Setting_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CurrentContent.ContentPage = new Pages.SettingPage();
                });
            }
        }

        public ICommand Update_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    UpdateRss.UpdateRssChannelsDateBase(CurrentContent.User);
                });
            }
        }

        public RssItem RssItems_SelectValue
        {
            get
            {
                return CurrentContent.RssItems_SelectValue;
            }
            set
            {
                CurrentContent.RssItems_SelectValue = value;
                CurrentContent.ContentPage = new Pages.RssItemPage();
            }
        }

        private void ActionSelectTreeItem(TreeView item)
        {
            object i = item.SelectedValue;

            if (i is RssChannel)
            {
                RssChannel selectTitle = (RssChannel)i as RssChannel;

                ICollection<string> collectionName = _operationDataBase.GetRssItemTitels(selectTitle.Title);
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

                ICollection<string> collectionName = _operationDataBase.GetRssItemFivoriteTitles(CurrentContent.User.Login);
                ObservableCollection<RssItem> rssItemTitles = new ObservableCollection<RssItem>();

                foreach (var ii in collectionName)
                {
                    rssItemTitles.Add(new RssItem { Title = ii });
                }

                CurrentContent.User.RssChannel.RssItems = rssItemTitles;
            }
        }
    }
}