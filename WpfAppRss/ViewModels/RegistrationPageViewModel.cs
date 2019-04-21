using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppRss.Commands;

namespace WpfAppRss.ViewModels
{
    class RegistrationPageViewModel : BaseViewModel
    {
        private OperationDataBase _operationDataBase;
        private User _currentRegistrUser;
        private string _currentPasswordFirst;
        private string _currentPasswordSecond;

        public RegistrationPageViewModel()
        {
            _operationDataBase = new OperationDataBase();
            _currentRegistrUser = new User();
        }

        public ICommand Registration_Click
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    RegistrationUser();
                });
            }
        }

        public string LoginText
        {
            get
            {
                return _currentRegistrUser.Login;
            }
            set
            {
                _currentRegistrUser.Login = value;
                OnPropertyChanged("LoginText");
            }
        }

        public string PasswordFirstText
        {
            get
            {
                return _currentPasswordFirst;
            }
            set
            {
                _currentPasswordFirst = value;
                OnPropertyChanged("Password1Text");
            }
        }

        public string PasswordSecondText
        {
            get
            {
                return _currentPasswordSecond;
            }
            set
            {
                _currentPasswordSecond = value;
                OnPropertyChanged("Password2Text");
            }
        }

        public string EmailText
        {
            get
            {
                return _currentRegistrUser.Email;
            }
            set
            {
                _currentRegistrUser.Email = value;
                OnPropertyChanged("EmailText");
            }
        }

        private void RegistrationUser()
        {
            if (_currentPasswordFirst != _currentPasswordSecond)
            {
                return;
            }

            _currentRegistrUser.Password = _currentPasswordFirst;
            _operationDataBase.AddUser(_currentRegistrUser);
            MessageBox.Show($"{_currentRegistrUser.Login}\n{_currentRegistrUser.Email}\n{_currentRegistrUser.Password}");
        }
    }
}
