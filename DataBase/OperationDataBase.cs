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
         
        public User FindUser(User user)
        {
            using (_db = new ApplicationContext())
            {
               var i  = _db.Users.FirstOrDefault(p => p.Login == user.Login && p.Password == user.Password);
               return (User)i;
            }
        }

        public bool AddUserContent(User user, RssChannel rssChannel)
        {
            UserContent userContent = new UserContent
            {
                User = user,
                Category = "null",
                RssChannel = rssChannel
            };

            using (_db = new ApplicationContext())
            {
                //var i = db.UserContents.FirstOrDefault(p => p == userContent);

                //if (i != null)
                //{
                //    return false;
                //}

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

        public List<string> FindRssChanelTitels(User user)
        {
            using (_db = new ApplicationContext())
            {
                var listTitels = _db.UserContents.Where(t => t.User.Login == user.Login).Select(rc => rc.RssChannel.Title);
                return listTitels.ToList();
            }             
        }

        public List<string> FindRssItemTitels(string title)
        {
            using (_db = new ApplicationContext())
            {
                var listTitels = _db.RssItems.Where(ri => ri.RssChannel.Title == title).Select(ri => ri.Title);
                return listTitels.ToList();
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
