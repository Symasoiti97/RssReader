using DataBase.DataBases;
using Ninject.Modules;

namespace DataBase.Ninject
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
