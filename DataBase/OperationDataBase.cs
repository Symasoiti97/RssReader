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
                var i = _db.Users.FirstOrDefault(p => p.Login == user.Login && p.Email == user.Email);

                if (i != null)
                {
                    return false;
                }

                _db.Users.Add(user);
                _db.SaveChanges();
            }

            return true;
        }

        public bool EditUser(string oldLogin, string login, string password, string email)
        {
            using (_db = new ApplicationContext())
            {
                var user = _db.Users.FirstOrDefault(p => p.Login == oldLogin);

                if (user == null)
                {
                    return false;
                }

                user.Email = email;
                user.Login = login;
                user.Password = password;

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
            UserContent userContent;

            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();

                var rssCh = _db.RssChanels.FirstOrDefault(rs => rs.Title == rssChannel.Title);

                if (rssCh == null)
                {
                    userContent = new UserContent
                    {
                        UserId = userId,
                        Category = catalog,
                        RssChannel = rssChannel
                    };
                }
                else
                {
                    userContent = _db.UserContents.Where(rs => rs.Category == catalog &&
                    rs.RssChannelId == rssCh.Id && rs.UserId == userId).FirstOrDefault();

                    if (userContent != null)
                    {
                        userContent.RssChannel = rssCh;
                        _db.SaveChanges();

                        return false;
                    }
                    else
                    {
                        userContent = new UserContent
                        {
                            UserId = userId,
                            Category = catalog,
                            RssChannelId = rssCh.Id
                        };
                    }
                }

                _db.UserContents.Add(userContent);
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                }
            }

            return true;
        }

        public void UpdateUserContent(string login, RssChannel rssChannel)
        {
            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();
                var rssCh = _db.RssChanels.FirstOrDefault(rs => rs.Title == rssChannel.Title);

                UserContent userContent = _db.UserContents.FirstOrDefault(rs =>
                rs.RssChannelId == rssCh.Id && rs.UserId == userId && rs.RssChannel.Link == rssChannel.Link);

                if (userContent != null)
                {
                    userContent.RssChannel = rssCh;
                    _db.SaveChanges();
                }
            }
        }

        public void RemoveUserContent(string login, string title)
        {
            using (_db = new ApplicationContext())
            {
                var userContent = _db.UserContents.FirstOrDefault(rs => rs.User.Login == login && rs.RssChannel.Title == title);
                _db.UserContents.Remove(userContent);
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

        public ICollection<string> GetRssChanelTitels(string login, string category)
        {
            using (_db = new ApplicationContext())
            {
                ICollection<string> listTitels = _db.UserContents.Where(t => t.User.Login == login && t.Category == category).Select(rc => rc.RssChannel.Title).ToArray();
                return listTitels;
            }             
        }

        public ICollection<string> GetRssItemTitels(string title)
        {
            using (_db = new ApplicationContext())
            {
                ICollection<string> listTitels = _db.RssItems.Where(ri => ri.RssChannel.Title == title).Select(ri => ri.Title).ToArray();
                return listTitels;
            }
        }

        public RssItem GetRssItem(string title)
        {
            using (_db = new ApplicationContext())
            {
                return _db.RssItems.FirstOrDefault(ri => ri.Title == title);
            }
        }

        public RssItem GetRssItemFavorite(string login, string title)
        {
            using (_db = new ApplicationContext())
            {
                var favoriteItem = _db.UserFavoriteItems.FirstOrDefault(ufi => ufi.RssItem.Title == title && ufi.User.Login == login);

                return favoriteItem.RssItem;
            }
        }

        public List<string> GetRssItemFivoriteTitles(string login)
        {
            using (_db = new ApplicationContext())
            {
                var favoriteItem = _db.UserFavoriteItems.Where(ufi => ufi.User.Login == login);

                var items = favoriteItem.Select(rs => rs.RssItem.Title);

                return items.ToList();
            }
        }

        public void AddRssItemFavorite(string login, string title)
        {
            UserFavoriteItem userFavoriteItem;

            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();
                var rssItemId = _db.RssItems.Where(ri => ri.Title == title).Select(ri => ri.Id).First();

                userFavoriteItem = _db.UserFavoriteItems.Where(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId).FirstOrDefault();

                if (userFavoriteItem != null)
                {
                    return;
                }

                userFavoriteItem = new UserFavoriteItem
                {
                    UserId = userId,
                    RssItemId = rssItemId
                };
                    
                _db.UserFavoriteItems.Add(userFavoriteItem);
                _db.SaveChanges();
            }
        }

        public void RemoveRssItemFavorite(string login, string title)
        {
            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();
                var rssItemId = _db.RssItems.Where(ri => ri.Title == title).Select(ri => ri.Id).First();

                UserFavoriteItem favoriteItem = _db.UserFavoriteItems.Where(fi => fi.RssItemId == rssItemId && fi.UserId == userId).FirstOrDefault();

                _db.UserFavoriteItems.Remove(favoriteItem);
                _db.SaveChanges();
            }
        }

        public bool CheckedFavoriteItem(string login, string title)
        {
            bool flag = false;

            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();
                var rssItemId = _db.RssItems.Where(ri => ri.Title == title).Select(ri => ri.Id).First();

                UserFavoriteItem favoriteItem = _db.UserFavoriteItems.Where(fi => fi.RssItemId == rssItemId && fi.UserId == userId).FirstOrDefault();

                if (favoriteItem != null)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public List<string> GetCurrentListUrlChannels(string login)
        {
            using (_db = new ApplicationContext())
            {
                var userId = _db.Users.Where(u => u.Login == login).Select(p => p.Id).First();
                var listUrl = _db.UserContents.Where(uc => uc.UserId == userId).Select(uc => uc.RssChannel.Link).ToList();

                return listUrl;
            }
        }
    }
}
