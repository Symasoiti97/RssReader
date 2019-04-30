using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class SettingPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }

        public SettingPageViewModel()
        {
            CurrentContent = Content.GetInstance();
        }
    }
}
