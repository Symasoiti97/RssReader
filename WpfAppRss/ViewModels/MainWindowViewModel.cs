using DataBase.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly Page _settingPage;
        private readonly Page _addChanelPage;
        private readonly Page _currentRssItemPage;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<RssItemsTitle> _rssItems;
        private RssItemsTitle _rssItemTitle;

        private string _userName;
        private Page _contentPage;

        private ActiveContent _activeUser;

        public MainWindowViewModel()
        {
            _activeUser = ActiveContent.GetInstance();

            _currentRssItemPage = new Pages.RssItemPage();
            _addChanelPage = new Pages.AddChanelPage();

            _categories = new ObservableCollection<Category>();
            _rssItems = new ObservableCollection<RssItemsTitle>();

            for (int i = 0; i < 5; i++)
            {
                Category category = new Category();
                category.CategoryName = ""+i;
                ObservableCollection<RssChanelTitle> rssChanelTitles = new ObservableCollection<RssChanelTitle>();
                
                for (int j = 0; j < 5; j++)
                {
                    rssChanelTitles.Add(new RssChanelTitle { RssChanelTitleName = $"{j}" });
                }

                category.RssChanelTitles = rssChanelTitles;
                _categories.Add(category);

                _rssItems.Add(new RssItemsTitle {RssItemTitleName = ""+i });
            }
            
            RssChanels = _categories;
            RssItems = _rssItems;
        }

        public ICommand AddChanel_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ContentPage = _addChanelPage; 
                });
            }
        }

        public ICommand Setting_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {

                });
            }
        }

        public ObservableCollection<Category> RssChanels
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                OnPropertyChanged("RssChanels");
            }
        }

        public ObservableCollection<RssItemsTitle> RssItems
        {
            get
            {
                return _rssItems;
            }
            set
            {
                _rssItems = value;
                OnPropertyChanged("RssItems");
            }
        }

        public RssItemsTitle RssItems_SelectValue
        {
            get
            {
                return _rssItemTitle;
            }
            set
            {
                _rssItemTitle = value;
                ContentPage = _currentRssItemPage;
                MessageBox.Show("" + value.RssItemTitleName);
                OnPropertyChanged("RssItems_SelectValue");
            }
        }

        public Page ContentPage
        {
            get
            {
                return _contentPage;
            }
            set
            {
                _contentPage = value;
                OnPropertyChanged("ContentPage");
            }
        }

        public string UserName
        {
            get
            {
                return _activeUser.User.Login;
            }
            set
            {
                _activeUser.User.Login = value;
                OnPropertyChanged("UserName");
            }
        }
    }
}