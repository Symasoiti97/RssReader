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

        public Content CurrentContent;

        public AddChanelPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();
        }

        public ICommand AddChannel_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    var rssChannel = RssLoader.ParserRss(RssLinkText);
                    _operationDataBase.AddUserContent(CurrentContent.User.Login, rssChannel, CatalogText);
                });
            }
        }

        public string RssLinkText { get; set; }

        public string CatalogText { get; set; }
    }
}
