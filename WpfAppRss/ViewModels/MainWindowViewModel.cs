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
using DataBase.Models;

namespace WpfAppRss.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }
        private OperationDataBase _operationDataBase;

        public MainWindowViewModel()
        {
            _operationDataBase = OperationDataBase.GetInstance();

            CurrentContent = Content.GetInstance();

            CurrentContent.Catalogs = UpdaterRss.UpdateTreeViewChannels(CurrentContent.User.Login);
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
                    UpdaterRss.UpdateRssChannelsDateBase(CurrentContent.User);
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

                ICollection<RssItem> rssItems = _operationDataBase.GetRssItems(selectTitle.Title);
                ObservableCollection<RssItem> selectRssItems = new ObservableCollection<RssItem>();

                foreach (var ri in rssItems)
                {
                    selectRssItems.Add(ri);
                }

                CurrentContent.RssItems = selectRssItems;

                CurrentContent.ContentPage = new Pages.SettingRssChannelPage()
                {
                    DataContext = new SettingRssChannelPageViewModel()
                    {
                        Catalog = "NZ",
                        NumberOfRssItems = selectRssItems.Count.ToString(),
                        RssChannelTitle = selectTitle.Title
                    }
                };
            }
            else if (i is Catalog)
            {
                Catalog selectCatolog = (Catalog)i as Catalog;

                if(selectCatolog.CatalogName == "Favorite")
                {
                    ICollection<RssItem> rssItems = _operationDataBase.GetFivoriteRssItems(CurrentContent.User);
                    ObservableCollection<RssItem> selectRssItems = new ObservableCollection<RssItem>();

                    foreach (var ri in rssItems)
                    {
                        selectRssItems.Add(ri);
                    }

                    CurrentContent.RssItems = selectRssItems;
                }
            }
        }
    }
}