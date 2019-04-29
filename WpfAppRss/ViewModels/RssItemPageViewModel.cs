using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class RssItemPageViewModel : BaseViewModel
    {
        private ActiveContent _activeContent;
        private OperationDataBase _operationDataBase;

        public RssItemPageViewModel()
        {
            _activeContent = ActiveContent.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();

            _activeContent.RssItem = _operationDataBase.FindRssItem(_activeContent.RssItemTitle.RssItemTitleName);
        }

        public string Title
        {
            get
            {
                return _activeContent.RssItem.Title;
            }
            set
            {
                _activeContent.RssItem.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Content
        {
            get
            {
                return _activeContent.RssItem.Content;
            }
            set
            {
                _activeContent.RssItem.Content = value;
                OnPropertyChanged("Content");
            }
        }

        public string PubTime
        {
            get
            {
                return _activeContent.RssItem.PubTime.ToShortDateString();
            }
            set
            {
                _activeContent.RssItem.PubTime = DateTime.Parse(value); ;
                OnPropertyChanged("PubTime");
            }
        }

    }
}
