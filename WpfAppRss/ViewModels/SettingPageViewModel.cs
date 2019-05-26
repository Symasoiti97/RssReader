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
        public ConcreteOperationDb _operationDataBase;

        private User _newUser;

        public SettingPageViewModel()
        {
            _operationDataBase = ConcreteOperationDb.GetInstance();
            CurrentContent = Content.GetInstance();
        }

        public ICommand ApplySetting_Click
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    _newUser = new User
                    {
                        Login = Login,
                        Password = Password,
                        Email = Email
                    };

                    if (_operationDataBase.EditUser(CurrentContent.User, _newUser))
                    {
                        CurrentContent.User = _newUser;
                    }
                });
            }
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
