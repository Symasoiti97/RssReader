using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Ninject
{
    static class NinjectContext
    {
        public static IKernel Kernel { get; private set; }

        static NinjectContext()
        {
            Kernel = new StandardKernel(new DbModule());
        }
    }
}
