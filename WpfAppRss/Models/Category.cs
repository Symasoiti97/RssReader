﻿using System;
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
        public ObservableCollection<RssChannelTitle> RssChannelTitles { get; set; } = new ObservableCollection<RssChannelTitle>();

        public string CatalogName { get; set; }
    }
}
