

namespace XamarinTestApp
{
    using Autofac;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    public static class DependencyResolver
    {
        public static T Get<T>()
        {
            var serviceLocator = (AutofacServiceLocator)ServiceLocator.Current;

            var ctx = serviceLocator.GetInstance<IComponentContext>();

            return ctx.Resolve<T>();
        }
    }
}