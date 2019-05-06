using DataBase;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppRss.Models;

namespace WpfAppRss.ViewModels
{
    class SettingPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }
        public OperationDataBase _operationDataBase;

        public SettingPageViewModel()
        {
            _operationDataBase = OperationDataBase.GetInstance();
            CurrentContent = Content.GetInstance();

            Login = CurrentContent.User.Login;
            Password = CurrentContent.User.Password;
            Email = CurrentContent.User.Email;
        }

        public ICommand ApplySetting_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    if (_operationDataBase.EditUser(CurrentContent.User.Login, Login, Password, Email))
                    {
                        CurrentContent.User = new User()
                        {
                            Login = Login,
                            Password = Password,
                            Email = Email
                        };
                    }
                });
            }
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
