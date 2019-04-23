using DataBase.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppRss.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly Page _settingPage;
        private readonly Page _addChanelPage;
        private readonly Page _currentChanelPage;

        private string _userName;
        private Page _contentPage;

        public User CurrentUser { get; set; }

        public MainWindowViewModel()
        {
            _addChanelPage = new Pages.AddChanelPage();
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
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
    }
}