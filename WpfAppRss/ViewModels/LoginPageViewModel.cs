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
        public Content CurrentContent { get; set; }

        public LoginPageViewModel()
        {
            CurrentContent = Content.GetInstance();
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
            var user = _operationDataBase.FindUser(CurrentContent.User.Login, CurrentContent.User.Password);

            if (user == null)
            {
                MessageBox.Show("Error");
                return;
            }

            CurrentContent.User.Login = user.Login;
            CurrentContent.User.Password = user.Password;
            CurrentContent.User.Email = user.Email;

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
