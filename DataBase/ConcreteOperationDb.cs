using DataBase.DataBases;
using DataBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Ninject;
using System.Reflection;

namespace DataBase
{
    public class ConcreteOperationDb
    {
        private static ConcreteOperationDb _operationDataBase;

        private readonly IKernel _kernal;
        private readonly IOperationDb _oDb;

        private ConcreteOperationDb()
        {
            _kernal = new StandardKernel(new DbModule());
            _oDb = _kernal.Get<IOperationDb>();
        }

        public static ConcreteOperationDb GetInstance()
        {
            if (_operationDataBase == null)
            {
                _operationDataBase = new ConcreteOperationDb();
            }

            return _operationDataBase;
        }

        public bool AddUser(User user)
        {
            bool flag;
            var u = _oDb.GetModelFirstOfDefault<User>(p => p.Login == user.Login && p.Email == user.Email);

            if (u == null)
            {
                _oDb.CreateModel<User>(user);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool EditUser(User oldUser, User newUser)
        {
            var user = _oDb.GetModelFirstOfDefault<User>(p => p.Login == oldUser.Login);

            if (user == null)
            {
                return false;
            }

            user.Email = newUser.Email;
            user.Login = newUser.Login;
            user.Password = newUser.Password;

            _oDb.UpdateModel<User>(user);

            return true;
        }

        public void RemoveUser(User user)
        {
            var u = _oDb.GetModelFirstOfDefault<User>(p => p.Login == user.Login);
            _oDb.RemoveModel<User>(u);
        }

        public User GetUser(User user)
        {
            return _oDb.GetModelFirstOfDefault<User>(p => p.Login == user.Login && p.Password == user.Password);
        }

        public bool AddUserContent(string login, RssChannel rssChannel, string catalog)
        {

            UserContent userContent;

            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var rssCh = _oDb.GetModelFirstOfDefault<RssChannel>(rs => rs.Title == rssChannel.Title);

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
                userContent = _oDb.GetModelFirstOfDefault<UserContent>(rs => rs.Category == catalog &&
                    rs.RssChannelId == rssCh.Id && rs.UserId == userId);

                if (userContent != null)
                {
                    userContent.RssChannel = rssCh;

                    _oDb.UpdateModel<UserContent>(userContent);

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

            _oDb.CreateModel<UserContent>(userContent);

            return true;
        }

        public void UpdateUserContent(string login, RssChannel rssChannel)
        {
            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var rssCh = _oDb.GetModelFirstOfDefault<RssChannel>(rs => rs.Title == rssChannel.Title);

            UserContent userContent = _oDb.GetModelFirstOfDefault<UserContent>(rs =>
                rs.RssChannelId == rssCh.Id && rs.UserId == userId && rs.RssChannel.Link == rssChannel.Link);

            if (userContent != null)
            {
                userContent.RssChannel = rssCh;

                _oDb.UpdateModel<UserContent>(userContent);
            }
        }

        public void RemoveUserContent(string login, string title)
        {
            var userContent = _oDb.GetModelFirstOfDefault<UserContent>(rs => rs.User.Login == login && rs.RssChannel.Title == title);

            _oDb.RemoveModel<UserContent>(userContent);
        }

        public ICollection<string> GetCatologsRssChannels(string login)
        {
            return _oDb.GetModels<UserContent>(t => t.User.Login == login).Select(rc => rc.Category).ToArray();
        }

        public ICollection<RssChannel> GetRssChannels(string login, string category)
        {
            return _oDb.GetModels<UserContent>(t => t.User.Login == login && t.Category == category).Select(rs => rs.RssChannel).ToArray();
        }

        public ICollection<RssItem> GetRssItems(string titleRssChannel)
        {
            return _oDb.GetModels<RssItem>(ri => ri.RssChannel.Title == titleRssChannel).ToArray();
        }

        public RssItem GetRssItem(string title)
        {
            return _oDb.GetModelFirstOfDefault<RssItem>(ri => ri.Title == title);
        }

        public RssItem GetRssItemFavorite(string login, string title)
        {
            return _oDb.GetModelFirstOfDefault<UserFavoriteItem>(ufi => ufi.RssItem.Title == title && ufi.User.Login == login).RssItem;
        }

        public ICollection<RssItem> GetFivoriteRssItems(User user)
        {
            return _oDb.GetModels<UserFavoriteItem>(ufi => ufi.User.Login == user.Login).Select(rs => rs.RssItem).ToArray();
        }

        public bool AddRssItemFavorite(string login, string title)
        {
            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var rssItemId = _oDb.GetModelFirstOfDefault<RssItem>(ri => ri.Title == title).Id;

            var userFavoriteItem = _oDb.GetModelFirstOfDefault<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            if (userFavoriteItem != null)
            {
                return false;
            }

            userFavoriteItem = new UserFavoriteItem
            {
                UserId = userId,
                RssItemId = rssItemId
            };

            _oDb.CreateModel<UserFavoriteItem>(userFavoriteItem);

            return true;
        }

        public void RemoveRssItemFavorite(string login, string title)
        {
            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var rssItemId = _oDb.GetModelFirstOfDefault<RssItem>(ri => ri.Title == title).Id;

            var userFavoriteItem = _oDb.GetModelFirstOfDefault<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            _oDb.RemoveModel<UserFavoriteItem>(userFavoriteItem);
        }

        public bool CheckedFavoriteItem(string login, string title)
        {
            bool flag = false;

            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var rssItemId = _oDb.GetModelFirstOfDefault<RssItem>(ri => ri.Title == title).Id;

            var favoriteItem = _oDb.GetModelFirstOfDefault<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            if (favoriteItem != null)
            {
                flag = true;
            }

            return flag;
        }

        public ICollection<string> GetCurrentListUrlChannels(string login)
        {
            var userId = _oDb.GetModelFirstOfDefault<User>(u => u.Login == login).Id;
            var listUrl = _oDb.GetModels<UserContent>(uc => uc.UserId == userId).Select(uc => uc.RssChannel.Link).ToArray();

            return listUrl;
        }
    }
}
