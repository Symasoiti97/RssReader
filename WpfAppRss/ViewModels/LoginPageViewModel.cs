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

        public Window CurrentWindow { get; set; }

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
                    if (LogIn())
                    {
                        ShowMainWindow();

                        if (CurrentWindow != null)
                        {
                            CurrentWindow.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                });
            }
        }

        private bool LogIn()
        {
            var user = _operationDataBase.GetUser(CurrentContent.User);

            if (user == null)
            {
                return false;
            }

            CurrentContent.User = user;

            return true;
        }

        private void ShowMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
