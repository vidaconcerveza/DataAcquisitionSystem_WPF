﻿using DataAcquisitionSystem_WPF.MvvmFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace MvvmFramework
{
    public abstract class BootstrapperBase
    {
        protected virtual IEnumerable<Assembly> SelectAssemblies()
        {
            if (Execution.InDesignMode)
            {
                var appDomain = AppDomain.CurrentDomain;
                var assemblies = appDomain.GetType()
                    .GetMethod("GetAssemblies")
                    .Invoke(appDomain, null) as Assembly[] ?? new Assembly[] { };

                var applicationAssembly = assemblies.LastOrDefault(ContainsApplicationClass);
                return applicationAssembly == null ? new Assembly[] { } : new[] { applicationAssembly };
            }
            var entryAssembly = Assembly.GetEntryAssembly();
            return entryAssembly == null ? new Assembly[] { } : new[] { entryAssembly };
        }

        private static bool ContainsApplicationClass(Assembly assembly)
        {
            var containsApp = false;

            try
            {
                containsApp = assembly.EntryPoint != null &&
                              assembly.GetExportedTypes().Any(t => t.IsSubclassOf(typeof(Application)));
            }
            catch { }
            return containsApp;
        }

        protected abstract object GetInstance(Type service, string key);

        public void Start()
        {
            AssemblySource.Instance.AddRange(SelectAssemblies());

            if (Execution.InDesignMode)
            {
                ConfigureForDesignTime();
            }
            else
            {
                ConfigureForRuntime();
            }
            IoC.GetInstance = GetInstance;
        }

        protected virtual void ConfigureForRuntime() { }
        protected virtual void ConfigureForDesignTime() { }
    }
}