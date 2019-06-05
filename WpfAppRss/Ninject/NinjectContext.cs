using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfAppRss.Ninject
{
    static class NinjectContext
    {
        public static IKernel Kernel { get; private set; }

        static NinjectContext()
        {
            Kernel = new StandardKernel(new NModule());
        }
    }
}