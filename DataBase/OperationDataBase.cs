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
        //private ApplicationContext db;

        public OperationDataBase()
        {
            //_db = new ApplicationContext();
        }

        public void AddUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void RemoveUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void AddRssChanel(RssChanel rssChanel)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.RssChanels.Add(rssChanel);
                db.SaveChanges();
            }
        }

        public void RemoveRssChanel(RssChanel rssChanel)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.RssChanels.Remove(rssChanel);
                db.SaveChanges();
            }
        }

        public void AddRssItemFavorite(RssItem rssItem)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.RssItems.Add(rssItem);
                db.SaveChanges();
            }
        }

        public void RemoveRssItemFavorite(RssItem rssItem)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.RssItems.Remove(rssItem);
                db.SaveChanges();
            }
        }
    }
}
