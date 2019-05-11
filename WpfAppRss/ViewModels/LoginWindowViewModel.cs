using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppRss.ViewModels
{
    class LoginWindowViewModel : BaseViewModel
    {
        private Page _loginPage;
        private readonly Page _registrationPage;

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
