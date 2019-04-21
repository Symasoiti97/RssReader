using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppRss.Commands;

namespace WpfAppRss.ViewModels
{
    class LoginWindowViewModel : BaseViewModel
    {
        private Page _loginPage;
        private Page _registrationPage;

        private Page _currentPage;

        public LoginWindowViewModel()
        {
            _loginPage = new Pages.LoginPage();
            _registrationPage = new Pages.RegistrationPage();

            CurrentPage = _loginPage;
        }

        public ICommand GoToLoginPage_Click
        {
            get
            {
                return new DelegateCommand((obj)=>
                {
                    CurrentPage = _loginPage;
                });
            }
        }

        public ICommand GoToRegistrationPage_Click
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CurrentPage = _registrationPage;
                });
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
    }
}
