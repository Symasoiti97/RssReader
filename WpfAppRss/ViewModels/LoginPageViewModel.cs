using DataBase;
using DataBase.DataBases;
using DataBase.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppRss.Views;

namespace WpfAppRss.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private OperationDataBase _operationDataBase;
        private User _currentUser;

        public LoginPageViewModel()
        {
            _currentUser = new User();
            _operationDataBase = OperationDataBase.GetInstance();
        }

        public ICommand LogIn_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ShowMainWindow();
                });
            }
        }

        private void ShowMainWindow()
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel
                {
                    CurrentUser = _currentUser
                }
            };
            mainWindow.Show();
        }

        public string LoginText
        {
            get
            {
                return _currentUser.Login;
            }
            set
            {
                _currentUser.Login = value;
                OnPropertyChanged("LoginText");
            }
        }

        public string PasswordText
        {
            get
            {
                return _currentUser.Password;
            }
            set
            {
                _currentUser.Password = value;
                OnPropertyChanged("PasswordText");
            }
        }
    }
}
