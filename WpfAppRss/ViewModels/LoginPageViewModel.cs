using DataBase;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WpfAppRss.Models;
using WpfAppRss.Views;
using Ninject;
using WpfAppRss.Helper;
using Logger;
using static Logger.Logger;

namespace WpfAppRss.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private static IKernel ninjectKernel = new StandardKernel(new LoggerModule());
        private static ILogger _logger = ninjectKernel.Get<ILogger>();

        private ConcreteOperationDb _operationDataBase;
        public Content CurrentContent { get; set; }

        public Window CurrentWindow { get; set; }

        public LoginPageViewModel()
        {
            CurrentContent = Content.GetInstance();
            _operationDataBase = ConcreteOperationDb.GetInstance();
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
                        _logger.Log(TypeLog.Info, $"{CurrentContent.User.Login} Log In");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                        _logger.Log(TypeLog.Eror, $"{CurrentContent.User.Login} Not Log In");
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
