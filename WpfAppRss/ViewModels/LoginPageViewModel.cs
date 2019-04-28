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
using WpfAppRss.Models;
using WpfAppRss.Views;

namespace WpfAppRss.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private OperationDataBase _operationDataBase;
        private ActiveContent _activeUser;

        public LoginPageViewModel()
        {
            _activeUser = ActiveContent.GetInstance();
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
            _activeUser.User = _operationDataBase.FindUser(_activeUser.User);
            if (_activeUser == null)
            {
                MessageBox.Show("Error");
                return;
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public string LoginText
        {
            get
            {
                return _activeUser.User.Login;
            }
            set
            {
                _activeUser.User.Login = value;
                OnPropertyChanged("LoginText");
            }
        }

        public string PasswordText
        {
            get
            {
                return _activeUser.User.Password;
            }
            set
            {
                _activeUser.User.Password = value;
                OnPropertyChanged("PasswordText");
            }
        }
    }
}
