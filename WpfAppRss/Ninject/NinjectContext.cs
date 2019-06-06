using Ninject;

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