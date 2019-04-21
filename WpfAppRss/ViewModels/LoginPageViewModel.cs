using DataBase;
using DataBase.DataBases;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppRss.ViewModels
{
    class LoginPageViewModel : BaseViewModel
    {
        private OperationDataBase _operationDataBase;
        private User _currentUser;

        public LoginPageViewModel()
        {
            _operationDataBase = new OperationDataBase();
        }
    }
}
