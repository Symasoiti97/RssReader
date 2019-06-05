using Logger;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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