using DataBase.DataBases;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        }

        public static OperationDataBase GetInstance()
        {
            if (_operationDataBase == null)
            {
                _operationDataBase = new OperationDataBase();
            }

            return _operationDataBase;
        }

        public bool AddUser(User user)
        {
            using (_db = new ApplicationContext())
            {

                var i = _db.Users.FirstOrDefault(p => p.Login == user.Login);

                if (i != null)
                {
                    return false;
                }

                _db.Users.Add(user);
                _db.SaveChanges();
            }

            return true;
        }

        public void RemoveUser(User user)
        {
            using (_db = new ApplicationContext())
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }
         
        public User FindUser(string login, string pass)
        {
            using (_db = new ApplicationContext())
            {
                var i = _db.Users.FirstOrDefault(p => p.Login == login && p.Password == pass);
               return (User)i;
            }
        }

        public bool AddUserContent(string login, RssChannel rssChannel, string catalog)
        {
            using (_db = new ApplicationContext())
            {
                var user = _db.Users.FirstOrDefault(p => p.Login == login);

                if (user != null)
                {
                    return false;
                }

                if (catalog == "" || catalog == null) catalog = "Different";

                UserContent userContent = new UserContent
                {
                    User = user,
                    Category = catalog,
                    RssChannel = rssChannel
                };

                _db.UserContents.Add(userContent);
                _db.SaveChanges();
            }

            return true;
        }

        public void RemoveRssChanel(RssChannel rssChanel)
        {
            using (_db = new ApplicationContext())
            {
                _db.RssChanels.Remove(rssChanel);
                _db.SaveChanges();
            }
        }

        public ICollection<string> FindRssChannelCategory(string login)
        {
            using (_db = new ApplicationContext())
            {
                ICollection<string> listTitels = _db.UserContents.Where(t => t.User.Login == login).Select(rc => rc.Category).ToArray();
                return listTitels;
            }
        }

        public ICollection<string> FindRssChanelTitels(string login, string category)
        {
            using (_db = new ApplicationContext())
            {
                ICollection<string> listTitels = _db.UserContents.Where(t => t.User.Login == login && t.Category == category).Select(rc => rc.RssChannel.Title).ToArray();
                return listTitels;
            }             
        }

        public ICollection<string> FindRssItemTitels(string title)
        {
            using (_db = new ApplicationContext())
            {
                ICollection<string> listTitels = _db.RssItems.Where(ri => ri.RssChannel.Title == title).Select(ri => ri.Title).ToArray();
                return listTitels;
            }
        }

        public RssItem FindRssItem(string title)
        {
            using (_db = new ApplicationContext())
            {
                return _db.RssItems.FirstOrDefault(ri => ri.Title == title);
            }
        }

        public void AddRssItemFavorite(RssItem rssItem)
        {
            using (_db = new ApplicationContext())
            {
                _db.RssItems.Add(rssItem);
                _db.SaveChanges();
            }
        }

        public void RemoveRssItemFavorite(RssItem rssItem)
        {
            using (_db = new ApplicationContext())
            {
                _db.RssItems.Remove(rssItem);
                _db.SaveChanges();
            }
        }
    }
}
