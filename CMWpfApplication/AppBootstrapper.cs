using System.Windows;
using Caliburn.Micro;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Core;
using System.Reflection;

using System.Linq;
using System.Collections.Generic;
using System;
namespace CMWpfApplication
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IWindsorContainer windsorContainer;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ITestDataGridViewModel>();
        }

        protected override void Configure()
        {
            //base.Configure();
            this.windsorContainer = new WindsorContainer();
            this.windsorContainer.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());
            this.windsorContainer.Register(Component.For<IEventAggregator>().ImplementedBy<EventAggregator>());

            this.windsorContainer.Register(Component.For<IErrorViewModel>().ImplementedBy<ErrorViewModel>().LifeStyle.Is(LifestyleType.Singleton));
            this.windsorContainer.Register(Component.For<IShellViewModel>().ImplementedBy<ShellViewModel>().LifeStyle.Is(LifestyleType.Singleton));
            this.windsorContainer.Register(Component.For<INextViewModel>().ImplementedBy<NextViewModel>().LifeStyle.Is(LifestyleType.Singleton));
            //this.windsorContainer.Register(Component.For<INextViewModel>().ImplementedBy<NextViewModel>().LifestyleTransient());
            //this.windsorContainer.Install(windsorContainer.ResolveAll<IWindsorInstaller>());

            this.windsorContainer.Register(Component.For<ITestDataGridViewModel>().ImplementedBy<TestDataGridViewModel>().LifeStyle.Is(LifestyleType.Singleton));
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrWhiteSpace(key) ? this.windsorContainer.Resolve(service) : this.windsorContainer.Resolve<object>(key, new { });
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.windsorContainer.ResolveAll(service).Cast<object>();
        }

        protected override void BuildUp(object instance)
        {
            instance.GetType().GetProperties()
                .Where(property =>
                property.CanWrite &&
                property.PropertyType.IsPublic)
                .Where(property =>
                this.windsorContainer.Kernel.HasComponent(property.PropertyType))
                .ToList().ForEach(property =>
                property.SetValue(instance,
                this.windsorContainer.Resolve(property.PropertyType), null));
        }
    }
}
