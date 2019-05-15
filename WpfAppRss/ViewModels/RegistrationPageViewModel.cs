using DataBase;
using DataBase.Models;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace WpfAppRss.ViewModels
{
    class RegistrationPageViewModel : BaseViewModel
    {
        private ConcreteOperationDb _operationDataBase;
        private User _currentRegistrUser;

        public RegistrationPageViewModel()
        {
            _operationDataBase = ConcreteOperationDb.GetInstance();
            _currentRegistrUser = new User();
        }

        public ICommand Registration_Click
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    RegistrationUser();
                });
            }
        }

        public string LoginText { get; set; }

        public string PasswordFirstText { get; set; }

        public string PasswordSecondText { get; set; }

        public string EmailText { get; set; }

        private void RegistrationUser()
        {
            if (PasswordFirstText != PasswordSecondText)
            {
                return;
            }

            _currentRegistrUser = new User
            {
                Login = LoginText,
                Password = PasswordFirstText,
                Email = EmailText
            };

            if (_operationDataBase.AddUser(_currentRegistrUser))
            {
                MessageBox.Show("Registration completed successfully");
            }
            else
            {
                MessageBox.Show("Registration NOcompleted successfully");
            }
        }
    }
}
