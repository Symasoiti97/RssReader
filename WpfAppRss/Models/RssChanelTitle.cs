using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class RssChanelTitle : BaseViewModel
    {
        private string _rssChanelTitleName;

        public string RssChanelTitleName
        {
            get
            {
                return _rssChanelTitleName;
            }
            set
            {
                _rssChanelTitleName = value;
                OnPropertyChanged("RssChanelTitleName");
            }
        }
    }
}
