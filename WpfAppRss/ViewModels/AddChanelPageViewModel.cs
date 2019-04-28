using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using Parsers.ParserRss;
using DataBase.Models;
using DataBase;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class AddChanelPageViewModel : BaseViewModel
    {
        private OperationDataBase _operationDataBase;

        private string _rssLink;
        private string _catalog;

        private ActiveContent _activeUser;

        public AddChanelPageViewModel()
        {
            _activeUser = ActiveContent.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();
        }

        public ICommand AddChannel_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                     RssChannel rssChannel =  RssLoader.ParserRss(RssLinkText);
                    _operationDataBase.AddUserContent(_activeUser.User, rssChannel);
                });
            }
        }

        public string RssLinkText
        {
            get
            {
                return _rssLink;
            }
            set
            {
                _rssLink = value;
                OnPropertyChanged("RssLinkText");
            }
        }

        public string CatalogText
        {
            get
            {
                return _catalog;
            }
            set
            {
                _catalog = value;
                OnPropertyChanged("CatalogText");
            }
        }
    }
}
