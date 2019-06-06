using System.Windows.Input;
using DevExpress.Mvvm;
using DataBase;
using WpfAppRss.Models;
using WpfAppRss.Helper;
using System.Windows;
using System;

namespace WpfAppRss.ViewModels
{
    class AddChanelPageViewModel : BaseViewModel
    {
        private ConcreteOperationDb _operationDataBase;

        public Content CurrentContent { get; set; }

        public AddChanelPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = ConcreteOperationDb.GetInstance();
        }

        public ICommand AddChannel_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    try
                    {
                        CurrentContent.Catalogs = UpdaterRss.AddChannelDataBase(RssLinkText, CatalogText, CurrentContent.User.Login);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                });
            }
        }

        public string RssLinkText { get; set; }

        public string CatalogText { get; set; }
    }
}
