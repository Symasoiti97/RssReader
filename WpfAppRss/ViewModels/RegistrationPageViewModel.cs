using DataBase;
using DataBase.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfAppRss.Helper;

namespace WpfAppRss.ViewModels
{
    class RegistrationPageViewModel : BaseViewModel, IDataErrorInfo
    {
        private ConcreteOperationDb _operationDataBase;
        private User _currentRegistrUser;

        public Dictionary<string, string> Errors { get; set; }

        public RegistrationPageViewModel()
        {
            _operationDataBase = ConcreteOperationDb.GetInstance();
            _currentRegistrUser = new User();
            Errors = new Dictionary<string, string>();
        }

        public ICommand Registration_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    if (Errors.Count > 0)
                    {
                        MessageBox.Show("Sorry:(");
                        return;
                    }

                    RegistrationUser();
                });
            }
        }

        public string Login { get; set; }

        public string ConfirmPassword { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        private void RegistrationUser()
        {
            if (ConfirmPassword != Password)
            {
                return;
            }

            _currentRegistrUser = new User
            {
                Login = Login,
                Password = ConfirmPassword,
                Email = Email
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

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Login":
                        Validation.ValidLogin(Login, ref error);
                        break;
                    case "Password":
                        Validation.ValidPassword(ConfirmPassword, ref error);
                        break;
                    case "ConfirmPassword":
                        if (Password != ConfirmPassword)
                        {
                            error = "Passwords must match";
                        }
                        break;
                    case "Email":
                        Validation.ValidEmail(Email, ref error);
                        break;
                }

                if (error == string.Empty)
                {
                    Errors.Remove(columnName);
                }
                else
                {
                    Errors.Remove(columnName);
                    Errors.Add(columnName, error);
                }

                return error;
            }
        }
    }
}
