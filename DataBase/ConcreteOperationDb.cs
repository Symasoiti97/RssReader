using DataBase.DataBases;
using DataBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Ninject;
using System.Reflection;

namespace DataBase
{
    public class ConcreteOperationDb : OperationDb
    {
        private static ConcreteOperationDb _operationDataBase;

        private ConcreteOperationDb()
        {

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
            var u = GetModel<User>(p => p.Login == user.Login && p.Email == user.Email);

            if (u == null)
            {
                CreateModel<User>(user);
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
            var user = GetModel<User>(p => p.Login == oldUser.Login);

            if (user == null)
            {
                return false;
            }

            user.Email = newUser.Email;
            user.Login = newUser.Login;
            user.Password = newUser.Password;

            UpdateModel<User>(user);

            return true;
        }

        public void RemoveUser(User user)
        {
            var u = GetModel<User>(p => p.Login == user.Login);
            RemoveModel<User>(u);
        }

        public User GetUser(User user)
        {
            return GetModel<User>(p => p.Login == user.Login && p.Password == user.Password);
        }

        public bool AddUserContent(string login, RssChannel rssChannel, string catalog)
        {

            UserContent userContent;

            var userId = GetModel<User>(u => u.Login == login).Id;
            var rssCh = GetModel<RssChannel>(rs => rs.Title == rssChannel.Title);

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
                userContent = GetModel<UserContent>(rs => rs.Category == catalog &&
                    rs.RssChannelId == rssCh.Id && rs.UserId == userId);

                if (userContent != null)
                {
                    userContent.RssChannel = rssCh;

                    UpdateModel<UserContent>(userContent);

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

            CreateModel<UserContent>(userContent);

            return true;
        }

        public void UpdateUserContent(string login, RssChannel rssChannel)
        {
            var userId = GetModel<User>(u => u.Login == login).Id;
            var rssCh = GetModel<RssChannel>(rs => rs.Title == rssChannel.Title);

            UserContent userContent = GetModel<UserContent>(rs =>
                rs.RssChannelId == rssCh.Id && rs.UserId == userId && rs.RssChannel.Link == rssChannel.Link);

            if (userContent != null)
            {
                userContent.RssChannel = rssCh;

                UpdateModel<UserContent>(userContent);
            }
        }

        public void RemoveUserContent(string login, string title)
        {
            var userContent = GetModel<UserContent>(rs => rs.User.Login == login && rs.RssChannel.Title == title);

            RemoveModel<UserContent>(userContent);
        }

        public ICollection<string> GetCatologsRssChannels(string login)
        {
            return GetModels<UserContent>(t => t.User.Login == login).Select(rc => rc.Category).ToArray();
        }

        public ICollection<RssChannel> GetRssChannels(string login, string category)
        {
            return GetModels<UserContent>(t => t.User.Login == login && t.Category == category).Select(rs => rs.RssChannel).ToArray();
        }

        public ICollection<RssItem> GetRssItems(string titleRssChannel)
        {
            return GetModels<RssItem>(ri => ri.RssChannel.Title == titleRssChannel).ToArray();
        }

        public RssItem GetRssItem(string title)
        {
            return GetModel<RssItem>(ri => ri.Title == title);
        }

        public RssItem GetRssItemFavorite(string login, string title)
        {
            return GetModel<UserFavoriteItem>(ufi => ufi.RssItem.Title == title && ufi.User.Login == login).RssItem;
        }

        public ICollection<RssItem> GetFivoriteRssItems(User user)
        {
            return GetModels<UserFavoriteItem>(ufi => ufi.User.Login == user.Login).Select(rs => rs.RssItem).ToArray();
        }

        public bool AddRssItemFavorite(string login, string title)
        {
            var userId = GetModel<User>(u => u.Login == login).Id;
            var rssItemId = GetModel<RssItem>(ri => ri.Title == title).Id;

            var userFavoriteItem = GetModel<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            if (userFavoriteItem != null)
            {
                return false;
            }

            userFavoriteItem = new UserFavoriteItem
            {
                UserId = userId,
                RssItemId = rssItemId
            };

            CreateModel<UserFavoriteItem>(userFavoriteItem);

            return true;
        }

        public void RemoveRssItemFavorite(string login, string title)
        {
            var userId = GetModel<User>(u => u.Login == login).Id;
            var rssItemId = GetModel<RssItem>(ri => ri.Title == title).Id;

            var userFavoriteItem = GetModel<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            RemoveModel<UserFavoriteItem>(userFavoriteItem);
        }

        public bool CheckedFavoriteItem(string login, string title)
        {
            bool flag = false;

            var userId = GetModel<User>(u => u.Login == login).Id;
            var rssItemId = GetModel<RssItem>(ri => ri.Title == title).Id;

            var favoriteItem = GetModel<UserFavoriteItem>(ufi => ufi.RssItemId == rssItemId && ufi.UserId == userId);

            if (favoriteItem != null)
            {
                flag = true;
            }

            return flag;
        }

        public ICollection<string> GetCurrentListUrlChannels(string login)
        {
            var userId = GetModel<User>(u => u.Login == login).Id;
            var listUrl = GetModels<UserContent>(uc => uc.UserId == userId).Select(uc => uc.RssChannel.Link).ToArray();

            return listUrl;
        }
    }
}
