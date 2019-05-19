using DataBase.DataBases;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class DbModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOperationDb>().To<OperationDb>();
            Bind<ApplicationContext>().ToSelf();
        }
    }
}
