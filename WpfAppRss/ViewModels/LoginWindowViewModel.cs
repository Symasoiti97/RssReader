using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppRss.Views;

namespace WpfAppRss.ViewModels
{
    class LoginWindowViewModel : BaseViewModel
    {
        private Page _loginPage;
        private readonly Page _registrationPage;

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
                return new DelegateCommand<Window>((window)=>
                {
                    CurrentPage = _loginPage;
                });
            }
        }

        public ICommand GoToRegistrationPage_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CurrentPage = _registrationPage;
                });
            }
        }

        public ICommand LoginWindow_Loaded
        {
            get
            {
                return new DelegateCommand<Window>((window) =>
                {
                    _loginPage.DataContext = new LoginPageViewModel
                    {
                        CurrentWindow = window
                    };
                });
            }
        }

        public Page CurrentPage { get; set; }
    }
}
