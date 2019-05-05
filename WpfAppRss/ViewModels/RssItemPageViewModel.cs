using DataBase;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class RssItemPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }
        private OperationDataBase _operationDataBase;
        private bool _favorite_Checked;
        private DataBase.Models.RssItem rssItem;

        public RssItemPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();

            PrintRssItems();

            Favorite_Checked = _operationDataBase.CheckedFavoriteItem(CurrentContent.User.Login, CurrentContent.User.RssItem.Title);
        }

        public bool Favorite_Checked
        {
            get
            {
                return _favorite_Checked;
            }
            set
            {
                _favorite_Checked = value;

                if (_favorite_Checked == true)
                {
                    _operationDataBase.AddRssItemFavorite(CurrentContent.User.Login, CurrentContent.User.RssItem.Title);
                }
                else
                {
                    _operationDataBase.RemoveRssItemFavorite(CurrentContent.User.Login, CurrentContent.User.RssItem.Title);
                }
            }
        }

        public ICommand<WebBrowser> WebBrowser_Loaded
        {
            get
            {
                return new DelegateCommand<WebBrowser>((webBrowser) =>
                {
                    webBrowser.NavigateToString("<meta charset=\"utf-8\"/>" + rssItem.Content);
                });
            }
        }

        private void PrintRssItems()
        {
            rssItem = _operationDataBase.GetRssItem(CurrentContent.RssItems_SelectValue.Title);

            if (rssItem != null)
            {
                CurrentContent.User.RssItem.Author = rssItem.Author;
                CurrentContent.User.RssItem.Category = rssItem.Category;
                //CurrentContent.User.RssItem.Content = rssItem.Content;
                CurrentContent.User.RssItem.Link = rssItem.Link;
                CurrentContent.User.RssItem.PubTime = rssItem.PubTime;
                CurrentContent.User.RssItem.Title = rssItem.Title;
            }
            else
            {
                MessageBox.Show("rssItem == null");
            }
        }
    }
}
