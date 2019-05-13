using DataBase;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppRss.Helper;
using WpfAppRss.Models;
using DataBase.Models;
using Ninject;
using Logger;
using static Logger.Logger;

namespace WpfAppRss.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private static IKernel ninjectKernel = new StandardKernel(new LoggerModule());
        private static ILogger _logger = ninjectKernel.Get<ILogger>();

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
                    _logger.Log(TypeLog.Info, $"{CurrentContent.User.Login} Start Update Rss");
                    UpdaterRss.UpdateRssChannelsDateBase(CurrentContent.User);
                    _logger.Log(TypeLog.Info, $"{CurrentContent.User.Login} Finish Update Rss");
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