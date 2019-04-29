using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class RssItemPageViewModel : BaseViewModel
    {
        public Content CurrentContent;
        private OperationDataBase _operationDataBase;

        public RssItemPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();

            var rssItem = _operationDataBase.FindRssItem(CurrentContent.RssItems_SelectValue);

            if (rssItem != null)
            {
                CurrentContent.User.RssItem.Author = rssItem.Author;
                CurrentContent.User.RssItem.Category = rssItem.Category;
                CurrentContent.User.RssItem.Content = rssItem.Content;
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
