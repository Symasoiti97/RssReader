using DataBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfAppRss.Models
{
    class ActiveContent
    {
        private static ActiveContent _activeUser;

        public User User { get; set; }
        public RssItem RssItem { get; set; }

        private ActiveContent()
        {
            RssItem = new RssItem();
            User = new User();
        }

        public static ActiveContent GetInstance()
        {
            if (_activeUser == null)
            {
                _activeUser = new ActiveContent();
            }

            return _activeUser;
        }
    }
}