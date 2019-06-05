using DataBase;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;
using WpfAppRss.Models;
using DataBase.Models;

namespace WpfAppRss.ViewModels
{
    class RssItemPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }
        private ConcreteOperationDb _operationDataBase;
        private bool _favorite_Checked;

        public RssItemPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = ConcreteOperationDb.GetInstance();

            PrintRssItems();

            Favorite_Checked = _operationDataBase.CheckedFavoriteItem(CurrentContent.User.Login, CurrentContent.RssItem.Title);
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
                    _operationDataBase.AddRssItemFavorite(CurrentContent.User.Login, CurrentContent.RssItem.Title);
                }
                else
                {
                    _operationDataBase.RemoveRssItemFavorite(CurrentContent.User.Login, CurrentContent.RssItem.Title);
                }
            }
        }

        public ICommand<WebBrowser> WebBrowser_Loaded
        {
            get
            {
                return new DelegateCommand<WebBrowser>((webBrowser) =>
                {
                    webBrowser.NavigateToString("<meta charset=\"utf-8\"/>" + CurrentContent.RssItem.Content);
                });
            }
        }

        private void PrintRssItems()
        {
            RssItem rssItem = _operationDataBase.GetRssItem(CurrentContent.RssItems_SelectValue.Title);

            if (rssItem != null)
            {
                CurrentContent.RssItem = new RssItem
                {
                    Author = rssItem.Author,
                    Category = rssItem.Category,
                    Content = rssItem.Content,
                    Link = rssItem.Link,
                    PubTime = rssItem.PubTime,
                    Title = rssItem.Title
                };
            }
            else
            {
                throw new System.Exception("rssItem == null");
            }
        }
    }
}
