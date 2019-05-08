using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    UpdaterRss.RemoveUserContentAndUpdate(CurrentContent.User.Login, RssChannelTitle);
                });
            }
        }

        public string Catalog { get; set; }

        public string RssChannelTitle { get; set; }
        
        public string NumberOfRssItems { get; set; }
    }
}
