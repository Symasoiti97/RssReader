using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class Category : BaseViewModel
    {
        private string _categoryName;
        private ObservableCollection<RssChanelTitle> _rssChanelTitles;

        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public ObservableCollection<RssChanelTitle> RssChanelTitles
        {
            get
            {
                return _rssChanelTitles;
            }
            set
            {
                _rssChanelTitles = value;
                OnPropertyChanged("RssChanelTitles");
            }
        }
    }

}
