using Logger;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppRss.Helper
{
    class LoggerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger.Logger>();
        }
    }
}