using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppRss.ViewModels;

namespace WpfAppRss.Models
{
    class RssChannel : BaseViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public ObservableCollection<RssItem> RssItems { get; set; }
    }
}
