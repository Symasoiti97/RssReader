using DataBase.DataBases;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class OperationDataBase
    {
        private static OperationDataBase _operationDataBase;
        private ApplicationContext _db;

        private OperationDataBase()
        {
            _db = new ApplicationContext();
        }

        public static OperationDataBase GetInstance()
        {
            if (_operationDataBase == null)
            {
                _operationDataBase = new OperationDataBase();
            }

            return _operationDataBase;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void AddRssChanel(RssChanel rssChanel)
        {
            _db.RssChanels.Add(rssChanel);
            _db.SaveChanges();
        }

        public void RemoveRssChanel(RssChanel rssChanel)
        {
            _db.RssChanels.Remove(rssChanel);
            _db.SaveChanges();
        }

        public void AddRssItemFavorite(RssItem rssItem)
        {
            _db.RssItems.Add(rssItem);
            _db.SaveChanges();
        }

        public void RemoveRssItemFavorite(RssItem rssItem)
        {
            _db.RssItems.Remove(rssItem);
            _db.SaveChanges();
        }
    }
}
