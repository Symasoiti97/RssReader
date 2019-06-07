using DevExpress.Mvvm;
using System.Windows.Input;
using WpfAppRss.Helper;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class SettingRssChannelPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }

        public SettingRssChannelPageViewModel()
        {
            CurrentContent = Content.GetInstance();
        }

        public ICommand DeleteChannel
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    CurrentContent.Catalogs = UpdaterRss.RemoveUserContentAndReturnUpdateTree(CurrentContent.User.Login, RssChannelTitle);
                    CurrentContent.ContentPage = null;
                });
            }
        }

        public string Catalog { get; set; }

        public string RssChannelTitle { get; set; }
        
        public string NumberOfRssItems { get; set; }
    }
}
