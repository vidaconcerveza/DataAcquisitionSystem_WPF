using DataAcquisitionSystem_WPF.Views;
using DataAcquisitionSystem_WPF.ViewModels;
using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get { return IoC.Get<MainViewModel>(); }
        }

        public SideBarViewModel SideBarViewModel
        {
            get { return IoC.Get<SideBarViewModel>(); }
        }

        public StatusBarViewModel StatusBarViewModel
        {
            get { return IoC.Get<StatusBarViewModel>(); }
        }

        public Plc1ViewModel Plc1ViewModel
        {
            get { return IoC.Get<Plc1ViewModel>(); }
        }

        public Plc2ViewModel Plc2ViewModel
        {
            get { return IoC.Get<Plc2ViewModel>(); }
        }
    }
}
