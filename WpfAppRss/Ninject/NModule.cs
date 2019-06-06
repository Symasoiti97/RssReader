using Logger;
using Ninject.Modules;

namespace WpfAppRss.Ninject
{
    class NModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger.Logger>();
        }
    }
}