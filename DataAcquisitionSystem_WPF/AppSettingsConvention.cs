using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF
{
    public class AppSettingsConvention : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependencyModel)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(dependencyModel.DependencyKey) && TypeDescriptor.GetConverter(dependencyModel.TargetType).CanConvertFrom(typeof(string));
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependencyModel)
        {
            return TypeDescriptor.GetConverter(dependencyModel.TargetType).ConvertFrom(ConfigurationManager.AppSettings[dependencyModel.DependencyKey]);
        }
    }
}
