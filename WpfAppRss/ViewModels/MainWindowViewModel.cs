using DataBase;
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

        private ActiveContent _activeContent;
        private ObservableCollection<Category> _categories;
        private OperationDataBase _operationDataBase;

        private Page _contentPage;

        public MainWindowViewModel()
        {
            _activeContent = ActiveContent.GetInstance();
            _operationDataBase = OperationDataBase.GetInstance();

            _currentRssItemPage = new Pages.RssItemPage();
            _addChanelPage = new Pages.AddChanelPage();

            _categories = new ObservableCollection<Category>();

            List<string> categories = _operationDataBase.FindRssChannelCategory(_activeContent.User).ToList();

            for (int i = 0; i < categories.Count; i++)
            {
                Category category = new Category();
                category.CategoryName = categories[i];

                ObservableCollection<RssChanelTitle> rssChanelTitles = new ObservableCollection<RssChanelTitle>();
                List<string> listChannelsTitles = _operationDataBase.FindRssChanelTitels(_activeContent.User, categories[i]).ToList();

                for (int j = 0; j < listChannelsTitles.Count; j++)
                {
                    rssChanelTitles.Add(new RssChanelTitle { RssChanelTitleName = listChannelsTitles[j] });
                }

                category.RssChanelTitles = rssChanelTitles;

                _categories.Add(category);
            }

            _activeContent.RssItemTitles = new ObservableCollection<RssItemTitle>
            {
                new RssItemTitle
                {
                    RssItemTitleName = "1"
                },
                new RssItemTitle
                {
                    RssItemTitleName = "1"
                },
                new RssItemTitle
                {
                    RssItemTitleName = "1"
                }
            };
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

        public ObservableCollection<RssItemTitle> RssItems
        {
            get
            {
                return _activeContent.RssItemTitles;
            }
            set
            {
                _activeContent.RssItemTitles = value;
                OnPropertyChanged("RssItems");
            }
        }

        public RssItemTitle RssItems_SelectValue
        {
            get
            {
                return _activeContent.RssItemTitle;
            }
            set
            {
                _activeContent.RssItemTitle = value;
                ContentPage = _currentRssItemPage;
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
                return _activeContent.User.Login;
            }
            set
            {
                _activeContent.User.Login = value;
                OnPropertyChanged("UserName");
            }
        }
    }
}