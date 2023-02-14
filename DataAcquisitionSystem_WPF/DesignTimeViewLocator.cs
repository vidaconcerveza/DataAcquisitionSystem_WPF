using DataAcquisitionSystem_WPF.MvvmFramework;
using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using DataAcquisitionSystem_WPF.Views;

namespace DataAcquisitionSystem_WPF
{
    public class DesignTimeViewModelLocator : IValueConverter
    {
        public static DesignTimeViewModelLocator Instance = new DesignTimeViewModelLocator();

        static DesignTimeViewModelLocator()
        {
            if (Execution.InDesignMode)
            {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Start();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var assembliesForSearchingIn = AssemblySource.Instance;

            var allExportedTypes = new List<Type>();
            foreach (var assembly in assembliesForSearchingIn)
            {
                allExportedTypes.AddRange(assembly.GetExportedTypes());
            }
            var viewModelType = allExportedTypes.First(t => t.FullName == value.ToString());
            return IoC.GetInstance(viewModelType, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
