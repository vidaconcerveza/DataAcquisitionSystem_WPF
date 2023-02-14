using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataAcquisitionSystem_WPF.ViewModels;
using MvvmFramework;
using Prism;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace DataAcquisitionSystem_WPF
{
    class Bootstrapper : BootstrapperBase
    {
        private WindsorContainer container;

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { typeof(MainViewModel).Assembly };
        }

        protected override void ConfigureForRuntime()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());

            container.Register(
            //    Component.For<IDataProvider<Student>>()
            //        .ImplementedBy<StudentsXmlProvider>()
            //        .DependsOn(Dependency.OnValue<string>("StudentsRepo.xml"))
            //        ,

                Component.For<Window>()
                    .ImplementedBy<Window>()
                    .LifestyleSingleton(),
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton()
                ) ;
            
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override void ConfigureForDesignTime()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            
            container.Register(
            //    Component.For<IDataProvider<Student>>()
             //   .ImplementedBy<DesignTimeStudentsProvider>()
             //   ,
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton()

                );
            
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrWhiteSpace(key)
                ? container.Resolve(service)
                : container.Resolve(key, service);
        }

        private void RegisterViewModels()
        {
            container.Register(Classes.FromAssembly(typeof(MainViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }

    }
}
