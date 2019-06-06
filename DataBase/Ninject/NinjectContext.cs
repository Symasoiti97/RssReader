using Ninject;

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
