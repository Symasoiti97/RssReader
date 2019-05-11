using DataBase;
using DevExpress.Mvvm;
using System.Windows.Input;
using WpfAppRss.Models;
using DataBase.Models;

namespace WpfAppRss.ViewModels
{
    class SettingPageViewModel : BaseViewModel
    {
        public Content CurrentContent { get; set; }
        public OperationDataBase _operationDataBase;
        public User NewUser { get; set; }

        public SettingPageViewModel()
        {
            _operationDataBase = OperationDataBase.GetInstance();
            CurrentContent = Content.GetInstance();

            NewUser = new User
            {
                Login = CurrentContent.User.Login,
                Password = CurrentContent.User.Password,
                Email = CurrentContent.User.Email
            };
        }

        public ICommand ApplySetting_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    if (_operationDataBase.EditUser(CurrentContent.User, NewUser))
                    {
                        CurrentContent.User = NewUser;
                    }
                });
            }
        }
    }
}
