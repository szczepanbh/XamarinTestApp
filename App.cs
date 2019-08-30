

namespace XamarinTestApp
{
    using Android.App;
    using Android.Runtime;
    using Autofac;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    using System;

    [Application]
    public class App : Application
    {
        public App(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        public override void OnCreate()
        {
            var containerBuilder = new ContainerBuilder();
            ConfigureContainer(containerBuilder);
            var container = containerBuilder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            base.OnCreate();
        }

        private void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(c => new AppSettingsManager(this.Assets))
                .As<IAppSettingsManager>();

            containerBuilder.Register(c =>
            {
                var mgr = c.Resolve<IAppSettingsManager>();
                return mgr.GetConfig();
            }).As<IAppSettings>();
        }
    }
}